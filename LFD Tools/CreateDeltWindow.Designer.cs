namespace LFD_Tools
{
    partial class CreateDeltWindow
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDeltWindow));
            groupBox1 = new GroupBox();
            btnLoadPltt = new Button();
            labelPlttName = new Label();
            openPlttDialog = new OpenFileDialog();
            openImageDialog = new OpenFileDialog();
            btnLoadSourceImg = new Button();
            pictureBoxSourceImage = new PictureBox();
            labelSourceImage = new Label();
            groupBox2 = new GroupBox();
            numericOffsetY = new NumericUpDown();
            numericOffsetX = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            radioBtnOffsetManual = new RadioButton();
            radioBtnOffsetAuto = new RadioButton();
            toolTip = new ToolTip(components);
            labelSourceImageSize = new Label();
            panel1 = new Panel();
            btnCreateDelt = new Button();
            saveDeltDialog = new SaveFileDialog();
            btnCreateEmptyDelt = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSourceImage).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericOffsetY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericOffsetX).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLoadPltt);
            groupBox1.Controls.Add(labelPlttName);
            groupBox1.Location = new Point(23, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 89);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "PLTT";
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
            // openImageDialog
            // 
            openImageDialog.Filter = "Image files|*.PNG;*.JPG;*.BMP";
            openImageDialog.Title = "Load Source Image";
            // 
            // btnLoadSourceImg
            // 
            btnLoadSourceImg.Location = new Point(23, 147);
            btnLoadSourceImg.Name = "btnLoadSourceImg";
            btnLoadSourceImg.Size = new Size(165, 36);
            btnLoadSourceImg.TabIndex = 1;
            btnLoadSourceImg.Text = "Load Source Image";
            btnLoadSourceImg.UseVisualStyleBackColor = true;
            btnLoadSourceImg.Click += BtnLoadSourceImg_Click;
            // 
            // pictureBoxSourceImage
            // 
            pictureBoxSourceImage.Location = new Point(0, 0);
            pictureBoxSourceImage.Name = "pictureBoxSourceImage";
            pictureBoxSourceImage.Size = new Size(100, 100);
            pictureBoxSourceImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSourceImage.TabIndex = 2;
            pictureBoxSourceImage.TabStop = false;
            // 
            // labelSourceImage
            // 
            labelSourceImage.AutoSize = true;
            labelSourceImage.Location = new Point(210, 147);
            labelSourceImage.Name = "labelSourceImage";
            labelSourceImage.Size = new Size(51, 20);
            labelSourceImage.TabIndex = 3;
            labelSourceImage.Text = "Empty";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericOffsetY);
            groupBox2.Controls.Add(numericOffsetX);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(radioBtnOffsetManual);
            groupBox2.Controls.Add(radioBtnOffsetAuto);
            groupBox2.Location = new Point(863, 147);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(283, 266);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Offset Options";
            // 
            // numericOffsetY
            // 
            numericOffsetY.Enabled = false;
            numericOffsetY.Location = new Point(117, 198);
            numericOffsetY.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericOffsetY.Name = "numericOffsetY";
            numericOffsetY.Size = new Size(127, 27);
            numericOffsetY.TabIndex = 5;
            // 
            // numericOffsetX
            // 
            numericOffsetX.Enabled = false;
            numericOffsetX.Location = new Point(117, 137);
            numericOffsetX.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericOffsetX.Name = "numericOffsetX";
            numericOffsetX.Size = new Size(127, 27);
            numericOffsetX.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 200);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 3;
            label2.Text = "Offset Y";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 139);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 2;
            label1.Text = "Offset X";
            // 
            // radioBtnOffsetManual
            // 
            radioBtnOffsetManual.AutoSize = true;
            radioBtnOffsetManual.Location = new Point(25, 75);
            radioBtnOffsetManual.Name = "radioBtnOffsetManual";
            radioBtnOffsetManual.Size = new Size(115, 24);
            radioBtnOffsetManual.TabIndex = 1;
            radioBtnOffsetManual.Text = "Set Manually";
            toolTip.SetToolTip(radioBtnOffsetManual, "Set offsets manually. Note: your DELT image will be shifted by OffsetX pixels to the right, and OffsetY pixels down.");
            radioBtnOffsetManual.UseVisualStyleBackColor = true;
            radioBtnOffsetManual.CheckedChanged += RadioBtnOffsetManual_CheckedChanged;
            // 
            // radioBtnOffsetAuto
            // 
            radioBtnOffsetAuto.AutoSize = true;
            radioBtnOffsetAuto.Checked = true;
            radioBtnOffsetAuto.Location = new Point(25, 38);
            radioBtnOffsetAuto.Name = "radioBtnOffsetAuto";
            radioBtnOffsetAuto.Size = new Size(147, 24);
            radioBtnOffsetAuto.TabIndex = 0;
            radioBtnOffsetAuto.TabStop = true;
            radioBtnOffsetAuto.Text = "Set Automatically";
            toolTip.SetToolTip(radioBtnOffsetAuto, "Offsets will be set based on the location of the first non-transparent pixel.");
            radioBtnOffsetAuto.UseVisualStyleBackColor = true;
            radioBtnOffsetAuto.CheckedChanged += RadioBtnOffsetAuto_CheckedChanged;
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 30000;
            toolTip.InitialDelay = 100;
            toolTip.ReshowDelay = 100;
            // 
            // labelSourceImageSize
            // 
            labelSourceImageSize.AutoSize = true;
            labelSourceImageSize.Location = new Point(210, 175);
            labelSourceImageSize.Name = "labelSourceImageSize";
            labelSourceImageSize.Size = new Size(15, 20);
            labelSourceImageSize.TabIndex = 5;
            labelSourceImageSize.Text = "-";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBoxSourceImage);
            panel1.Location = new Point(23, 222);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 703);
            panel1.TabIndex = 6;
            // 
            // btnCreateDelt
            // 
            btnCreateDelt.Location = new Point(956, 460);
            btnCreateDelt.Name = "btnCreateDelt";
            btnCreateDelt.Size = new Size(107, 62);
            btnCreateDelt.TabIndex = 7;
            btnCreateDelt.Text = "Create DELT";
            btnCreateDelt.UseVisualStyleBackColor = true;
            btnCreateDelt.Click += BtnCreateDelt_Click;
            // 
            // saveDeltDialog
            // 
            saveDeltDialog.Filter = "DELT resource|*.delt;*.dlt";
            saveDeltDialog.Title = "Create DELT";
            // 
            // btnCreateEmptyDelt
            // 
            btnCreateEmptyDelt.Location = new Point(956, 558);
            btnCreateEmptyDelt.Name = "btnCreateEmptyDelt";
            btnCreateEmptyDelt.Size = new Size(107, 62);
            btnCreateEmptyDelt.TabIndex = 8;
            btnCreateEmptyDelt.Text = "Create empty DELT";
            btnCreateEmptyDelt.UseVisualStyleBackColor = true;
            btnCreateEmptyDelt.Click += BtnCreateEmptyDelt_Click;
            // 
            // CreateDeltWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 953);
            Controls.Add(btnCreateEmptyDelt);
            Controls.Add(btnCreateDelt);
            Controls.Add(panel1);
            Controls.Add(labelSourceImageSize);
            Controls.Add(groupBox2);
            Controls.Add(labelSourceImage);
            Controls.Add(btnLoadSourceImg);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1200, 1000);
            Name = "CreateDeltWindow";
            Text = "Create DELT";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSourceImage).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericOffsetY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericOffsetX).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelPlttName;
        private Button btnLoadPltt;
        private OpenFileDialog openPlttDialog;
        private OpenFileDialog openImageDialog;
        private Button btnLoadSourceImg;
        private PictureBox pictureBoxSourceImage;
        private Label labelSourceImage;
        private GroupBox groupBox2;
        private RadioButton radioBtnOffsetManual;
        private RadioButton radioBtnOffsetAuto;
        private ToolTip toolTip;
        private NumericUpDown numericOffsetY;
        private NumericUpDown numericOffsetX;
        private Label label2;
        private Label label1;
        private Label labelSourceImageSize;
        private Panel panel1;
        private Button btnCreateDelt;
        private SaveFileDialog saveDeltDialog;
        private Button btnCreateEmptyDelt;
    }
}