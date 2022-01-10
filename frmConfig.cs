using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Giwer
{
    public partial class frmConfig : Form
    {
        //public string[] config;
        Dictionary<string, string> config = new Dictionary<string, string>();
        public frmConfig()
        {
            InitializeComponent();
            readConfig();
        }

        void readConfig()
        {
            var sarray = File.ReadAllLines(Application.StartupPath + @"\config.cfg");
            for (int i=0; i<sarray.Length; i++)
            {
               config.Add(sarray[i].Split(',')[0], sarray[i].Split(',')[1]);
            }
            dgv.DataSource = config;
            //dgv.Rows[0].ReadOnly = true;
            //dgv.Columns[0].ReadOnly = true;
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //config[e.RowIndex + 1] = dgv.Rows[e.RowIndex].Cells[0].Value.ToString() + "," + dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                saveConfig();
            }
        }

        void saveConfig()
        {
            //File.WriteAllLines(Application.StartupPath + @"\config.cfg", config);
        }
    }
}
