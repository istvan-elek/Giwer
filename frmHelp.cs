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
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void bttndatastock_Click(object sender, EventArgs e)
        {
            frmGuide guide = new frmGuide(Application.StartupPath + @"\giwer_ug.pdf");
            guide.Show();
        }

        private void bttnCatalog_Click(object sender, EventArgs e)
        {
            frmGuide guide = new frmGuide(Application.StartupPath + @"\catalog_ug.pdf");
            guide.Show();
        }

        private void bttnDataStockTutor_Click(object sender, EventArgs e)
        {
            frmGuide guide = new frmGuide(Application.StartupPath + @"\datastock_tutor.pdf");
            guide.Show();
        }

        private void bttnCatTutor_Click(object sender, EventArgs e)
        {
            frmGuide guide = new frmGuide(Application.StartupPath + @"\catalog_tutor.pdf");
            guide.Show();
        }

        private void bttnWfGuide_Click(object sender, EventArgs e)
        {
            frmGuide guide = new frmGuide(Application.StartupPath + @"\workflow_ug.pdf");
            guide.Show();
        }

        private void bttnWfTutor_Click(object sender, EventArgs e)
        {
            frmGuide guide = new frmGuide(Application.StartupPath + @"\workflow_tutor.pdf");
            guide.Show();
        }
    }
}
