﻿using System;
using System.Drawing;

using Mappy;

namespace LifeGame
{
    public class Cell
    {
        public static int CELL_SIZE = 5;

        protected bool alive;

        protected Color color;
        protected Color aliveColor;
        protected Point position;
        protected Grid parent;

        public bool Alive { get { return alive; } }

        public int X { get { return (int)position.X; } }
        public int Y { get { return (int)position.Y; } }

        public Color Color { get { return color; } set { color = value; } }
        public Grid Parent { get { return parent; } set { parent = value; } }

        public static Random r = new Random();

        public Cell()
        {
            this.alive = false;
            this.position = new Point();

            this.aliveColor = PickRandomColor();
            DetermineColorFromLifeState();
        }

        public Cell(Grid parent)
        {
            this.parent = parent;

            this.alive = false;
            this.position = new Point();

            this.aliveColor = PickRandomColor();
            DetermineColorFromLifeState();
        }

        public Cell(Cell cell)
        {
            this.parent = cell.parent;

            this.alive = cell.alive;
            this.position = cell.position;

            this.color = cell.color;
            this.aliveColor = cell.aliveColor;
        }

        public Cell(Point position, bool alive, Grid parent = null)
        {
            this.parent = parent;

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
            aliveColor = PickRandomColor();

            DetermineColorFromLifeState();
        }

        public void Kill()
        {
            alive = false;
            aliveColor = PickRandomColor();

            DetermineColorFromLifeState();
        }

        public void ReverseLife()
        {
            if (Alive)
                Kill();
            else Live();
        }

        public virtual void Render(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(X, Y, CELL_SIZE - 1, CELL_SIZE - 1);

            if (parent.UseMeanColor)
                rectangle.Size = new Size(rectangle.Size.Width + 1, rectangle.Size.Height + 1);

            graphics.FillRectangle(new SolidBrush(color), rectangle);
        }

        public void DetermineColorFromLifeState()
        {
            if (alive)
                color = aliveColor;
            else
                color = Color.White;
        }

        public static Color GetMeanColor(Cell[] neighbours)
        {
            float red = 0, green = 0, blue = 0;

            foreach (Cell cell in neighbours)
            {
                red += cell.color.R;
                green += cell.color.G;
                blue += cell.color.B;
            }

            red /= neighbours.Length;
            green /= neighbours.Length;
            blue /= neighbours.Length;

            return Color.FromArgb((int)red, (int)green, (int)blue);
        }

        public static Color PickRandomColor()
        {
            return Color.FromArgb(r.Next(35, 255), r.Next(35, 255), r.Next(35, 255));
        }
    }
}
