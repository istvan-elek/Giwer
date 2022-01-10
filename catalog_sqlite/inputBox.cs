using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catalog
{
    public partial class inputBox : Form
    {
        string mode="";
        public string inputText = "";
        public inputBox(string header)
        {
            InitializeComponent();
            mode = header;
            this.Text = header;
        }

        public inputBox(string header, string db)
        {
            InitializeComponent();
            mode = header;
            this.Text = header;
            textBox1.Text = db;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            inputText = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            inputText = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
