using System.Drawing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace testDrawPolygon
{
    public partial class Form1 : Form
    {
        Grid grid;

        Bitmap bmp;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();

            grid = new Grid(new Point(95, 40));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            bmp = new System.Drawing.Bitmap(Width, Height);
            graphics = Graphics.FromImage(bmp);

            grid.Render(graphics);
            grid.Render(e.Graphics);

            bmp.Save("hexagons.png", ImageFormat.Png);
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
