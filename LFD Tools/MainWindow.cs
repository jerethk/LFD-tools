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
            this.checkBoxMultiSelect.Visible = false;
            this.listBoxDelts.Visible = false;
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

            if (anim.Delts.Count == 0)
            {
                throw new Exception("ANIM does not contains any DELTs!");
            }

            if (anim.Delts.Count != anim.NumDelts)
            {
                throw new Exception("Error loading ANIM: incorrect number of DELTs");
            }

            this.anim = anim;
            this.currentMode = Mode.ANIM;
            this.bitmaps.Clear();

            var infoLines = new string[2];
            infoLines[0] = $"ANIM: {anim.Name}";
            infoLines[1] = $"Contains {anim.NumDelts} DELTs";
            this.textBoxInfo.Lines = infoLines;

            this.checkBoxMultiSelect.Visible = true;
            this.listBoxDelts.Visible = true;
            this.listBoxDelts.Items.Clear();
            for (var d = 0; d < this.anim.NumDelts; d++)
            {
                this.listBoxDelts.Items.Add($"DELT {d}");
            }

            for (var d = 0; d < this.anim.NumDelts; d++)
            {
                var bitmap = this.anim.Delts[d].Delt.CreateBitmap(this.palette);
                this.bitmaps.Add(bitmap!);
            }

            this.checkBoxMultiSelect.Checked = false;
            this.listBoxDelts.SelectedIndex = 0;
            this.SetupDisplay();
        }

        private void SetupDisplay()
        {
            if (this.bitmaps.Count == 0)
            {
                return;
            }

            this.SetDisplayBoxSizeToFirstBitmap();

            using (var graphics = this.displayBox.CreateGraphics())
            {
                if (this.currentMode == Mode.DELT)
                {
                    this.DrawDeltImage(graphics);
                }
                if (this.currentMode == Mode.ANIM)
                {
                    this.DrawAnimImage(graphics);
                }
            }
        }

        private void SetDisplayBoxSizeToFirstBitmap()
        {
            if (this.bitmaps[0] != null)
            {
                this.displayBox.Width = (int)(this.bitmaps[0].Width * this.scaleFactor);
                this.displayBox.Height = (int)(this.bitmaps[0].Height * this.scaleFactor);
            }
            else
            {
                this.displayBox.Width = 320;
                this.displayBox.Height = 200;
            }
        }

        private void CheckBoxMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            this.listBoxDelts.SelectionMode = this.checkBoxMultiSelect.Checked
                ? SelectionMode.MultiSimple
                : SelectionMode.One;

            if (checkBoxMultiSelect.Checked)
            {
                var validBitmaps = this.bitmaps.Where(b => b != null);
                this.displayBox.Width = (int)(validBitmaps.Max(b => b.Width) * this.scaleFactor);
                this.displayBox.Height = (int)(validBitmaps.Max(b => b.Height) * this.scaleFactor);
            }
            else
            {
                this.listBoxDelts.SelectedIndex = 0;
                this.SetDisplayBoxSizeToFirstBitmap();
            }

            using (var graphics = this.displayBox.CreateGraphics())
            {
                this.DrawAnimImage(graphics);
            }
        }

        private void ListBoxDelts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBoxMultiSelect.Checked)
            {
                var index = this.listBoxDelts.SelectedIndex;

                if (this.anim == null || this.bitmaps.Count <= index)
                {
                    return;
                }

                if (index < 0 || index >= this.anim.NumDelts)
                {
                    return;
                }

                if (this.bitmaps[index] == null)
                {
                    this.displayBox.Width = 320;
                    this.displayBox.Height = 200;
                }
                else
                {
                    this.displayBox.Width = (int)(this.bitmaps[index].Width * this.scaleFactor);
                    this.displayBox.Height = (int)(this.bitmaps[index].Height * this.scaleFactor);

                }
            }

            using (var graphics = this.displayBox.CreateGraphics())
            {
                this.DrawAnimImage(graphics);
            }
        }

        private void DisplayBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.currentMode == Mode.NIL)
            {
                return;
            }

            if (this.currentMode == Mode.DELT)
            {
                this.DrawDeltImage(e.Graphics);
                return;
            }

            if (this.currentMode == Mode.ANIM)
            {
                this.DrawAnimImage(e.Graphics);
                return;
            }
        }

        private void DrawDeltImage(Graphics graphics)
        {
            if (this.delt == null || this.bitmaps.Count == 0)
            {
                return;
            }

            graphics.Clear(Color.Black);
            graphics.DrawImage(
                this.bitmaps[0],
                0,
                0,
                this.bitmaps[0].Width * this.scaleFactor,
                this.bitmaps[0].Height * this.scaleFactor);
        }

        private void DrawAnimImage(Graphics graphics)
        {
            if (this.anim == null || this.anim.NumDelts == 0 || this.bitmaps.Count == 0)
            {
                return;
            }

            graphics.Clear(Color.Black);

            if (this.checkBoxMultiSelect.Checked)
            {
                // Multi selection
                var selectedDelts = this.listBoxDelts.SelectedIndices;
                foreach (var selectedDelt in selectedDelts)
                {
                    var index = (int)selectedDelt;
                    if (index >= this.anim.NumDelts)
                    {
                        continue;
                    }
                    if (this.bitmaps[index] == null)
                    {
                        continue;
                    }

                    graphics.DrawImage(
                        this.bitmaps[index],
                        0,
                        0,
                        this.bitmaps[index].Width * this.scaleFactor,
                        this.bitmaps[index].Height * this.scaleFactor);
                }
            }
            else
            {
                // Single selection
                var index = this.listBoxDelts.SelectedIndex;
                if (index < 0 || index >= this.anim.NumDelts)
                {
                    return;
                }

                if (this.bitmaps[index] == null)
                {
                    graphics.Clear(SystemColors.Control);
                    graphics.DrawString("** EMPTY **", Control.DefaultFont, new SolidBrush(Color.Black), new PointF(10, 10));
                    return;
                }

                graphics.DrawImage(
                    this.bitmaps[index],
                    0,
                    0,
                    this.bitmaps[index].Width * this.scaleFactor,
                    this.bitmaps[index].Height * this.scaleFactor);
            }
        }
    }
}
