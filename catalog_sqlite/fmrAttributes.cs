using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace catalog
{
    public partial class frmAttributes : Form
    {
        public string meteo="";
        public string author = "";
        public string content = "";
        public string purpose = "";
        public Boolean publi = false;
        public string tipus = "";
        public string loc = "";
        public string comment = "";
        public string drontype = "";
        public string opera = "";
        public frmAttributes(string[] columns)
        {
            InitializeComponent();
            fillAttributeNames(columns);
        }


        void fillAttributeNames(string[] cols)
        {
            foreach (string item in cols)
            {
                if (item != "public") { dgvattributes.Rows.Add(item); }
                else dgvattributes.Rows.Add("public", publi.ToString());
            }
            
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvattributes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "meteo") meteo = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "author") author = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "location") loc = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "content") content = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "purpose") purpose = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "public") publi = Convert.ToBoolean(dgvattributes.Rows[e.RowIndex].Cells[1].Value);
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "type") tipus = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "comment") comment = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "dron_type") drontype = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvattributes.Rows[e.RowIndex].Cells[0].Value.ToString() == "operator") opera = dgvattributes.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void dgvattributes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvattributes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            if (dgvattributes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "public")
            {
                publi = !publi;
                dgvattributes.Rows[e.RowIndex].Cells[1].Value = publi.ToString();
            }
        }
    }
}
