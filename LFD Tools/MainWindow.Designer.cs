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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            openPlttDialog = new OpenFileDialog();
            openDeltDialog = new OpenFileDialog();
            displayBox = new PictureBox();
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
            btnOpenResource = new Button();
            listBoxLfdContents = new ListBox();
            labelLfd = new Label();
            label4 = new Label();
            mainPanel = new Panel();
            label6 = new Label();
            comboBoxDisplayBackground = new ComboBox();
            label5 = new Label();
            labelResourceName = new Label();
            openLfdDialog = new OpenFileDialog();
            toolStrip = new ToolStrip();
            toolStripButtonOpenLFD = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripDropDownButtonOpenFile = new ToolStripDropDownButton();
            toolStripMenuItemOpenPltt = new ToolStripMenuItem();
            toolStripMenuItemOpenDelt = new ToolStripMenuItem();
            toolStripMenuItemOpenAnim = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonExport = new ToolStripButton();
            savePngDialog = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            displayPanel.SuspendLayout();
            lfdPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // openPlttDialog
            // 
            openPlttDialog.Filter = "PLTT resource|*.plt;*.pltt";
            openPlttDialog.Title = "Open PLTT";
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
            displayPanel.Location = new Point(336, 140);
            displayPanel.Name = "displayPanel";
            displayPanel.Size = new Size(894, 634);
            displayPanel.TabIndex = 5;
            // 
            // comboBoxScale
            // 
            comboBoxScale.FormattingEnabled = true;
            comboBoxScale.Items.AddRange(new object[] { "100%", "200%", "300%", "400%" });
            comboBoxScale.Location = new Point(450, 95);
            comboBoxScale.Name = "comboBoxScale";
            comboBoxScale.Size = new Size(151, 28);
            comboBoxScale.TabIndex = 6;
            comboBoxScale.SelectedIndexChanged += ComboBoxScale_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(336, 98);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 7;
            label1.Text = "Display Scale";
            // 
            // textBoxInfo
            // 
            textBoxInfo.BackColor = SystemColors.Control;
            textBoxInfo.Location = new Point(36, 141);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.ReadOnly = true;
            textBoxInfo.Size = new Size(256, 190);
            textBoxInfo.TabIndex = 8;
            // 
            // checkBoxMultiSelect
            // 
            checkBoxMultiSelect.AutoSize = true;
            checkBoxMultiSelect.Location = new Point(36, 377);
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
            listBoxDelts.Location = new Point(36, 410);
            listBoxDelts.Name = "listBoxDelts";
            listBoxDelts.Size = new Size(243, 364);
            listBoxDelts.TabIndex = 11;
            listBoxDelts.Visible = false;
            listBoxDelts.SelectedIndexChanged += ListBoxDelts_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 103);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 12;
            label2.Text = "Resource Info";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 21);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 13;
            label3.Text = "Current PLTT";
            // 
            // labelPltt
            // 
            labelPltt.AutoSize = true;
            labelPltt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPltt.Location = new Point(36, 52);
            labelPltt.Name = "labelPltt";
            labelPltt.Size = new Size(73, 20);
            labelPltt.TabIndex = 14;
            labelPltt.Text = "BRF-JAN";
            // 
            // lfdPanel
            // 
            lfdPanel.BorderStyle = BorderStyle.FixedSingle;
            lfdPanel.Controls.Add(btnOpenResource);
            lfdPanel.Controls.Add(listBoxLfdContents);
            lfdPanel.Controls.Add(labelLfd);
            lfdPanel.Controls.Add(label4);
            lfdPanel.Dock = DockStyle.Left;
            lfdPanel.Location = new Point(0, 45);
            lfdPanel.Name = "lfdPanel";
            lfdPanel.Size = new Size(363, 808);
            lfdPanel.TabIndex = 16;
            lfdPanel.Visible = false;
            // 
            // btnOpenResource
            // 
            btnOpenResource.Enabled = false;
            btnOpenResource.Location = new Point(98, 710);
            btnOpenResource.Name = "btnOpenResource";
            btnOpenResource.Size = new Size(146, 63);
            btnOpenResource.TabIndex = 3;
            btnOpenResource.Text = "Open Selected Resource";
            btnOpenResource.UseVisualStyleBackColor = true;
            btnOpenResource.Click += BtnOpenResource_Click;
            // 
            // listBoxLfdContents
            // 
            listBoxLfdContents.FormattingEnabled = true;
            listBoxLfdContents.Location = new Point(24, 98);
            listBoxLfdContents.Name = "listBoxLfdContents";
            listBoxLfdContents.Size = new Size(305, 584);
            listBoxLfdContents.TabIndex = 2;
            listBoxLfdContents.SelectedIndexChanged += ListBoxLfdContents_SelectedIndexChanged;
            // 
            // labelLfd
            // 
            labelLfd.AutoSize = true;
            labelLfd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLfd.Location = new Point(24, 52);
            labelLfd.Name = "labelLfd";
            labelLfd.Size = new Size(79, 20);
            labelLfd.TabIndex = 1;
            labelLfd.Text = "LFD name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 21);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 0;
            label4.Text = "LFD";
            // 
            // mainPanel
            // 
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(label6);
            mainPanel.Controls.Add(comboBoxDisplayBackground);
            mainPanel.Controls.Add(label5);
            mainPanel.Controls.Add(labelResourceName);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(labelPltt);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(listBoxDelts);
            mainPanel.Controls.Add(displayPanel);
            mainPanel.Controls.Add(checkBoxMultiSelect);
            mainPanel.Controls.Add(comboBoxScale);
            mainPanel.Controls.Add(textBoxInfo);
            mainPanel.Controls.Add(label1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(363, 45);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1259, 808);
            mainPanel.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(647, 98);
            label6.Name = "label6";
            label6.Size = new Size(141, 20);
            label6.TabIndex = 18;
            label6.Text = "Display background";
            // 
            // comboBoxDisplayBackground
            // 
            comboBoxDisplayBackground.FormattingEnabled = true;
            comboBoxDisplayBackground.Items.AddRange(new object[] { "Black", "White", "Grey" });
            comboBoxDisplayBackground.Location = new Point(805, 95);
            comboBoxDisplayBackground.Name = "comboBoxDisplayBackground";
            comboBoxDisplayBackground.Size = new Size(151, 28);
            comboBoxDisplayBackground.TabIndex = 17;
            comboBoxDisplayBackground.SelectedIndexChanged += ComboBoxDisplayBackground_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(336, 21);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 15;
            label5.Text = "Current Resource";
            // 
            // labelResourceName
            // 
            labelResourceName.AutoSize = true;
            labelResourceName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelResourceName.Location = new Point(336, 52);
            labelResourceName.Name = "labelResourceName";
            labelResourceName.Size = new Size(29, 20);
            labelResourceName.TabIndex = 16;
            labelResourceName.Text = "Nil";
            // 
            // openLfdDialog
            // 
            openLfdDialog.Filter = "LFD file|*.lfd";
            openLfdDialog.Title = "Open LFD";
            // 
            // toolStrip
            // 
            toolStrip.AutoSize = false;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButtonOpenLFD, toolStripSeparator1, toolStripDropDownButtonOpenFile, toolStripSeparator2, toolStripButtonExport });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1622, 45);
            toolStrip.TabIndex = 16;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonOpenLFD
            // 
            toolStripButtonOpenLFD.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonOpenLFD.ImageTransparentColor = Color.Magenta;
            toolStripButtonOpenLFD.Name = "toolStripButtonOpenLFD";
            toolStripButtonOpenLFD.Size = new Size(78, 42);
            toolStripButtonOpenLFD.Text = "Open LFD";
            toolStripButtonOpenLFD.Click += ToolStripButtonOpenLFD_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 45);
            // 
            // toolStripDropDownButtonOpenFile
            // 
            toolStripDropDownButtonOpenFile.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButtonOpenFile.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemOpenPltt, toolStripMenuItemOpenDelt, toolStripMenuItemOpenAnim });
            toolStripDropDownButtonOpenFile.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonOpenFile.Name = "toolStripDropDownButtonOpenFile";
            toolStripDropDownButtonOpenFile.Size = new Size(86, 42);
            toolStripDropDownButtonOpenFile.Text = "Open File";
            // 
            // toolStripMenuItemOpenPltt
            // 
            toolStripMenuItemOpenPltt.Name = "toolStripMenuItemOpenPltt";
            toolStripMenuItemOpenPltt.Size = new Size(195, 26);
            toolStripMenuItemOpenPltt.Text = "Open PLTT file";
            toolStripMenuItemOpenPltt.Click += ToolStripMenuItemOpenPltt_Click;
            // 
            // toolStripMenuItemOpenDelt
            // 
            toolStripMenuItemOpenDelt.Name = "toolStripMenuItemOpenDelt";
            toolStripMenuItemOpenDelt.Size = new Size(195, 26);
            toolStripMenuItemOpenDelt.Text = "Open DELT file";
            toolStripMenuItemOpenDelt.Click += ToolStripMenuItemOpenDelt_Click;
            // 
            // toolStripMenuItemOpenAnim
            // 
            toolStripMenuItemOpenAnim.Name = "toolStripMenuItemOpenAnim";
            toolStripMenuItemOpenAnim.Size = new Size(195, 26);
            toolStripMenuItemOpenAnim.Text = "Open ANIM file";
            toolStripMenuItemOpenAnim.Click += ToolStripMenuItemOpenAnim_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 45);
            // 
            // toolStripButtonExport
            // 
            toolStripButtonExport.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonExport.ImageTransparentColor = Color.Magenta;
            toolStripButtonExport.Name = "toolStripButtonExport";
            toolStripButtonExport.Size = new Size(120, 42);
            toolStripButtonExport.Text = "Export Resource";
            toolStripButtonExport.Click += ToolStripButtonExport_Click;
            // 
            // savePngDialog
            // 
            savePngDialog.DefaultExt = "PNG";
            savePngDialog.Filter = "PNG images|*.png";
            savePngDialog.Title = "Export Resource";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1622, 853);
            Controls.Add(mainPanel);
            Controls.Add(lfdPanel);
            Controls.Add(toolStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1500, 900);
            Name = "MainWindow";
            Text = "LFD Tools version 0.9";
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            displayPanel.ResumeLayout(false);
            lfdPanel.ResumeLayout(false);
            lfdPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openPlttDialog;
        private OpenFileDialog openDeltDialog;
        private PictureBox displayBox;
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
        private OpenFileDialog openLfdDialog;
        private Label labelLfd;
        private Label label4;
        private ListBox listBoxLfdContents;
        private Button btnOpenResource;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripButtonOpenLFD;
        private ToolStripDropDownButton toolStripDropDownButtonOpenFile;
        private ToolStripMenuItem toolStripMenuItemOpenPltt;
        private ToolStripMenuItem toolStripMenuItemOpenDelt;
        private ToolStripMenuItem toolStripMenuItemOpenAnim;
        private ToolStripSeparator toolStripSeparator1;
        private Label label5;
        private Label labelResourceName;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButtonExport;
        private SaveFileDialog savePngDialog;
        private Label label6;
        private ComboBox comboBoxDisplayBackground;
    }
}
