using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Giwer.dataStock;

namespace Giwer.workflowBuilder
{
    public partial class WorkflowBuilder : Form
    {
        Workflow currentWorkflow = new Workflow();
        public Dictionary<string, string> config = new Dictionary<string, string>();
        frmConfig conf = new frmConfig();
        string ProjectFolder="";
        string WorkflowFolder="";

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

            operations = Assembly
                .GetAssembly(typeof(MultiBandOperation))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(MultiBandOperation)))
                .OrderBy(t => t.Name);

            foreach (Type opType in operations)
            {
                lstAvailableOperations.Items.Add(new WorkflowItem(opType));
            }
        }

        private void WorkflowBuilder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                workflowBuilder.Properties.Settings.Default["StartLocation"] = this.Location;
                workflowBuilder.Properties.Settings.Default["FormSize"] = this.Size;
                workflowBuilder.Properties.Settings.Default["WindowState"] = this.WindowState;
                workflowBuilder.Properties.Settings.Default.Save();
                conf.config["WorkflowFolder"] = WorkflowFolder;
                conf.saveConfig();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            if (lstSelectedOperations.Items.Count > 0) lstSelectedOperations.Enabled = true;
            if (lstAvailableOperations.SelectedItem == null) return;
            if (lstAvailableOperations.SelectedItem.ToString()[0] == '=') return;

            WorkflowItem wItem = (WorkflowItem)lstAvailableOperations.SelectedItem;
            lstSelectedOperations.Items.Add(new WorkflowItem(wItem.Operation));
            currentWorkflow.Methods.Add(wItem.ToString());
            List<string> parlist = new List<string>();
            int  lsCount =int.Parse(wItem.ToString().Split(' ')[1].Trim('(').Trim(')')); 
            if (lsCount==0) currentWorkflow.Pars.Add(new List<string>() { "" });
            for (int i=0; i < lsCount; i++) currentWorkflow.Pars.Add(new List<string>() {"" });
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
                pTbx.Text = currentWorkflow.Pars[lstSelectedOperations.SelectedIndex][0].ToString();

                pTbx.TextChanged += ParameterChanged;
                pTbx.Tag = param.Key;
                pTbx.KeyDown += AcceptParam;
                pTbx.Tag = lstSelectedOperations.SelectedIndex;
                pTbx.Location = new Point(pLabel.Location.X + pLabel.Width, pLabel.Location.Y);
                pTbx.Width = 30;

                if (pnlParams.Controls.Count == 0)
                {
                    pnlParams.Controls.Add(pLabel);
                    pnlParams.Controls.Add(pTbx);
                }
                ++index;
            }
        }

        private void AcceptParam(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                TextBox tSender = (TextBox)sender;
                currentWorkflow.Pars[int.Parse(tSender.Tag.ToString())][0] = tSender.Text;
            }
        }

        private void ParameterChanged(object sender, EventArgs e)
        {
            TextBox tSender = (TextBox) sender;
            WorkflowItem wItem = (WorkflowItem)lstSelectedOperations.SelectedItem;
            wItem.Parameters[tSender.Tag.ToString()] = tSender.Text;
            
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            if (lstSelectedOperations.SelectedItem != null)
            {
                string removedItem = lstSelectedOperations.SelectedItem.ToString();
                int removedIndex = lstSelectedOperations.SelectedIndex;
                lstSelectedOperations.Items.RemoveAt(removedIndex);
                currentWorkflow.Methods.Remove(removedItem);
                currentWorkflow.Pars.RemoveAt(removedIndex); //(new List<string>() { removedItem });
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
            var movePar = currentWorkflow.Pars[oldIndex];
            lstSelectedOperations.Items.RemoveAt(oldIndex);
            currentWorkflow.Methods.RemoveAt(oldIndex);
            currentWorkflow.Pars.RemoveAt(oldIndex);
            currentWorkflow.Methods.Insert(oldIndex - 1, moveItem.ToString());
            currentWorkflow.Pars.Insert(oldIndex - 1, movePar);
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
            var movePar = currentWorkflow.Pars[oldIndex];
            currentWorkflow.Methods.RemoveAt(oldIndex);
            currentWorkflow.Pars.RemoveAt(oldIndex);
            currentWorkflow.Methods.Insert(oldIndex + 1, moveItem.ToString());
            currentWorkflow.Pars.Insert(oldIndex + 1, movePar);
            lstSelectedOperations.Items.RemoveAt(lstSelectedOperations.SelectedIndex);
            lstSelectedOperations.Items.Insert(oldIndex + 1, moveItem);
            lstSelectedOperations.SelectedIndex = oldIndex + 1;
        }

        private void bttnRun_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Project files (*.proj)|*.proj";
            of.InitialDirectory = ProjectFolder;
            if (of.ShowDialog()==DialogResult.OK)
            {
                Project prj = new Project();
                prj.ProjectFileName = of.FileName;
                RunWorkflow(prj);
            }
        }

        void RunWorkflow(Project proj)
        {
            //Assembly assem = typeof(WorkflowBuilder).Assembly;
            //Type tt = assem.GetType("Giwer.workflowBuilder.Operations.HighPassFilter");

            //MethodInfo method = tt.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance);           
            //method.Invoke(tt, null);

            //GeoImageData imgData=new GeoImageData();
            //int band = 0;
            //SingleBandOperation op = (SingleBandOperation)Activator.CreateInstance(tt, new object[] { imgData, band });
            //// propertyket beállítani
            //op.Execute();

            if (!checkParameters()) return;
            if (MessageBox.Show("The process can take a long time (even hours)", "Long last process notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            this.Cursor = Cursors.WaitCursor;
            progressWorkflow.Maximum = proj.FileNames.Count;
            progressWorkflow.Value = 0;
            progressWorkflow.Visible = true;

            foreach (string fileItem in proj.FileNames)
            {
                progressWorkflow.PerformStep();
                GeoImageData imgData = new GeoImageData();
                imgData.FileName = fileItem;
                byte[] byin = new byte[imgData.Nrows * imgData.Ncols];
                byte[] byout = new byte[imgData.Nrows * imgData.Ncols];

                for (int band=0; band < imgData.Nbands; band++)
                {
                int k = 0;
                    for (int i = 0; i < currentWorkflow.Methods.Count; i++)
                    {
                        Assembly assem = typeof(WorkflowBuilder).Assembly;
                        Type opt = assem.GetType("Giwer.workflowBuilder.Operations." + currentWorkflow.Methods[i].Split(' ')[0]);
                        if (opt.BaseType.Name == "SingleBandOperation")
                        {
                            if (k == 0)
                            {
                                GeoImageTools gt = new GeoImageTools(imgData);
                                byin = gt.getOneBandBytes(band);
                                SingleBandOperation op = (SingleBandOperation)Activator.CreateInstance(opt, new object[] { imgData, band, currentWorkflow.Pars[i] });
                                op.Execute();
                                byin = op.Output;
                                byout = op.Output;
                                k = 1;
                            }
                            else
                            {
                                SingleBandOperation op = (SingleBandOperation)Activator.CreateInstance(opt, new object[] { byin, imgData, currentWorkflow.Pars[i] });
                                op.Execute();
                                byin = op.Output;
                                byout = op.Output;
                            }

                        }
                        if (opt.BaseType.Name == "MultiBandOperation")
                        {

                        }

                    }
                    if (chkSave.Checked)
                    {
                        SaveResult(imgData, byout, band);
                    }
                }
            }
            this.Cursor = Cursors.Default;
            progressWorkflow.Visible = false;
            MessageBox.Show("Save process has completed", "Save completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void SaveResult(GeoImageData gimda, byte[] byout, int iband)
        {
            GeoImageTools gt = new GeoImageTools(gimda);
            string dirname= Path.GetDirectoryName(gimda.FileName);
            string fname = Path.GetFileNameWithoutExtension(gimda.FileName);
            string extension = Path.GetExtension(gimda.FileName);
            string fileName = dirname + "\\" + fname + tbResultAppendix.Text + extension;
            if (iband==0) gt.saveHeader2Giwer(fileName);
            gt.saveGivenBand2GiwerFormat(dirname + "\\" + fname + tbResultAppendix.Text, byout, iband, "");
            //gt.saveOneBandResultAsGiwerFormat(fileName, byout, "");
        }

        private void bttnSave_Click(object sender, EventArgs e) // a save as és a lista bővítése még nem működik
        {
            if (!checkParameters()) return;
            Workflow wkf = currentWorkflow;
            wkf.Description = tbDescription.Text;
            //for (int i = 0; i < lstSelectedOperations.Items.Count; i++)
            //{
            //    WorkflowItem wi = (WorkflowItem)lstSelectedOperations.Items[i];
            //    //wkf.Methods.Add(wi.ToString());
            //    List<string> lsPars = new List<string>();
                
            //    for (int j = 0; j < wi.Parameters.Count; j++)
            //    {
            //        string val = wi.Parameters.ElementAt(j).Value;
            //        lsPars.Add(val);
            //    }
            //    wkf.Pars.Add(lsPars);
            //}
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Workflow files(*.wkf)|*.wkf";
            sf.FileName = tbxName.Text.Trim();
            if (sf.ShowDialog() == DialogResult.OK) currentWorkflow.saveWorkflowFile(sf.FileName);
            bttnRun.Enabled = true;
        }

        Boolean checkParameters()
        {
            Boolean res = true;
            for (int i=0; i <currentWorkflow.Methods.Count; i++)
            {
                int numOfPars = int.Parse( currentWorkflow.Methods[i].Split(' ')[1].Trim('(').Trim(')'));
                if (numOfPars != 0 && currentWorkflow.Pars[i][0] == "")
                //if (currentWorkflow.Pars[i].Count!=numOfPars || currentWorkflow.Pars[i][0]=="0")
                {
                    MessageBox.Show("Missing parameters of '" + currentWorkflow.Methods[i] + "'","Missing parameters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    res = false;
                }
            }
            return res;
        }

        private void loadWorkflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Workflow wkf = new Workflow();
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = WorkflowFolder;
            of.Filter = "Workflow files (*.wkf)|*.wkf";
            if (of.ShowDialog() == DialogResult.OK)
            {
                WorkflowFolder = Path.GetDirectoryName(of.FileName);
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
                        if (wkf.Methods[j].Contains(opType.Name))
                        {
                            WorkflowItem op = new WorkflowItem(opType);
                            lstSelectedOperations.Items.Add(op);
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
            if (of.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    File.Delete(of.FileName);
                    MessageBox.Show(Path.GetFileName(of.FileName) + " file successfully deleted");
                }
                catch (IOException err)
                {
                    MessageBox.Show("Deletion is failed: " + err.Message, "Failed action",MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            currentWorkflow.Description = tbDescription.Text;
        }


    }
}
