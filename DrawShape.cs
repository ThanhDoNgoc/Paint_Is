using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    class DrawShape
    {
        public static Rectangle CreateRectangle (Point ptMouseDown, Point ptMouseCurrent)
        {
            return new Rectangle(
                Math.Min(ptMouseDown.X, ptMouseCurrent.X),
                Math.Min(ptMouseDown.Y, ptMouseCurrent.Y),
                Math.Abs(ptMouseDown.X - ptMouseCurrent.X),
                Math.Abs(ptMouseDown.Y - ptMouseCurrent.Y)
                ); ;
        }

        public static Rectangle CreateSquare(Point ptMouseDown, Point ptCurrent)
        {
            if ((ptMouseDown.X - ptCurrent.X) > Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)))
                return new Rectangle(
                    ptMouseDown.X - Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(ptMouseDown.Y, ptCurrent.Y),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                        Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));

            else if ((ptMouseDown.Y - ptCurrent.Y) > Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)))
                return new Rectangle(
                    Math.Min(ptMouseDown.X, ptCurrent.X),
                    ptMouseDown.Y - Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                    Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                    Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));

            return new Rectangle(
                Math.Min(ptMouseDown.X, ptCurrent.X),
                Math.Min(ptMouseDown.Y, ptCurrent.Y),
                Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)),
                Math.Min(Math.Abs(ptCurrent.X - ptMouseDown.X), Math.Abs(ptMouseDown.Y - ptCurrent.Y)));
        }

        private static Point[] RightArrowPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Right, rect.Top + (rect.Height / 2));
            Point p1 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p2 = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 4));
            Point p3 = new Point(rect.Left, rect.Top + (rect.Height / 4));
            Point p4 = new Point(rect.Left, rect.Bottom - (rect.Height / 4));
            Point p5 = new Point(rect.Left + (rect.Width / 2), rect.Bottom - (rect.Height / 4));
            Point p6 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6 };
            return pts;
        }

        private static Point[] LeftArrowPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p1 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p2 = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 4));
            Point p3 = new Point(rect.Right, rect.Top + (rect.Height / 4));
            Point p4 = new Point(rect.Right, rect.Bottom - (rect.Height / 4));
            Point p5 = new Point(rect.Left + (rect.Width / 2), rect.Bottom - (rect.Height / 4));
            Point p6 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6 };
            return pts;
        }

        private static Point[] UpArrowPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p1 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p2 = new Point(rect.Left + (rect.Width / 4), rect.Top + (rect.Height / 2));
            Point p3 = new Point(rect.Left + (rect.Width / 4), rect.Bottom);
            Point p4 = new Point(rect.Right - (rect.Width / 4), rect.Bottom);
            Point p5 = new Point(rect.Right - (rect.Width / 4), rect.Bottom - (rect.Height / 2));
            Point p6 = new Point(rect.Right, rect.Bottom - (rect.Height / 2));
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6 };
            return pts;
        }

        public static void Draw(Graphics g, Pen pen, Rectangle rect, Shape type)
        {
            try
            {
                Point[] pts = null;

                switch(type)
                {
                    case Shape.RecTangle:
                        g.DrawRectangle(pen, rect);
                        return;
                    case Shape.RightArrow:
                        pts = RightArrowPoints(rect);
                        return;
                }
                g.DrawPolygon(pen, pts);
            }
            catch { }
        }
    }

    public enum Shape
    {
        RecTangle, RightArrow, LeftArrow, UpArrow, DownArrow,
    }
}
