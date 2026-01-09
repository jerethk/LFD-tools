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
            DisplayBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DisplayBox).BeginInit();
            SuspendLayout();
            // 
            // openPlttDialog
            // 
            openPlttDialog.Filter = "PLTT resource|*.plt;*.pltt";
            openPlttDialog.Title = "Open PLTT";
            // 
            // button1
            // 
            button1.Location = new Point(22, 23);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "openPlt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(152, 23);
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
            DisplayBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DisplayBox.BackColor = Color.Black;
            DisplayBox.BorderStyle = BorderStyle.FixedSingle;
            DisplayBox.Location = new Point(22, 84);
            DisplayBox.Name = "DisplayBox";
            DisplayBox.Size = new Size(1056, 563);
            DisplayBox.TabIndex = 2;
            DisplayBox.TabStop = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 681);
            Controls.Add(DisplayBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainWindow";
            Text = "Main Window";
            ((System.ComponentModel.ISupportInitialize)DisplayBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openPlttDialog;
        private Button button1;
        private Button button2;
        private OpenFileDialog openDeltDialog;
        private PictureBox DisplayBox;
    }
}
