using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class PenUC : UserControl
    {
        private static PenUC _instance;
        public static PenUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PenUC();
                return _instance;
            }
        }
        //butons
        public event EventHandler PencilClicked;
        public event EventHandler BrushClicked;
        public event EventHandler BucketClicked;
        public Image getPencil()
        {
            return PencilB.BackgroundImage;
        }
        public Image getBrush()
        {
            return BrushB.BackgroundImage;
        }
        public Image getBucket()
        {
            return BucketB.BackgroundImage;
        }
        //color
        public event EventHandler WhiteClicked;
        public event EventHandler RedClicked;
        public event EventHandler YellowClicked;
        public event EventHandler OrangeClicked;
        public event EventHandler BlackClicked;
        public event EventHandler GreenClicked;
        public event EventHandler BlueClicked;
        public event EventHandler PurpleClicked;
        public Color getWhite()
        {
            return ptbWhite.BackColor;
        }
        public Color getRed()
        {
            return Color.Red;
        }
        public Color getYellow()
        {
            return Color.Yellow;
        }
        public Color getOrange()
        {
            return Color.Orange;
        }
        public Color getGreen()
        {
            return Color.Green;
        }
        public Color getBlue()
        {
            return Color.Blue;
        }
        public Color getPurple()
        {
            return Color.Purple;
        }
        public Color getBlack()
        {

            return Color.Black;
        }
        public PenUC()
        {
            InitializeComponent();
        }

        private void PencilB_Click(object sender, EventArgs e)
        {
            if (this.PencilClicked != null)
            {
                this.PencilClicked(sender, e);
            }
        }

        private void BrushB_Click(object sender, EventArgs e)
        {
            if (this.BrushClicked != null)
            {
                this.BrushClicked(sender, e);
            }
        }

        private void BucketB_Click(object sender, EventArgs e)
        {
            if (this.BucketClicked != null)
            {
                this.BucketClicked(sender, e);
            }
        }

        private void ptbWhite_Click(object sender, EventArgs e)
        {
            if (this.WhiteClicked != null)
            {
                this.WhiteClicked(sender, e);
            }
        }

        private void ptbRed_Click(object sender, EventArgs e)
        {
            if (this.RedClicked != null)
            {
                this.RedClicked(sender, e);
            }
        }

        private void ptbYellow_Click(object sender, EventArgs e)
        {
            if (this.YellowClicked != null)
            {
                this.YellowClicked(sender, e);
            }
        }

        private void ptbOrange_Click(object sender, EventArgs e)
        {
            if (this.OrangeClicked != null)
            {
                this.OrangeClicked(sender, e);
            }
        }

        private void ptbBlack_Click(object sender, EventArgs e)
        {
            if (this.BlackClicked != null)
            {
                this.BlackClicked(sender, e);
            }
        }

        private void ptbGreen_Click(object sender, EventArgs e)
        {
            if (this.GreenClicked != null)
            {
                this.GreenClicked(sender, e);
            }
        }

        private void ptbBlue_Click(object sender, EventArgs e)
        {
            if (this.BlueClicked != null)
            {
                this.BlueClicked(sender, e);
            }
        }

        private void ptbPurple_Click(object sender, EventArgs e)
        {
            if (this.PurpleClicked != null)
            {
                this.PurpleClicked(sender, e);
            }
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Test.PenSize = metroTrackBar1.Value;
        }
    }
}

