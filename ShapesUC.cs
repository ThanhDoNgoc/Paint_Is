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
    public partial class ShapesUC : UserControl
    {
        private static ShapesUC _instance;
        public static ShapesUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ShapesUC();
                return _instance;
            }
        }
        //buttons
        public event EventHandler LineClicked;
        public event EventHandler CircleClicked;
        public event EventHandler StarClicked;
        public event EventHandler RectangleClicked;
        public event EventHandler PentagonClicked;
        public event EventHandler HexagonClicked;
        public event EventHandler RightArrowClicked;
        public event EventHandler LeftArrowClicked;
        public event EventHandler TriangleClicked;

        public Image getLine()
        {
            return LineB.BackgroundImage;
        }

        public Image getCircle()
        {
            return CircleB.BackgroundImage;
        }
        public Image getStar()
        {
            return StarB.BackgroundImage;
        }
        public Image getTriangle()
        {
            return TriangleB.BackgroundImage;
        }
        public Image getRectangle()
        {
            return RectangleB.BackgroundImage;
        }
        public Image getPentagon()
        {
            return PentagonB.BackgroundImage;
        }
        public Image getHexagon()
        {
            return HexagonB.BackgroundImage;
        }
        public Image getRightArrow()
        {
            return ArrowRB.BackgroundImage;
        }
        public Image getLeftArrow()
        {
            return ArrowLB.BackgroundImage;
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
        public ShapesUC()
        {
            InitializeComponent();
        }

        private void ShapesUC_Load(object sender, EventArgs e)
        {

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

        private void LineB_Click(object sender, EventArgs e)
        {
            if (this.LineClicked != null)
            {
                this.LineClicked(sender, e);

            }
        }

        private void CircleB_Click(object sender, EventArgs e)
        {
            if (this.CircleClicked != null)
            {
                this.CircleClicked(sender, e);
            }
        }

        private void StarB_Click(object sender, EventArgs e)
        {
            if (this.StarClicked != null)
            {
                this.StarClicked(sender, e);
            }
        }

        private void TriangleB_Click(object sender, EventArgs e)
        {
            if (this.TriangleClicked != null)
            {
                this.TriangleClicked(sender, e);
            }
        }

        private void RectangleB_Click(object sender, EventArgs e)
        {
            if (this.RectangleClicked != null)
            {
                this.RectangleClicked(sender, e);
            }
        }

        private void PentagonB_Click(object sender, EventArgs e)
        {
            if (this.PentagonClicked != null)
            {
                this.PentagonClicked(sender, e);
            }
        }

        private void HexagonB_Click(object sender, EventArgs e)
        {
            if (this.HexagonClicked != null)
            {
                this.HexagonClicked(sender, e);
            }
        }

        private void ArrowRB_Click(object sender, EventArgs e)
        {
            if (this.RightArrowClicked != null)
            {
                this.RightArrowClicked(sender, e);
            }
        }

        private void ArrowLB_Click(object sender, EventArgs e)
        {
            if (this.LeftArrowClicked != null)
            {
                this.LeftArrowClicked(sender, e);
            }
        }
    }
}
