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

        private static Point MouseDown, MouseCurrent;
        public static Rectangle CreateRectangle(Point ptMouseDown, Point ptMouseCurrent)
        {
            MouseDown = ptMouseDown;
            MouseCurrent = ptMouseCurrent;
            return new Rectangle(
                Math.Min(ptMouseDown.X, ptMouseCurrent.X),
                Math.Min(ptMouseDown.Y, ptMouseCurrent.Y),
                Math.Abs(ptMouseDown.X - ptMouseCurrent.X),
                Math.Abs(ptMouseDown.Y - ptMouseCurrent.Y)
                ); ;
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

        private static Point[] DownArrowPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            Point p1 = new Point(rect.Left, rect.Top + (rect.Height / 2));
            Point p2 = new Point(rect.Left + (rect.Width / 4), rect.Top + (rect.Height / 2));
            Point p3 = new Point(rect.Left + (rect.Width / 4), rect.Top);
            Point p4 = new Point(rect.Right - (rect.Width / 4), rect.Top);
            Point p5 = new Point(rect.Right - (rect.Width / 4), rect.Bottom - (rect.Height / 2));
            Point p6 = new Point(rect.Right, rect.Bottom - (rect.Height / 2));
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

        private static Point[] TrianglePoint(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + (rect.Width / 2), rect.Top);
            Point p1 = new Point(rect.Left, rect.Bottom);
            Point p2 = new Point(rect.Right, rect.Bottom);
            Point[] pts = { p0, p1, p2 };
            return pts;
        }

        private static Point[] HexagonPoint(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + rect.Width / 2, rect.Top);
            Point p1 = new Point(rect.Right, rect.Top + rect.Height / 3);
            Point p2 = new Point(rect.Right, rect.Top + 2*rect.Height / 3);
            Point p3 = new Point(rect.Left + rect.Width / 2, rect.Bottom);
            Point p4 = new Point(rect.Left, rect.Top + 2*rect.Height / 3);
            Point p5 = new Point(rect.Left, rect.Top + rect.Height / 3);
            Point[] pts = { p0, p1, p2, p3, p4, p5 };
            return pts;
        }

        private static Point[] PentagonPoint(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + rect.Width / 2, rect.Top);
            Point p1 = new Point(rect.Left, rect.Top + (11 * rect.Height / 30));
            Point p2 = new Point(rect.Left + rect.Width / 5, rect.Bottom);
            Point p3 = new Point(rect.Right - rect.Width / 5, rect.Bottom);
            Point p4 = new Point(rect.Right, rect.Top + (11 * rect.Height / 30));
            Point[] pts = { p0, p1, p2, p3, p4 };
            return pts;
        }

        private static Point[] StarPoints(Rectangle rect)
        {
            Point p0 = new Point(rect.Left + rect.Width / 2, rect.Top);
            Point p1 = new Point(rect.Left + 3 * rect.Width / 8, rect.Top + rect.Height / 3);
            Point p2 = new Point(rect.Left, rect.Top + (11 * rect.Height / 30));
            Point p3 = new Point(rect.Left + rect.Width / 4, rect.Bottom - (2 * rect.Height / 5));
            Point p4 = new Point(rect.Left + rect.Width / 5, rect.Bottom);
            Point p5 = new Point(rect.Left + rect.Width / 2, rect.Bottom - (rect.Height / 5));
            Point p6 = new Point(rect.Right - rect.Width / 5, rect.Bottom);
            Point p7 = new Point(rect.Right - rect.Width / 4, rect.Bottom - (2 * rect.Height / 5));
            Point p8 = new Point(rect.Right, rect.Top + (11 * rect.Height / 30));
            Point p9 = new Point(rect.Right - 3 * rect.Width / 8, rect.Top + rect.Height / 3);
            Point[] pts = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 };
            return pts;
        }

        public static void Draw(Graphics g, Pen pen, Rectangle rect, Shape type)
        {

            Point[] pts = null;

            switch (type)
            {
                case Shape.RecTangle:
                    g.DrawRectangle(pen, rect);
                    return;
                case Shape.Circle:
                    g.DrawEllipse(pen, rect);
                    return;
                case Shape.Line:
                    pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLine(pen, MouseDown, MouseCurrent);
                    return;
                case Shape.RightArrow:
                    pts = RightArrowPoints(rect);
                    break;
                case Shape.LeftArrow:
                    pts = LeftArrowPoints(rect);
                    break;
                case Shape.DownArrow:
                    pts = DownArrowPoints(rect);
                    break;
                case Shape.UpArrow:
                    pts = UpArrowPoints(rect);
                    break;
                case Shape.Triangle:
                    pts = TrianglePoint(rect);
                    break;
                case Shape.Hexagon:
                    pts = HexagonPoint(rect);
                    break;
                case Shape.Pentagon:
                    pts = PentagonPoint(rect);
                    break;
                case Shape.Star:
                    pts = StarPoints(rect);
                    break;
            }
            if (pts != null)
            g.DrawPolygon(pen, pts);
        }
    }

    public enum Shape
    {
        RecTangle, RightArrow, LeftArrow, UpArrow, DownArrow, Circle, Star, Triangle, Pentagon, Hexagon, Line
    }
}
