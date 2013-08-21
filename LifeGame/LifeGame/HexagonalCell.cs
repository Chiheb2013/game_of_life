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
    class HexagonalCell : Cell
    {
        public static int RADIUS { get { return Cell.CELL_SIZE; } }
        public static int DIAMETER = RADIUS * 2;

        static Vector2D z = new Vector2D((float)Math.Sqrt(RADIUS * RADIUS - RADIUS *
            Math.Sin(ToRadians(60))),
            (float)(RADIUS * Math.Sin(ToRadians(60))));

        static Vector2D upRight = new Vector2D(z.X, 2 * -z.Y);
        static Vector2D horRight = new Vector2D(2 * z.X, 0);
        static Vector2D botRight = new Vector2D(z.X, 2 * z.Y);
        static Vector2D botLeft = new Vector2D(-z.X, 2 * z.Y);
        static Vector2D horLeft = new Vector2D(-2 * z.X, 0);
        static Vector2D upLeft = new Vector2D(-z.X, 2 * -z.Y);

        Vector2D center;
        Vector2D gridCenter;

        public new int X { get { return (int)gridCenter.X; } }
        public new int Y { get { return (int)gridCenter.Y; } }

        public HexagonalCell()
        {
            this.alive = false;
            this.position = new Point();

            this.aliveColor = PickRandomColor();
            DetermineColorFromLifeState();
        }

        public HexagonalCell(Vector2D position, Vector2D translation)
        {
            this.alive = false;

            this.gridCenter = position;
            this.center = new Vector2D(position.X * DIAMETER, position.Y * DIAMETER);
            this.center += translation;

            this.color = PickRandomColor();
            DetermineColorFromLifeState();
        }

        public HexagonalCell(Vector2D position, Vector2D translation, bool alive)
        {
            this.alive = alive;

            this.gridCenter = position;
            this.center = new Vector2D(position.X * DIAMETER, position.Y * DIAMETER);
            this.center += translation;

            this.color = PickRandomColor();
            DetermineColorFromLifeState();
        }

        public void Render(Graphics graphics, Vector2D translation)
        {
            Pen pen = new Pen(new SolidBrush(color));

            Vector2D posUpRight = center + upRight + translation;
            Vector2D posHorRight = center + horRight + translation;
            Vector2D posBotRight = center + botRight + translation;
            Vector2D posBotLeft = center + botLeft + translation;
            Vector2D posHorLeft = center + horLeft + translation;
            Vector2D posUpLeft = center + upLeft + translation;

            PointF[] points = new PointF[]
            {
                new PointF(posUpRight.X, posUpRight.Y),
                new PointF(posHorRight.X, posHorRight.Y),
                new PointF(posBotRight.X, posBotRight.Y),
                new PointF(posBotLeft.X, posBotLeft.Y),
                new PointF(posHorLeft.X, posHorLeft.Y),
                new PointF(posUpLeft.X, posUpLeft.Y)
            };

            graphics.DrawPolygon(pen, points);
        }

        private static float ToRadians(float degrees)
        {
            return degrees * (float)Math.PI / 180;
        }
    }
}
