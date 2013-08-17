using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Mappy;

namespace LifeGame
{
    public partial class MainForm : Form
    {
        bool working;

        Grid grid;

        Bitmap bmp;
        Graphics graphics;

        Thread updateThread;

        Rectangle view;

        public MainForm()
        {
            InitializeComponent();

            CreateGrid();
        }

        private void CreateGrid()
        {
            working = false;
            Vector2D gridSize = new Vector2D((float)nud_GridWidth.Value, (float)nud_GridHeight.Value);
            grid = new Grid(gridSize);

            CreateBitmap();
            SetScrollBarsMaximums();
        }

        private void CreateBitmap()
        {
            bmp = new Bitmap(pb_Ozone.Width, pb_Ozone.Height);
            graphics = Graphics.FromImage(bmp);

            view = new Rectangle(0, 0, pb_Ozone.Width, pb_Ozone.Height);

            pb_Ozone.Image = bmp;
        }

        private void SetScrollBarsMaximums()
        {
            int width = grid.Width * Cell.CELL_SIZE;
            int height = grid.Height * Cell.CELL_SIZE;

            hsc_HorizontalScroller.Maximum = width;
            vsc_VerticalScroller.Maximum = height;
        }

        private void hsc_HorizontalScroller_Scroll(object sender, ScrollEventArgs e)
        {
            view.X = e.NewValue;

            graphics.ResetTransform();
            graphics.TranslateTransform(-view.X, 0);

            DrawGrid();
        }

        private void vsc_VerticalScroller_Scroll(object sender, ScrollEventArgs e)
        {
            view.Y = e.NewValue;
            
            graphics.ResetTransform();
            graphics.TranslateTransform(0, -view.Y);

            DrawGrid();
        }

        private void DrawGrid()
        {
            graphics.Clear(Color.White);

            grid.Render(graphics);
            pb_Ozone.Refresh();
        }

        private void bt_StartStop_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                working = true;
                bt_StartStop.Text = "Stop";
         
                updateThread = new Thread(new ThreadStart(UpdateGrid));
                updateThread.Start();
            }
            else
            {
                working = false;
                bt_StartStop.Text = "Start";
                updateThread.Abort();
            }
        }

        private void UpdateGrid()
        {
            grid.UpdateFinished += grid_UpdateFinished;

            while (true)
            {
                grid.Update();

                this.Invoke(new Action(() =>
                    {
                        DrawGrid();
                    }
                ));
            }
        }

        private void grid_UpdateFinished(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
                {
                    lbl_NumberOfLivingCells.Text = grid.LivingCells.ToString();
                }
            ));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseUpdateThread();
        }

        private void CloseUpdateThread()
        {
            if (updateThread != null)
            if (updateThread.IsAlive)
                updateThread.Abort();
        }

        private void bt_NewGrid_Click(object sender, EventArgs e)
        {
            bt_StartStop.Text = "Start";
            graphics.Clear(Color.White);

            CloseUpdateThread();
            CreateGrid();
        }

        private void pb_Ozone_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
