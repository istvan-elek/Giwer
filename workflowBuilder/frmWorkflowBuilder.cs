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
        string witemType = "";
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
            if (witemType == "")
            {
                witemType = wItem.Operation.BaseType.ToString();
            }
            else
            {
                if (witemType != wItem.Operation.BaseType.ToString())
                {
                    MessageBox.Show("Mixed operations. Do not mix SingleBandOperaton with MultiBandOperation", "Mixed operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            lstSelectedOperations.Items.Add(new WorkflowItem(wItem.Operation));
            currentWorkflow.Methods.Add(wItem.ToString());         
            int  lsCount = int.Parse(wItem.ToString().Split(' ')[1].Trim('(').Trim(')')); 
            List<string> parlist = new List<string>();
            if (lsCount == 0)
            {
                parlist.Add("");
                //new List<string>() { "" };
            }
            else
            {
                for (int i = 0; i < lsCount; i++)
                {
                    parlist.Add("");
                }
            }
            currentWorkflow.Pars.Add(parlist);
        }

        private void lstSelectedOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlParams.Controls.Clear();
            if (lstSelectedOperations.SelectedItem == null) return;
            WorkflowItem wItem = (WorkflowItem)lstSelectedOperations.SelectedItem;
            int index = 0;
            //parI = 0;
            foreach (var param in wItem.Parameters)
            {
                Label pLabel = new Label();
                pLabel.Text = $"{param.Key}:";
                pLabel.Location = new Point(10, 10 + index * 25);
                pLabel.AutoSize = true;
                TextBox pTbx = new TextBox();
                pTbx.Text = currentWorkflow.Pars[lstSelectedOperations.SelectedIndex][index].ToString();
                pTbx.TextChanged += ParameterChanged;
                pTbx.Tag = param.Key;
                //parI = pTbx.TabIndex; //lstSelectedOperations.SelectedIndex;
                //pTbx.Tag = lstSelectedOperations.SelectedIndex;
                //pTbx.KeyDown += AcceptParam;
                pTbx.Location = new Point(pLabel.Location.X + pLabel.Width, pLabel.Location.Y);
                pTbx.Width = 30;
                if (pnlParams.Controls.Count == 2*index)               
                {
                    pnlParams.Controls.Add(pLabel);
                    pnlParams.Controls.Add(pTbx);
                }
                //parI = index;
                ++index;

            }
        }


        private void ParameterChanged(object sender, EventArgs e)
        {
            TextBox tSender = (TextBox)sender;
            WorkflowItem wItem = (WorkflowItem)lstSelectedOperations.SelectedItem;
            wItem.Parameters[tSender.Tag.ToString()] = tSender.Text;
            int wItemIndex= Array.IndexOf(wItem.Parameters.Keys.ToArray(), tSender.Tag);
            currentWorkflow.Pars[lstSelectedOperations.SelectedIndex][wItemIndex] = tSender.Text;
            bttnRun.Enabled = false;
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            if (lstSelectedOperations.SelectedItem != null)
            {
                string removedItem = lstSelectedOperations.SelectedItem.ToString();
                int removedIndex = lstSelectedOperations.SelectedIndex;
                lstSelectedOperations.Items.RemoveAt(removedIndex);
                currentWorkflow.Methods.Remove(removedItem);
                currentWorkflow.Pars.RemoveAt(removedIndex); 
                if (lstSelectedOperations.Items.Count == 0 && tbxName.Text == "")
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
            bttnRun.Enabled = false;
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
            bttnRun.Enabled = false;
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
                tslProjFile.Text = "Project file: " + Path.GetFileName(of.FileName);
                RunWorkflow(prj);
            }
        }

        void RunWorkflow(Project proj)
        {
            if (!checkParameters()) return;
            if (MessageBox.Show("The process can take a long time (even hours for many images)", "NOTICE: Potential long last process", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            this.Cursor = Cursors.WaitCursor;
            progressWorkflow.Maximum = proj.FileNames.Count;
            progressWorkflow.Value = 0;
            progressWorkflow.Visible = true;
            int numberOfSingleBandOp;
            int numberOfMultiBandOp;
            getWorkflowNumber(out numberOfSingleBandOp, out numberOfMultiBandOp);

            foreach (string fileItem in proj.FileNames)  //egyenként vesszük a fájlokat
            {
                progressWorkflow.PerformStep();
                GeoImageData imgData = new GeoImageData();
                imgData.FileName = fileItem;
                byte[] byin = new byte[imgData.Nrows * imgData.Ncols];
                byte[] byout = new byte[imgData.Nrows * imgData.Ncols];
                if (numberOfSingleBandOp > 0)  //ha SingleBandOperation a tennivaló
                {
                    for (int band = 0; band < imgData.Nbands; band++) // sávonként megyünk
                    {
                        int k = 0;
                        for (int i = 0; i < numberOfSingleBandOp; i++)   // itt indítjuk az eljárásokat az aktuális sávra
                        {
                            Assembly assem = typeof(WorkflowBuilder).Assembly;
                            Type opt = assem.GetType("Giwer.workflowBuilder.Operations." + currentWorkflow.Methods[i].Split(' ')[0]);
                            if (k == 0) // az első  eljárásnál be kell olvasni az aktuális sávot
                            {
                                GeoImageTools gt = new GeoImageTools(imgData);
                                byin = gt.getOneBandBytes(band);
                                SingleBandOperation op = (SingleBandOperation)Activator.CreateInstance(opt, new object[] { imgData, band, currentWorkflow.Pars[i] });
                                op.Execute();
                                byin = op.Output;
                                byout = op.Output;
                                k = 1;
                            }
                            else  // a második, harmadik... eljárás bemenete az előző kimenete
                            {
                                SingleBandOperation op = (SingleBandOperation)Activator.CreateInstance(opt, new object[] { byin, imgData, currentWorkflow.Pars[i] });
                                op.Execute();
                                byin = op.Output;
                                byout = op.Output;
                            }                            
                        } // end of single band cycle
                        if (chkSave.Checked) SaveResultSingleBand(imgData, byout, band);                        
                    }
                }

                if (numberOfMultiBandOp > 0)  // ha MultiBandOperation a tennivaló
                    for (int i = 0; i < numberOfMultiBandOp; i++)   // itt indítjuk az eljárásokat kiválasztott sávokra
                {
                    Assembly assem = typeof(WorkflowBuilder).Assembly;
                    Type opt = assem.GetType("Giwer.workflowBuilder.Operations." + currentWorkflow.Methods[i].Split(' ')[0]);
                    GeoImageTools gt = new GeoImageTools(imgData);
                    int nirband = int.Parse(currentWorkflow.Pars[i][0]);
                    int redband = int.Parse(currentWorkflow.Pars[i][1]);
                    MultiBandOperation op = (MultiBandOperation)Activator.CreateInstance(opt, new object[] { imgData, nirband, redband });
                    imgData.Nbands = 1; 
                    imgData.BytesPerPixel = imgData.Nbands * imgData.Nbits/8;
                    op.Execute();
                    byout = op.Output;
                    if (chkSave.Checked) SaveResultMultiBand(imgData, byout, 0, opt.Name);                  
                }

            }
            this.Cursor = Cursors.Default;
            progressWorkflow.Visible = false;
            MessageBox.Show("The saving process has completed", "Save completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void getWorkflowNumber(out int numofSingle, out int numofMulti)
        {
            int numofS = 0;
            int numofM = 0;
            Assembly assem = typeof(WorkflowBuilder).Assembly;
            foreach (WorkflowItem wi in lstSelectedOperations.Items)
            {
                Type opt = assem.GetType("Giwer.workflowBuilder.Operations." + wi.Operation.Name);
                if (opt.BaseType.Name == "SingleBandOperation") numofS += 1;
                else numofM += 1;
            }
            numofSingle = numofS;
            numofMulti = numofM;
        }

        void SaveResultSingleBand(GeoImageData gimda, byte[] byout, int iband)
        {
            GeoImageTools gt = new GeoImageTools(gimda);
            string dirname= Path.GetDirectoryName(gimda.FileName);
            string fname = Path.GetFileNameWithoutExtension(gimda.FileName);
            string extension = Path.GetExtension(gimda.FileName);
            string fileName = dirname + "\\" + fname + tbResultAppendix.Text  + extension;
            gimda.Comment = tbDescription.Text;
            if (iband==0) gt.saveHeader2Giwer(fileName);
            gt.saveGivenBand2GiwerFormat(dirname + "\\" + fname + tbResultAppendix.Text, byout, iband, tbDescription.Text);

        }

        void SaveResultMultiBand(GeoImageData gimda, byte[] byout, int iband, string opName)
        {
            GeoImageTools gt = new GeoImageTools(gimda);
            string dirname = Path.GetDirectoryName(gimda.FileName);
            string fname = Path.GetFileNameWithoutExtension(gimda.FileName);
            string extension = Path.GetExtension(gimda.FileName);
            string fileName = dirname + "\\" + fname + tbResultAppendix.Text + opName + extension;
            gimda.Comment = tbDescription.Text;
            gt.saveHeader2Giwer(fileName);
            gt.saveOneBandResultAsGiwerFormat(Path.ChangeExtension(fileName, "gwr"), byout, tbDescription.Text);
        }

        private void bttnSave_Click(object sender, EventArgs e) 
        {
            if (!checkParameters()) return;
            Workflow wkf = currentWorkflow;
            wkf.Description = tbDescription.Text;
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
                tslProjFile.Text = "";
                WorkflowFolder = Path.GetDirectoryName(of.FileName);
                currentWorkflow.initWorkflow();
                lstSelectedOperations.Items.Clear();
                pnlParams.Controls.Clear();
                wkf.LoadWorkflowFile(of.FileName);
                tbxName.Text = Path.GetFileNameWithoutExtension(of.FileName);
                tbDescription.Text = wkf.Description;
                var operations = Assembly.GetAssembly(typeof(SingleBandOperation)).GetTypes().Where(t => t.IsSubclassOf(typeof(SingleBandOperation))).OrderBy(t => t.Name);
                var MultiOper = Assembly.GetAssembly(typeof(MultiBandOperation)).GetTypes().Where(t => t.IsSubclassOf(typeof(MultiBandOperation))).OrderBy(t => t.Name);

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
                    foreach (Type opType in MultiOper)
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
            witemType = "";
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
            if (tbxName.Text == "") { bttnSave.Enabled = false; bttnRun.Enabled = false; }
            else
            {
                bttnSave.Enabled = true;
                lstSelectedOperations.Enabled = true;
            }
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

        private void bttnViewProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Project files|*.proj";
            if (of.ShowDialog()==DialogResult.OK)
            {
                Form frmViewProject = new Form();
                frmViewProject.Size = new Size(2 * this.Width / 3, this.Height / 2);
                Project prj = new Project();
                prj.ProjectFileName = of.FileName;
                TextBox tbProj = new TextBox();
                frmViewProject.Text = Path.GetFileName(of.FileName);
                tbProj.Multiline = true;
                tbProj.WordWrap = true;
                tbProj.ScrollBars = ScrollBars.Vertical;
                tbProj.Dock = DockStyle.Fill;
                tbProj.Text = prj.readAlltoString(of.FileName);
                frmViewProject.Controls.Add(tbProj);
                frmViewProject.StartPosition = FormStartPosition.CenterScreen;
                frmViewProject.Show();
            }
        }

        private void bttnViewFunctionsDesc_Click(object sender, EventArgs e)
        {
            Form frmViewFunctions = new Form();
            frmViewFunctions.Size = new Size(3 * this.Width / 4, this.Height / 2);
            Project prj = new Project();
            string fncDesc = "Histogram (0): automatic histogram equaliser, no parameter (0)" + '\n' +
                "Isotropic (0): Isotropic filter, no parameter (0)" + '\n' +
                "LaplaceFilter (0): Laplace filter, no parameter (0)" + '\n' +
                "LowPassFilter (1): low pass filter with 1 parameter (Kernel length)" + '\n' +
                "HighPassFilter (1): high pass filter with 1 parameter (Kernel length)" + '\n' +
                "MedianFilter (1): median filter with 1 parameter (Kernel length)" + '\n' +
                "NDVI (2):  compute NDVI with two parameters (nearInfraRedBabnd, redBand)" + '\n' +
                "PrewittFilter (0): Prewitt filter, no parameter (0)" + '\n' +
                "SobelFilter (0): Sobel filter, no parameter (0)" + '\n' +
                "Thresholding (1): Thresholding with 1 parameter (threshold)";

            string[] desc=fncDesc.Split('\n');
            DataGridView dgv = new DataGridView();
            dgv.Columns.Add("Function", "Function");
            dgv.Columns.Add("Description", "Description");
            dgv.ReadOnly = true;
            dgv.Dock = DockStyle.Fill;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            frmViewFunctions.Controls.Add(dgv);
            foreach(string item in desc)
            {
                string[] s = item.Split(':');
                dgv.Rows.Add(s);
            }
            frmViewFunctions.StartPosition = FormStartPosition.CenterScreen;
            frmViewFunctions.Text = "Quick function description";
            frmViewFunctions.Show();
        }
    }
}
