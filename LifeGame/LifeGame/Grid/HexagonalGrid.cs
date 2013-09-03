using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

using Mappy;

namespace LifeGame
{
    class HexagonalGrid : Grid
    {
        HexagonalCell[] copy;
        HexagonalCell[] cells;

        public new int LivingCells
        {
            get
            {
                return cells.Where<HexagonalCell>(new Func<HexagonalCell, bool>((cell) => cell.Alive)).Count();
            }
        }

        public new Cell[] Cells { get { return cells; } }

        public HexagonalGrid()
        {
            CreateCells();
        }

        public HexagonalGrid(Vector2D size)
        {
            this.size = new Point((int)size.X, (int)size.Y);
            CreateCells();
        }

        public HexagonalGrid(Vector2D size, HexagonalCell[] cells, int iteration)
        {
            this.size = new Point((int)size.X, (int)size.Y);

            this.cells = cells;
            this.iteration = iteration;

            this.copy = new HexagonalCell[Width * Height];
        }

        public override void Live()
        {
            foreach (HexagonalCell cell in cells)
                cell.Live();
        }

        public override void Kill()
        {
            foreach (HexagonalCell cell in cells)
                cell.Kill();
        }

        private void CreateCells()
        {
            CreateEmptyGrids();
            FillGrid();
        }

        private void CreateEmptyGrids()
        {
            cells = new HexagonalCell[Width * Height];
            copy = new HexagonalCell[Width * Height];
        }

        private void FillGrid()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);
                    cells[i] = new HexagonalCell(new Vector2D(x, y), new Vector2D(10, 20), 
                        HexagonalCell.r.NextDouble() < 0.4);
                }
        }

        public override void Update()
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
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);

                    int[] neighbours = GetNeightboursIndexes(i);
                    int aliveNeighbours = GetNumberOfAliveCellsIn(neighbours);

                    if (aliveNeighbours == 3) cells[i].Live();
                    else if (aliveNeighbours < 2 || aliveNeighbours >= 4) cells[i].Kill();
                }
        }

        private int[] GetNeightboursIndexes(int i)
        {
            List<int> neightbours = new List<int>();

            int cx = copy[i].X;
            int cy = copy[i].Y;

            int up = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx, cy - 1), Width);
            int upRight = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx + 1, cy - 1), Width);
            int upLeft = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx - 1, cy - 1), Width);

            int bottom = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx, cy + 1), Width);
            int bottomRight = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx + 1, cy + 1), Width);
            int bottomLeft = CoordinateSystemConverter.PlaneToLine(new Vector2D(cx - 1, cy + 1), Width);

            neightbours.Add(up);
            neightbours.Add(upLeft);
            neightbours.Add(upRight);
            neightbours.Add(bottom);
            neightbours.Add(bottomLeft);
            neightbours.Add(bottomRight);

            return neightbours.ToArray();
        }

        private int GetNumberOfAliveCellsIn(int[] neighbours)
        {
            return neighbours.Count<int>(new Func<int, bool>((cell) =>
                {
                    if (cell > -1 && cell < copy.Length)
                        return copy[cell].Alive;
                    return false;
                }
            ));
        }

        public override void Render(Graphics graphics)
        {
            DrawRow(graphics, Vector2D.Zero, 0);
            for (int y = 1; y < Height; y++)
                DrawRow(graphics, new Vector2D(0, y * HexagonalCell.DIAMETER), y);
        }

        private void DrawRow(Graphics graphics, Vector2D translation, int row)
        {
            for (int x = 0; x < Width; x++)
            {
                int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, row), Width);

                if (x % 2 != 0)
                {
                    Vector2D totalTranslation = new Vector2D(x * HexagonalCell.RADIUS, -HexagonalCell.DIAMETER);
                    totalTranslation += translation;
                    cells[i].Render(graphics, totalTranslation);
                }
                else
                {
                    Vector2D totalTranslation = new Vector2D(x * HexagonalCell.RADIUS, 0);
                    totalTranslation += translation;
                    cells[i].Render(graphics, totalTranslation);
                }
            }
        }
    }
}
