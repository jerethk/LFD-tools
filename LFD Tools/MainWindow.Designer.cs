namespace LFD_Tools
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openPlttDialog = new OpenFileDialog();
            button1 = new Button();
            button2 = new Button();
            openDeltDialog = new OpenFileDialog();
            displayBox = new PictureBox();
            button3 = new Button();
            openAnimDialog = new OpenFileDialog();
            displayPanel = new Panel();
            comboBoxScale = new ComboBox();
            label1 = new Label();
            textBoxInfo = new TextBox();
            checkBoxMultiSelect = new CheckBox();
            listBoxDelts = new ListBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            displayPanel.SuspendLayout();
            SuspendLayout();
            // 
            // openPlttDialog
            // 
            openPlttDialog.Filter = "PLTT resource|*.plt;*.pltt";
            openPlttDialog.Title = "Open PLTT";
            // 
            // button1
            // 
            button1.Location = new Point(343, 11);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "openPlt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(458, 12);
            button2.Name = "button2";
            button2.Size = new Size(94, 28);
            button2.TabIndex = 1;
            button2.Text = "openDelt";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openDeltDialog
            // 
            openDeltDialog.Filter = "DELT resource|*.dlt;*.delt";
            openDeltDialog.Title = "Open DELT";
            // 
            // displayBox
            // 
            displayBox.BackColor = SystemColors.Control;
            displayBox.Location = new Point(0, 0);
            displayBox.Name = "displayBox";
            displayBox.Size = new Size(200, 200);
            displayBox.TabIndex = 2;
            displayBox.TabStop = false;
            displayBox.Paint += DisplayBox_Paint;
            // 
            // button3
            // 
            button3.Location = new Point(574, 12);
            button3.Name = "button3";
            button3.Size = new Size(94, 28);
            button3.TabIndex = 3;
            button3.Text = "openAnim";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // openAnimDialog
            // 
            openAnimDialog.Filter = "ANIM resource|*.anm;*.anim";
            openAnimDialog.Title = "Open ANIM";
            // 
            // displayPanel
            // 
            displayPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            displayPanel.AutoScroll = true;
            displayPanel.BorderStyle = BorderStyle.FixedSingle;
            displayPanel.Controls.Add(displayBox);
            displayPanel.Location = new Point(337, 205);
            displayPanel.Name = "displayPanel";
            displayPanel.Size = new Size(1169, 616);
            displayPanel.TabIndex = 5;
            // 
            // comboBoxScale
            // 
            comboBoxScale.FormattingEnabled = true;
            comboBoxScale.Items.AddRange(new object[] { "100%", "200%", "300%", "400%" });
            comboBoxScale.Location = new Point(338, 152);
            comboBoxScale.Name = "comboBoxScale";
            comboBoxScale.Size = new Size(151, 28);
            comboBoxScale.TabIndex = 6;
            comboBoxScale.SelectedIndexChanged += comboBoxScale_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 129);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 7;
            label1.Text = "Scale";
            // 
            // textBoxInfo
            // 
            textBoxInfo.BackColor = SystemColors.Control;
            textBoxInfo.Location = new Point(38, 152);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.ReadOnly = true;
            textBoxInfo.Size = new Size(256, 238);
            textBoxInfo.TabIndex = 8;
            // 
            // checkBoxMultiSelect
            // 
            checkBoxMultiSelect.AutoSize = true;
            checkBoxMultiSelect.Location = new Point(38, 439);
            checkBoxMultiSelect.Name = "checkBoxMultiSelect";
            checkBoxMultiSelect.Size = new Size(172, 24);
            checkBoxMultiSelect.TabIndex = 10;
            checkBoxMultiSelect.Text = "Allow multi-selection";
            checkBoxMultiSelect.UseVisualStyleBackColor = true;
            checkBoxMultiSelect.Visible = false;
            checkBoxMultiSelect.CheckedChanged += CheckBoxMultiSelect_CheckedChanged;
            // 
            // listBoxDelts
            // 
            listBoxDelts.FormattingEnabled = true;
            listBoxDelts.Location = new Point(38, 479);
            listBoxDelts.Name = "listBoxDelts";
            listBoxDelts.Size = new Size(243, 304);
            listBoxDelts.TabIndex = 11;
            listBoxDelts.Visible = false;
            listBoxDelts.SelectedIndexChanged += ListBoxDelts_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 129);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 12;
            label2.Text = "Info";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1542, 853);
            Controls.Add(label2);
            Controls.Add(listBoxDelts);
            Controls.Add(checkBoxMultiSelect);
            Controls.Add(textBoxInfo);
            Controls.Add(label1);
            Controls.Add(comboBoxScale);
            Controls.Add(displayPanel);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainWindow";
            Text = "Main Window";
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            displayPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openPlttDialog;
        private Button button1;
        private Button button2;
        private OpenFileDialog openDeltDialog;
        private PictureBox displayBox;
        private Button button3;
        private OpenFileDialog openAnimDialog;
        private Panel displayPanel;
        private ComboBox comboBoxScale;
        private Label label1;
        private TextBox textBoxInfo;
        private CheckBox checkBoxMultiSelect;
        private ListBox listBoxDelts;
        private Label label2;
    }
}
