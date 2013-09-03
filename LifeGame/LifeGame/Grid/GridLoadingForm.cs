using System;
using System.Threading;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class GridLoadingForm : Form
    {
        public event EventHandler LoadingFinished;

        bool finished;

        Thread loadingThread;

        public GridLoadingForm()
        {
            finished = false;

            InitializeComponent();
        }

        private void GridLoadingForm_Shown(object sender, EventArgs e)
        {
            string to = DialogHelper.GetLoadPath("Load grid...", "Grid|*.xgrid");

            loadingThread = new Thread(new ParameterizedThreadStart(LoadGrid));
            loadingThread.Start(to);
        }

        private void LoadGrid(object to)
        {
            Grid buffer;
            GridStorageHelper store = new GridStorageHelper();

            store.BitsIterationPassed += GridStorageHelper_BitsIterationPassed;
            store.CellsIterationPassed += GridStorageHelper_CellsIterationPassed;

            buffer = store.LoadGrid((string)to);

            if (finished)
            {
                this.Invoke(new Action(() =>
                    {
                        RaiseLoadFinishedEvent(buffer);
                        this.Close();
                    }
                ));
            }
        }

        private void GridStorageHelper_BitsIterationPassed(int progress)
        {
            this.Invoke(new Action(() => pgb_BitsLoaded.Value = progress));
        }

        private void GridStorageHelper_CellsIterationPassed(int progress)
        {
            this.Invoke(new Action(() => pgb_CellsCreated.Value = progress));

            if (progress == 100)
                finished = true;
        }

        private void RaiseLoadFinishedEvent(Grid buffer)
        {
            if (LoadingFinished != null)
                LoadingFinished(this, new GridEventArgs(buffer));
        }

        private void GridLoadingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadingThread.Abort();
        }
    }
}
