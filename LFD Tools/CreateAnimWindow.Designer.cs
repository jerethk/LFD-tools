namespace LFD_Tools
{
    partial class CreateAnimWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAnimWindow));
            btnGetDelts = new Button();
            openDeltDialog = new OpenFileDialog();
            listBoxDelts = new ListBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            btnLoadPltt = new Button();
            labelPlttName = new Label();
            openPlttDialog = new OpenFileDialog();
            pictureBoxDeltPreview = new PictureBox();
            panel1 = new Panel();
            btnRemoveDelt = new Button();
            btnMoveUp = new Button();
            btnMoveDown = new Button();
            button1 = new Button();
            saveAnimDialog = new SaveFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDeltPreview).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGetDelts
            // 
            btnGetDelts.Location = new Point(29, 24);
            btnGetDelts.Name = "btnGetDelts";
            btnGetDelts.Size = new Size(105, 40);
            btnGetDelts.TabIndex = 0;
            btnGetDelts.Text = "Add DELTs";
            btnGetDelts.UseVisualStyleBackColor = true;
            btnGetDelts.Click += BtnGetDelts_Click;
            // 
            // openDeltDialog
            // 
            openDeltDialog.AddExtension = false;
            openDeltDialog.Filter = "DELT files|*.delt;*.dlt";
            openDeltDialog.Title = "Select Folder Containing DELTs";
            // 
            // listBoxDelts
            // 
            listBoxDelts.FormattingEnabled = true;
            listBoxDelts.Location = new Point(29, 91);
            listBoxDelts.Name = "listBoxDelts";
            listBoxDelts.Size = new Size(200, 664);
            listBoxDelts.TabIndex = 1;
            listBoxDelts.SelectedIndexChanged += ListBoxDelts_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnLoadPltt);
            groupBox1.Controls.Add(labelPlttName);
            groupBox1.Location = new Point(471, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 129);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "PLTT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 84);
            label1.Name = "label1";
            label1.Size = new Size(326, 20);
            label1.TabIndex = 2;
            label1.Text = "Note: the PLTT is only used for the DELT preview";
            // 
            // btnLoadPltt
            // 
            btnLoadPltt.Location = new Point(19, 33);
            btnLoadPltt.Name = "btnLoadPltt";
            btnLoadPltt.Size = new Size(94, 36);
            btnLoadPltt.TabIndex = 1;
            btnLoadPltt.Text = "Change";
            btnLoadPltt.UseVisualStyleBackColor = true;
            btnLoadPltt.Click += BtnLoadPltt_Click;
            // 
            // labelPlttName
            // 
            labelPlttName.AutoSize = true;
            labelPlttName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPlttName.Location = new Point(131, 41);
            labelPlttName.Name = "labelPlttName";
            labelPlttName.Size = new Size(76, 20);
            labelPlttName.TabIndex = 0;
            labelPlttName.Text = "PlttName";
            // 
            // openPlttDialog
            // 
            openPlttDialog.Filter = "PLTT resource|*.plt;*.pltt";
            openPlttDialog.Title = "Load PLTT";
            // 
            // pictureBoxDeltPreview
            // 
            pictureBoxDeltPreview.Location = new Point(0, 0);
            pictureBoxDeltPreview.Name = "pictureBoxDeltPreview";
            pictureBoxDeltPreview.Size = new Size(372, 356);
            pictureBoxDeltPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxDeltPreview.TabIndex = 3;
            pictureBoxDeltPreview.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBoxDeltPreview);
            panel1.Location = new Point(471, 188);
            panel1.Name = "panel1";
            panel1.Size = new Size(677, 642);
            panel1.TabIndex = 4;
            // 
            // btnRemoveDelt
            // 
            btnRemoveDelt.Location = new Point(259, 91);
            btnRemoveDelt.Name = "btnRemoveDelt";
            btnRemoveDelt.Size = new Size(125, 56);
            btnRemoveDelt.TabIndex = 5;
            btnRemoveDelt.Text = "Remove from list";
            btnRemoveDelt.UseVisualStyleBackColor = true;
            btnRemoveDelt.Click += BtnRemoveDelt_Click;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Location = new Point(259, 187);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(125, 49);
            btnMoveUp.TabIndex = 6;
            btnMoveUp.Text = "Move Up";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += BtnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Location = new Point(259, 266);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(125, 49);
            btnMoveDown.TabIndex = 7;
            btnMoveDown.Text = "Move Down";
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += BtnMoveDown_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(1011, 57);
            button1.Name = "button1";
            button1.Size = new Size(137, 56);
            button1.TabIndex = 8;
            button1.Text = "Create ANIM";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonCreateAnim_Click;
            // 
            // saveAnimDialog
            // 
            saveAnimDialog.Filter = "ANIM file|*.anim;*.anm";
            saveAnimDialog.Title = "Create ANIM";
            // 
            // CreateAnimWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 873);
            Controls.Add(button1);
            Controls.Add(btnMoveDown);
            Controls.Add(btnMoveUp);
            Controls.Add(btnRemoveDelt);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(listBoxDelts);
            Controls.Add(btnGetDelts);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1200, 920);
            Name = "CreateAnimWindow";
            Text = "Create ANIM";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDeltPreview).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnGetDelts;
        private OpenFileDialog openDeltDialog;
        private ListBox listBoxDelts;
        private GroupBox groupBox1;
        private Button btnLoadPltt;
        private Label labelPlttName;
        private OpenFileDialog openPlttDialog;
        private Label label1;
        private PictureBox pictureBoxDeltPreview;
        private Panel panel1;
        private Button btnRemoveDelt;
        private Button btnMoveUp;
        private Button btnMoveDown;
        private Button button1;
        private SaveFileDialog saveAnimDialog;
    }
}