using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Giwer
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            lblDesc.Text = "This program is the Giwer (GeoImage Workflow Editing Resources). It contains many functions for handling satellite and drone images. You can use it interactively, run the built-in workflows or create your own, which can be constructed from the available functions.";
            lblCompanyName.Text = "Company name: " + Application.CompanyName;
            lblVersionGiwer.Text = "Giwer version: " + Application.ProductVersion;
            var versInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\datastock.exe");
            lblVersionDataStock.Text = "DataStock version: " + versInfo.ProductVersion;
            versInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\catalog.exe");
            lblVersionCatalog.Text = "Catalog version: " + versInfo.ProductVersion;
            versInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\workflowbuilder.exe");
            lblVersionProjectBuilder.Text = "WorkflowBuilder version: " + versInfo.ProductVersion;
            lblCopyright.Text = "Copyright \u00A9 István Elek, 2019, 2020, 2021, 2022 " + Environment.NewLine + "          and    Máté Cserép, 2021, 2022" + Environment.NewLine + "          and    Dávid Borbély, 2021" + Environment.NewLine + "          and    Tamás Tarczali, 2021";
            lblProductName.Text = "Product name: " + Application.ProductName;
        }
    }
}
