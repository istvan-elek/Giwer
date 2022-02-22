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
            cmbTutorLanguage.SelectedIndex = 0;
            cmbUsersguideLanguage.SelectedIndex = 0;
        }


        private void cmbUsersguideLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsersguideLanguage.SelectedIndex == 0)
            {
                bttnGiwerUG.Text = "Felhasználói leírás";
            }
            else
            {
                bttnGiwerUG.Text = "Users' guide";
            }
        }

        private void cmbTutorLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTutorLanguage.SelectedIndex == 0)
            {
                bttnTutor.Text = "Gyakorlás";
            }
            else
            {
                bttnTutor.Text = "Tutorial";
            }
        }

        private void bttnGiwerUG_Click(object sender, EventArgs e)
        {
            if (cmbUsersguideLanguage.SelectedIndex == 0)
            {
                frmGuide guide = new frmGuide(Application.StartupPath + @"\giwer_ug_hu.pdf");
                guide.Show();
            }
            else
            {
                frmGuide guide = new frmGuide(Application.StartupPath + @"\giwer_ug_eng.pdf");
                guide.Show();
            }
        }

        private void bttnTutor_Click(object sender, EventArgs e)
        {
            if (cmbTutorLanguage.SelectedIndex == 0)
            {
                frmGuide guide = new frmGuide(Application.StartupPath + @"\tutor_hu.pdf");
                guide.Show();
            }
            else
            {
                frmGuide guide = new frmGuide(Application.StartupPath + @"\tutor_eng.pdf");
                guide.Show();
            }
        }
    }
}
