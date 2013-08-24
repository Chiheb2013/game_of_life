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
        bool working;       //tells to the update thread if it has
                            //to compute the next generation of cells
        
        bool mouseDown;     //used to know if the mouse is pressed
                            //to draw cells

        Vector2D lastDrawnPosition; //the last position where a cell was drawn
                                    //using this allows not to draw twice on the same cell

        Grid grid;          //the grid of cells

        Bitmap bmp;         //bitmap buffer where to draw the cells
        Graphics graphics;  //the renderer
        Rectangle view;     //the view that can be seen on the screen

        Thread updateThread;    //the worker thread. it computes the generations of cells

        public MainForm()
        {
            InitializeComponent();

            InitializeLifeGame(hasBitmap:false);    //initializes a new game of life grid
                                                    //and creates a new bitmap (initializes 'bmp' and 'graphics' too)
        }

        /// <summary>
        /// Creates a new game of life grid with the specified parameters on the UI
        /// </summary>
        /// <param name="sender">The new grid button</param>
        /// <param name="e">None</param>
        private void bt_NewGrid_Click(object sender, EventArgs e)
        {
            bt_StartStop.Text = "Start";
            graphics.Clear(Color.White);

            CloseUpdateThread();        //Each time a new grid is created
                                        //create a new worker thread

            InitializeLifeGame();       //Initialize a new game of life grid

            Render();                   //Render the new grid on the screen
        }

        private void InitializeLifeGame(bool hasBitmap = true, bool hasGrid = false)
        {
            working = false;

            mouseDown = false;
            lastDrawnPosition = Vector2D.Zero;
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
            int width, height;
            if (!chk_UseHexagonalGrid.Checked)
            {
                width = grid.Width * Cell.CELL_SIZE;
                height = grid.Height * Cell.CELL_SIZE;
            }
            else
            {
                width = grid.Width * HexagonalCell.DIAMETER;
                height = grid.Height * HexagonalCell.DIAMETER;
            }

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
            GridLoadingForm glf = new GridLoadingForm();
            try
            {
                glf.LoadingFinished += glf_LoadingFinished;
                glf.ShowDialog();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file was not found.", "LifeGame", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                glf.Close();
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

        private void pb_Ozone_MouseClick(object sender, MouseEventArgs e)
        {
            if (grid != null)
                lastDrawnPosition = ReverseCellStateAndRender(e);
        }

        private void pb_Ozone_MouseMove(object sender, MouseEventArgs e)
        {
            if (grid != null && mouseDown)
                lastDrawnPosition = ReverseCellStateAndRender(e);
        }

        private Vector2D ReverseCellStateAndRender(MouseEventArgs e)
        {
            Vector2D position = new Vector2D(e.X / Cell.CELL_SIZE, e.Y / Cell.CELL_SIZE);

            if (!lastDrawnPosition.Equals(position))
            {
                grid.ReverseCellLifeState(position);
                Render();
            }

            return position;
        }

        private void UpdateGrid()
        {
            grid.UpdateFinished += grid_UpdateFinished;

            while (true)
            {
                grid.Update();
                Render();

                DetermineTimeToWaitForSpeed();
            }
        }

        private void DetermineTimeToWaitForSpeed()
        {
            this.Invoke(new Action(() =>
                {
                    if (cmb_Speed.Text == "Medium speed")
                        Thread.Sleep(200);
                    if (cmb_Speed.Text == "Slow speed")
                        Thread.Sleep(500);
                }
            ));
        }

        private void grid_UpdateFinished(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void Render()
        {
            this.Invoke(new Action(() =>
                {
                    DrawGrid();

                    if (chk_ShowGridLimits.Checked)
                        DrawGridLimits();
                }
            ));
        }

        private void DrawGrid()
        {
            graphics.Clear(Color.White);

            grid.Render(graphics);

            if (!chk_ShowGridLimits.Checked)
                pb_Ozone.Refresh();
        }

        private void DrawGridLimits()
        {
            Rectangle limits = new Rectangle(0, 0, grid.Width * Cell.CELL_SIZE, grid.Height * Cell.CELL_SIZE);
            graphics.DrawRectangle(new Pen(Brushes.Blue, 2), limits);

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

        private void pb_Ozone_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void pb_Ozone_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void nud_CellSize_ValueChanged(object sender, EventArgs e)
        {
            //Can change cell size, but can't change it the same grid !
            Cell.CELL_SIZE = (int)nud_CellSize.Value;

            bt_NewGrid_Click(this, e);  //Creates a new grid by simulating a click on
                                        //the 'new grid' button

            Render();                   //And renders the result
        }

        private void bt_Hecatomb_Click(object sender, EventArgs e)
        {
            if (grid != null)
            {
                grid.Kill();
                Render();
            }
        }
    }
}
