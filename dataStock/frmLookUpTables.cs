using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmLookUpTables : Form
    {
        string actualCPName;
        int colorStep = 32;
        int numOfColors = 8;

        public frmLookUpTables()
        {
            InitializeComponent();
            dgvCP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            loadAvailableCPFiles();
            if (cmbColPaletteTables.Items.Contains("default"))
            {
                cmbColPaletteTables.SelectedItem = "default";
            }
            //fillBaseColors();
            loadLUT(actualCPName + ".lut");
            dgvCP.RowHeadersVisible = false;
            dgvLUT.RowHeadersVisible = false;
        }

        void loadAvailableCPFiles()
        {
            string[] fileEntries = Directory.GetFiles(Application.StartupPath, "*.cp");
            foreach (string item in fileEntries)
            {
                cmbColPaletteTables.Items.Add(Path.GetFileNameWithoutExtension(item.ToLower()));
            }
        }

        void fillBaseColors()
        {
            dgvLUT.Columns.Clear();
            colorStep = (int)(256 / Convert.ToInt16(tbNumOfColors.Text));
            dgvLUT.Columns.Add("Start", "Start");
            //dgvLUT.Columns[0].ReadOnly = true;
            dgvLUT.Columns.Add("Color", "Color");
            //dgvLUT.Columns[1].ReadOnly = true;
            dgvLUT.Columns.Add("Category", "Category");

            numOfColors = Convert.ToInt16(tbNumOfColors.Text);
            for (int i = 0; i < numOfColors; i++)
            {
                dgvLUT.Rows.Add();
                dgvLUT.Rows[i].Cells[0].Value = i * colorStep;
            }
            dgvLUT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            for (int j = 0; j < numOfColors; j++)
            {
                dgvLUT.Rows[j].Cells["Color"].Style.BackColor = dgvCP.Rows[j * colorStep].Cells["Color"].Style.BackColor;
            }
        }

        void createNewCP() // string LUTType)
        {
            dgvCP.Columns.Clear();
            dgvCP.Columns.Add("Index", "Index");
            dgvCP.Columns["Index"].ReadOnly = true;
            dgvCP.Columns.Add("Red", "Red");
            dgvCP.Columns.Add("Green", "Green");
            dgvCP.Columns.Add("Blue", "Blue");
            dgvCP.Columns.Add("Alfa", "Alfa");
            dgvCP.Columns.Add("Color", "Color");
            dgvCP.Columns["Color"].ReadOnly = true;
            for (int i = 0; i < 256; i++)
            {
                dgvCP.Rows.Add();
                dgvCP.Rows[i].Cells[0].Value = i;
                dgvCP.Rows[i].Cells[1].Value = i;
                dgvCP.Rows[i].Cells[2].Value = i;
                dgvCP.Rows[i].Cells[3].Value = i;
                dgvCP.Rows[i].Cells[4].Value = 255;
                dgvCP.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(255, i, i, i);
            }
            dgvCP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        }

        void loadCP(string fname)  // load color palette and lookup table
        {
            dgvCP.Columns.Clear();
            using (FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    string line = sr.ReadLine();
                    string[] ln = line.Split(';');
                    dgvCP.Columns.Add(ln[0], ln[0]); // Index column
                    dgvCP.Columns[ln[0]].ReadOnly = true;
                    dgvCP.Columns.Add("Red", "Red");  // Red column
                    dgvCP.Columns.Add("Green", "Green");  // Green column
                    dgvCP.Columns.Add("Blue", "Blue");  // Blue column
                    dgvCP.Columns.Add("Alfa", "Alfa");  // Alfa column
                    dgvCP.Columns.Add("Color", "Color");  // Color column
                    for (int i = 0; i < 256; i++)
                    {
                        dgvCP.Rows.Add();
                        line = sr.ReadLine();
                        ln = line.Split(';');
                        dgvCP.Rows[i].Cells[0].Value = ln[0];
                        Int32 c = Convert.ToInt32(ln[1]);
                        Color col = ColorTranslator.FromWin32(c);
                        dgvCP.Rows[i].Cells[1].Value = col.R; //r;
                        dgvCP.Rows[i].Cells[2].Value = col.G; //g;
                        dgvCP.Rows[i].Cells[3].Value = col.B; // b;
                        dgvCP.Rows[i].Cells[4].Value = col.A; // a;
                        dgvCP.Rows[i].Cells[5].Style.BackColor = col; // Color.FromArgb(a, r, g, b );
                    }
                }
            }
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            saveCP2File(actualCPName + ".cp");
            MessageBox.Show(actualCPName + ".cp successfuly saved");
        }

        void saveCP2File(string fname) // save current color palette
        {
            using (FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    string wrSt = "Index;Color";
                    sr.WriteLine(wrSt);
                    for (int i = 0; i < 256; i++)
                    {
                        wrSt = dgvCP.Rows[i].Cells[0].Value + ";" + ColorTranslator.ToWin32(dgvCP.Rows[i].Cells[5].Style.BackColor);
                        sr.WriteLine(wrSt);
                    }
                    sr.Flush();
                }
            }
        }

        private void bttnCreateNewCP_Click(object sender, EventArgs e) // create new color palette and LUT
        {
            frmTextInput frmNewLut = new frmTextInput("LUT name");
            if (frmNewLut.ShowDialog() == DialogResult.OK)
            {
                actualCPName = frmNewLut.inpuText;
                createNewCP();
                cmbColPaletteTables.Items.Add(actualCPName);
                cmbColPaletteTables.SelectedIndex = cmbColPaletteTables.Items.Count - 1;
            }
        }

        private void cmbColPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualCPName = cmbColPaletteTables.SelectedItem.ToString();
            if (File.Exists(Application.StartupPath + "\\" + actualCPName + ".cp"))
            {
                loadCP(actualCPName + ".cp");
            }
            //fillBaseColors();
            if (File.Exists(Application.StartupPath + "\\" + actualCPName + ".lut"))
            {
                loadLUT(actualCPName + ".lut");
            }
            else
            {
                fillBaseColors();
            }
        }

        private void dgvCP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            Int32 a = Convert.ToInt32(dgvCP.Rows[e.RowIndex].Cells[4].Value);
            Int32 r = Convert.ToInt32(dgvCP.Rows[e.RowIndex].Cells[1].Value);
            Int32 g = Convert.ToInt32(dgvCP.Rows[e.RowIndex].Cells[2].Value);
            Int32 b = Convert.ToInt32(dgvCP.Rows[e.RowIndex].Cells[3].Value);
            try
            {
                dgvCP.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.FromArgb(a, r, g, b);
            }
            catch (Exception err)
            {
                MessageBox.Show("Improper RGB value: " + err.Message + ". change it, please");
            }
        }

        private void bttnRemoveSelectedCP_Click(object sender, EventArgs e)
        {
            if (cmbColPaletteTables.SelectedItem.ToString() == "default")
            {
                MessageBox.Show("Default.cp file cannot be removed");
            }
            else
            {
                if (cmbColPaletteTables.SelectedIndex > -1)
                {
                    if (MessageBox.Show("Are you going to delete this colorpalette and LUT?", "Delete colorpalette and LUT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        actualCPName = cmbColPaletteTables.SelectedItem.ToString();
                        cmbColPaletteTables.Items.RemoveAt(cmbColPaletteTables.SelectedIndex);
                        File.Delete(Application.StartupPath + "\\" + actualCPName + ".cp");
                        File.Delete(Application.StartupPath + "\\" + actualCPName + ".lut");
                        dgvCP.Columns.Clear();
                        dgvLUT.Columns.Clear();
                    }
                }
            }
        }

        private void dgvBaseColors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int[] custom_colors = new int[1];
                ColorDialog cold = new ColorDialog();
                custom_colors[0] = ColorTranslator.ToWin32(dgvLUT.Rows[e.RowIndex].Cells[1].Style.BackColor);
                cold.CustomColors = custom_colors;
                if (cold.ShowDialog() == DialogResult.OK)
                {
                    dgvLUT.Rows[e.RowIndex].Cells[1].Style.BackColor = cold.Color;
                }
                //ColorDialog cold = new ColorDialog();
                //if (cold.ShowDialog()==DialogResult.OK)
                //{
                //    dgvLUT.Rows[e.RowIndex].Cells[1].Style.BackColor = cold.Color;
                //}
            }
        }

        private void bttnGenerateCP_Click(object sender, EventArgs e)
        {
            int k = 0;
            int l = 0;
            for (int i = 1; i < dgvLUT.Rows.Count - 1; i++)
            {
                for (int j = Convert.ToInt16(dgvLUT.Rows[i - 1].Cells[0].Value); j < Convert.ToInt16(dgvLUT.Rows[i].Cells[0].Value); j++)
                {
                    dgvCP.Rows[k].Cells["Color"].Style.BackColor = dgvLUT.Rows[i - 1].Cells["Color"].Style.BackColor;
                    k++;
                }
                l = i;
            }
            for (int j = Convert.ToInt16(dgvLUT.Rows[l - 1].Cells[0].Value); j < Convert.ToInt16(dgvLUT.Rows[l].Cells[0].Value); j++)
            {
                dgvCP.Rows[k].Cells["Color"].Style.BackColor = dgvLUT.Rows[l].Cells["Color"].Style.BackColor;
                k++;
            }
            //dgvCP.Rows[k].Cells["Color"].Style.BackColor = dgvLUT.Rows[l].Cells["Color"].Style.BackColor;
            //int k = 0;
            //for (int i=0; i< numOfColors; i++)
            //{
            //    for (int j=0; j< colorStep; j++)
            //    {
            //        dgvCP.Rows[k].Cells["Color"].Style.BackColor = dgvLUT.Rows[i].Cells["Color"].Style.BackColor;
            //        k += 1;
            //    }
            //}
        }

        void loadLUT(string fname)
        {
            dgvLUT.Columns.Clear();
            dgvLUT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            using (FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = sr.ReadLine();
                    string[] ln = line.Split(';');
                    dgvLUT.Columns.Add(ln[0], ln[0]); // Start Index for colors
                    dgvLUT.Columns.Add(ln[1], ln[1]);  // Color
                    dgvLUT.Columns.Add(ln[2], ln[2]);  // Category
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        dgvLUT.Rows.Add();
                        line = sr.ReadLine();
                        ln = line.Split(';');
                        dgvLUT.Rows[i].Cells[0].Value = ln[0];
                        Int32 c = Convert.ToInt32(ln[1]);
                        Color col = ColorTranslator.FromWin32(c);
                        dgvLUT.Rows[i].Cells[2].Value = ln[2];
                        dgvLUT.Rows[i].Cells[1].Style.BackColor = col;
                        i += 1;
                    }
                }
            }
        }

        private void bttnSaveLUT_Click(object sender, EventArgs e)
        {
            saveLUT(actualCPName + ".lut");
            MessageBox.Show("LUT file was successfully saved");
        }

        void saveLUT(string fname)
        {
            using (FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    string wrSt = "Start;Color;Category";
                    sr.WriteLine(wrSt);
                    for (int i = 0; i < dgvLUT.Rows.Count - 1; i++)
                    {
                        wrSt = dgvLUT.Rows[i].Cells[0].Value + ";" + ColorTranslator.ToWin32(dgvLUT.Rows[i].Cells[1].Style.BackColor) + ";" + dgvLUT.Rows[i].Cells[2].Value;
                        sr.WriteLine(wrSt);
                    }
                    sr.Flush();
                }
            }
        }

        private void tbNumOfColors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int d = Convert.ToInt16(tbNumOfColors.Text) - dgvLUT.Rows.Count + 1;
                int count = dgvLUT.Rows.Count;
                if (d == 0) return;
                if (d < 0)
                {
                    for (int i = 0; i < -d; i++)
                    {
                        dgvLUT.Rows.RemoveAt(dgvLUT.Rows[count - 2 - i].Index);
                    }
                }
                if (d > 0)
                {
                    for (int i = 0; i < d; i++)
                    {
                        dgvLUT.Rows.Add();
                    }
                }
            }
        }

        private void frmLookUpTables_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvLUT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
