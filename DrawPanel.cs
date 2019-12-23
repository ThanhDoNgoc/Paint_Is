using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class DrawPanel : Panel
    {

        #region Component

        int dragHandleIndex;
        Rectangle[] dragRects;
        Surface drawsurface;
        PanelStatus panelStatus;

        #endregion

        public Surface Surface { get => drawsurface; }


        public DrawPanel()
        {
            Controls.Add(drawsurface = new Surface());

        }

        #region Init square
        void InitDragRectangles()
        {
            Point p1 = new Point(drawsurface.Right, drawsurface.Bottom);
            Point p2 = new Point(drawsurface.Left - 6, drawsurface.Top - 6);
            Point p3 = new Point(drawsurface.Left - 6, drawsurface.Bottom);
            Point p4 = new Point(drawsurface.Right, drawsurface.Top - 6);
            Point[] dragPoints = { p1, p2, p3, p4 };

            dragRects = new Rectangle[4];


            for (int i = 0; i < 4; i++)
            {
                dragRects[i] = new Rectangle(dragPoints[i], new Size(5, 5));
            }
        }
        #endregion

        #region draw draging square
        void DrawDragRects(Graphics _g)
        {
            InitDragRectangles();
            _g.FillRectangles(new SolidBrush(Color.White), dragRects);
            _g.DrawRectangles(new Pen(Color.Black), dragRects);
        }
        #endregion

        #region Mouse activity
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (dragHandleIndex != 5)
            {
                panelStatus = PanelStatus.Resize;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                switch (panelStatus)
                {
                    case PanelStatus.Idle:
                        // return the rectangle containt the currosr
                        dragHandleIndex = dragRects.TakeWhile(rect => !rect.Contains(e.Location)).Count() + 1;

                        switch (dragHandleIndex)
                        {
                            case 1:
                                Cursor = Cursors.SizeNWSE;
                                break;
                            case 2:
                                Cursor = Cursors.SizeNWSE;
                                break;
                            case 3:
                                Cursor = Cursors.SizeNESW;
                                break;
                            case 4:
                                Cursor = Cursors.SizeNESW;
                                break;
                            case 5:
                                Cursor = Cursors.Default;
                                break;
                        }
                        break;
                    case PanelStatus.Resize:
                        switch (dragHandleIndex)
                        {
                            case 1:
                                drawsurface.Size = new Size(e.X - drawsurface.Left, e.Y - drawsurface.Top);
                                break;
                            case 2:

                                drawsurface.Size = new Size(-(e.X - drawsurface.Left) + drawsurface.Width, -(e.Y - drawsurface.Top) + drawsurface.Height);
                                drawsurface.Location = e.Location;
                                break;
                            case 3:
                                drawsurface.Size = new Size(drawsurface.Left + drawsurface.Width - e.X, e.Y - drawsurface.Top);
                                drawsurface.Location = new Point(e.X, drawsurface.Top);
                                break;
                            case 4:
                                drawsurface.Size = new Size(e.X - drawsurface.Left, drawsurface.Top + drawsurface.Height - e.Y);
                                drawsurface.Location = new Point(drawsurface.Left, e.Y);
                                break;
                        }
                        break;
                }
            }
            catch { }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawDragRects(e.Graphics);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            /*if (panelStatus == PanelStatus.Resize)
            {
                panelStatus = PanelStatus.Idle;

                switch (dragHandleIndex)
                {
                    case 1:
                        drawsurface.Size = new Size(e.X - drawsurface.Left, e.Y - drawsurface.Top);
                        break;
                    case 2:

                        drawsurface.Size = new Size(-(e.X - drawsurface.Left) + drawsurface.Width, -(e.Y - drawsurface.Top) + drawsurface.Height);
                        drawsurface.Location = e.Location;
                        break;
                    case 3:
                        drawsurface.Size = new Size(drawsurface.Left + drawsurface.Width - e.X, e.Y - drawsurface.Top);
                        drawsurface.Location = new Point(e.X, drawsurface.Top);
                        break;
                    case 4:
                        drawsurface.Size = new Size(e.X - drawsurface.Left, drawsurface.Top + drawsurface.Height - e.Y);
                        drawsurface.Location = new Point(drawsurface.Left, e.Y);
                        break;
                }*/
                
            if (panelStatus == PanelStatus.Resize) 
            {
                panelStatus = PanelStatus.Idle;
            }
                    // store the current image and resize the bitmap contain image
                    Image OldImage = drawsurface.Image;
                    drawsurface.Image = new Bitmap(drawsurface.Width, drawsurface.Height);
                    // draw a new image with new size of the surface
                    Graphics g = Graphics.FromImage(drawsurface.Image);
                    g.DrawImage(OldImage, new Rectangle(0, 0, OldImage.Width, OldImage.Height));

                    drawsurface.PushRedo(drawsurface.Image);
        
            this.Refresh();
        }
        #endregion
    }

    enum PanelStatus
    {
        Idle,
        Resize
    };
}
