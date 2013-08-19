using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

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

            InitializeLifeGame(hasBitmap:false);
        }

        private void bt_NewGrid_Click(object sender, EventArgs e)
        {
            bt_StartStop.Text = "Start";
            graphics.Clear(Color.White);

            CloseUpdateThread();
            InitializeLifeGame();
        }

        private void InitializeLifeGame(bool hasBitmap = true, bool hasGrid = false)
        {
            working = false;
            view = new Rectangle(0, 0, pb_Ozone.Width, pb_Ozone.Height);

            if (!hasGrid)
                CreateGrid();

            if (!hasBitmap)
                CreateBitmap();

            SetScrollBarsMaximums();
        }

        private void CreateGrid()
        {
            Point gridSize = new Point((int)nud_GridWidth.Value, (int)nud_GridHeight.Value);
            grid = new Grid(gridSize);
        }

        private void CreateBitmap()
        {
            bmp = new Bitmap(pb_Ozone.Width, pb_Ozone.Height);
            graphics = Graphics.FromImage(bmp);
            
            pb_Ozone.Image = bmp;
        }

        private void SetScrollBarsMaximums()
        {
            int width = grid.Width * Cell.CELL_SIZE;
            int height = grid.Height * Cell.CELL_SIZE;

            hsc_HorizontalScroller.Maximum = width;
            vsc_VerticalScroller.Maximum = height;
        }

        private void bt_SaveTo_Click(object sender, EventArgs e)
        {
            try
            {
                string to = DialogHelper.GetSavePath("Save grid...", "Grid|*.xgrid");
                GridStorageHelper.SaveGrid(grid, to);
            }
            catch (Exception x)
            {
                MessageBox.Show("An error occured : " + x.Message);
            }
        }

        private void bt_LoadFrom_Click(object sender, EventArgs e)
        {
            try
            {
                string from = DialogHelper.GetLoadPath("Load grid...", "Grid|*.xgrid");
                grid = GridStorageHelper.LoadGrid(from);

                InitializeLifeGame(hasGrid: true);

                nud_GridWidth.Value = (decimal)grid.Width;
                nud_GridHeight.Value = (decimal)grid.Height;
            }
            catch (Exception x)
            {
                MessageBox.Show("An error occured : " + x.Message);
            }
        }

        private void bt_StartStop_Click(object sender, EventArgs e)
        {
            if (!working)
                CreateWorkerThreadAndSetUI();
            else
                StopWorkerThreadAndSetUI();
        }

        private void UpdateGrid()
        {
            grid.UpdateFinished += grid_UpdateFinished;

            while (true)
            {
                grid.Update();
                Render();
            }
        }

        private void grid_UpdateFinished(object sender, EventArgs e)
        {
            RefreshLivingCellsLabel();
        }

        private void Render()
        {
            this.Invoke(new Action(() => DrawGrid()));
        }

        private void DrawGrid()
        {
            graphics.Clear(Color.White);

            grid.Render(graphics);
            pb_Ozone.Refresh();
        }

        private void CreateWorkerThreadAndSetUI()
        {
            working = true;
            bt_StartStop.Text = "Stop";

            updateThread = new Thread(new ThreadStart(UpdateGrid));
            updateThread.Start();
        }

        private void StopWorkerThreadAndSetUI()
        {
            working = false;
            bt_StartStop.Text = "Start";

            updateThread.Abort();
        }

        private void RefreshLivingCellsLabel()
        {
            this.Invoke(new Action(() => lbl_NumberOfLivingCells.Text = grid.LivingCells.ToString()));
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
    }
}
