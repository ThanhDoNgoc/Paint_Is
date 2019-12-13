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
    public partial class Test : MetroFramework.Forms.MetroForm
    {
        Surface surface;
        public static Shape CurrentShape { get; set; }
        public static BrushType CurrentBrush { get; set; }
        public static BrushType PenBrush { get; set; }
        public static Color color{ get; set; }
        public event EventHandler PanelPaint;
        int PenSize;

        public Test()
        {
            InitializeComponent();
            penUC1.Visible = false;
            fileUC1.Visible = false;
            surface = drawPanel1.Surface;
            surface.MouseDown += Surface_MouseDown;
            surface.MouseMove += Surface_MouseMove;
            surface.MouseLeave += Surface_MouseLeave;
            surface.SizeChanged += Surface_SizeChange;

            //đổi ảnh button
            penUC1.PencilClicked += PenUC1_PencilClicked;
            penUC1.BrushClicked += PenUC1_BrushClicked;
            penUC1.BucketClicked += PenUC1_BucketClicked;
            //đổi màu button
            penUC1.WhiteClicked += PenUC1_WhiteClicked;
            penUC1.RedClicked += PenUC1_RedClicked;
            penUC1.YellowClicked += PenUC1_YellowClicked;
            penUC1.OrangeClicked += PenUC1_OrangeClicked;
            penUC1.BlackClicked += PenUC1_BlackClicked;
            penUC1.BlueClicked += PenUC1_BlueClicked;
            penUC1.GreenClicked += PenUC1_GreenClicked;
            penUC1.PurpleClicked += PenUC1_PurpleClicked;
            //Open file
            fileUC1.OpenClicked += FileUC1_OpenClicked;
            //always start with pencil
            CurrentBrush = BrushType.Pencil;
        }

        private void FileUC1_OpenClicked(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void PenUC1_PurpleClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getPurple();
        }

        private void PenUC1_GreenClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getGreen();
        }

        private void PenUC1_BlueClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getBlue();
        }

        private void PenUC1_BlackClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getBlack();
        }

        private void PenUC1_OrangeClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getOrange();
        }

        private void PenUC1_YellowClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getYellow();
        }

        private void PenUC1_RedClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getRed();
        }

        private void PenUC1_WhiteClicked(object sender, EventArgs e)
        {
            PenB.BackColor = PenUC.Instance.getWhite();
        }

        private void PenUC1_BucketClicked(object sender, EventArgs e)
        {
            PenB.Text = "";
            PenB.BackgroundImage = PenUC.Instance.getBucket();
            Test.CurrentBrush = BrushType.Bucket;
            PenBrush = CurrentBrush;
        }

        private void PenUC1_BrushClicked(object sender, EventArgs e)
        {
            PenB.Text = "";
            PenB.BackgroundImage = PenUC.Instance.getBrush();
            Test.CurrentBrush = BrushType.Brush;
            PenBrush = CurrentBrush;
        }

        private void PenUC1_PencilClicked(object sender, EventArgs e)
        {
            PenB.Text = "";
            PenB.BackgroundImage = PenUC.Instance.getPencil();
            Test.CurrentBrush = BrushType.Pencil;
            PenBrush = CurrentBrush;
        }

        private void Surface_SizeChange(object sender, EventArgs e)
        {
            drawPanel1.Refresh();
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Surface_MouseDown(object sender, MouseEventArgs e)
        {
            color = Color.Black;
            PenSize = 1000;
        }

        private void Surface_MouseMove(object sender, MouseEventArgs e)
        {

        }
    
        private void EraserB_Click(object sender, EventArgs e)
        {
            Test.CurrentBrush = BrushType.Eraser;
        }
        void HideAllPanels()
        {
            shapesUC1.Visible = false;
            penUC1.Visible = false;
            fileUC1.Visible = false;
        }
        private void FileB_Click(object sender, EventArgs e)
        {
            if (!fileUC1.Visible)
            {
                HideAllPanels();              
                Transition1.ShowSync(fileUC1, false, BunifuAnimatorNS.Animation.HorizSlide);
            }
            else
            {               
                Transition1.HideSync(fileUC1, false, BunifuAnimatorNS.Animation.HorizSlide);
            }
        }

        private void PenB_Click(object sender, EventArgs e)
        {
            if (!penUC1.Visible)
            {
                HideAllPanels();
                Transition1.ShowSync(penUC1, false, BunifuAnimatorNS.Animation.HorizSlide);
            }
            else if (penUC1.Visible && CurrentBrush == BrushType.Eraser)
            {
                CurrentBrush = PenBrush;
            }
            else
                Transition1.HideSync(penUC1, false, BunifuAnimatorNS.Animation.HorizSlide);
        }

        private void EraserB_Click_1(object sender, EventArgs e)
        {
            Test.CurrentBrush = BrushType.Eraser;
        }

        private void drawPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.PanelPaint != null)
                this.PanelPaint(sender, e);
        }

        private void UndoB_Click(object sender, EventArgs e)
        {
            surface.UndoPress();
        }

        private void RedoB_Click(object sender, EventArgs e)
        {
            surface.RedoPress();
        }

        private void ShapesB_Click(object sender, EventArgs e)
        {
            if (!shapesUC1.Visible)
            {
                HideAllPanels();
                Transition1.ShowSync(shapesUC1, false, BunifuAnimatorNS.Animation.HorizSlide);
            }
            else
                Transition1.HideSync(shapesUC1, false, BunifuAnimatorNS.Animation.HorizSlide);
        }
    }
}
