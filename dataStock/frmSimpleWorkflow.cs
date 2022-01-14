using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmSimpleWorkflow : Form
    {
        Project curProject = new Project();
        SimpleWorkflow sworkflow = new SimpleWorkflow();
        //string wkfName;
        BindingSource bs = new BindingSource();
        DataTable AllRows;

        void printProjectData(string fname)
        {
            tbProjData.Text = "#Project_file_name: " + curProject.ProjectFileName + Environment.NewLine;
            tbProjData.AppendText("#Project description: " + curProject.ProjectDescription + Environment.NewLine);
            tbProjData.AppendText("#Files:" + Environment.NewLine);
            tbProjData.AppendText(string.Join(Environment.NewLine, curProject.FileNames));
            tbProjData.AppendText(Environment.NewLine + "#Config_data:" + Environment.NewLine);
            tbProjData.AppendText("BilDataFolder:" + curProject.BilDataFolder + Environment.NewLine);
            tbProjData.AppendText("JpgDataFolder:" + curProject.JpgDataFolder + Environment.NewLine);
            tbProjData.AppendText("TifDataFolder:" + curProject.TifDataFolder + Environment.NewLine);
            tbProjData.AppendText("DtmDataFolder:" + curProject.DtmDataFolder + Environment.NewLine);
            tbProjData.AppendText("GiwerDataFolder:" + curProject.GiwerDataFolder);
        }

        public frmSimpleWorkflow(string fname)
        {
            InitializeComponent();
            if (System.IO.Path.GetExtension(fname) == ".proj") // if file extension is .proj
            {
                curProject.ProjectFileName = fname;
                printProjectData(fname);
            }
            else // if file extension is .wkf
            {
                sworkflow.NameOfWorkflow = fname;
                curProject.ProjectFileName = sworkflow.NameOfProject;
                tbWorkflowData.Text = "#Workflow_name: " + sworkflow.NameOfWorkflow;
                tbWorkflowData.AppendText(Environment.NewLine + "#Workflow_description: " + sworkflow.WorkflowDescription);
                tbWorkflowData.AppendText(Environment.NewLine + "#Project_file: " + sworkflow.NameOfProject);
                tbWorkflowData.AppendText(Environment.NewLine + "#Files:" + Environment.NewLine);
                tbWorkflowData.AppendText(string.Join(Environment.NewLine, sworkflow.FileNames));
                tbWorkflowData.AppendText(Environment.NewLine + "#Methods:" + Environment.NewLine);
                tbWorkflowData.AppendText(string.Join(Environment.NewLine, sworkflow.MethodNames));
                tabProjdata.SelectedTab = tabProjdata.TabPages["tabViewWorkflow"];
                pg.SelectedObject = sworkflow;
                setpgColumnWidth(pg, 120);
                printProjectData(curProject.ProjectFileName);
            }
            foreach (string item in sworkflow.MethodNames)
            {
                lstSelectedFunctions.Items.Add(item);
            }
            //tabProjdata.SelectedTab = tabProjdata.TabPages["tabGiwerFunctions"];
            cmbGroups.SelectedIndex = 0;
            AllRows = FillDataTablewithAvailableMethods();
            bs.DataSource = AllRows;
            bn.BindingSource = bs;
            dgv.DataSource = bs;
            dgv.Sort(dgv.Columns[2], ListSortDirection.Ascending);
            this.Text = "Simple Workflow for project '" + System.IO.Path.GetFileName(curProject.ProjectFileName) + "'" + Environment.NewLine;
            //tbProjData.Text = System.IO.File.ReadAllText(curProject.ProjectFileName);
        }



        DataTable FillDataTablewithAvailableMethods()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Function_name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Group_name");
            foreach (System.Reflection.MethodInfo item in typeof(GeoImageData).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                dt.Rows.Add(item.Name, "Data functions", "GeoImageData");
            }
            foreach (System.Reflection.MethodInfo item in typeof(GeoImageTools).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                dt.Rows.Add(item.Name, "IO + display functions", "GeoImageTools");
            }
            foreach (System.Reflection.MethodInfo item in typeof(Filter).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                dt.Rows.Add(item.Name, "Digital filtering", "Filter");
            }
            foreach (System.Reflection.MethodInfo item in typeof(GeoMultiBandMethods).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                dt.Rows.Add(item.Name, "MultiBand functions", "GeoMultiBandMethods");
            }
            foreach (System.Reflection.MethodInfo item in typeof(StatMath).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                dt.Rows.Add(item.Name, "Math stat functions", "StatMath");
            }
            return dt;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                lblDesc.Text = "";
                lblDesc.Visible = false;
            }
            else
            {
                lblDesc.Text = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int x = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).X;
                int y = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y + dgv.ColumnHeadersHeight;
                lblDesc.Location = new Point(x, y);
                lblDesc.Visible = true;
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                int x = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).X;
                int y = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y + dgv.ColumnHeadersHeight;
                contextMenuAdd.Items[0].Text = "Add '" + dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' function to selected function list";
                contextMenuAdd.Show(dgv, new Point(x, y));
                lstSelectedFunctions.Tag = dgv.Rows[e.RowIndex].Cells["Function_name"].Value;
            }
        }

        private void bttnClearList_Click(object sender, EventArgs e)
        {
            lstSelectedFunctions.Items.Clear();
        }

        private void bttnClearSelectedItem_Click(object sender, EventArgs e)
        {
            if (lstSelectedFunctions.SelectedIndex != -1)
            {
                lstSelectedFunctions.Items.RemoveAt(lstSelectedFunctions.SelectedIndex);
            }
            bttnClearSelectedItem.Enabled = false;
        }

        private void lstSelectedFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedFunctions.SelectedIndex != -1)
            {
                bttnClearSelectedItem.Enabled = true;
                bttnDown.Enabled = true;
                bttnUp.Enabled = true;
            }
            else
            {
                bttnClearSelectedItem.Enabled = false;
                bttnDown.Enabled = false;
                bttnUp.Enabled = false;
            }
        }

        private void addToSelectedFunctionsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstSelectedFunctions.Items.Add(lstSelectedFunctions.Tag);
        }

        private void bttnUp_Click(object sender, EventArgs e)
        {
            string item = lstSelectedFunctions.SelectedItem.ToString();
            int index = lstSelectedFunctions.SelectedIndex;
            if (index == 0) return;
            lstSelectedFunctions.Items.RemoveAt(index);
            lstSelectedFunctions.Items.Insert(index - 1, item);
            lstSelectedFunctions.SelectedIndex = index - 1;
        }

        private void bttnDown_Click(object sender, EventArgs e)
        {
            string item = lstSelectedFunctions.SelectedItem.ToString();
            int index = lstSelectedFunctions.SelectedIndex;
            if (index == lstSelectedFunctions.Items.Count - 1) return;
            lstSelectedFunctions.Items.RemoveAt(index);
            lstSelectedFunctions.Items.Insert(index + 1, item);
            lstSelectedFunctions.SelectedIndex = index + 1;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = selectRows(cmbGroups.SelectedItem.ToString());
            dgv.Refresh();
        }

        DataTable selectRows(string selectedGroup)
        {
            string s = selectedGroup.Substring(0, selectedGroup.LastIndexOf(' '));
            DataTable dt = new DataTable();
            if (s == "All") { dt = AllRows; return dt; }
            else
            {
                var results = from myRow in AllRows.AsEnumerable()
                              where myRow.Field<string>("Group_name") == s
                              select myRow;
                dt = results.CopyToDataTable<DataRow>();
            }
            return dt;
        }

        private void bttnCreateWorkflow_Click(object sender, EventArgs e)
        {
            List<string> lstmethods = new List<string>();
            foreach (string item in lstSelectedFunctions.Items)
            { lstmethods.Add(item); }

            sworkflow.createWorkflow("unsaved workflow", curProject.ProjectFileName, curProject.FileNames, lstmethods, sworkflow.WorkflowDescription);
            tbWorkflowData.Text = "#Workflow_name: " + sworkflow.NameOfWorkflow;
            tbWorkflowData.AppendText(Environment.NewLine + "#Workflow_description: " + Environment.NewLine + "description");//sworkflow.WorkflowDescription);
            tbWorkflowData.AppendText(Environment.NewLine + "#Project_file: " + sworkflow.NameOfProject);
            tbWorkflowData.AppendText(Environment.NewLine + "#Files:" + Environment.NewLine);
            tbWorkflowData.AppendText(string.Join(Environment.NewLine, sworkflow.FileNames));
            tbWorkflowData.AppendText(Environment.NewLine + "#Methods:" + Environment.NewLine);
            tbWorkflowData.AppendText(string.Join(Environment.NewLine, sworkflow.MethodNames));
            tabProjdata.SelectedTab = tabProjdata.TabPages["tabViewWorkflow"];
            pg.SelectedObject = sworkflow;

            //wkf = "#Workflow_name: " + sworkflow.NameOfWorkflow;
            //wkf += (Environment.NewLine + "#Workflow_description: " + sworkflow.WorkflowDescription);
            //wkf += (Environment.NewLine + "#Project_file: " + sworkflow.NameOfProject);
            //wkf += (Environment.NewLine + "#Files:" + Environment.NewLine);
            //wkf += (string.Join(Environment.NewLine, sworkflow.FileNames));
            //wkf += (Environment.NewLine + "#Methods:" + Environment.NewLine);
            //wkf += (string.Join(Environment.NewLine, sworkflow.MethodNames));
            //printProjectData(curProject.ProjectFileName);
            //System.IO.File.WriteAllText(wkfName, tbWorkflowData.Text);
            //tbWorkflowData.Text = "#Workflow file: " + wkfName + Environment.NewLine;           
            //tbWorkflowData.AppendText("#Project_file: " + projectName + Environment.NewLine);
            //string projData = System.IO.File.ReadAllText(projectName);
            //tbWorkflowData.AppendText(projData);
        }

        private void bttnSaveWorkflow_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Workflow files|*.wkf";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string wkf;
                wkf = "#Workflow_name: " + sf.FileName;
                wkf += (Environment.NewLine + "#Workflow_description: " + Environment.NewLine + "description"); // + sworkflow.WorkflowDescription);
                wkf += (Environment.NewLine + "#Project_file: " + sworkflow.NameOfProject);
                wkf += (Environment.NewLine + "#Files:" + Environment.NewLine);
                wkf += (string.Join(Environment.NewLine, sworkflow.FileNames));
                wkf += (Environment.NewLine + "#Methods:" + Environment.NewLine);
                wkf += (string.Join(Environment.NewLine, sworkflow.MethodNames));
                System.IO.File.WriteAllText(sf.FileName, wkf);
            }
        }

        void setpgColumnWidth(PropertyGrid grid, int width)
        {
            FieldInfo fi = grid?.GetType().GetField("tabViewWorkflow", BindingFlags.Instance | BindingFlags.NonPublic);
            Control view = fi?.GetValue(grid) as Control;
            MethodInfo mi = view?.GetType().GetMethod("MoveSplitterTo", BindingFlags.Instance | BindingFlags.NonPublic);
            mi?.Invoke(view, new object[] { width });
        }
        //private void frmSimpleWorkflow_Load(object sender, EventArgs e)
        //{
        //    //tabProjdata.SelectedTab = tabProjdata.TabPages["tabViewWorkflow"];
        //    //setpgColumnWidth(pg, 100);
        //}


    }
}
