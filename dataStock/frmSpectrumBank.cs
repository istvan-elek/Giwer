using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Giwer.dataStock
{
    public partial class frmSpectrumBank : Form
    {
        SQLiteConnectionStringBuilder cnsb = new SQLiteConnectionStringBuilder();
        string spectrumBankName;
        string currentBankName;
        int currentBankIndex;
        public string SpectrumBankPath;
        public DataTable dtSpectrum2Save;
        frmChart frmCh = new frmChart();
        public frmSpectrumBank(string specFolder)
        {
            InitializeComponent();
            SpectrumBankPath = specFolder;
            cnsb.DataSource = specFolder;
            if (System.IO.File.Exists(specFolder))
            {
                LoadAvailableBanks();
                btnCreateNewBank.Enabled = true;
                tslblBankFile.Text = specFolder;
            }
            else tslblBankFile.Text = "";  // dtSpectrum2Save.Rows.Count.ToString();
        }
        

        #region create db and default table

        private void tsbttnCreateNewBankCollectionFile_Click(object sender, EventArgs e)
        {
            frmInputText inpBox = new frmInputText("Create spectrum bank file as Sqlite DB file (*.s3db)");
            if (inpBox.ShowDialog() == DialogResult.OK)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    spectrumBankName = fb.SelectedPath + "\\" + inpBox.tbNewBankName.Text + ".s3db";
                    createNewSpectrumBankCollectionFile(spectrumBankName);
                    SpectrumBankPath = spectrumBankName;
                    LoadAvailableBanks();
                    dgvBank.ClearSelection();
                }
            }
            //frmConfig conf = new frmConfig();
            //conf.config["SpectrumBankFolder"] = SpectrumBankFolder;
            //conf.saveConfig();
        }

        void createNewSpectrumBankCollectionFile(string newName)
        {
            cnsb.DataSource = newName;
            SQLiteConnection.CreateFile(newName);
            cnsb.DataSource = newName;
            cnsb.Version = 3;
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "CREATE DATABASE " + newName + " ENCODING = 'UTF8' LC_COLLATE = 'Hungarian_Hungary.1250' LC_CTYPE = 'Hungarian_Hungary.1250'  CONNECTION LIMIT = -1; ";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        if (e.ErrorCode == -2147467259)
                        {
                            MessageBox.Show("'" + newName + "' is an existing database. Give an other name, or delete the existing one directly", "Error in database creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                dgvBank.DataSource = null;

                createNewBank();
                createSpectrumsTable();
                dgvBank.ClearSelection();
                btnCreateNewBank.Enabled = true;
                btnAddNewSpectrum.Enabled = true;
                tslblBankFile.Text = "Spectrum bank: " + cnsb.DataSource;

                MessageBox.Show("'" + cnsb.DataSource + "' successfully created. Click to 'open' menu item");
            }
        }

        void createNewBank()
        {           
            string tabName = "banks";
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText =
                        "CREATE TABLE " + tabName +
                        "(" +
                        "id integer PRIMARY KEY AUTOINCREMENT NOT NULL," +
                        "bankname varchar(20)," +
                        "description varchar(50)," +
                        "provider varchar(30)" +
                        ")";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO " + tabName + " (bankname) VALUES('default')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void createSpectrumsTable()
        {
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText =
                        "CREATE TABLE spectrums " +
                        "(" +
                        "id integer PRIMARY KEY AUTOINCREMENT NOT NULL," +
                        "name character varying(20)," +
                        "bankname character varying(20)," +
                        "band integer," +
                        "wavelength character varying(10)," +
                        "intensity integer" +
                        //"cathegory character varying(20)" +
                        ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //void insertNewSpectrum(string specName)
        //{
        //    using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
        //    {
        //        cnn.Open();
        //        using (SQLiteCommand cmd = new SQLiteCommand())
        //        {
        //            cmd.Connection = cnn;
        //            cmd.CommandText = "INSERT INTO spectrums" + " (Name) VALUES('" + specName + "')";
        //            cmd.ExecuteNonQuery();
        //        }
        //        dgvSpectrum.DataSource = loadTableData("select * from spectrums");
        //    }
        //}

        private void tsbttnCreateNewBank_Click(object sender, EventArgs e) // new spectrum
        {
            frmInputText inputBankName = new frmInputText("Create new bank");
            if (inputBankName.ShowDialog() == DialogResult.OK)
            {
                using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
                {
                    cnn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = "INSERT INTO banks (bankname) VALUES('" + inputBankName.tbNewBankName.Text + "')";
                        cmd.ExecuteNonQuery();
                        currentBankName = inputBankName.tbNewBankName.Text;
                        this.Text = "Spectrum editor - Bank name: " + inputBankName.tbNewBankName.Text;
                    }
                }
                LoadAvailableBanks();
                this.Text = "Spectrum bank";
                btnDeleteSelectedRecord.Enabled = false;
                dgvBank.ClearSelection();
            }
        }
        #endregion

        private void tsbttnOpenSpectrumBank_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = System.IO.Path.GetDirectoryName( SpectrumBankPath);
            of.Filter = "Spectrum bank files (*.s3db)|*.s3db";
            if (of.ShowDialog()==DialogResult.OK)
            {
                cnsb.DataSource = of.FileName;
                LoadAvailableBanks();
                tslblBankFile.Text = "Bank file name: " + cnsb.DataSource;
                btnCreateNewBank.Enabled = true;
                SpectrumBankPath = of.FileName;
            }
        }

        void LoadAvailableBanks()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                dt = loadTableData("select * from banks");
                if (dt == null) { tslblBankFile.Text = ""; return; }
                dgvBank.DataSource = dt;
                dgvBank.Rows[0].Selected = true;
            }
        }

        DataTable loadTableData(string cmdSql)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                try
                {
                    cnn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cmdSql, cnn))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
                    return dt;
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show("Error in SQL command:" + e.Message, "Sql error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        void deleteSelectedRecord(string id)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                SQLiteCommand cmd = new SQLiteCommand(cnn);
                cmd.CommandText = "DELETE FROM banks WHERE id=" + id;
                cmd.ExecuteNonQuery();
            }
            dgvBank.DataSource = loadTableData("select * from banks");
            this.Text = "Spectrum bank";
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (dgvBank.SelectedRows.Count == 0) return;
            string id = dgvBank.SelectedRows[0].Cells["id"].Value.ToString();
            deleteSelectedRecord(id);
            btnDeleteSelectedRecord.Enabled = false; 
        }


        private void btnCreateNewSpectrum_Click(object sender, EventArgs e)
        {
            //insertNewSpectrum("new bank");
        }

        private void dgvBank_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //currentBankName = dgvBank.Rows[e.RowIndex].Cells[1].Value.ToString();
            //currentBankIndex = int.Parse(dgvBank.Rows[e.RowIndex].Cells[0].Value.ToString());
            //this.Text = "Spectrum bank - current bank: " + currentBankName;
            if (e.ColumnIndex > -1)
            {
                btnDeleteSelectedRecord.Enabled = false;
                dgvBank.ClearSelection();
                dgvSpectrum.DataSource = null;
            }
        }

        private void dgvBank_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDeleteSelectedRecord.Enabled = true;
            currentBankName = dgvBank.SelectedRows[0].Cells[1].Value.ToString();
            currentBankIndex= int.Parse(dgvBank.SelectedRows[0].Cells[0].Value.ToString());
            this.Text = "Spectrum bank - current bank: " + currentBankName;
        }

        private void tabControlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = currentBankName;
            btnAddNewSpectrum.Enabled = !btnAddNewSpectrum.Enabled;
            btnCreateNewBank.Enabled = !btnCreateNewBank.Enabled;
            if (dgvBank.SelectedRows.Count > 0)
            { 
                btnDeleteSelectedRecord.Enabled = !btnDeleteSelectedRecord.Enabled;
                dgvSpectrum.DataSource = bindingSource1;
                bindingSource1.DataSource= loadTableData("select * from spectrums where bankname ='" + currentBankName + "'");

            }
            if (dgvSpectrum.SelectedRows.Count > 0 ) btnDeleteSpectrumRow.Enabled = !btnDeleteSpectrumRow.Enabled;
            
            //if (dgvSpectrum.DataSource == null) dgvSpectrum.DataSource = loadTableData("select * from spectrums" ); 
            
        }


        private void dgvSpectrum_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                btnDeleteSpectrumRow.Enabled = false;
                dgvSpectrum.ClearSelection();
            }
        }

        private void dgvSpectrum_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDeleteSpectrumRow.Enabled = true;
            DataTable dtSelectedSpectrum = new DataTable();
            //if (frmCh == null) frmCh = new frmChart();
            dtSelectedSpectrum = loadTableData("select band,intensity from spectrums where name='" + dgvSpectrum.SelectedRows[0].Cells["name"].Value +"'");
            frmCh.displaySpectrum(dtSelectedSpectrum);
            frmCh.Text = dgvSpectrum.SelectedRows[0].Cells["name"].Value.ToString();
            frmCh.TopMost = true;
            frmCh.StartPosition = FormStartPosition.Manual;
            frmCh.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            frmCh.Show();
        }

        private void btnDeleteSpectrumRow_Click(object sender, EventArgs e)
        {
            if (dgvSpectrum.SelectedRows.Count == 0) return;
            string id = dgvSpectrum.SelectedRows[0].Cells["id"].Value.ToString();
            deleteSelectedSpectrumRow(id);
            btnDeleteSpectrumRow.Enabled = false;
        }

        void deleteSelectedSpectrumRow(string id)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                SQLiteCommand cmd = new SQLiteCommand(cnn);
                cmd.CommandText = "DELETE FROM spectrums WHERE id=" + id;
                cmd.ExecuteNonQuery();
            }
            dgvSpectrum.DataSource = loadTableData("select * from spectrums where bankname ='" + currentBankName + "'");
            this.Text = "Spectrum bank";
        }

        private void tstbSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (tstbSql.Text.ToLower().Contains("select"))
                {
                    if (tabControlBank.SelectedTab.Name == "Banks") dgvBank.DataSource = loadTableData(tstbSql.Text);

                    if (tabControlBank.SelectedTab.Name == "Spectrums") dgvSpectrum.DataSource = loadTableData(tstbSql.Text);
                }
                else
                { 
                    if (tabControlBank.SelectedTab.Name == "Banks")
                    {
                        ExecuteSqlCommand(tstbSql.Text);
                        dgvBank.DataSource = loadTableData("select * from banks");
                    }
                    if (tabControlBank.SelectedTab.Name == "Spectrums")
                    {
                        ExecuteSqlCommand(tstbSql.Text);
                        dgvSpectrum.DataSource = loadTableData("select * from spectrums where bankname ='" + currentBankName + "'");
                    }
                }
            }
        }

        void ExecuteSqlCommand(string sqlCommand)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                SQLiteCommand cmd = new SQLiteCommand(cnn);
                cmd.CommandText = sqlCommand;
                cmd.ExecuteNonQuery();
            }
        }

        private void dgvBank_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBank.Columns[e.ColumnIndex].Name;
            string cellValue = dgvBank[e.ColumnIndex, e.RowIndex].Value.ToString();
            int idx = int.Parse( dgvBank.Rows[e.RowIndex].Cells["id"].Value.ToString());
            SaveChangedCellValue(colName, cellValue, idx);
            this.Text = "Spectrum bank";
        }

        void SaveChangedCellValue(string colName, string cellValue, int idx)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                SQLiteCommand cmdBank = new SQLiteCommand(cnn);
                cmdBank.CommandText = "UPDATE banks SET " + colName + "='" + cellValue + "' WHERE id=" + idx;
                cmdBank.ExecuteNonQuery();
            }
            if (colName=="bankname") updateSpectrumTable(colName, cellValue);
        }

        void updateSpectrumTable(string colName, string cellValue)
        {           
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                SQLiteCommand cmdSpectrum = new SQLiteCommand(cnn);
                string sqlSpec = "UPDATE spectrums SET " + colName + "='" + cellValue + "' WHERE " + colName + "='" + currentBankName + "'";
                cmdSpectrum.CommandText = sqlSpec;
                cmdSpectrum.ExecuteNonQuery();
            }
        }

        private void frmSpectrumBank_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmConfig conf = new frmConfig();
            conf.config["SpectrumBankPath"] = SpectrumBankPath;
            conf.saveConfig();
            frmCh.Close();
        }
    }
}
