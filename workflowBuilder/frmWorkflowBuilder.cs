using Giwer.dataStock;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Giwer.workflowBuilder
{
    public partial class WorkflowBuilder : Form
    {
        Workflow currentWorkflow = new Workflow();
        public Dictionary<string, string> config = new Dictionary<string, string>();
        frmConfig conf = new frmConfig();
        string ProjectFolder = "";
        string WorkflowFolder = "";

        public WorkflowBuilder()
        {
            InitializeComponent();
            this.Location = workflowBuilder.Properties.Settings.Default.StartLocation;
            this.Size = workflowBuilder.Properties.Settings.Default.FormSize;
            this.WindowState = workflowBuilder.Properties.Settings.Default.WindowState;
            FillAvailableMethods();
            conf = new frmConfig();
            ProjectFolder = conf.config["ProjectFolder"];
            WorkflowFolder = conf.config["WorkflowFolder"];
        }

        private void FillAvailableMethods()
        {
            lstAvailableOperations.Items.Clear();
            var operations = Assembly
                .GetAssembly(typeof(SingleBandOperation))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(SingleBandOperation)))
                .OrderBy(t => t.Name);

            foreach (Type opType in operations)
            {
                lstAvailableOperations.Items.Add(new WorkflowItem(opType));
            }
        }


        private void frmProjectBuilder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                workflowBuilder.Properties.Settings.Default["StartLocation"] = this.Location;
                workflowBuilder.Properties.Settings.Default["FormSize"] = this.Size;
                workflowBuilder.Properties.Settings.Default["WindowState"] = this.WindowState;
                workflowBuilder.Properties.Settings.Default.Save();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            if (lstSelectedOperations.Items.Count > 0) lstSelectedOperations.Enabled = true;
            if (lstAvailableOperations.SelectedItem == null) return;
            if (lstAvailableOperations.SelectedItem.ToString()[0] == '=') return;

            WorkflowItem wItem = (WorkflowItem)lstAvailableOperations.SelectedItem;

            lstSelectedOperations.Items.Add(new WorkflowItem(wItem.Operation));
            currentWorkflow.Methods.Add(lstSelectedOperations.Items[lstSelectedOperations.Items.Count - 1].ToString());
            //List<string> lstnewpar = new List<string>();
            //currentWorkflow.Pars.Add(lstnewpar);
            //currentWorkflow.Pars.Add(new List<string>() { "" }); //{ wItem.Parameters.Values.ToString() });
            //currentWorkflow.Pars.Add(wItem.Parameters)
        }

        private void lstSelectedOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlParams.Controls.Clear();
            if (lstSelectedOperations.SelectedItem == null)
                return;

            WorkflowItem wItem = (WorkflowItem)lstSelectedOperations.SelectedItem;
            int index = 0;
            foreach (var param in wItem.Parameters)
            {
                Label pLabel = new Label();
                pLabel.Text = $"{param.Key}:";
                pLabel.Location = new Point(10, 10 + index * 25);
                pLabel.AutoSize = true;
                TextBox pTbx = new TextBox();
                pTbx.Text = param.Value;
                if (currentWorkflow.Pars.Count != 0) //pTbx.Text = lstSelectedOperations.SelectedItem.ToString();
                {
                    for (int i = 0; i < wItem.Parameters.Count; i++)
                    {
                        pTbx.Text = currentWorkflow.Pars[lstSelectedOperations.SelectedIndex][0]; // nemcsak az első kellhet!!
                    }
                }
                pTbx.TextChanged += ParameterChanged;
                pTbx.Tag = param.Key;
                pTbx.Location = new Point(pLabel.Location.X + pLabel.Width, pLabel.Location.Y);
                pTbx.Width = 30;

                pnlParams.Controls.Add(pLabel);
                pnlParams.Controls.Add(pTbx);
                ++index;
            }
        }

        private void ParameterChanged(object sender, EventArgs e)
        {
            TextBox tSender = (TextBox)sender;
            WorkflowItem wItem = (WorkflowItem)lstSelectedOperations.SelectedItem;
            wItem.Parameters[tSender.Tag.ToString()] = tSender.Text;
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            if (lstSelectedOperations.SelectedItem != null)
            {
                lstSelectedOperations.Items.RemoveAt(lstSelectedOperations.SelectedIndex);
                if (lstSelectedOperations.Items.Count == 0)
                {
                    lstSelectedOperations.Enabled = false;
                    bttnRun.Enabled = false;
                    return;
                }
            }
        }

        private void btnUpOperation_Click(object sender, EventArgs e)
        {
            if (lstSelectedOperations.SelectedItem == null)
                return;

            if (lstSelectedOperations.SelectedIndex == 0)
                return;

            int oldIndex = lstSelectedOperations.SelectedIndex;
            var moveItem = lstSelectedOperations.SelectedItem;
            lstSelectedOperations.Items.RemoveAt(lstSelectedOperations.SelectedIndex);
            lstSelectedOperations.Items.Insert(oldIndex - 1, moveItem);
            lstSelectedOperations.SelectedIndex = oldIndex - 1;
        }

        private void btnDownOperation_Click(object sender, EventArgs e)
        {
            if (lstSelectedOperations.SelectedItem == null)
                return;

            if (lstSelectedOperations.SelectedIndex == lstSelectedOperations.Items.Count - 1)
                return;

            int oldIndex = lstSelectedOperations.SelectedIndex;
            var moveItem = lstSelectedOperations.SelectedItem;
            lstSelectedOperations.Items.RemoveAt(lstSelectedOperations.SelectedIndex);
            lstSelectedOperations.Items.Insert(oldIndex + 1, moveItem);
            lstSelectedOperations.SelectedIndex = oldIndex + 1;
        }

        private void bttnRun_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Project files (*.proj)|*.proj";
            of.InitialDirectory = ProjectFolder;
            if (of.ShowDialog() == DialogResult.OK)
            {
                Project prj = new Project();
                prj.ProjectFileName = of.FileName;
                RunWorkflow(prj);
            }
        }

        void RunWorkflow(Project proj)
        {
            foreach (string item in proj.FileNames)
            {
                //itt kell alkalmazni a workflowt az adott fájlra (a fájl beolvasás: a proj fileból fognak jönni a fájlnevek)
            }
        }

        private void bttnSave_Click(object sender, EventArgs e) // a save as és a lista bővítése még nem működik
        {
            Workflow wkf = currentWorkflow;

            currentWorkflow.initWorkflow();
            currentWorkflow.Description = tbDescription.Text;
            for (int i = 0; i < lstSelectedOperations.Items.Count; i++)
            {
                WorkflowItem wi = (WorkflowItem)lstSelectedOperations.Items[i];
                currentWorkflow.Methods.Add(wi.ToString());
                List<string> lsPars = new List<string>();
                for (int j = 0; j < wi.Parameters.Count; j++)
                {
                    string val = wi.Parameters.ElementAt(j).Value;
                    lsPars.Add(val);
                }
                currentWorkflow.Pars.Add(lsPars);
            }
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Workflow files(*.wkf)|*.wkf";
            sf.FileName = tbxName.Text.Trim();
            if (sf.ShowDialog() == DialogResult.OK) wkf.saveWorkflowFile(sf.FileName);
            bttnRun.Enabled = true;
        }

        private void loadWorkflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Workflow wkf = new Workflow();
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = WorkflowFolder;
            of.Filter = "Workflow files (*.wkf)|*.wkf";
            if (of.ShowDialog() == DialogResult.OK)
            {
                currentWorkflow.initWorkflow();
                lstSelectedOperations.Items.Clear();
                pnlParams.Controls.Clear();
                wkf.LoadWorkflowFile(of.FileName);
                tbxName.Text = Path.GetFileNameWithoutExtension(of.FileName);
                tbDescription.Text = wkf.Description;
                var operations = Assembly
                    .GetAssembly(typeof(SingleBandOperation))
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(SingleBandOperation)))
                    .OrderBy(t => t.Name);
                for (int j = 0; j < wkf.Methods.Count; j++)
                {
                    foreach (Type opType in operations)
                    {
                        if (wkf.Methods[j].ToLower().Contains(opType.Name.ToLower()))
                        {
                            lstSelectedOperations.Items.Add(new WorkflowItem(opType));
                            break;
                        }
                    }
                }

                currentWorkflow = wkf;
                if (lstSelectedOperations.Items.Count > 0)
                {
                    lstSelectedOperations.Enabled = true;
                    bttnRun.Enabled = true;
                }
            }
        }

        private void createWorkflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstSelectedOperations.Items.Clear();
            tbxName.Text = "";
            tbDescription.Text = "";
            pnlParams.Controls.Clear();
            currentWorkflow.initWorkflow();
            lstSelectedOperations.Enabled = true;
            bttnRun.Enabled = false;
            bttnSave.Enabled = false;
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            bttnSave.Enabled = true;
            lstSelectedOperations.Enabled = true;
        }

        private void deleteWorkflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Workflow files (wkf)|*.wkf";
            of.Title = "Remove selected workflow file";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Delete(of.FileName);
                    MessageBox.Show(Path.GetFileName(of.FileName) + " file successfully deleted");
                }
                catch (IOException err)
                {
                    MessageBox.Show("Deletion is failed: " + err.Message, "Failed action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            currentWorkflow.Description = tbDescription.Text;
        }
    }
}
