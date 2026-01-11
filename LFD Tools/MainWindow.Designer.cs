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
            label3 = new Label();
            labelPltt = new Label();
            lfdPanel = new Panel();
            mainPanel = new Panel();
            button4 = new Button();
            openLfdDialog = new OpenFileDialog();
            label4 = new Label();
            labelLfd = new Label();
            listBoxLfdContents = new ListBox();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            displayPanel.SuspendLayout();
            lfdPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // openPlttDialog
            // 
            openPlttDialog.Filter = "PLTT resource|*.plt;*.pltt";
            openPlttDialog.Title = "Open PLTT";
            // 
            // button1
            // 
            button1.Location = new Point(483, 23);
            button1.Name = "button1";
            button1.Size = new Size(104, 29);
            button1.TabIndex = 0;
            button1.Text = "Open PLTT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(609, 23);
            button2.Name = "button2";
            button2.Size = new Size(104, 29);
            button2.TabIndex = 1;
            button2.Text = "Open DELT";
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
            button3.Location = new Point(733, 23);
            button3.Name = "button3";
            button3.Size = new Size(104, 29);
            button3.TabIndex = 3;
            button3.Text = "Open ANIM";
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
            displayPanel.Location = new Point(335, 212);
            displayPanel.Name = "displayPanel";
            displayPanel.Size = new Size(896, 610);
            displayPanel.TabIndex = 5;
            // 
            // comboBoxScale
            // 
            comboBoxScale.FormattingEnabled = true;
            comboBoxScale.Items.AddRange(new object[] { "100%", "200%", "300%", "400%" });
            comboBoxScale.Location = new Point(336, 159);
            comboBoxScale.Name = "comboBoxScale";
            comboBoxScale.Size = new Size(151, 28);
            comboBoxScale.TabIndex = 6;
            comboBoxScale.SelectedIndexChanged += comboBoxScale_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(336, 136);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 7;
            label1.Text = "Scale";
            // 
            // textBoxInfo
            // 
            textBoxInfo.BackColor = SystemColors.Control;
            textBoxInfo.Location = new Point(36, 159);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.ReadOnly = true;
            textBoxInfo.Size = new Size(256, 238);
            textBoxInfo.TabIndex = 8;
            // 
            // checkBoxMultiSelect
            // 
            checkBoxMultiSelect.AutoSize = true;
            checkBoxMultiSelect.Location = new Point(36, 446);
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
            listBoxDelts.Location = new Point(36, 486);
            listBoxDelts.Name = "listBoxDelts";
            listBoxDelts.Size = new Size(243, 324);
            listBoxDelts.TabIndex = 11;
            listBoxDelts.Visible = false;
            listBoxDelts.SelectedIndexChanged += ListBoxDelts_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 136);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 12;
            label2.Text = "Info";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 27);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 13;
            label3.Text = "Current PLTT";
            // 
            // labelPltt
            // 
            labelPltt.AutoSize = true;
            labelPltt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPltt.Location = new Point(36, 55);
            labelPltt.Name = "labelPltt";
            labelPltt.Size = new Size(73, 20);
            labelPltt.TabIndex = 14;
            labelPltt.Text = "BRF-JAN";
            // 
            // lfdPanel
            // 
            lfdPanel.BorderStyle = BorderStyle.FixedSingle;
            lfdPanel.Controls.Add(listBoxLfdContents);
            lfdPanel.Controls.Add(labelLfd);
            lfdPanel.Controls.Add(label4);
            lfdPanel.Dock = DockStyle.Left;
            lfdPanel.Location = new Point(0, 0);
            lfdPanel.Name = "lfdPanel";
            lfdPanel.Size = new Size(363, 853);
            lfdPanel.TabIndex = 16;
            lfdPanel.Visible = false;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(button4);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(labelPltt);
            mainPanel.Controls.Add(button1);
            mainPanel.Controls.Add(button2);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(button3);
            mainPanel.Controls.Add(listBoxDelts);
            mainPanel.Controls.Add(displayPanel);
            mainPanel.Controls.Add(checkBoxMultiSelect);
            mainPanel.Controls.Add(comboBoxScale);
            mainPanel.Controls.Add(textBoxInfo);
            mainPanel.Controls.Add(label1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(363, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1259, 853);
            mainPanel.TabIndex = 15;
            // 
            // button4
            // 
            button4.Location = new Point(356, 23);
            button4.Name = "button4";
            button4.Size = new Size(104, 29);
            button4.TabIndex = 15;
            button4.Text = "Open LFD";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // openLfdDialog
            // 
            openLfdDialog.Filter = "LFD file|*.lfd";
            openLfdDialog.Title = "Open LFD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 26);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 0;
            label4.Text = "LFD";
            // 
            // labelLfd
            // 
            labelLfd.AutoSize = true;
            labelLfd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLfd.Location = new Point(24, 54);
            labelLfd.Name = "labelLfd";
            labelLfd.Size = new Size(51, 20);
            labelLfd.TabIndex = 1;
            labelLfd.Text = "label5";
            // 
            // listBoxLfdContents
            // 
            listBoxLfdContents.FormattingEnabled = true;
            listBoxLfdContents.Location = new Point(24, 158);
            listBoxLfdContents.Name = "listBoxLfdContents";
            listBoxLfdContents.Size = new Size(305, 484);
            listBoxLfdContents.TabIndex = 2;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1622, 853);
            Controls.Add(mainPanel);
            Controls.Add(lfdPanel);
            Name = "MainWindow";
            Text = "Main Window";
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            displayPanel.ResumeLayout(false);
            lfdPanel.ResumeLayout(false);
            lfdPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
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
        private Label label3;
        private Label labelPltt;
        private Panel mainPanel;
        private Panel lfdPanel;
        private Button button4;
        private OpenFileDialog openLfdDialog;
        private Label labelLfd;
        private Label label4;
        private ListBox listBoxLfdContents;
    }
}
