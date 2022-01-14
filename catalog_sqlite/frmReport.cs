using System;
using System.IO;
using System.Windows.Forms;

namespace catalog
{
    public partial class frmReport : Form
    {
        string fileName;
        public frmReport(string dirName)
        {
            InitializeComponent();
            fileName = dirName + "\\report";
            this.Text = "Display report";
            loadReport();
        }

        void loadReport()
        {
            if (File.Exists(fileName))
            {
                tbReport.Text = File.ReadAllText(fileName);
                tbReport.SelectionStart = tbReport.Text.Length;
                tbReport.SelectionLength = 0;
                bttnSave.Visible = true;
                bttnCreateEmptyReport.Visible = false;
            }
            else
            {
                bttnCreateEmptyReport.Visible = true;
                bttnSave.Visible = false;
                this.Text = "There is no report file to these images.";
            }
        }

        private void bttnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(fileName, tbReport.Text);
            this.Close();
        }

        private void bttnCreateEmptyReport_Click(object sender, EventArgs e)
        {
            try
            {
                File.Create(fileName).Close();
                bttnCreateEmptyReport.Visible = false;
                bttnSave.Visible = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(Path.GetFileName("'" + fileName + "' has not been created. " + err.Message));
            }
        }
    }
}
