using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

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

            if (!chk_UseHexagonalGrid.Checked)
                grid = new Grid(gridSize);
            else
                grid = new HexagonalGrid(new Vector2D(gridSize.X, gridSize.Y));
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
                GridStorageHelper store = new GridStorageHelper();

                string to = DialogHelper.GetSavePath("Save grid...", "Grid|*.xgrid");
                store.SaveGrid(grid, to);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file was not found.", "LifeGame", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                GridLoadingForm glf = new GridLoadingForm();
                glf.LoadingFinished += glf_LoadingFinished;
                glf.ShowDialog();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file was not found.", "LifeGame", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception x)
            {
                MessageBox.Show("An error occured : " + x.Message, "LifeGame", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void glf_LoadingFinished(object sender, EventArgs e)
        {
            grid = ((GridEventArgs)e).Grid;

            InitializeLifeGame(hasGrid: true);

            nud_GridWidth.Value = (decimal)grid.Width;
            nud_GridHeight.Value = (decimal)grid.Height;

            RefreshUI();
            DrawGrid();
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
            RefreshUI();
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

        private void RefreshUI()
        {
            RefreshLivingCellsLabel();
            RefreshIterationLabel();
        }

        private void RefreshLivingCellsLabel()
        {
            this.Invoke(new Action(() => lbl_NumberOfLivingCells.Text = grid.LivingCells.ToString()));
        }

        private void RefreshIterationLabel()
        {
            this.Invoke(new Action(() => lbl_CurrentIteration.Text = grid.Iteration.ToString()));
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

        private void chk_UseMeanColor_CheckedChanged(object sender, EventArgs e)
        {
            grid.UseMeanColor = chk_UseMeanColor.Checked;
        }
    }
}
