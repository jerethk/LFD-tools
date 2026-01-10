using LFD_Tools.DFTypes;
using System.Drawing;
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

            this.bitmaps = new();
            this.currentMode = Mode.NIL;
        }

        private Mode currentMode;

        private Pltt palette;
        private Pltt brfJanPltt;
        private Delt? delt;
        private Anim? anim;

        private List<Bitmap> bitmaps;
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
            // Load PLTT
            try
            {
                var dlgResult = this.openPlttDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    this.palette.LoadFromFile(this.openPlttDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading PLTT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Load DELT
            try
            {
                var dlgResult = this.openDeltDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    this.LoadDelt(this.openDeltDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading DELT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Load ANIM
            try
            {
                var dlgResult = this.openAnimDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    this.LoadAnim(this.openAnimDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDelt(string filename)
        {
            var delt = new Delt();
            delt.LoadFromFile(filename);

            this.delt = delt;
            this.currentMode = Mode.DELT;
            this.bitmaps.Clear();

            var infoLines = new string[5];
            infoLines[0] = $"DELT: {delt.Name}";
            infoLines[1] = $"SizeX: {delt.SizeX}";
            infoLines[2] = $"SizeY: {delt.SizeY}";
            infoLines[3] = $"OffsetX: {delt.OffsetX}";
            infoLines[4] = $"OffsetY: {delt.OffsetY}";
            this.textBoxInfo.Lines = infoLines;

            var bitmap = delt.CreateBitmap(this.palette);
            if (bitmap == null)
            {
                throw new Exception("Error creating bitmap");
            }

            this.bitmaps.Add(bitmap);
            this.SetupDisplay();
        }

        private void LoadAnim(string filename)
        {
            var anim = new Anim();
            anim.LoadFromFile(filename);

            if (anim.Delts.Count != anim.NumDelts)
            {
                throw new Exception("Error loading ANIM: incorrect number of DELTs");
            }

            this.anim = anim;
            this.currentMode = Mode.ANIM;
            this.bitmaps.Clear();

            var infoLines = new string[1];
            infoLines[0] = $"ANIM: {anim.Name}";
            this.textBoxInfo.Lines = infoLines;

            if (this.anim.NumDelts > 0)
            {
                for (var d = 0; d < this.anim.NumDelts; d++)
                {
                    var bitmap = this.anim.Delts[d].Delt.CreateBitmap(this.palette);
                    if (bitmap == null)
                    {
                        throw new Exception("Error creating bitmap");
                    }
                    this.bitmaps.Add(bitmap);
                }
            }

            this.SetupDisplay();
        }

        private void SetupDisplay()
        {
            if (this.bitmaps.Count == 0)
            {
                return;
            }

            if (this.currentMode == Mode.DELT)
            {
                this.displayBox.Width = (int)(this.bitmaps[0].Width * this.scaleFactor);
                this.displayBox.Height = (int)(this.bitmaps[0].Height * this.scaleFactor);
            }

            if (this.currentMode == Mode.ANIM)
            {
                this.displayBox.Width = (int)(this.bitmaps.Max(b => b.Width) * this.scaleFactor);
                this.displayBox.Height = (int)(this.bitmaps.Max(b => b.Height) * this.scaleFactor);
            }
        }

        private void spinner_ValueChanged(object sender, EventArgs e)
        {

        }

        private void displayBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.currentMode == Mode.NIL)
            {
                return;
            }

            if (this.currentMode == Mode.DELT)
            {
                if (this.delt == null || this.bitmaps.Count == 0)
                {
                    return;
                }

                e.Graphics.Clear(Color.Black);
                e.Graphics.DrawImage(
                    this.bitmaps[0],
                    0,
                    0,
                    this.bitmaps[0].Width * this.scaleFactor,
                    this.bitmaps[0].Height * this.scaleFactor);
            }

            if (this.currentMode == Mode.ANIM)
            {
                if (this.anim == null || this.anim.NumDelts == 0 || this.bitmaps.Count == 0)
                {
                    return;
                }

                var index = (int)this.spinner.Value;
                if (index < this.anim.NumDelts)
                {
                    e.Graphics.Clear(Color.Black);
                    e.Graphics.DrawImage(
                        this.bitmaps[index],
                        0,
                        0,
                        this.bitmaps[index].Width * this.scaleFactor,
                        this.bitmaps[index].Height * this.scaleFactor);
                }
            }
        }
    }
}
