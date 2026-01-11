using LFD_Tools.DFTypes;
using System;
using System.Drawing;
using static LFD_Tools.Types.AppMode;

namespace LFD_Tools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            lfdPanel.Visible = false;
            this.comboBoxScale.SelectedIndex = 1;   // 200%

            this.brfJanPltt = new();
            this.LoadBrfJanPltt();
            this.palette = this.brfJanPltt;
            this.labelPltt.Text = "BRF-JAN";

            this.currentMode = Mode.NIL;
        }

        private Mode currentMode;

        private Pltt palette;
        private Pltt brfJanPltt;
        private Delt? delt;
        private Anim? anim;
        private Lfd? lfd;

        private Bitmap[]? bitmaps;
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
                    var pltt = new Pltt();
                    pltt.LoadFromFile(this.openPlttDialog.FileName);
                    this.palette = pltt;

                    this.SetupPltt();
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
                MessageBox.Show(ex.Message, "Error loading ANIM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Load LFD
            try
            {
                var dlgResult = this.openLfdDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    this.LoadLfd(this.openLfdDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading LFD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLfd(string filename)
        {
            var lfd = new Lfd();
            lfd.LoadFromFile(filename);
            this.lfd = lfd;

            lfdPanel.Visible = true;
            labelLfd.Text = Path.GetFileName(filename);
            listBoxLfdContents.Items.Clear();

            for (int i = 0; i < lfd.Resources.Count; i++)
            {
                listBoxLfdContents.Items.Add(lfd.Resources[i]);
                listBoxLfdContents.DisplayMember = nameof(LfdResource.Label);
            }
        }

        private void SetupPltt()
        {
            this.labelPltt.Text = this.palette.Name;

            // Regenerate bitmaps
            if (this.currentMode == Mode.DELT && this.delt != null && this.bitmaps?.Length > 0)
            {
                var bitmap = this.delt.CreateBitmap(this.palette);
                this.bitmaps[0] = bitmap!;
                this.RedrawDeltImage();
            }

            if (this.currentMode == Mode.ANIM && this.anim != null && this.bitmaps?.Length > 0)
            {
                this.GenerateAnimBitmaps();
                this.RedrawAnimImage();
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

            var infoLines = new string[5];
            infoLines[0] = $"DELT {delt.Name}";
            infoLines[1] = $"Width: {delt.SizeX}";
            infoLines[2] = $"Height: {delt.SizeY}";
            infoLines[3] = $"OffsetX: {delt.OffsetX}";
            infoLines[4] = $"OffsetY: {delt.OffsetY}";
            this.textBoxInfo.Lines = infoLines;

            this.bitmaps = new Bitmap[1];
            var bitmap = delt.CreateBitmap(this.palette);
            this.bitmaps[0] = bitmap!;

            this.SetDisplayBoxToBitmapSize(0);
            this.RedrawDeltImage();
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
            this.checkBoxMultiSelect.Visible = true;
            this.listBoxDelts.Visible = true;

            var infoLines = new string[8];
            infoLines[0] = $"ANIM {anim.Name}";
            infoLines[1] = $"Contains {anim.NumDelts} DELTs";
            infoLines[2] = string.Empty;
            this.textBoxInfo.Lines = infoLines;

            this.listBoxDelts.Items.Clear();
            for (var d = 0; d < this.anim.NumDelts; d++)
            {
                this.listBoxDelts.Items.Add($"DELT {d}");
            }

            this.bitmaps = new Bitmap[this.anim.NumDelts];
            this.GenerateAnimBitmaps();

            this.checkBoxMultiSelect.Checked = false;
            this.listBoxDelts.SelectedIndex = 0;

            this.SetDisplayBoxToBitmapSize(0);
            this.RedrawAnimImage();
        }

        private void GenerateAnimBitmaps()
        {
            for (var d = 0; d < this.anim!.NumDelts; d++)
            {
                var bitmap = this.anim.Delts[d].Delt.CreateBitmap(this.palette);
                this.bitmaps![d] = bitmap!;
            }
        }

        private void SetDisplayBoxToBitmapSize(int index)
        {
            if (this.bitmaps![index] == null)
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

        private void SetDisplayBoxToMaxBitmapSize()
        {
            var validBitmaps = this.bitmaps?.Where(b => b != null);
            this.displayBox.Width = (int)(validBitmaps?.Max(b => b.Width) * this.scaleFactor ?? 0);
            this.displayBox.Height = (int)(validBitmaps?.Max(b => b.Height) * this.scaleFactor ?? 0);
        }

        private void RedrawDeltImage()
        {
            using (var graphics = this.displayBox.CreateGraphics())
            {
                this.DrawDeltImage(graphics);
            }
        }

        private void RedrawAnimImage()
        {
            using (var graphics = this.displayBox.CreateGraphics())
            {
                this.DrawAnimImage(graphics);
            }
        }

        private void CheckBoxMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            this.listBoxDelts.SelectionMode = this.checkBoxMultiSelect.Checked
                ? SelectionMode.MultiSimple
                : SelectionMode.One;

            if (checkBoxMultiSelect.Checked)
            {
                this.SetDisplayBoxToMaxBitmapSize();

                // Don't show individual DELT info
                var infoLines = this.textBoxInfo.Lines;
                for (int i = 3; i < infoLines.Length; i++)
                {
                    infoLines[i] = string.Empty;
                }
                this.textBoxInfo.Lines = infoLines;
            }
            else
            {
                this.listBoxDelts.SelectedIndex = 0;
                this.SetDisplayBoxToBitmapSize(0);
            }

            this.RedrawAnimImage();
        }

        private void ListBoxDelts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBoxMultiSelect.Checked)
            {
                var index = this.listBoxDelts.SelectedIndex;

                if (this.anim == null)
                {
                    return;
                }

                if (index < 0 || index >= this.anim.NumDelts)
                {
                    return;
                }

                this.SetDisplayBoxToBitmapSize(index);

                // Single DELT info
                var infoLines = this.textBoxInfo.Lines;
                infoLines[3] = $"DELT {index}";
                infoLines[4] = $"Width: {anim.Delts[index].Delt.SizeX}";
                infoLines[5] = $"Height: {anim.Delts[index].Delt.SizeY}";
                infoLines[6] = $"OffsetX: {anim.Delts[index].Delt.OffsetX}";
                infoLines[7] = $"OffsetY: {anim.Delts[index].Delt.OffsetY}";
                this.textBoxInfo.Lines = infoLines;
            }

            this.RedrawAnimImage();
        }

        private void comboBoxScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxScale.SelectedIndex)
            {
                case 0:
                    this.scaleFactor = 1.0f;
                    break;
                case 1:
                    this.scaleFactor = 2.0f;
                    break;
                case 2:
                    this.scaleFactor = 3.0f;
                    break;
                case 3:
                    this.scaleFactor = 4.0f;
                    break;
                default:
                    this.scaleFactor = 2.0f;
                    break;
            }

            if (this.bitmaps == null || this.bitmaps.Length == 0)
            {
                return;
            }

            if (this.currentMode == Mode.DELT)
            {
                this.SetDisplayBoxToBitmapSize(0);
                this.RedrawDeltImage();
                return;
            }
            if (this.currentMode == Mode.ANIM)
            {
                if (this.checkBoxMultiSelect.Checked)
                {
                    this.SetDisplayBoxToMaxBitmapSize();
                }
                else
                {
                    var index = this.listBoxDelts.SelectedIndex;
                    this.SetDisplayBoxToBitmapSize(index);
                }

                this.RedrawAnimImage();
                return;
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
            if (this.delt == null || this.bitmaps == null || this.bitmaps.Length == 0)
            {
                return;
            }

            if (this.bitmaps[0] == null)
            {
                graphics.Clear(SystemColors.Control);
                graphics.DrawString("** EMPTY **", Control.DefaultFont, new SolidBrush(Color.Black), new PointF(10, 10));
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
            if (this.anim == null || this.anim.NumDelts == 0 || this.bitmaps == null || this.bitmaps.Length == 0)
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

        private void listBoxLfdContents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxLfdContents.SelectedIndex < 0)
            {
                return;
            }

            var selectedResource = this.listBoxLfdContents.SelectedItem as LfdResource;
            if (selectedResource == null)
            {
                return;
            }

            var type = selectedResource.ResourceType;
            if (type == ResourceType.PLTT || type == ResourceType.DELT || type == ResourceType.ANIM)
            {
                btnOpenResource.Enabled = true;
            }
            else
            {
                btnOpenResource.Enabled = false;
            }
        }

        private void btnOpenResource_Click(object sender, EventArgs e)
        {
            var selectedResource = this.listBoxLfdContents.SelectedItem as LfdResource;
            if (selectedResource == null)
            {
                return;
            }
            if (selectedResource.Data == null)
            {
                MessageBox.Show("Data for resource is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedResource.ResourceType == ResourceType.PLTT)
            {
                try
                {
                    var pltt = new Pltt();
                    pltt.LoadFromStream(new MemoryStream(selectedResource.Data));
                    pltt.Name = selectedResource.Name;
                    this.palette = pltt;

                    this.SetupPltt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading PLTT.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (selectedResource.ResourceType == ResourceType.DELT)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading DELT.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (selectedResource.ResourceType == ResourceType.ANIM)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading ANIM.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }
    }
}
