using LFD_Tools.DFTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFD_Tools
{
    public partial class CreateDeltWindow : Form
    {
        public CreateDeltWindow()
        {
            InitializeComponent();

            this.pltt = Pltt.GetBrfJanPltt();
            this.labelPlttName.Text = this.pltt.Name;
        }

        private Pltt pltt;
        private Bitmap? sourceImage;
        private int autoOffsetX;
        private int autoOffsetY;

        private void BtnLoadPltt_Click(object sender, EventArgs e)
        {
            var dlgResult = this.openPlttDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                try
                {
                    var pltt = new Pltt();
                    pltt.LoadFromFile(this.openPlttDialog.FileName);
                    this.pltt = pltt;
                    this.labelPlttName.Text = this.pltt.Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load PLTT: {ex.Message}");
                }
            }
        }

        private void BtnLoadSourceImg_Click(object sender, EventArgs e)
        {
            var dlgResult = this.openImageDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                try
                {
                    using var img = Image.FromFile(this.openImageDialog.FileName);
                    this.sourceImage = new Bitmap(img);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                }

                this.DisplaySourceImage();
            }
        }

        private void DisplaySourceImage()
        {
            if (this.sourceImage == null)
            {
                return;
            }

            this.pictureBoxSourceImage.Image = this.sourceImage;
            this.pictureBoxSourceImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxSourceImage.BackColor = Color.LightGray;
            this.pictureBoxSourceImage.Width = this.sourceImage.Width * 2;
            this.pictureBoxSourceImage.Height = this.sourceImage.Height * 2;
            this.labelSourceImage.Text = Path.GetFileName(this.openImageDialog.FileName);
            this.labelSourceImageSize.Text = $"{this.sourceImage.Width} x {this.sourceImage.Height}";

            this.CalculateOffsets();
        }

        private void CalculateOffsets()
        {
            if (this.sourceImage == null)
            {
                return;
            }

            for (var y = 0; y < this.sourceImage.Height; y++)
            {
                for (var x = 0; x < this.sourceImage.Width; x++)
                {
                    var pixel = this.sourceImage.GetPixel(x, y);
                    if (pixel.A != 0)
                    {
                        this.autoOffsetX = x;
                        this.autoOffsetY = y;
                        
                        if (this.radioBtnOffsetAuto.Checked)
                        {
                            this.ShowAutoOffsets();
                        }
                        
                        return;
                    }
                }
            }

            this.autoOffsetX = 0;
            this.autoOffsetY = 0;
            this.ShowAutoOffsets();
        }

        private void RadioBtnOffsetAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioBtnOffsetAuto.Checked)
            {
                this.numericOffsetX.Enabled = false;
                this.numericOffsetY.Enabled = false;
            }

            this.ShowAutoOffsets();
        }

        private void RadioBtnOffsetManual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioBtnOffsetManual.Checked)
            {
                this.numericOffsetX.Enabled = true;
                this.numericOffsetY.Enabled = true;
            }
        }

        private void ShowAutoOffsets()
        {
            this.numericOffsetX.Value = this.autoOffsetX;
            this.numericOffsetY.Value = this.autoOffsetY;
        }
    }
}
