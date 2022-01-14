using System;
using System.Windows.Forms;

namespace Giwer
{
    public partial class frmGuide : Form
    {
        public frmGuide(string fname)
        {
            InitializeComponent();
            var uri = new Uri(fname);
            this.webBrowser1.Navigate(uri);
        }

    }
}
