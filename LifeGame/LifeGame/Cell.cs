using System;
using System.Drawing;

using Mappy;

namespace LifeGame
{
    class Cell
    {
        public const int CELL_SIZE = 5;

        bool alive;

        Color color;
        Color aliveColor;
        Vector2D position;

        public bool Alive { get { return alive; } }

        public int X { get { return (int)position.X; } }
        public int Y { get { return (int)position.Y; } }

        static Random r = new Random();

        public Cell(Vector2D position, bool alive)
        {
            this.alive = alive;
            this.position = new Vector2D(position.X * CELL_SIZE, position.Y * CELL_SIZE);

            aliveColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
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
    }
}
