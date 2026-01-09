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
    }
}
