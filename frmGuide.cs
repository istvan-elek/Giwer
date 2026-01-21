using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giwer
{
    public partial class frmGuide : Form
    {
        public frmGuide(string fname)
        {
            InitializeComponent();
            var uri = new Uri(fname); 
            webView21.Source = uri;
            //this.webBrowser1.Navigate(uri);            
        }

    }
}
