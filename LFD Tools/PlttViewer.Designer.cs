namespace LFD_Tools
{
    partial class PlttViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlttViewer));
            plttDisplay = new PictureBox();
            labelColour = new Label();
            ((System.ComponentModel.ISupportInitialize)plttDisplay).BeginInit();
            SuspendLayout();
            // 
            // plttDisplay
            // 
            plttDisplay.Location = new Point(38, 41);
            plttDisplay.Name = "plttDisplay";
            plttDisplay.Size = new Size(700, 700);
            plttDisplay.TabIndex = 0;
            plttDisplay.TabStop = false;
            plttDisplay.Paint += plttDisplay_Paint;
            plttDisplay.MouseMove += plttDisplay_MouseMove;
            // 
            // labelColour
            // 
            labelColour.AutoSize = true;
            labelColour.Location = new Point(38, 765);
            labelColour.Name = "labelColour";
            labelColour.Size = new Size(45, 20);
            labelColour.TabIndex = 1;
            labelColour.Text = "R G B";
            // 
            // PlttViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 813);
            Controls.Add(labelColour);
            Controls.Add(plttDisplay);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(800, 860);
            MinimumSize = new Size(800, 860);
            Name = "PlttViewer";
            Text = "PlttViewer";
            FormClosing += PlttViewer_FormClosing;
            ((System.ComponentModel.ISupportInitialize)plttDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox plttDisplay;
        private Label labelColour;
    }
}