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
    }
}
