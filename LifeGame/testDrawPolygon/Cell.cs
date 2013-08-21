using System;
using System.Drawing;

using Mappy;

namespace testDrawPolygon
{
    [Serializable]
    class Cell
    {
        public static float RADIUS = 5;
        public static float DIAMETER = RADIUS * 2;

        Color color;
        Vector2D center;

        static Random rand = new Random();

        public Vector2D Center { get { return center; } set { center = value; } }

        public Cell(Vector2D center, Vector2D translation)
        {
            this.center = new Vector2D(center.X * DIAMETER, center.Y * DIAMETER);
            this.center += translation;

            this.color = PickRandomColor();
        }

        public void Render(Graphics g, Vector2D translation)
        {
            Pen pen = new Pen(new SolidBrush(color));
            Vector2D z = new Vector2D((float)Math.Sqrt(RADIUS * RADIUS - RADIUS * Math.Sin(ToRadians(60))), (float)(RADIUS * Math.Sin(ToRadians(60))));

            Vector2D upRight = new Vector2D(z.X, 2 * -z.Y);
            Vector2D horRight = new Vector2D(2 * z.X, 0);
            Vector2D botRight = new Vector2D(z.X, 2 * z.Y);
            Vector2D botLeft = new Vector2D(-z.X, 2 * z.Y);
            Vector2D horLeft = new Vector2D(-2 * z.X, 0);
            Vector2D upLeft = new Vector2D(-z.X, 2 * -z.Y);


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

            g.DrawPolygon(pen, points);
        }

        public static float ToRadians(float degrees)
        {
            return (float)(degrees * Math.PI / 180);
        }

        private static Color PickRandomColor()
        {
            return Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }
    }
}
