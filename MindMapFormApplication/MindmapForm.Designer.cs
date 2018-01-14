namespace LatexTiksMindMapTool
{
    partial class MindmapForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private Node root;
        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MindmapForm));
            this.childrenListBox = new System.Windows.Forms.ListBox();
            this.addChildButton = new System.Windows.Forms.Button();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.backToParentButton = new System.Windows.Forms.Button();
            this.createLatexCodeButton = new System.Windows.Forms.Button();
            this.clockWiseCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startAngleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelDistanceTrackBar = new System.Windows.Forms.TrackBar();
            this.enableLevelDistanceCeckBox = new System.Windows.Forms.CheckBox();
            this.levelDistanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.siblingAngleChildrenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteNodeButton = new System.Windows.Forms.Button();
            this.startAngleTrackBar = new System.Windows.Forms.TrackBar();
            this.siblingAngleChildrenTrackBar = new System.Windows.Forms.TrackBar();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.newFileButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.createFromSelectedNodeCheckBox = new System.Windows.Forms.CheckBox();
            this.copyNodeButton = new System.Windows.Forms.Button();
            this.pasteNodeButton = new System.Windows.Forms.Button();
            this.childUpButton = new System.Windows.Forms.Button();
            this.childDownButton = new System.Windows.Forms.Button();
            this.selectChildcheckBox = new System.Windows.Forms.CheckBox();
            this.currentToRootButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.tempRootCheckBox = new System.Windows.Forms.CheckBox();
            this.textWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.textWidthEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.textWidthTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.startAngleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelDistanceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelDistanceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siblingAngleChildrenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAngleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siblingAngleChildrenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWidthTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // childrenListBox
            // 
            this.childrenListBox.FormattingEnabled = true;
            this.childrenListBox.Location = new System.Drawing.Point(12, 187);
            this.childrenListBox.Name = "childrenListBox";
            this.childrenListBox.Size = new System.Drawing.Size(148, 69);
            this.childrenListBox.TabIndex = 0;
            this.childrenListBox.SelectedIndexChanged += new System.EventHandler(this.childrenListBox_SelectedIndexChanged);
            // 
            // addChildButton
            // 
            this.addChildButton.Location = new System.Drawing.Point(174, 187);
            this.addChildButton.Name = "addChildButton";
            this.addChildButton.Size = new System.Drawing.Size(83, 34);
            this.addChildButton.TabIndex = 1;
            this.addChildButton.Text = "Add Child";
            this.addChildButton.UseVisualStyleBackColor = true;
            this.addChildButton.Click += new System.EventHandler(this.addChildButton_Click);
            // 
            // colorTextBox
            // 
            this.colorTextBox.Location = new System.Drawing.Point(12, 144);
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.Size = new System.Drawing.Size(148, 20);
            this.colorTextBox.TabIndex = 3;
            this.colorTextBox.TextChanged += new System.EventHandler(this.colorTextBox_TextChanged);
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(12, 51);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(144, 74);
            this.contentTextBox.TabIndex = 4;
            this.contentTextBox.TextChanged += new System.EventHandler(this.contentTextBox_TextChanged);
            // 
            // backToParentButton
            // 
            this.backToParentButton.Location = new System.Drawing.Point(16, 12);
            this.backToParentButton.Name = "backToParentButton";
            this.backToParentButton.Size = new System.Drawing.Size(57, 23);
            this.backToParentButton.TabIndex = 5;
            this.backToParentButton.Text = "<<";
            this.backToParentButton.UseVisualStyleBackColor = true;
            this.backToParentButton.Click += new System.EventHandler(this.backToParentButton_Click);
            // 
            // createLatexCodeButton
            // 
            this.createLatexCodeButton.Location = new System.Drawing.Point(174, 315);
            this.createLatexCodeButton.Name = "createLatexCodeButton";
            this.createLatexCodeButton.Size = new System.Drawing.Size(83, 34);
            this.createLatexCodeButton.TabIndex = 8;
            this.createLatexCodeButton.Text = "Create Latex Code";
            this.createLatexCodeButton.UseVisualStyleBackColor = true;
            this.createLatexCodeButton.Click += new System.EventHandler(this.createLatexCodeButton_Click);
            // 
            // clockWiseCheckBox
            // 
            this.clockWiseCheckBox.AutoSize = true;
            this.clockWiseCheckBox.Location = new System.Drawing.Point(729, 98);
            this.clockWiseCheckBox.Name = "clockWiseCheckBox";
            this.clockWiseCheckBox.Size = new System.Drawing.Size(115, 17);
            this.clockWiseCheckBox.TabIndex = 10;
            this.clockWiseCheckBox.Text = "Children Clockwise";
            this.clockWiseCheckBox.UseVisualStyleBackColor = true;
            this.clockWiseCheckBox.CheckedChanged += new System.EventHandler(this.clockWiseCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "startAngle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Content";
            // 
            // startAngleNumericUpDown
            // 
            this.startAngleNumericUpDown.Location = new System.Drawing.Point(591, 52);
            this.startAngleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.startAngleNumericUpDown.Name = "startAngleNumericUpDown";
            this.startAngleNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.startAngleNumericUpDown.TabIndex = 15;
            this.startAngleNumericUpDown.ValueChanged += new System.EventHandler(this.startAngleNumericUpDown_ValueChanged);
            // 
            // levelDistanceTrackBar
            // 
            this.levelDistanceTrackBar.Enabled = false;
            this.levelDistanceTrackBar.Location = new System.Drawing.Point(710, 51);
            this.levelDistanceTrackBar.Maximum = 10000;
            this.levelDistanceTrackBar.Name = "levelDistanceTrackBar";
            this.levelDistanceTrackBar.Size = new System.Drawing.Size(148, 45);
            this.levelDistanceTrackBar.TabIndex = 16;
            this.levelDistanceTrackBar.Scroll += new System.EventHandler(this.levelDistanceTrackBar_Scroll);
            // 
            // enableLevelDistanceCeckBox
            // 
            this.enableLevelDistanceCeckBox.AutoSize = true;
            this.enableLevelDistanceCeckBox.Location = new System.Drawing.Point(729, 26);
            this.enableLevelDistanceCeckBox.Name = "enableLevelDistanceCeckBox";
            this.enableLevelDistanceCeckBox.Size = new System.Drawing.Size(145, 17);
            this.enableLevelDistanceCeckBox.TabIndex = 17;
            this.enableLevelDistanceCeckBox.Text = "enable Level Distance fix";
            this.enableLevelDistanceCeckBox.UseVisualStyleBackColor = true;
            this.enableLevelDistanceCeckBox.CheckedChanged += new System.EventHandler(this.enableLevelDistanceCheckBox_CheckedChanged);
            // 
            // levelDistanceNumericUpDown
            // 
            this.levelDistanceNumericUpDown.DecimalPlaces = 2;
            this.levelDistanceNumericUpDown.Enabled = false;
            this.levelDistanceNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.levelDistanceNumericUpDown.Location = new System.Drawing.Point(854, 51);
            this.levelDistanceNumericUpDown.Name = "levelDistanceNumericUpDown";
            this.levelDistanceNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.levelDistanceNumericUpDown.TabIndex = 18;
            this.levelDistanceNumericUpDown.ValueChanged += new System.EventHandler(this.levelDistanceNumericUpDown_ValueChanged);
            // 
            // siblingAngleChildrenNumericUpDown
            // 
            this.siblingAngleChildrenNumericUpDown.Location = new System.Drawing.Point(591, 98);
            this.siblingAngleChildrenNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.siblingAngleChildrenNumericUpDown.Name = "siblingAngleChildrenNumericUpDown";
            this.siblingAngleChildrenNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.siblingAngleChildrenNumericUpDown.TabIndex = 19;
            this.siblingAngleChildrenNumericUpDown.ValueChanged += new System.EventHandler(this.siblingAngleChildrenNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(588, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Sibling Angle Children";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(277, 170);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(932, 404);
            this.webBrowser.TabIndex = 21;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(331, 27);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(41, 23);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteNodeButton
            // 
            this.deleteNodeButton.Location = new System.Drawing.Point(174, 84);
            this.deleteNodeButton.Name = "deleteNodeButton";
            this.deleteNodeButton.Size = new System.Drawing.Size(83, 34);
            this.deleteNodeButton.TabIndex = 23;
            this.deleteNodeButton.Text = "Delete Node";
            this.deleteNodeButton.UseVisualStyleBackColor = true;
            this.deleteNodeButton.Click += new System.EventHandler(this.deleteChildButton_Click);
            // 
            // startAngleTrackBar
            // 
            this.startAngleTrackBar.Location = new System.Drawing.Point(434, 40);
            this.startAngleTrackBar.Maximum = 360;
            this.startAngleTrackBar.Name = "startAngleTrackBar";
            this.startAngleTrackBar.Size = new System.Drawing.Size(148, 45);
            this.startAngleTrackBar.TabIndex = 24;
            this.startAngleTrackBar.Scroll += new System.EventHandler(this.startAngleTrackBar_Scroll);
            // 
            // siblingAngleChildrenTrackBar
            // 
            this.siblingAngleChildrenTrackBar.Location = new System.Drawing.Point(437, 82);
            this.siblingAngleChildrenTrackBar.Maximum = 360;
            this.siblingAngleChildrenTrackBar.Name = "siblingAngleChildrenTrackBar";
            this.siblingAngleChildrenTrackBar.Size = new System.Drawing.Size(148, 45);
            this.siblingAngleChildrenTrackBar.TabIndex = 25;
            this.siblingAngleChildrenTrackBar.Scroll += new System.EventHandler(this.siblingAngleChildrenTrackBar_Scroll);
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.Location = new System.Drawing.Point(283, 56);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(148, 69);
            this.filesListBox.TabIndex = 26;
            // 
            // newFileButton
            // 
            this.newFileButton.Location = new System.Drawing.Point(283, 27);
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(42, 23);
            this.newFileButton.TabIndex = 27;
            this.newFileButton.Text = "New";
            this.newFileButton.UseVisualStyleBackColor = true;
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(283, 126);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(53, 23);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(378, 27);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(41, 23);
            this.loadButton.TabIndex = 29;
            this.loadButton.Text = "load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // createFromSelectedNodeCheckBox
            // 
            this.createFromSelectedNodeCheckBox.AutoSize = true;
            this.createFromSelectedNodeCheckBox.Location = new System.Drawing.Point(174, 279);
            this.createFromSelectedNodeCheckBox.Name = "createFromSelectedNodeCheckBox";
            this.createFromSelectedNodeCheckBox.Size = new System.Drawing.Size(95, 30);
            this.createFromSelectedNodeCheckBox.TabIndex = 30;
            this.createFromSelectedNodeCheckBox.Text = "Create from \r\nselected Node";
            this.createFromSelectedNodeCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyNodeButton
            // 
            this.copyNodeButton.Location = new System.Drawing.Point(174, 49);
            this.copyNodeButton.Name = "copyNodeButton";
            this.copyNodeButton.Size = new System.Drawing.Size(83, 34);
            this.copyNodeButton.TabIndex = 31;
            this.copyNodeButton.Text = "Copy Node";
            this.copyNodeButton.UseVisualStyleBackColor = true;
            this.copyNodeButton.Click += new System.EventHandler(this.copyNodeButton_Click);
            // 
            // pasteNodeButton
            // 
            this.pasteNodeButton.Location = new System.Drawing.Point(174, 222);
            this.pasteNodeButton.Name = "pasteNodeButton";
            this.pasteNodeButton.Size = new System.Drawing.Size(83, 34);
            this.pasteNodeButton.TabIndex = 32;
            this.pasteNodeButton.Text = "Paste Copy as Children";
            this.pasteNodeButton.UseVisualStyleBackColor = true;
            this.pasteNodeButton.Visible = false;
            this.pasteNodeButton.Click += new System.EventHandler(this.pasteNodeButton_Click);
            // 
            // childUpButton
            // 
            this.childUpButton.Location = new System.Drawing.Point(12, 287);
            this.childUpButton.Name = "childUpButton";
            this.childUpButton.Size = new System.Drawing.Size(147, 22);
            this.childUpButton.TabIndex = 33;
            this.childUpButton.Text = "UP";
            this.childUpButton.UseVisualStyleBackColor = true;
            this.childUpButton.Visible = false;
            this.childUpButton.Click += new System.EventHandler(this.childUpButton_Click);
            // 
            // childDownButton
            // 
            this.childDownButton.Location = new System.Drawing.Point(12, 315);
            this.childDownButton.Name = "childDownButton";
            this.childDownButton.Size = new System.Drawing.Size(147, 22);
            this.childDownButton.TabIndex = 34;
            this.childDownButton.Text = "Down";
            this.childDownButton.UseVisualStyleBackColor = true;
            this.childDownButton.Visible = false;
            this.childDownButton.Click += new System.EventHandler(this.childDownButton_Click);
            // 
            // selectChildcheckBox
            // 
            this.selectChildcheckBox.AutoSize = true;
            this.selectChildcheckBox.Location = new System.Drawing.Point(12, 264);
            this.selectChildcheckBox.Name = "selectChildcheckBox";
            this.selectChildcheckBox.Size = new System.Drawing.Size(84, 17);
            this.selectChildcheckBox.TabIndex = 35;
            this.selectChildcheckBox.Text = "Switch Child";
            this.selectChildcheckBox.UseVisualStyleBackColor = true;
            this.selectChildcheckBox.CheckedChanged += new System.EventHandler(this.selectChildcheckBox_CheckedChanged);
            // 
            // currentToRootButton
            // 
            this.currentToRootButton.Location = new System.Drawing.Point(80, 12);
            this.currentToRootButton.Name = "currentToRootButton";
            this.currentToRootButton.Size = new System.Drawing.Size(80, 36);
            this.currentToRootButton.TabIndex = 36;
            this.currentToRootButton.Text = "Make current\r\nNode to Root";
            this.currentToRootButton.UseVisualStyleBackColor = true;
            this.currentToRootButton.Click += new System.EventHandler(this.currentToRootButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(342, 126);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(89, 23);
            this.renameButton.TabIndex = 37;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Visible = false;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Location = new System.Drawing.Point(437, 128);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.newNameTextBox.TabIndex = 38;
            // 
            // tempRootCheckBox
            // 
            this.tempRootCheckBox.AutoSize = true;
            this.tempRootCheckBox.Location = new System.Drawing.Point(166, 12);
            this.tempRootCheckBox.Name = "tempRootCheckBox";
            this.tempRootCheckBox.Size = new System.Drawing.Size(120, 17);
            this.tempRootCheckBox.TabIndex = 39;
            this.tempRootCheckBox.Text = "(...to temporary root)";
            this.tempRootCheckBox.UseVisualStyleBackColor = true;
            // 
            // textWidthNumericUpDown
            // 
            this.textWidthNumericUpDown.Enabled = false;
            this.textWidthNumericUpDown.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textWidthNumericUpDown.Location = new System.Drawing.Point(1107, 51);
            this.textWidthNumericUpDown.Name = "textWidthNumericUpDown";
            this.textWidthNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.textWidthNumericUpDown.TabIndex = 42;
            this.textWidthNumericUpDown.ValueChanged += new System.EventHandler(this.textWidthNumericUpDown_ValueChanged);
            // 
            // textWidthEnabledCheckBox
            // 
            this.textWidthEnabledCheckBox.AutoSize = true;
            this.textWidthEnabledCheckBox.Location = new System.Drawing.Point(970, 26);
            this.textWidthEnabledCheckBox.Name = "textWidthEnabledCheckBox";
            this.textWidthEnabledCheckBox.Size = new System.Drawing.Size(113, 17);
            this.textWidthEnabledCheckBox.TabIndex = 41;
            this.textWidthEnabledCheckBox.Text = "enable Text Width";
            this.textWidthEnabledCheckBox.UseVisualStyleBackColor = true;
            this.textWidthEnabledCheckBox.CheckedChanged += new System.EventHandler(this.textWidthEnabledCheckBox_CheckedChanged);
            // 
            // textWidthTrackBar
            // 
            this.textWidthTrackBar.Enabled = false;
            this.textWidthTrackBar.Location = new System.Drawing.Point(953, 51);
            this.textWidthTrackBar.Maximum = 100;
            this.textWidthTrackBar.Name = "textWidthTrackBar";
            this.textWidthTrackBar.Size = new System.Drawing.Size(148, 45);
            this.textWidthTrackBar.TabIndex = 40;
            this.textWidthTrackBar.Scroll += new System.EventHandler(this.textWidthTrackBar_Scroll);
            // 
            // MindmapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 598);
            this.Controls.Add(this.textWidthNumericUpDown);
            this.Controls.Add(this.textWidthEnabledCheckBox);
            this.Controls.Add(this.textWidthTrackBar);
            this.Controls.Add(this.tempRootCheckBox);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.currentToRootButton);
            this.Controls.Add(this.selectChildcheckBox);
            this.Controls.Add(this.childDownButton);
            this.Controls.Add(this.childUpButton);
            this.Controls.Add(this.pasteNodeButton);
            this.Controls.Add(this.copyNodeButton);
            this.Controls.Add(this.createFromSelectedNodeCheckBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newFileButton);
            this.Controls.Add(this.filesListBox);
            this.Controls.Add(this.siblingAngleChildrenTrackBar);
            this.Controls.Add(this.startAngleTrackBar);
            this.Controls.Add(this.deleteNodeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.siblingAngleChildrenNumericUpDown);
            this.Controls.Add(this.levelDistanceNumericUpDown);
            this.Controls.Add(this.enableLevelDistanceCeckBox);
            this.Controls.Add(this.levelDistanceTrackBar);
            this.Controls.Add(this.startAngleNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clockWiseCheckBox);
            this.Controls.Add(this.createLatexCodeButton);
            this.Controls.Add(this.backToParentButton);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.colorTextBox);
            this.Controls.Add(this.addChildButton);
            this.Controls.Add(this.childrenListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MindmapForm";
            this.Text = "Mindmap-Designer";
            ((System.ComponentModel.ISupportInitialize)(this.startAngleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelDistanceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelDistanceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siblingAngleChildrenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAngleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siblingAngleChildrenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWidthTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox childrenListBox;
        private System.Windows.Forms.Button addChildButton;
        private System.Windows.Forms.TextBox colorTextBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Button backToParentButton;
        private System.Windows.Forms.Button createLatexCodeButton;
        private System.Windows.Forms.CheckBox clockWiseCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown startAngleNumericUpDown;
        private System.Windows.Forms.TrackBar levelDistanceTrackBar;
        private System.Windows.Forms.CheckBox enableLevelDistanceCeckBox;
        private System.Windows.Forms.NumericUpDown levelDistanceNumericUpDown;
        private System.Windows.Forms.NumericUpDown siblingAngleChildrenNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteNodeButton;
        private System.Windows.Forms.TrackBar startAngleTrackBar;
        private System.Windows.Forms.TrackBar siblingAngleChildrenTrackBar;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.Button newFileButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.CheckBox createFromSelectedNodeCheckBox;
        private System.Windows.Forms.Button copyNodeButton;
        private System.Windows.Forms.Button pasteNodeButton;
        private System.Windows.Forms.Button childUpButton;
        private System.Windows.Forms.Button childDownButton;
        private System.Windows.Forms.CheckBox selectChildcheckBox;
        private System.Windows.Forms.Button currentToRootButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.CheckBox tempRootCheckBox;
        private System.Windows.Forms.NumericUpDown textWidthNumericUpDown;
        private System.Windows.Forms.CheckBox textWidthEnabledCheckBox;
        private System.Windows.Forms.TrackBar textWidthTrackBar;
    }
}

