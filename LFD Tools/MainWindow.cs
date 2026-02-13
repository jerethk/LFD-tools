using LFD_Tools.DFTypes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using static LFD_Tools.Types.AppMode;
using static LFD_Tools.Types.Helpers;

namespace LFD_Tools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            lfdPanel.Visible = false;
            this.comboBoxScale.SelectedIndex = 1;   // 200%
            this.comboBoxDisplayBackground.SelectedIndex = 0; // Black
            this.toolStripButtonExport.Enabled = false;

            this.brfJanPltt = Pltt.GetBrfJanPltt();
            this.palette = this.brfJanPltt;
            this.labelPltt.Text = this.brfJanPltt.Name;

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
        private Color displayBackground = Color.Black;

        private string? resourcePath;
        private string? lfdPath;
        private string? exportPath;

        private PlttViewer plttViewer = new();

        private void ToolStripButtonOpenLFD_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.lfdPath))
                {
                    this.openLfdDialog.InitialDirectory = this.lfdPath;
                }

                var dlgResult = this.openLfdDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    this.LoadLfd(this.openLfdDialog.FileName);
                    this.lfdPath = Path.GetDirectoryName(this.openLfdDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading LFD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItemOpenPltt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.resourcePath))
                {
                    this.openPlttDialog.InitialDirectory = this.resourcePath;
                }

                var dlgResult = this.openPlttDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    var pltt = new Pltt();
                    pltt.LoadFromFile(this.openPlttDialog.FileName);
                    this.palette = pltt;

                    this.SetupPltt();
                    this.resourcePath = Path.GetDirectoryName(this.openPlttDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading PLTT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItemOpenDelt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.resourcePath))
                {
                    this.openDeltDialog.InitialDirectory = this.resourcePath;
                }

                var dlgResult = this.openDeltDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    var delt = new Delt();
                    delt.LoadFromFile(this.openDeltDialog.FileName);
                    this.delt = delt;

                    this.SetupDelt();
                    this.resourcePath = Path.GetDirectoryName(this.openDeltDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading DELT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItemOpenAnim_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.resourcePath))
                {
                    this.openAnimDialog.InitialDirectory = this.resourcePath;
                }

                var dlgResult = this.openAnimDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    var anim = new Anim();
                    anim.LoadFromFile(this.openAnimDialog.FileName);
                    this.anim = anim;

                    this.SetupAnim();
                    this.resourcePath = Path.GetDirectoryName(this.openAnimDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading ANIM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLfd(string filename)
        {
            var lfd = new Lfd();
            lfd.LoadFromFile(filename);
            this.lfd = lfd;

            lfdPanel.Visible = true;
            labelLfd.Text = Path.GetFileName(filename);
            listBoxLfdContents.DataSource = this.lfd.Resources;
            listBoxLfdContents.DisplayMember = nameof(LfdResource.Label);
        }

        private void SetupPltt()
        {
            this.labelPltt.Text = this.palette.Name;

            // Re-initialise the viewer
            this.plttViewer.Initialise(this.palette);

            // Regenerate bitmaps, then redraw
            if (this.currentMode == Mode.DELT && this.delt != null && this.bitmaps?.Length > 0)
            {
                var bitmap = this.delt.CreateBitmap(this.palette, this.checkBoxSubtractOffsets.Checked);
                this.bitmaps[0] = bitmap!;
                this.displayBox.Invalidate();
                return;
            }

            if (this.currentMode == Mode.ANIM && this.anim != null && this.bitmaps?.Length > 0)
            {
                this.GenerateAnimBitmaps();
                this.displayBox.Invalidate();
                return;
            }
        }

        private void SetupDelt()
        {
            this.currentMode = Mode.DELT;
            this.labelResourceName.Text = $"DELT {this.delt!.Name}";
            this.checkBoxMultiSelect.Visible = false;
            this.listBoxDelts.Visible = false;

            var infoLines = new string[4];
            infoLines[0] = $"Width: {this.delt!.SizeX}";
            infoLines[1] = $"Height: {this.delt.SizeY}";
            infoLines[2] = $"OffsetX: {this.delt.OffsetX}";
            infoLines[3] = $"OffsetY: {this.delt.OffsetY}";
            this.textBoxInfo.Lines = infoLines;

            this.bitmaps = new Bitmap[1];
            var bitmap = this.delt.CreateBitmap(this.palette, this.checkBoxSubtractOffsets.Checked);
            this.bitmaps[0] = bitmap!;

            this.SetDisplayBoxToBitmapSize(0);
            this.displayBox.Invalidate();
            this.toolStripButtonExport.Enabled = true;
        }

        private void SetupAnim()
        {
            this.currentMode = Mode.ANIM;
            this.labelResourceName.Text = $"ANIM {this.anim!.Name}";
            this.checkBoxMultiSelect.Visible = true;
            this.listBoxDelts.Visible = true;

            var infoLines = new string[7];
            infoLines[0] = $"Contains {this.anim!.NumDelts} DELTs";
            infoLines[1] = string.Empty;
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
            this.displayBox.Invalidate();
            this.toolStripButtonExport.Enabled = true;
        }

        private void GenerateAnimBitmaps()
        {
            for (var d = 0; d < this.anim!.NumDelts; d++)
            {
                var bitmap = this.anim.Delts[d].Delt.CreateBitmap(this.palette, this.checkBoxSubtractOffsets.Checked);
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
                for (int i = 2; i < infoLines.Length; i++)
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

            this.displayBox.Invalidate();
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
                infoLines[2] = $"DELT {index}";
                infoLines[3] = $"Width: {this.anim.Delts[index].Delt.SizeX}";
                infoLines[4] = $"Height: {this.anim.Delts[index].Delt.SizeY}";
                infoLines[5] = $"OffsetX: {this.anim.Delts[index].Delt.OffsetX}";
                infoLines[6] = $"OffsetY: {this.anim.Delts[index].Delt.OffsetY}";
                this.textBoxInfo.Lines = infoLines;
            }

            this.displayBox.Invalidate();
        }

        private void ComboBoxScale_SelectedIndexChanged(object sender, EventArgs e)
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

            // Resize display area, then redraw
            if (this.currentMode == Mode.DELT)
            {
                this.SetDisplayBoxToBitmapSize(0);
                this.displayBox.Invalidate();
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
                    if (index < 0 || index >= this.anim!.NumDelts) { return; }
                    this.SetDisplayBoxToBitmapSize(index);
                }

                this.displayBox.Invalidate();
                return;
            }
        }

        private void ComboBoxDisplayBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxDisplayBackground.SelectedIndex)
            {
                case 0:
                    this.displayBackground = Color.Black;
                    break;
                case 1:
                    this.displayBackground = Color.White;
                    break;
                case 2:
                    this.displayBackground = Color.Gray;
                    break;
                default:
                    this.displayBackground = Color.Black;
                    break;
            }

            if (this.bitmaps == null || this.bitmaps.Length == 0)
            {
                return;
            }

            if (this.currentMode == Mode.DELT)
            {
                this.displayBox.Invalidate();
                return;
            }
            if (this.currentMode == Mode.ANIM)
            {
                this.displayBox.Invalidate();
                return;
            }
        }

        private void CheckBoxSubtractOffsets_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bitmaps == null || this.bitmaps.Length == 0)
            {
                return;
            }

            // Regenerate bitmaps, resize display area, and redraw
            if (this.currentMode == Mode.DELT && this.delt != null)
            {
                var bitmap = this.delt.CreateBitmap(this.palette, this.checkBoxSubtractOffsets.Checked);
                this.bitmaps[0] = bitmap!;
                this.SetDisplayBoxToBitmapSize(0);
                this.displayBox.Invalidate();
                return;
            }

            if (this.currentMode == Mode.ANIM && this.anim != null)
            {
                this.GenerateAnimBitmaps();

                if (this.checkBoxMultiSelect.Checked)
                {
                    this.SetDisplayBoxToMaxBitmapSize();
                }
                else
                {
                    var index = this.listBoxDelts.SelectedIndex;
                    if (index < 0 || index >= this.anim!.NumDelts) { return; }
                    this.SetDisplayBoxToBitmapSize(index);
                }

                this.displayBox.Invalidate();
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

            graphics.Clear(displayBackground);
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

            graphics.Clear(displayBackground);

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

        private void ListBoxLfdContents_SelectedIndexChanged(object sender, EventArgs e)
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

        private void BtnOpenResource_Click(object sender, EventArgs e)
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
                    var delt = new Delt();
                    delt.LoadFromStream(new MemoryStream(selectedResource.Data));
                    delt.Name = selectedResource.Name;
                    this.delt = delt;

                    this.SetupDelt();
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
                    var anim = new Anim();
                    anim.LoadFromStream(new MemoryStream(selectedResource.Data));
                    anim.Name = selectedResource.Name;
                    this.anim = anim;

                    this.SetupAnim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading ANIM.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }

        private void ToolStripButtonExport_Click(object sender, EventArgs e)
        {
            if (this.currentMode == Mode.NIL)
            {
                return;
            }

            if (this.currentMode == Mode.DELT)
            {
                if (this.bitmaps == null || this.bitmaps.Length == 0 || this.delt == null)
                {
                    MessageBox.Show("Image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.bitmaps[0] == null)
                {
                    MessageBox.Show("This DELT has no image.", "Cannot Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(this.exportPath))
                {
                    this.savePngDialog.InitialDirectory = this.exportPath;
                }

                this.savePngDialog.Title = "Export DELT as PNG";
                this.savePngDialog.FileName = $"{this.delt.Name}.DELT.png";
                var dlgResult = this.savePngDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    this.bitmaps[0].Save(this.savePngDialog.FileName, ImageFormat.Png);
                    this.exportPath = Path.GetDirectoryName(this.savePngDialog.FileName);
                    MessageBox.Show("Export successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            if (this.currentMode == Mode.ANIM)
            {
                if (this.bitmaps == null || this.bitmaps.Length == 0 || this.anim == null)
                {
                    MessageBox.Show("Images not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(this.exportPath))
                {
                    this.savePngDialog.InitialDirectory = this.exportPath;
                }

                this.savePngDialog.Title = "Export ANIM as PNGs";
                this.savePngDialog.FileName = $"{this.anim.Name}.ANIM";
                var dlgResult = this.savePngDialog.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    var directory = Path.GetDirectoryName(this.savePngDialog.FileName) ?? string.Empty;
                    var baseFilename = Path.GetFileNameWithoutExtension(this.savePngDialog.FileName);

                    for (int i = 0; i < this.anim.NumDelts; i++)
                    {
                        if (this.bitmaps[i] == null)
                        {
                            continue;
                        }

                        var number = GetNumberWithLeadingZeroes(i);
                        var fileName = $"{baseFilename}{number}.PNG";
                        var path = Path.Combine(directory, fileName);

                        this.bitmaps[i].Save(path, ImageFormat.Png);
                    }

                    this.exportPath = Path.GetDirectoryName(this.savePngDialog.FileName);
                    MessageBox.Show("Export successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnViewPltt_Click(object sender, EventArgs e)
        {
            if (this.plttViewer.Visible)
            {
                this.plttViewer.Focus();
                return;
            }

            this.plttViewer.Initialise(this.palette);
            this.plttViewer.Show(this);
        }

        private void toolStripMenuItemCreateDelt_Click(object sender, EventArgs e)
        {
            var deltWindow = new CreateDeltWindow();
            deltWindow.Show(this);
        }

        private void toolStripMenuItemCreateAnim_Click(object sender, EventArgs e)
        {
            var animWindow = new CreateAnimWindow();
            animWindow.Show(this);
        }
    }
}
