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
    public partial class PlttViewer : Form
    {
        public PlttViewer()
        {
            InitializeComponent();
        }

        public void Initialise(Pltt pltt)
        {
            this.pltt = pltt;
            this.Text = $"PLTT {pltt.Name}";
            this.plttDisplay.Invalidate();
        }

        private static readonly int ColourRectSize = 32;

        private Pltt? pltt;

        private void plttDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (this.pltt == null) { return; }

            var brush = new SolidBrush(Color.Black);
            for (var y = 0; y < 16; y++)
            {
                for (var x = 0; x < 16; x++)
                {
                    byte index = (byte)(y * 16 + x);
                    if (index < this.pltt.FirstColour || index > this.pltt.LastColour)
                    {
                        continue;
                    }

                    var colour = this.pltt.Colours[index];
                    brush.Color = Color.FromArgb(255, colour.R, colour.G, colour.B);
                    e.Graphics.FillRectangle(brush, x * ColourRectSize, y * ColourRectSize, ColourRectSize, ColourRectSize);
                }
            }
        }

        private void plttDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.pltt == null) { return; }

            var xPos = e.X / ColourRectSize;
            var yPos = e.Y / ColourRectSize;
            if (xPos < 0 || yPos < 0 || xPos > 15 || yPos > 15) { return; }

            var colourIndex = yPos * 16 + xPos;
            var notDefined = colourIndex < this.pltt.FirstColour || colourIndex > this.pltt.LastColour;
            var colour = this.pltt.Colours[colourIndex];

            this.labelColour.Text = notDefined
                ? $"Colour {colourIndex}: Not defined"
                : $"Colour {colourIndex}: R{colour.R}, G{colour.G}, B{colour.B}";

        }

        private void PlttViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
