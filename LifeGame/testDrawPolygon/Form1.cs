using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Mappy;

namespace testDrawPolygon
{
    public partial class Form1 : Form
    {
        Grid grid;

        public Form1()
        {
            InitializeComponent();

            grid = new Grid(new Point(30, 30));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            grid.Render(e.Graphics);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
                grid.Save("grid.bin");
            else if (e.KeyChar == 'l')
            {
                (this.CreateGraphics()).Clear(Color.White);
                this.Refresh();
                grid = Grid.Load("grid.bin");
            }
        }
    }
}
