using System;
using System.Drawing;

using Mappy;

namespace LifeGame
{
    public class Cell
    {
        public const int CELL_SIZE = 5;

        bool alive;

        Color color;
        Color aliveColor;
        Point position;

        public bool Alive { get { return alive; } }

        public int X { get { return (int)position.X; } }
        public int Y { get { return (int)position.Y; } }

        static Random r = new Random();

        public Cell()
        {
            this.alive = false;
            this.position = new Point();

            this.aliveColor = PickRandomColor();
            DetermineColorFromLifeState();
        }

        public Cell(Point position, bool alive)
        {
            this.alive = alive;
            this.position = new Point(position.X * CELL_SIZE, position.Y * CELL_SIZE);

            this.aliveColor = PickRandomColor();
            DetermineColorFromLifeState();
        }

        public override string ToString()
        {
            return alive ? "Alive" : "Dead";
        }

        public void Live()
        {
            alive = true;

            DetermineColorFromLifeState();
        }

        public void Kill()
        {
            alive = false;

            DetermineColorFromLifeState();
        }

        public void Render(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(X, Y, CELL_SIZE - 1, CELL_SIZE - 1);

            graphics.FillRectangle(new SolidBrush(color), rectangle);
        }

        private void DetermineColorFromLifeState()
        {
            if (alive)
                color = aliveColor;
            else
                color = Color.White;
        }

        private Color PickRandomColor()
        {
            return Color.FromArgb(r.Next(35, 255), r.Next(35, 255), r.Next(35, 255));
        }
    }
}
