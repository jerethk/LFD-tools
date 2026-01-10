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
            comboBox1 = new ComboBox();
            label1 = new Label();
            spinner = new NumericUpDown();
            textBoxInfo = new TextBox();
            ListBoxSelectedImages = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            displayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spinner).BeginInit();
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
            // DisplayBox
            // 
            displayBox.BackColor = SystemColors.Control;
            displayBox.Location = new Point(0, 0);
            displayBox.Name = "DisplayBox";
            displayBox.Size = new Size(640, 600);
            displayBox.TabIndex = 2;
            displayBox.TabStop = false;
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
            // DisplayPanel
            // 
            displayPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            displayPanel.BorderStyle = BorderStyle.FixedSingle;
            displayPanel.Controls.Add(displayBox);
            displayPanel.Location = new Point(337, 205);
            displayPanel.Name = "DisplayPanel";
            displayPanel.Size = new Size(1169, 616);
            displayPanel.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "100%", "200%", "300%", "400%" });
            comboBox1.Location = new Point(338, 152);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 6;
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
            // spinner
            // 
            spinner.Location = new Point(882, 48);
            spinner.Name = "spinner";
            spinner.Size = new Size(150, 27);
            spinner.TabIndex = 4;
            spinner.ValueChanged += spinner_ValueChanged;
            // 
            // TextBoxInfo
            // 
            textBoxInfo.BackColor = SystemColors.Control;
            textBoxInfo.Location = new Point(38, 152);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "TextBoxInfo";
            textBoxInfo.Size = new Size(256, 226);
            textBoxInfo.TabIndex = 8;
            // 
            // ListBoxSelectedImages
            // 
            ListBoxSelectedImages.FormattingEnabled = true;
            ListBoxSelectedImages.Location = new Point(38, 424);
            ListBoxSelectedImages.Name = "ListBoxSelectedImages";
            ListBoxSelectedImages.Size = new Size(256, 246);
            ListBoxSelectedImages.TabIndex = 9;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1542, 853);
            Controls.Add(ListBoxSelectedImages);
            Controls.Add(textBoxInfo);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(displayPanel);
            Controls.Add(spinner);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainWindow";
            Text = "Main Window";
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            displayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spinner).EndInit();
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
        private ComboBox comboBox1;
        private Label label1;
        private NumericUpDown spinner;
        private TextBox textBoxInfo;
        private CheckedListBox ListBoxSelectedImages;
    }
}
