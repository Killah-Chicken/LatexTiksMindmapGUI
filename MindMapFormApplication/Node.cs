using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LatexTiksMindMapTool
{
    class Node
    {
        private List<Node> children;
        private string content;
        private string color;
        private bool clockWise;
        private int startAngle;
        private bool levelDistanceEnabled;
        private double levelDistance;
        private int siblingAngleChildren;

        public static Node recursiveMindmapCreatingFromTexCode(string code, string color,double levelDistance, bool levelDistanceEnabled)
        {
            if (code == "")
            {
                return new Node("black");
            }

            Node root = new Node(color,levelDistance,levelDistanceEnabled);
            code = root.setContentByCode(code);
            code = root.setClockWiseAndStartAngleByCode(code);
            root.setChildrenByCode(code);

            return root;
        }
        private Node(string color = "", double levelDistance = 15 , bool levelDistanceEnabled = false, string content = "")
        {
            children = new List<Node>();
            this.content = content;
            this.color = color;
            this.clockWise = true;
            this.startAngle = 0;
            this.levelDistanceEnabled = levelDistanceEnabled;
            this.levelDistance = levelDistance;
            this.siblingAngleChildren = 60;
        }
        public void addChild(string content = "", string color = "")
        {
            children.Add(new Node(color, 15,false,content));
        }
        public string [] getChildren()
        {
            string [] children = new string[getChildrenCount()];
            int i = 0;
            foreach(var c in this.children)
            {
                children[i] = c.content;
                i++;
            }
            return children;
        }
        public Node getChild(int index)
        {
            return children.ToArray()[index];
        }
        public void removeChildren()
        {
            children = new List<Node>();
            //Sauberes Loeschen
            /*foreach(var c in children)
            {
                if(c.getChildrenCount() > 0)
                {
                    c.removeChildren();
                }
            }*/

        }
        public void removeChild(int index)
        {
            children.RemoveAt(index);

        }
        public void setLevelDistanceEnabled(bool enable)
        {
            levelDistanceEnabled = enable;
        }
        public void setLevelDistance(double distance)
        {
            levelDistance = distance;
        }
        public bool getLevelDistanceEnabled()
        {
            return levelDistanceEnabled;
        }
        public double getLevelDistance()
        {
            return levelDistance;
        }
        public void setSiblingAngleChildren(int angle)
        {
            siblingAngleChildren = angle;
        }
        public int getSiblingAngleChildren()
        {
            return siblingAngleChildren;
        }
        public void setStartAngle(int angle)
        {
            startAngle = angle;
        }
        public void setClockWise(bool clockWise)
        {
            this.clockWise = clockWise;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public void setContent(string content)
        {
            this.content = content;
        }

        public int getStartAngle()
        {
            return startAngle;
        }
        public bool getClockWise()
        {
            return clockWise;
        }
        public string getColor()
        {
            return this.color;
        }
        public string getContent()
        {
            return this.content;
        }
        private string setContentByCode(string code)
        {
            int startIndexContent = code.IndexOf("{") + 1;
            //int endIndexContent = code.IndexOf("}");
            int bracketCounter = 1;
            int nextIndex = startIndexContent;
            char[] tempCharArray = code.ToCharArray();
            while (bracketCounter > 0)
            {
                int leftBracketIndex = code.IndexOf("{", nextIndex);
                int rightBracketIndex = code.IndexOf("}", nextIndex);
                if (leftBracketIndex < 0 || rightBracketIndex < 0)
                {
                    nextIndex = Math.Max(leftBracketIndex, rightBracketIndex);
                }
                else
                {
                    nextIndex = Math.Min(leftBracketIndex, rightBracketIndex);
                }
                if (tempCharArray[nextIndex - 1] != '\\')
                {
                    bracketCounter += (tempCharArray[nextIndex] == '{' ? 1 : -1);
                }
                nextIndex++;
            }
            nextIndex--;
            content = code.Substring(startIndexContent, nextIndex - startIndexContent);
            return code.Substring(nextIndex+1);
        }
        private string setClockWiseAndStartAngleByCode(string code)
        {
            int startIndexStartAngle = code.IndexOf("=") + 1;
            int endIndexStartAngle = code.IndexOf("]");
            clockWise = !code.Substring(0, endIndexStartAngle).Contains("counter");
            startAngle = Convert.ToInt16(code.Substring(startIndexStartAngle, endIndexStartAngle - startIndexStartAngle));
            return code.Substring(endIndexStartAngle + 1);

        }
        private string getChildCode(string code)
        {
            int startIndex = code.IndexOf("{") + 1;
            int nextIndex = startIndex;
            int bracketCounter = 1;
            char[] tempCharArray = code.ToCharArray();
            while (bracketCounter > 0)
            {
                int leftBracketIndex = code.IndexOf("{", nextIndex);
                int rightBracketIndex = code.IndexOf("}", nextIndex);
                if(leftBracketIndex < 0 || rightBracketIndex < 0)
                {
                    nextIndex = Math.Max(leftBracketIndex,rightBracketIndex);
                }
                else
                {
                    nextIndex = Math.Min(leftBracketIndex, rightBracketIndex);
                }
                if(tempCharArray[nextIndex-1] != '\\')
                {
                    bracketCounter += (tempCharArray[nextIndex] == '{' ? 1 : -1);
                }
                nextIndex++;
            }
            nextIndex--;
            return code.Substring(startIndex, nextIndex - startIndex);

        }
        private string getChildAttribute(string code,string attribute)
        {
            if (!code.Contains(attribute))
                return "";
            int startIndex = code.IndexOf(attribute);
            startIndex = code.IndexOf("=", startIndex)+1;
            int indexOfComma = code.IndexOf(",", startIndex);
            int indexOfKlammer = code.IndexOf("]", startIndex);
            int endIndex = Math.Min(indexOfKlammer, indexOfComma);
            if (endIndex == -1)
                endIndex = Math.Max(indexOfKlammer, indexOfComma);
            return code.Substring(startIndex, endIndex - startIndex);
        }
        private void setChildrenByCode(string code)
        {
            while(code.Contains("child"))
            {
                string childAttributes = code.Substring(0, code.IndexOf("{"));
                string childColor = getChildAttribute(childAttributes,"concept color");
                string levelDistanceString = getChildAttribute(childAttributes, "level distance");
                bool levelDistanceEnabled = (levelDistanceString != "");
                siblingAngleChildren = Convert.ToInt16(getChildAttribute(childAttributes, "sibling angle"));
                string childrenCode = getChildCode(code);
                double levelDistance = (levelDistanceEnabled ? Convert.ToDouble(levelDistanceString.Substring(0,levelDistanceString.IndexOf("em")),System.Globalization.CultureInfo.GetCultureInfo("EN")) : 0);
                children.Add(recursiveMindmapCreatingFromTexCode(childrenCode, childColor,levelDistance, levelDistanceEnabled));
                code = code.Substring(childrenCode.Length + childAttributes.Length +2);
            }
        }
        public string Node2LatexCode()
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("node[concept] {" + content + "}");
            code.AppendLine("["+ (clockWise ? "":"counter")+"clockwise from = "+startAngle+"]");
            foreach (var c in children)
            {
                string color = c.getColor();
                code.AppendLine("child[" + (color == "" ? "" : "concept color=" + color) + (c.levelDistanceEnabled?", level distance = " +c.levelDistance.ToString(System.Globalization.CultureInfo.GetCultureInfo("EN"))+ "em":"" )+ ",sibling angle=" + siblingAngleChildren +"] {");
                code.Append(c.Node2LatexCode());
                code.AppendLine("}");
            }
            return code.ToString();
        }
        public int getChildrenCount()
        {
            return children.Count;
        }
    }
}
