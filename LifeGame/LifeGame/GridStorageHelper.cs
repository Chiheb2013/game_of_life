using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using Mappy;

namespace LifeGame
{
    static class GridStorageHelper
    {
        public static void SaveGrid(Grid grid, string to)
        {
            try
            {
                using (FileStream fs = File.OpenWrite(to))
                {
                    fs.WriteByte((byte)grid.Width);
                    fs.WriteByte((byte)grid.Height);

                    foreach (Cell cell in grid.Cells)
                        fs.WriteByte(cell.Alive ? (byte)1 : (byte)0);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Grid LoadGrid(string from)
        {
            try
            {
                using (FileStream fs = File.OpenRead(from))
                {
                    int width = fs.ReadByte();
                    int height = fs.ReadByte();

                    List<int> cells = new List<int>();
                    for (int i = 0; i < width * height; i++)
                        cells.Add(fs.ReadByte());

                    List<Cell> acells = new List<Cell>();
                    for (int i = 0; i < width * height; i++)
                    {
                        Vector2D v = CoordinateSystemConverter.LineToPlane(i, width);
                        acells.Add(new Cell(new Point((int)v.X, (int)v.Y), cells[i] == 1));
                    }

                    Grid grid = new Grid(new Point(width, height), acells.ToArray());
                    return grid;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
