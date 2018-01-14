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
        private Node copy;
        private Node tempRoot;
        private Stack<Node> previous;
        private Stack<int> previousIndex;
        private Node current;
        private bool switchOutputPdf;
        private bool enableSubmitting= true;
        private readonly string workingDirectory = System.IO.Directory.GetCurrentDirectory() +"\\";
        private readonly string pathTemp =  System.IO.Path.GetTempPath();
        private readonly string header = "\\documentclass[border = 10pt]{standalone}\n\\usepackage{tikz}\n\\usepackage[ngerman]{babel} %deutsche Trennung und neue Rechtschreibung\n" +
            "\\usetikzlibrary{mindmap,trees}\n" +
"\\begin{document}\n" +
"\\pagestyle{empty}\n" +
"\\begin{tikzpicture}\n";//[every annotation/.style = {draw,\n" +"fill = white, font = \\Large}]\n";
  
        public MindmapForm()
        {
            InitializeComponent();
            webBrowser.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            copy = null;
            loadFileNames();
            loadFile("mindmap",pathTemp);
            tempRoot = root;         
        }
        private void loadFileNames()
        {
            filesListBox.Items.Clear();
            var files = System.IO.Directory.GetFiles(workingDirectory);
            for (var i = 0; i < files.Length; i++)
            {
                if(files[i].Contains(".tex"))
                {
                    filesListBox.Items.Add(files[i].Substring(files[i].LastIndexOf("\\")+1 ,  files[i].Length - files[i].LastIndexOf("\\") - 5));
                }
            }
        }
        private void loadFile(string file, string filePath)
        {
            string code = System.IO.File.ReadAllText(filePath + file + ".tex");
            code = code.Substring(code.IndexOf("concept color"));
            int startIndex = code.IndexOf("=") + 1;
            string color = code.Substring(startIndex, Math.Min(code.IndexOf(","), code.IndexOf("]")) - startIndex);
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
            string fileName = workingDirectory + "mindmap_lastVersion.tex";
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
            textWidthEnabledCheckBox.Checked = current.getTextWidthEnabled();
            textWidthNumericUpDown.Value = current.getTextWidth();
            enableSubmitting = true;
        }

        private void backToParentButton_Click(object sender, EventArgs e)
        {
            if (previous.Count < 1)
            {
                root = root.createParentNode();
                current = root;
            }
            else
            {
                current = previous.Pop();
                previousIndex.Pop();
            } 
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
                current.setTextWidth(Convert.ToInt16(textWidthNumericUpDown.Value));
                current.setTextWidthEnabled(textWidthEnabledCheckBox.Checked);
            }
        }
        private void createLatexCode(string fileName, string path, bool createFromRootNode = true)
        {
            Node startNode = createFromRootNode ? (tempRootCheckBox.Checked?tempRoot:root) : current;
            string code = header +
                "\\path[mindmap, concept color =" + startNode.getColor() +
                ", text =" + (startNode.getColor() == "white" ? "black" : "white") + "]\n" +
                startNode.Node2LatexCode() +
                ";\n" +
                "\\end{tikzpicture}\\end{document};";
            code = code.Replace("ä", "{\\\"a}").Replace("ü", "{\\\"u}").Replace("ö", "{\\\"ö}").Replace("Ä", "{\\\"A}").Replace("Ü", "{\\\"U}").Replace("Ö", "{\\\"O}").Replace("ß","{\\ss}");
            string pathName = path +fileName  + ".tex";
            System.IO.File.WriteAllText(pathName, code);
        }
        private void createLatexCodeButton_Click(object sender, EventArgs e)
        {
            string fileName = "mindmap" + ((switchOutputPdf) ? "_" : "");
            createLatexCode(fileName, pathTemp, !createFromSelectedNodeCheckBox.Checked);
            var p= new System.Diagnostics.Process();
            p.EnableRaisingEvents = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = "-synctex=1 -aux-directory=" + pathTemp + " -interaction=nonstopmode " + pathTemp + fileName + ".tex";
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
            if(filesListBox.SelectedIndex < 0)
            {
                return;
            }
            createLatexCode(filesListBox.SelectedItem.ToString() , workingDirectory);
        }

        private void childrenListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (childrenListBox.SelectedIndex == -1 || selectChildcheckBox.Checked)
                return;
            previous.Push(current);
            previousIndex.Push(childrenListBox.SelectedIndex);
            current = current.getChild(childrenListBox.SelectedIndex);
            loadCurrentNode();
        }

        private void deleteChildButton_Click(object sender, EventArgs e)
        {
            if (previousIndex.Count == 0)
            {
                return;
            }
            if (askForDeleteIfMoreThanOneNode(current.countSubNodes()))
            {
                current = previous.Pop();
                current.removeChild(previousIndex.Pop());
                loadCurrentNode();
            }
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


        private void newFileButton_Click(object sender, EventArgs e)
        {
            //int i = 1;
            string fileName = newNameTextBox.Text;//"mindmap" + i;
            while (filesListBox.Items.Contains(fileName))
            {
                return;
                //i++;
                //fileName = "mindmap" + i;
            }
            createLatexCode(fileName, workingDirectory);
            loadFileNames();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(filesListBox.SelectedIndex < 0)
            {
                return;
            }
            System.IO.File.Delete(workingDirectory + filesListBox.SelectedItem.ToString() + ".tex");
            loadFileNames();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (filesListBox.SelectedIndex < 0)
            {
                return;
            }
            loadFile(filesListBox.SelectedItem.ToString(), workingDirectory);
        }

        private void copyNodeButton_Click(object sender, EventArgs e)
        {
            copy = current.deepCopy();
            pasteNodeButton.Visible = true;
        }

        private void pasteNodeButton_Click(object sender, EventArgs e)
        {
            current.addChild(copy.deepCopy());
            loadCurrentNode();
        }

        private void childUpButton_Click(object sender, EventArgs e)
        {
            shiftChild(true);
            //childrenListBox.SelectedIndex = (childrenListBox.Items.Count+(childrenListBox.SelectedIndex - 1)) % childrenListBox.Items.Count;
        }

        private void childDownButton_Click(object sender, EventArgs e)
        {
            shiftChild(false);
            //childrenListBox.SelectedIndex = (childrenListBox.SelectedIndex + 1) % childrenListBox.Items.Count;
        }
        private void shiftChild(bool up)
        {
            int direction = up ? -1 : 1;
            if (childrenListBox.SelectedIndex < 0)
                return;
            current.switchChildOrder(childrenListBox.SelectedIndex, childrenListBox.SelectedIndex + direction);
            int nextIndex = (childrenListBox.Items.Count + (childrenListBox.SelectedIndex + direction)) % childrenListBox.Items.Count;
            loadCurrentNode();
            childrenListBox.SelectedIndex = nextIndex;
        }

        private void selectChildcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            childDownButton.Visible = selectChildcheckBox.Checked;
            childUpButton.Visible = selectChildcheckBox.Checked;
        }

        private void currentToRootButton_Click(object sender, EventArgs e)
        {
            if(current == root)
            {
                return;
            }
            if(tempRootCheckBox.Checked)
            {
                tempRoot = current;
                return;
            }
            int nodesToDelete = root.countSubNodes() - current.countSubNodes();
            if (askForDeleteIfMoreThanOneNode(nodesToDelete))
            {
                root = current;
                previous = new Stack<Node>();
                previousIndex = new Stack<int>();
            }
        }
        private bool askForDeleteIfMoreThanOneNode(int nodesToDelete)
        {
            var dR = DialogResult.OK;
            if (nodesToDelete > 1)
            {
                dR = MessageBox.Show("Seriously? You are about to delete " + nodesToDelete + " fucking nodes with this action!!!", "Deleting " + nodesToDelete + " nodes...", MessageBoxButtons.OKCancel);
            }
            return (dR == DialogResult.OK);
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            var newName = newNameTextBox.Text;
            if (newName.Contains('\\') ||
                newName.Contains('/') ||
                newName.Contains(':') ||
                newName.Contains('*') ||
                newName.Contains('?') ||
                newName.Contains('"') ||
                newName.Contains('<') ||
                newName.Contains('>') ||
                newName.Contains('|'))
            {
                /*if(*/
                MessageBox.Show("Filename shall not contain: \\/:*?\"<>|", "Invalid Name");//, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            }
            if(filesListBox.Items.Contains(newName))
            {
                MessageBox.Show("Choose another filename!", "FileName allready exists");//, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            }
            string oldName = filesListBox.SelectedItem.ToString();
            System.IO.File.Create(workingDirectory  + newName + ".tex");
            System.IO.File.Replace(workingDirectory + oldName + ".tex", workingDirectory + newName + ".tex", pathTemp+newName+"_bu.tex");
            loadFileNames();
        }

        private void textWidthEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            textWidthTrackBar.Enabled = textWidthEnabledCheckBox.Checked;
            textWidthNumericUpDown.Enabled = textWidthEnabledCheckBox.Checked;
            setCurrentNodeAttributes();
        }

        private void textWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            textWidthTrackBar.Value = Convert.ToInt16(textWidthNumericUpDown.Value);
            setCurrentNodeAttributes();
        }

        private void textWidthTrackBar_Scroll(object sender, EventArgs e)
        {
            textWidthNumericUpDown.Value = textWidthTrackBar.Value;
        }
    }
}
