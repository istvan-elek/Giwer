using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmConfig : Form
    {
        public Dictionary<string, string> config = new Dictionary<string, string>();

        public frmConfig()
        {
            InitializeComponent();
            readConfig();
        }

        public void readConfig()
        {
            try
            {
                var sarray = File.ReadAllLines(Application.StartupPath + @"\config.cfg");
                for (int i = 0; i < sarray.Length; i += 2)
                {
                    string key = sarray[i];
                    string val = sarray[i + 1];
                    if (!(key == "" && val == ""))
                    {
                        config.Add(key, val);
                        dgvConfig.Rows.Add(key, val);
                    }
                    //config.Add(key, val);
                    //dgvConfig.Rows.Add(key, val);
                }
                dgvConfig.Columns[0].ReadOnly = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Loading 'config.cfg' file has failed. " + e.Message,"Error in loading config file",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        public void readConfig(string fname)
        {
            try
            {
                var sarray = File.ReadAllLines(fname);
                for (int i = 0; i < sarray.Length; i += 2)
                {
                    string key = sarray[i];
                    string val = sarray[i + 1];
                    if (!(key == "" && val ==""))
                    {
                        config.Add(key, val);
                        dgvConfig.Rows.Add(key, val);
                    }
                }
                dgvConfig.Columns[0].ReadOnly = true;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Loading 'config.cfg' file has failed. " + e.Message, "Error in loading config file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //public Dictionary setConfig()
        //{
        //    Dictionary<string,string> 
        //}

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //if (dgvConfig.Rows[e.RowIndex].Cells[0].Value.ToString() == "DisplayImageSize" || dgvConfig.Rows[e.RowIndex].Cells[0].Value.ToString() == "DisplayCursorPosition")
                //{
                //    string v = dgvConfig.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToLower();
                //    if (v != "true" && v != "false")
                //    {
                //        MessageBox.Show("Improper value for DisplayImageSize or DisplayCursorPosition parameter. The value must be 'true' or 'false'. Look at the 'config.cfg' file content.", "Improper value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        dgvConfig.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "false";
                //    }
                //}
                config[dgvConfig.Rows[e.RowIndex].Cells[0].Value.ToString()] = dgvConfig.Rows[e.RowIndex].Cells[1].Value.ToString();
                saveConfig();
            }
        }

        public void saveConfig()
        {
            if (File.Exists(Application.StartupPath + @"\config.cfg")) File.Delete(Application.StartupPath + @"\config.cfg");
            using (FileStream fs = new FileStream(Application.StartupPath + @"\config.cfg", FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in config)
                        {
                            sw.WriteLine(item.Key);
                            sw.WriteLine(item.Value);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in writing 'config.cfg' file, probably concurrent access. " + e.Message, "Error with config file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (e.RowIndex < 7)
                {
                    FolderBrowserDialog fb = new FolderBrowserDialog();
                    fb.ShowNewFolderButton = true;
                    fb.SelectedPath = dgvConfig.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    fb.ShowDialog();
                    dgvConfig.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fb.SelectedPath;
                }
            }
        }

        private void frmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveConfig();
        }
    }
}
