using Giwer.dataStock;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Giwer
{
    public partial class frmMain : Form
    {
        public static readonly string WorkflowBuilderPath = Application.StartupPath + @"\workflowBuilder.exe";
        public static readonly string DataStockPath = Application.StartupPath + @"\dataStock.exe";
        public static readonly string CatalogPath = Application.StartupPath + @"\catalog.exe";

        public frmMain()
        {
            InitializeComponent();
            this.Location = Properties.Settings.Default.StartLocation;
            bttnGiwerPlant.Enabled = File.Exists(WorkflowBuilderPath);
            bttnDataStock.Enabled = File.Exists(DataStockPath);
            bttnCatalog.Enabled = File.Exists(CatalogPath);
        }

        private void ProjectBuilder_Click(object sender, EventArgs e)
        {
            if (File.Exists(WorkflowBuilderPath))
                Process.Start(WorkflowBuilderPath);
            else
                MessageBox.Show("Workflow Builder executable not found.", "Giwer", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataStock_Click(object sender, EventArgs e)
        {
            if (File.Exists(DataStockPath))
                Process.Start(DataStockPath);
            else
                MessageBox.Show("Data Stock executable not found.", "Giwer", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bttnCatalog_Click(object sender, EventArgs e)
        {
            if (File.Exists(CatalogPath))
                Process.Start(CatalogPath);
            else
                MessageBox.Show("Catalog executable not found.", "Giwer", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bttnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp();
            help.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Giwer.Properties.Settings.Default["StartLocation"] = this.Location;
            Giwer.Properties.Settings.Default.Save();
            closeOpenApps();
        }

        void closeOpenApps()
        {
            Process[] procsDataStock = Process.GetProcessesByName("dataStock");
            foreach (Process item in procsDataStock)
            {
                item.CloseMainWindow();
                item.Kill();
            }
            Process[] procsWorkflowBuilder = Process.GetProcessesByName("workflowBuilder");
            foreach (Process item in procsWorkflowBuilder)
            {
                item.CloseMainWindow();
                item.Kill();
            }
            Process[] procsCatalog = Process.GetProcessesByName("catalog");
            foreach (Process item in procsCatalog)
            {
                item.CloseMainWindow();
                item.Kill();
            }
        }


        private void bttnAbout_Click(object sender, EventArgs e)
        {
            frmAbout About = new frmAbout();
            About.Location = new Point(this.Width, 0);
            About.ShowDialog();
        }

        private void bttnConfig_Click(object sender, EventArgs e)
        {
            frmConfig ConfigDisplay = new frmConfig();
            ConfigDisplay.ShowDialog();
        }


    }
}
