using LFD_Tools.DFTypes;

namespace LFD_Tools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = this.openPlttDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var pltt = new Pltt();
                pltt.LoadFromFile(this.openPlttDialog.FileName);
            }
        }
    }
}
