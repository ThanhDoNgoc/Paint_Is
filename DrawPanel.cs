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
            Point p1 = new Point(drawsurface.Width, drawsurface.Height);
            Point p2 = new Point(drawsurface.Width / 2, drawsurface.Height);
            Point p3 = new Point(drawsurface.Width, drawsurface.Height / 2);
            Point[] dragPoints = { p1, p2, p3 };

            dragRects = new Rectangle[3];

            
            for (int i = 0; i < 3; i++)
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

            if (dragHandleIndex != 4)
            {
                panelStatus = PanelStatus.Resize;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                if (panelStatus == PanelStatus.Idle)
                {
                    // return the rectangle containt the currosr
                    dragHandleIndex = dragRects.TakeWhile(rect => !rect.Contains(e.Location)).Count() + 1; 

                    switch (dragHandleIndex)
                    {
                        case 1:
                            Cursor = Cursors.SizeNWSE;
                            break;

                        case 2:
                            Cursor = Cursors.SizeNS;
                            break;

                        case 3:
                            Cursor = Cursors.SizeWE;
                            break;

                        case 4:
                            Cursor = Cursors.Default;
                            break;
                    }
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
            try
            {
                if (panelStatus == PanelStatus.Resize)
                {
                    panelStatus = PanelStatus.Idle;

                    switch (dragHandleIndex)
                    {
                        case 1:
                            drawsurface.Size = new Size(e.Location.X, e.Location.Y);
                            break;

                        case 2:
                            drawsurface.Size = new Size(drawsurface.Width, e.Location.Y);
                            break;

                        case 3:
                            drawsurface.Size = new Size(e.Location.X, drawsurface.Height);
                            break;
                    }
                    // store the current image and resize the bitmap contain image
                    Image OldImage = drawsurface.Image;
                    drawsurface.Image = new Bitmap(drawsurface.Width, drawsurface.Height);
                    // draw a new image with new size of the surface
                    Graphics g = Graphics.FromImage(drawsurface.Image);
                    g.DrawImage(OldImage, new Rectangle(0, 0, OldImage.Width, OldImage.Height));

                    if (drawsurface.Image.Width > OldImage.Width || drawsurface.Image.Height > OldImage.Height)
                    {
                        Rectangle OldSize = new Rectangle(0, 0, OldImage.Width, OldImage.Height);
                        Rectangle NewSize = new Rectangle(0, 0, drawsurface.Width, drawsurface.Height);
                        Region OldRegion = new Region(OldSize);
                        Region NewRegion = new Region(NewSize);

                        //draw the new area with the backcolor of the surface
                        NewRegion.Exclude(OldRegion);
                        SolidBrush brush = new SolidBrush(Surface.BackColor);
                        g.FillRegion(brush, NewRegion);
                    }
                }
            }
            catch { }
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
