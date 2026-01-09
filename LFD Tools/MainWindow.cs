using LFD_Tools.DFTypes;

namespace LFD_Tools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.palette = new();
        }

        private Pltt palette;
        private Anim? anim;
        private Bitmap[]? bitmaps;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadPalette();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Delt delt = new Delt();
                this.LoadDelt(delt);

                var bitmap = delt.CreateBitmap(this.palette);
                this.DisplayBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.anim = new();
                this.LoadAnim(this.anim);

                if (this.anim.NumDelts > 0)
                {
                    this.bitmaps = new Bitmap[this.anim.NumDelts];
                    for (var d = 0; d < this.anim.NumDelts; d++)
                    {
                        if (this.anim.Delts?[d] == null) { continue; }
                        this.bitmaps[d] = this.anim.Delts[d].Delt.CreateBitmap(this.palette);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPalette()
        {
            var dlgResult = this.openPlttDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                this.palette.LoadFromFile(this.openPlttDialog.FileName);
            }
        }

        private void LoadDelt(Delt delt)
        {
            var dlgResult = this.openDeltDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                delt.LoadFromFile(this.openDeltDialog.FileName);
            }
        }

        private void LoadAnim(Anim anim)
        {
            var dlgResult = this.openAnimDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                anim.LoadFromFile(this.openAnimDialog.FileName);
            }
        }

        private void spinner_ValueChanged(object sender, EventArgs e)
        {
            if (this.anim == null || this.anim.NumDelts == 0)
            { 
                return;
            }

            var index = (int)this.spinner.Value;
            if (index < this.anim.NumDelts)
            {
                if (this.bitmaps == null || this.bitmaps[index] == null)
                {
                    return;
                }
                this.DisplayBox.Image = this.bitmaps[index];
            }
        }
    }
}
