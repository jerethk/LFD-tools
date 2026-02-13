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
    public partial class CreateAnimWindow : Form
    {
        public CreateAnimWindow()
        {
            InitializeComponent();

            this.pltt = Pltt.GetBrfJanPltt();
            this.labelPlttName.Text = this.pltt.Name;
        }

        private record SourceDelt
        {
            public string Name { get; set; } = string.Empty;
            public byte[]? Data { get; set; }
            public Bitmap? Bitmap { get; set; }
        }

        private Pltt pltt;
        private List<SourceDelt>? sourceDelts;
        private BindingSource? sourceDeltsBindingSource;

        private void BtnGetDelts_Click(object sender, EventArgs e)
        {
            var dlgResult = this.openDeltDialog.ShowDialog();

            if (dlgResult == DialogResult.OK)
            {
                var dir = Path.GetDirectoryName(this.openDeltDialog.FileName);
                if (string.IsNullOrEmpty(dir))
                {
                    return;
                }

                var deltFiles = Directory.GetFiles(dir)
                    .Where(filename =>
                    {
                        var ext = Path.GetExtension(filename);
                        return ext.Equals(".DLT", StringComparison.OrdinalIgnoreCase) || ext.Equals(".DELT", StringComparison.OrdinalIgnoreCase);
                    });

                if (!deltFiles.Any())
                {
                    return;
                }

                this.sourceDelts = this.LoadSourceDelts(deltFiles).ToList();

                if (this.sourceDelts != null && this.sourceDelts.Any())
                {
                    this.GenerateBitmaps();
                    this.sourceDeltsBindingSource = new BindingSource();
                    this.sourceDeltsBindingSource.DataSource = this.sourceDelts;
                    this.listBoxDelts.DataSource = this.sourceDeltsBindingSource;
                    this.listBoxDelts.DisplayMember = nameof(SourceDelt.Name);
                    this.listBoxDelts.SelectedIndex = 0;
                }
            }
        }

        private IEnumerable<SourceDelt> LoadSourceDelts(IEnumerable<string> deltFiles)
        {
            foreach (var deltFile in deltFiles)
            {
                var sourceDelt = new SourceDelt();
                sourceDelt.Name = Path.GetFileName(deltFile);

                try
                {
                    using (var stream = File.OpenRead(deltFile))
                    {
                        sourceDelt.Data = new byte[stream.Length];
                        stream.Read(sourceDelt.Data, 0, (int)stream.Length);
                    }
                }
                catch
                {
                    // Just forget this file and move on to the next
                    continue;
                }

                yield return sourceDelt;
            }
        }

        private void GenerateBitmaps()
        {
            if (this.sourceDelts == null)
            {
                return;
            }

            foreach (var sourceDelt in this.sourceDelts)
            {
                if (sourceDelt.Data == null)
                {
                    continue;
                }

                var delt = new Delt();
                delt.LoadFromStream(new MemoryStream(sourceDelt.Data));
                sourceDelt.Bitmap = delt.CreateBitmap(this.pltt, false, true);
            }
        }

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

                    this.GenerateBitmaps();
                    this.PreviewDelt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load PLTT: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListBoxDelts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PreviewDelt();
        }

        private void PreviewDelt()
        {
            if (this.listBoxDelts.SelectedItem == null)
            {
                return;
            }

            var sourceDelt = this.listBoxDelts.SelectedItem as SourceDelt;
            if (sourceDelt == null)
            {
                return;
            }

            if (sourceDelt.Bitmap != null)
            {
                this.pictureBoxDeltPreview.BackColor = Color.Gray;
                this.pictureBoxDeltPreview.Image = sourceDelt.Bitmap;
                this.pictureBoxDeltPreview.Width = sourceDelt.Bitmap.Width * 2;
                this.pictureBoxDeltPreview.Height = sourceDelt.Bitmap.Height * 2;
            }
            else
            {
                this.pictureBoxDeltPreview.Image = null;
                this.pictureBoxDeltPreview.Width = 0;
                this.pictureBoxDeltPreview.Height = 0;
            }
        }

        private void BtnRemoveDelt_Click(object sender, EventArgs e)
        {
            if (this.sourceDelts == null || !this.sourceDelts.Any() || this.listBoxDelts.SelectedItem == null)
            {
                return;
            }

            var sourceDelt = this.listBoxDelts.SelectedItem as SourceDelt;
            if (sourceDelt == null)
            {
                return;
            }

            this.sourceDelts?.Remove(sourceDelt);
            this.sourceDeltsBindingSource?.ResetBindings(false);
            this.PreviewDelt();
        }

        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            if (this.sourceDelts == null || !this.sourceDelts.Any() || this.listBoxDelts.SelectedItem == null)
            {
                return;
            }


            var index = this.listBoxDelts.SelectedIndex;
            if (index > 0)
            {
                this.sourceDelts.Reverse(index - 1, 2);
                this.listBoxDelts.SelectedIndex--;
            }

            this.sourceDeltsBindingSource?.ResetBindings(false);
            this.PreviewDelt();
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            if (this.sourceDelts == null || !this.sourceDelts.Any() || this.listBoxDelts.SelectedItem == null)
            {
                return;
            }


            var index = this.listBoxDelts.SelectedIndex;
            if (index < this.sourceDelts.Count - 1)
            {
                this.sourceDelts.Reverse(index, 2);
                this.listBoxDelts.SelectedIndex++;
            }

            this.sourceDeltsBindingSource?.ResetBindings(false);
            this.PreviewDelt();
        }

        private void ButtonCreateAnim_Click(object sender, EventArgs e)
        {
            if (this.sourceDelts == null || !this.sourceDelts.Any())
            {
                return;
            }

            var dlgResult = this.saveAnimDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                var sourceDeltsData = this.sourceDelts
                    .Where(sourceDelt => sourceDelt.Data != null)
                    .Select(sourceDelt => sourceDelt.Data);

                try
                {
                    Anim.SaveFromRawDelts(sourceDeltsData.ToList()!, this.saveAnimDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving ANIM to file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
