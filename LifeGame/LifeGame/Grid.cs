//CoordinateSystemConvert is a class from Mappy, an external library.
//It is used here to convert 1D coordinates (an index in an array) to
//2D coordinates (the position on the grid). Life Game uses it to know
//the positions of the cells, since they are stored in a 1D array and not
//in a matrix.

using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using Mappy;

namespace LifeGame
{
    public class Grid
    {
        public event EventHandler UpdateFinished;
        Random rand = new Random();

        protected int iteration;
        bool useMeanColor;

        Cell[] copy;
        Cell[] cells;

        Point size;

        public int Width { get { return size.X; } }
        public int Height { get { return size.Y; } }
        public int Iteration { get { return iteration; } }
        public int LivingCells
        {
            get
            {
                return cells.Where<Cell>(new Func<Cell, bool>((cell) => cell.Alive)).Count();
            }
        }
        public bool UseMeanColor { get { return useMeanColor; } set { useMeanColor = value; } }

        public Cell[] Cells { get { return cells; } }

        public Grid()
        {
            this.size = new Point(10, 10);

            CreateCells();
        }

        public Grid(Point size)
        {
            this.size = size;

            CreateCells();
        }

        public Grid(Point size, Cell[] cells)
        {
            this.size = size;
            this.cells = cells;

            this.copy = new Cell[size.X * size.Y];
        }

        public Grid(Point size, Cell[] cells, int iteration)
        {
            this.size = size;
            this.cells = cells;
            this.iteration = iteration;

            this.copy = new Cell[size.X * size.Y];
        }

        private void CreateCells()
        {
            CreateEmptyGrids();
            FillGrid();
        }

        private void CreateEmptyGrids()
        {
            cells = new Cell[Width * Height];
            copy = new Cell[Width * Height];
        }

        private void FillGrid()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    //to know more about CoordinateSystemConverter, see above (file start, before using's)
                    int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);
                    cells[i] = new Cell(new Point(x, y), rand.NextDouble() < 0.4, this);
                }
        }

        public virtual void Update()
        {
            iteration++;

            CreateGridCopy();
            DetermineNextStateForCells();
            RaiseUpdateFinishedEvent();
        }

        private void CreateGridCopy()
        {
            cells.CopyTo(copy, 0);
        }
        
        private void DetermineNextStateForCells()
        {
            DetermineNextLifeState();
            DetermineNextColorState();
        }

        private void DetermineNextLifeState()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);

                    int[] neighbours = GetNeightboursIndexes(i);
                    Cell[] neighboursCells = GetAliveCells(neighbours);
                    int aliveNeighbours = neighboursCells.Length;

                    DetermineCellLifeState(i, aliveNeighbours);
                }
        }

        private void DetermineNextColorState()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);
                    Cell[] neighbours = GetAliveCells(GetNeightboursIndexes(i));
                    
                    if (useMeanColor)
                        DetermineCellMeanColor(i, neighbours);
                }
        }

        private void DetermineCellLifeState(int i, int aliveNeighbours)
        {
            if (aliveNeighbours == 3) cells[i].Live();
            else if (aliveNeighbours < 2 || aliveNeighbours >= 4) cells[i].Kill();
        }

        private void DetermineCellMeanColor(int i, Cell[] neighbours)
        {
            if (neighbours.Length > 0 && cells[i].Alive)
                cells[i].Color = Cell.GetMeanColor(neighbours);
        }

        private int[] GetNeightboursIndexes(int i)
        {
            List<int> neightbours = new List<int>();

            int cx = copy[i].X / Cell.CELL_SIZE;
            int cy = copy[i].Y / Cell.CELL_SIZE;

            int upLeft = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx - 1, cy - 1), Width);
            int up = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx, cy - 1), Width);
            int upRight = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx + 1, cy - 1), Width);

            int left = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx - 1, cy), Width);
            int right = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx + 1, cy), Width);

            int bottomLeft = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx - 1, cy + 1), Width);
            int bottom = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx, cy + 1), Width);
            int bottomRight = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx + 1, cy + 1), Width);

            neightbours.Add(upLeft);
            neightbours.Add(up);
            neightbours.Add(upRight);

            neightbours.Add(left);
            neightbours.Add(right);

            neightbours.Add(bottomLeft);
            neightbours.Add(bottom);
            neightbours.Add(bottomRight);

            return neightbours.ToArray();
        }

        private Cell[] GetAliveCells(int[] neighbours)
        {
            List<Cell> alive = new List<Cell>();

            foreach (int index in neighbours)
                if (index > -1 && index < copy.Length)
                if (copy[index].Alive)
                    alive.Add(copy[index]);
            return alive.ToArray();
        }

        protected void RaiseUpdateFinishedEvent()
        {
            if (UpdateFinished != null)
                UpdateFinished(this, EventArgs.Empty);
        }

        public virtual void Render(Graphics graphics)
        {
            foreach (Cell cell in cells)
                cell.Render(graphics);
        }
    }
}
