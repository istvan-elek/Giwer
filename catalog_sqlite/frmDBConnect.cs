using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace catalog
{
    public partial class frmDBConnect : Form
    {
        public NpgsqlConnectionStringBuilder connsb = new NpgsqlConnectionStringBuilder();
        public frmDBConnect()
        {
            InitializeComponent();
            getPostgresUserData();
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            connsb = null;
            this.Close();
        }

        private void bttnConnect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            connsb.Database = tbdbname.Text;
            connsb.Username = tbusername.Text;
            connsb.Password = tbpw.Text;
            connsb.Host = tbhost.Text;
            connsb.Port = Convert.ToInt32(tbport.Text);
            this.Close();
        }


        void getPostgresUserData()
        {
            //connsb.Username = Properties.Settings.Default.username;
            //tbusername.Text = connsb.Username;
            //connsb.Password = Properties.Settings.Default.password;
            //tbpw.Text = connsb.Password;
            //connsb.Host = Properties.Settings.Default.hostname;
            //tbhost.Text = connsb.Host;
            //connsb.Database = Properties.Settings.Default.admindbname;
            //connsb.Port = Properties.Settings.Default.port;
            //tbport.Text = connsb.Port.ToString();
        }
    }
}
