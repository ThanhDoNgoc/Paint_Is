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
    public partial class FileUC : UserControl
    {
      
        public event EventHandler OpenClicked;
        public event EventHandler SaveClicked;
        public event EventHandler SaveAsClicked;
        public event EventHandler NewClicked;
        private static FileUC _instance;
        public static FileUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FileUC();
                return _instance;
            }
        }
        public FileUC()
        {
            InitializeComponent();
        }

        private void OpenB_Click(object sender, EventArgs e)
        {
            if (this.OpenClicked != null)
            {
                this.OpenClicked(sender, e);
            }
            
        }

        private void SaveB2_Click(object sender, EventArgs e)
        {
            if (this.SaveClicked != null)
            {
                this.SaveClicked(sender, e);
            }
        }

        private void SaveAsB_Click(object sender, EventArgs e)
        {
            if (this.SaveAsClicked != null)
            {
                this.SaveAsClicked(sender, e);
            }

        }

        private void NewB_Click(object sender, EventArgs e)
        {
            if (this.NewClicked != null)
            {
                this.NewClicked(sender, e);
            }
        }
    }
}
