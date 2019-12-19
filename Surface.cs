using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Paint
{
    public partial class Surface : PictureBox
    {
        #region Component
        int Draghandle;

        Rectangle OldRect;
        Rectangle AreaRect;

        Graphics grp;
        Pen pen;
        Color color;
        int Pensize;

        DrawStatus CurrentStatus;

        Stack<Bitmap> Undo;
        Stack<Bitmap> Redo;

        Point MouseDown;
        Shape shape;
        #endregion
        //List<Point> points = null;


        #region Init Surface
        public Surface()
        {
            InitializeComponent();
            Undo = new Stack<Bitmap>();
            Redo = new Stack<Bitmap>();

            Location = new Point(100, 100);
            Size = new Size(100, 100);
            Image = new Bitmap(Width, Height);
            BackColor = Color.Yellow;

            Region region = new Region(new Rectangle(0, 0, Width, Height));
            grp = Graphics.FromImage(Image);

        }

        #endregion

        #region Paint and Mouse Control
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseDown = e.Location;

            switch (CurrentStatus)
            {
                case DrawStatus.Idle:

                    if (e.Button == MouseButtons.Left)
                    {
                        color = Test.color;
                        Pensize = Test.PenSize;
                    }
                    SetGraphics();
                    Cursor = Cursors.Cross;
                    break;
                #region undone 
                case DrawStatus.Edit:
                    if (Draghandle != 9)
                    {
                        OldRect = AreaRect;
                        CurrentStatus = DrawStatus.Resizing;
                    }
                    else if (AreaRect.Contains(e.Location))
                    {
                        OldRect = AreaRect;
                        CurrentStatus = DrawStatus.Moving;
                    }
                    else
                    {
                        CurrentStatus = DrawStatus.Idle;
                        grp = Graphics.FromImage(Image);

                        DrawShape.Draw(grp, pen, AreaRect, Test.CurrentShape);
                        Redo.Push(new Bitmap(Image));

                        DrawShape.Draw(grp, pen, AreaRect, shape);
                        AreaRect = Rectangle.Empty;
                        this.Refresh();
                    }
                    break;
                    #endregion
            }
        }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            switch (CurrentStatus)
            {
                case DrawStatus.ToolDraw:
                    DrawDrag(MouseDown, e.Location, Test.CurrentBrush);
                    MouseDown = e.Location;
                    break;
                //ongoing
                case DrawStatus.ShapeDraw:
                    AreaRect = DrawShape.CreateRectangle(MouseDown, e.Location);
                    break;
                case DrawStatus.Edit:
                    Draghandle = Edit.GetDragHandle(e.Location, AreaRect);
                    if (Draghandle < 9)
                    {
                        UpdateCursors();
                    }
                    else if (AreaRect.Contains(e.Location))
                    {
                        Cursor = Cursors.SizeAll;
                    }
                    else Cursor = Cursors.Default;
                    break;
                case DrawStatus.Resizing:
                    Edit.UpdateResizeRect(ref AreaRect, OldRect, MouseDown, e.Location, Draghandle);
                    break;

                case DrawStatus.Moving:
                    Edit.UpdateMoveRect(ref AreaRect, OldRect, MouseDown, e.Location);
                    break;
            }
            this.Refresh();
        }



        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            switch (CurrentStatus)
            {
                case DrawStatus.ToolDraw:
                    CurrentStatus = DrawStatus.Idle;
                    Redo.Push(new Bitmap(Image));
                    Cursor = Cursors.Default;
                    break;
                    //ongoing
            }
        }

        private void SetGraphics()
        {
            switch (Test.CurrentBrush)
            {
                case BrushType.Pencil:
                    Undo.Push(new Bitmap(Image));
                    Redo.Clear();
                    pen = new Pen(color, 10);
                    pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    CurrentStatus = DrawStatus.ToolDraw;
                    break;
                case BrushType.Eraser:
                    Undo.Push(new Bitmap(Image));
                    Redo.Clear();
                    pen = new Pen(Color.Transparent, 10);
                    pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    grp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    CurrentStatus = DrawStatus.ToolDraw;
                    break;
                case BrushType.Bucket:
                    Undo.Push(new Bitmap(Image));
                    Redo.Clear();
                    FloodFill(MouseDown, color);
                    Redo.Push(new Bitmap(Image));
                    break;
                case BrushType.Brush:
                    Undo.Push(new Bitmap(Image));
                    Redo.Clear();
                    pen = new Pen(Color.FromArgb(10, color), 10);
                    pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    //grp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    CurrentStatus = DrawStatus.ToolDraw;
                    break;
                case BrushType.Picker:
                    // ongoing
                    break;
            }
        }

        #endregion
        //bucket
        private void FloodFill(Point node, Color replaceColor)
        {

            Bitmap DrawBitmap = new Bitmap(Image);
            Color targetColor = DrawBitmap.GetPixel(node.X, node.Y);

            if (targetColor.ToArgb() == replaceColor.ToArgb())
                return;

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(node);

            while (pixels.Count != 0)
            {
                Point floodNode = pixels.Pop();
                Color floodColor = DrawBitmap.GetPixel(floodNode.X, floodNode.Y);

                if (floodColor == targetColor)
                {
                    DrawBitmap.SetPixel(floodNode.X, floodNode.Y, replaceColor);

                    if (floodNode.X != 0)
                        pixels.Push(new Point(floodNode.X - 1, floodNode.Y));

                    if (floodNode.X + 1 < Width)
                        pixels.Push(new Point(floodNode.X + 1, floodNode.Y));

                    if (floodNode.Y != 0)
                        pixels.Push(new Point(floodNode.X, floodNode.Y - 1));

                    if (floodNode.Y + 1 < Height)
                        pixels.Push(new Point(floodNode.X, floodNode.Y + 1));
                }
            }
            Image = DrawBitmap;
        }
        //chuột kéo 
        private void DrawDrag(Point mouseDown, Point location, BrushType currentBrush)
        {
            switch (currentBrush)
            {

                case BrushType.Pencil:
                    //grp = CreateGraphics();
                    grp = Graphics.FromImage(Image);
                    grp.DrawLine(pen, mouseDown, location);
                    // grp.SmoothingMode = 
                    break;
                case BrushType.Eraser:
                    //grp = CreateGraphics();
                    grp = Graphics.FromImage(Image);
                    grp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    grp.DrawLine(pen, mouseDown, location);
                    break;
                case BrushType.Brush:
                    //GraphicsPath path = new GraphicsPath();     
                    grp = Graphics.FromImage(Image);
                    //grp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

                    //for (int i=0;i<points.Count;i++)
                    //pen.LineJoin = LineJoin.Round;
                    grp.DrawLine(pen, mouseDown, location);


                    break;
                    //ongoing
            }
        }

        private void UpdateCursors()
        {
           switch (Draghandle)
            {
                case 1:
                case 8:
                    Cursor = Cursors.SizeNWSE;
                    break;

                case 2:
                case 7:
                    Cursor = Cursors.SizeWE;
                    break;

                case 3:
                case 6:
                    Cursor = Cursors.SizeNESW;
                    break;

                case 4:
                case 5:
                    Cursor = Cursors.SizeNS;
                    break;
            }
        }

        #region Undo & Redo
        public void UndoPress()
        {
            if (Undo.Count > 0)
            {
                Redo.Push(Undo.Peek());
                Image = Undo.Peek();
                Size = Undo.Pop().Size;
            }
        }

        public void RedoPress()
        {
            if (Redo.Count > 1)
            {
                Undo.Push(Redo.Pop());
                Image = Redo.Peek();
                Size = Image.Size;
            }
        }

        public void PushUndo(Image img)
        {
            Undo.Push(new Bitmap(img));
        }

        public void PushRedo(Image img)
        {
            Redo.Push(new Bitmap(img));
        }
        #endregion
    }
    public enum BrushType
    {
        Pencil, Eraser, Brush, Bucket, Shape, Picker
    }
    enum DrawStatus
    {
        Idle, LineDraw, ToolDraw, ShapeDraw, Edit, Resizing, Moving
    }
}
