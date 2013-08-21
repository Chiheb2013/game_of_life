using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using Mappy;

namespace testDrawPolygon
{
    [Serializable]
    class Grid
    {
        Point size;
        Cell[] cells;

        public int Width { get { return size.X; } }
        public int Height { get { return size.Y; } }
        public int Area { get { return Width * Height; } }

        public Cell[] Cells { get { return cells; } }
        public Cell this[int x,int y]
        {
            get
            {
                int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);
                return cells[i];
            }
        }

        public Grid(Point size)
        {
            this.size = size;
            CreateCells();
        }

        private void CreateCells()
        {
            Console.WriteLine("Creating cells...");
            cells = new Cell[Area];

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);

                    cells[i] = new Cell(new Vector2D(x, y), new Vector2D(10, 20));
                }
        }

        public void Save(string to)
        {
            using (FileStream fs = File.Create(to))
            {
                BinaryFormatter form = new BinaryFormatter();
                form.Serialize(fs, this);
            }
        }

        public static Grid Load(string from)
        {
            using (FileStream fs = File.OpenRead(from))
            {
                BinaryFormatter form = new BinaryFormatter();
                return (Grid)form.Deserialize(fs);
            }
        }

        public void Render(Graphics g)
        {
            Console.WriteLine("Rendering cells...");

            DrawRow(g, 0, Vector2D.Zero);
            for (int y = 1; y < Height; y++)
                DrawRow(g, y, new Vector2D(0, y * Cell.DIAMETER));
        }

        private void DrawRow(Graphics g, int y, Vector2D translation)
        {
            for (int x = 0; x < Width; x++)
            {
                int i = CoordinateSystemConverter.PlaneToLine(new Vector2D(x, y), Width);

                if (x % 2 != 0)
                {
                    Vector2D totalTranslation = new Vector2D(x * Cell.RADIUS, -Cell.DIAMETER);
                    totalTranslation += translation;
                    cells[i].Render(g, totalTranslation);
                }
                else
                {
                    Vector2D totalTranslation = new Vector2D(x * Cell.RADIUS, 0);
                    totalTranslation += translation;
                    cells[i].Render(g, totalTranslation);
                }
            }
        }
    }
}
