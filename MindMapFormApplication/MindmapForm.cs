using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatexTiksMindMapTool
{
    public partial class MindmapForm : Form
    {
        private Node root;
        private Stack<Node> previous;
        private Stack<int> previousIndex;
        private Node current;
        private bool switchOutputPdf;
        private bool enableSubmitting= true;
        private readonly string pathTemp =  System.IO.Path.GetTempPath();
        private readonly string header = "\\documentclass[border = 10pt]{standalone}\n\\usepackage{tikz}\n\\usepackage[ngerman]{babel} %deutsche Trennung und neue Rechtschreibung\n" +
            "\\usetikzlibrary{mindmap,trees}\n" +
"\\begin{document}\n" +
"\\pagestyle{empty}\n" +
"\\begin{tikzpicture}\n";//[every annotation/.style = {draw,\n" +"fill = white, font = \\Large}]\n";
  
        public MindmapForm()
        {
            InitializeComponent();
            switchOutputPdf = false;
            string code = System.IO.File.ReadAllText(pathTemp + "mindmap.tex");
            code = code.Substring(code.IndexOf("concept color"));
            int startIndex = code.IndexOf("=") + 1;
            string color = code.Substring(startIndex, Math.Min(code.IndexOf(","), code.IndexOf("]"))- startIndex);
            startIndex = code.IndexOf("]") + 1;
            code = code.Substring(startIndex, code.Length - startIndex);
            root = Node.recursiveMindmapCreatingFromTexCode(code, color, 0, false);
            current = root;
            loadCurrentNode();
            previous = new Stack<Node>();
            previousIndex = new Stack<int>();
        }

        protected override void OnFormClosing(FormClosingEventArgs a)
        {
            base.OnFormClosing(a);
            string code = header +
                "\\path[mindmap, concept color =" + root.getColor() +
                ", text =" + (root.getColor() == "white" ? "black" : "white") + "]\n" +
                root.Node2LatexCode() +
                ";\n" +
                "\\end{tikzpicture}\\end{document};";
            string fileName = pathTemp + "mindmap.tex";
            System.IO.File.WriteAllText(fileName, code);

        }

        private void addChildButton_Click(object sender, EventArgs e)
        {
            current.addChild("Node Nr" + (current.getChildrenCount() + 1) , current.getColor());
            loadCurrentNode();
        }
        private void loadCurrentNode()
        {
            enableSubmitting = false;
            colorTextBox.Text = current.getColor();
            contentTextBox.Text = current.getContent();
            childrenListBox.Items.Clear();
            childrenListBox.Items.AddRange(current.getChildren());
            clockWiseCheckBox.Checked = current.getClockWise();
            startAngleNumericUpDown.Value = current.getStartAngle();
            enableLevelDistanceCeckBox.Checked = true;
            levelDistanceNumericUpDown.Value = Convert.ToDecimal(current.getLevelDistance());
            enableLevelDistanceCeckBox.Checked = current.getLevelDistanceEnabled();
            siblingAngleChildrenNumericUpDown.Value = current.getSiblingAngleChildren();
            enableSubmitting = true;
        }

        private void backToParentButton_Click(object sender, EventArgs e)
        {
            if (previous.Count < 1)
                return;
            current = previous.Pop();
            previousIndex.Pop();
            loadCurrentNode();
        }


        private void setCurrentNodeAttributes()
        {
            if (enableSubmitting)
            {
                current.setContent(contentTextBox.Text);
                current.setColor(colorTextBox.Text);
                current.setClockWise(clockWiseCheckBox.Checked);
                current.setStartAngle((int)startAngleNumericUpDown.Value);
                current.setLevelDistanceEnabled(enableLevelDistanceCeckBox.Checked);
                current.setLevelDistance(Convert.ToDouble(levelDistanceNumericUpDown.Value));
                current.setSiblingAngleChildren(Convert.ToInt16(siblingAngleChildrenNumericUpDown.Value));
            }
        }

        private void createLatexCodeButton_Click(object sender, EventArgs e)
        {
            //webBrowser.Navigate("http://localhost/");
            string code = header +
                "\\path[mindmap, concept color =" + root.getColor() +
                ", text =" + (root.getColor() == "white" ? "black" : "white") + "]\n" +
                root.Node2LatexCode() + 
                ";\n" +
                "\\end{tikzpicture}\\end{document};";
            string fileName = pathTemp + "mindmap" + ((switchOutputPdf) ? "_":"") +".tex";
            System.IO.File.WriteAllText(fileName, code);
            var p= new System.Diagnostics.Process();
            p.EnableRaisingEvents = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = "-synctex=1 -aux-directory=" + pathTemp + " -interaction=nonstopmode " + fileName;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "pdflatex.exe";
            p.Start();
            p.Exited += new EventHandler(openMindmapPdf);
        }
        private void openMindmapPdf(object sender, System.EventArgs e)
        {
            webBrowser.Navigate(@"file:///" + System.IO.Directory.GetCurrentDirectory() + "\\mindmap"+ ((switchOutputPdf) ? "_" : "") + ".pdf" + "#toolbar=0");
            switchOutputPdf = !switchOutputPdf;
        }

        private void levelDistanceTrackBar_Scroll(object sender, EventArgs e)
        {
            levelDistanceNumericUpDown.Value = Convert.ToDecimal(levelDistanceTrackBar.Value/100.0);
        }

        private void levelDistanceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            levelDistanceTrackBar.Value = Convert.ToInt16(Convert.ToDouble(levelDistanceNumericUpDown.Value)*100.0);
            setCurrentNodeAttributes();
        }

        private void enableLevelDistanceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            levelDistanceTrackBar.Enabled = enableLevelDistanceCeckBox.Checked;
            levelDistanceNumericUpDown.Enabled = enableLevelDistanceCeckBox.Checked;
            setCurrentNodeAttributes();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            System.IO.File.Copy(pathTemp + "mindmap.tex", System.IO.Directory.GetCurrentDirectory() + "\\mindmap_save.tex");
        }

        private void childrenListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (childrenListBox.SelectedIndex == -1)
                return;
            previous.Push(current);
            previousIndex.Push(childrenListBox.SelectedIndex);
            current = current.getChild(childrenListBox.SelectedIndex);
            loadCurrentNode();
        }

        private void deleteChildButton_Click(object sender, EventArgs e)
        {
            if (previousIndex.Count==0)
                return;
            current = previous.Pop();
            current.removeChild(previousIndex.Pop());
            loadCurrentNode();
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e)
        {
            setCurrentNodeAttributes();
        }

        private void startAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            startAngleTrackBar.Value = Convert.ToInt16(startAngleNumericUpDown.Value);
            setCurrentNodeAttributes();
        }

        private void siblingAngleChildrenNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            siblingAngleChildrenTrackBar.Value = Convert.ToInt16(siblingAngleChildrenNumericUpDown.Value);
            setCurrentNodeAttributes();
        }

        private void clockWiseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setCurrentNodeAttributes();
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {
            setCurrentNodeAttributes();
        }

        private void startAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            startAngleNumericUpDown.Value = startAngleTrackBar.Value;
        }

        private void siblingAngleChildrenTrackBar_Scroll(object sender, EventArgs e)
        {
            siblingAngleChildrenNumericUpDown.Value = siblingAngleChildrenTrackBar.Value;
        }
    }
}
