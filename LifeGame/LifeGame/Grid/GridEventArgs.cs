using System;

namespace LifeGame
{
    class GridEventArgs : EventArgs
    {
        public Grid Grid { get; private set; }

        public GridEventArgs(Grid grid)
        {
            this.Grid = grid;
        }
    }
}
