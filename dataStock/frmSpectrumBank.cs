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
        string currentBank="";
        public frmSpectrumBank()
        {
            InitializeComponent();
        }

        #region create db and tables
        private void tsbttnCreateNewBankCollectionFile_Click(object sender, EventArgs e)
        {
            frmInputText inpBox = new frmInputText("Create spectrum bank collection file");
            if (inpBox.ShowDialog() == DialogResult.OK)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    spectrumBankName = fb.SelectedPath + "\\" + inpBox.tbNewBankName.Text + ".s3db";
                    createNewSpectrumBankCollectionFile(spectrumBankName);
                }
            }
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
                    //cmd.CommandText = "CREATE DATABASE " + newName + " WITH OWNER = postgres ENCODING = 'UTF8' LC_COLLATE = 'Hungarian_Hungary.1250' LC_CTYPE = 'Hungarian_Hungary.1250' TABLESPACE = pg_default   CONNECTION LIMIT = -1; ";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        if (e.ErrorCode == -2147467259)
                        {
                            MessageBox.Show("'" + newName + "' is an existing database. Give an other name, or delete the existing one directly in Postgres", "Error in database creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                dgv.DataSource = null;
                createSpectrumsTable();
                createNewBank();
                tsbttnCreateNewBank.Enabled = true;
                this.Text = "Spectrum bank: " + cnsb.DataSource;
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
                        "name varchar(20)," +
                        "bandnumber integer," +
                        "description varchar(50)," +
                        "provider varchar(30)" +
                        ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void createSpectrumsTable()
        {
            string tabName = "spectrums";
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
                        "name character varying," +
                        "band integer," +
                        "wavelength integer," +
                        "intensity integer" +
                        ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void tsbttnCreateNewBank_Click(object sender, EventArgs e)
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
                        cmd.CommandText = "INSERT INTO banks (name) VALUES('" + inputBankName.tbNewBankName.Text + "')";
                        cmd.ExecuteNonQuery();
                        currentBank = inputBankName.tbNewBankName.Text;
                        this.Text = "Bank name: " + inputBankName.tbNewBankName.Text;
                    }
                }
                LoadAvailableBankNames();
            }
        }
        #endregion

        private void tsbttnOpenSpectrumBank_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Spectrum bank files (*.s3db)|*.s3db";
            if (of.ShowDialog()==DialogResult.OK)
            {
                cnsb.DataSource = of.FileName;
                LoadAvailableBankNames();
                this.Text = "Bank file name: " + cnsb.DataSource;
                tsbttnCreateNewBank.Enabled = true;
                //dgv.DataSource = loadSelectedBank("Select * from spectrums");
            }
        }

        void LoadAvailableBankNames()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                dt = loadTableData("select name from banks");
            }
            tscmbAvailableSpectrums.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                tscmbAvailableSpectrums.Items.Add(row["name"].ToString());
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
                    //throw;
                    MessageBox.Show("Error in SQL command:" + e.Message, "Sql error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
        
        private void tscmbAvailableSpectrums_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentBank = tscmbAvailableSpectrums.SelectedItem.ToString();
            dgv.DataSource = loadTableData("SELECT * FROM banks WHERE name='" + currentBank  + "'");
            this.Text = "Current bank: " + currentBank;
        }
    }
}
