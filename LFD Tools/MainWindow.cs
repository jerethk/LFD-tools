using LFD_Tools.DFTypes;
using static LFD_Tools.Types.AppMode;

namespace LFD_Tools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            this.brfJanPltt = new();
            this.LoadBrfJanPltt();
            this.palette = this.brfJanPltt;

            this.display = this.displayBox.CreateGraphics();
            this.currentMode = Mode.NIL;
        }

        private Mode currentMode;

        private Pltt palette;
        private Pltt brfJanPltt;
        private Delt? delt;
        private Anim? anim;

        private Bitmap[]? bitmaps;
        private Graphics display;
        private float scaleFactor = 2.0f;

        private void LoadBrfJanPltt()
        {
            var data = Pltt.BrfJan.Split();
            for (int c = 0; c < 256; c++)
            {
                this.brfJanPltt.Colours[c].R = Convert.ToByte(data[c * 3]);
                this.brfJanPltt.Colours[c].G = Convert.ToByte(data[c * 3 + 1]);
                this.brfJanPltt.Colours[c].B = Convert.ToByte(data[c * 3 + 2]);
            }
        }

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
                this.display.Clear(Color.Black);
                this.display.DrawImage(
                    bitmap,
                    0,
                    0,
                    bitmap.Width * this.scaleFactor,
                    bitmap.Height * this.scaleFactor);
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
                this.display.Clear(Color.Black);
                this.display.DrawImage(
                    this.bitmaps[index],
                    0,
                    0,
                    this.bitmaps[index].Width * this.scaleFactor,
                    this.bitmaps[index].Height * this.scaleFactor);
            }
        }
    }
}
