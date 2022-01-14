using System;
using System.Collections.Generic;
using System.Data;
//using Npgsql;
//using NpgsqlTypes;
using System.Data.SQLite;
using System.Windows.Forms;

namespace catalog
{
    public partial class frmQueryEditor : Form
    {
        SQLiteConnectionStringBuilder cnsb;
        string where = "";
        List<string> whereFields = new List<string>();
        List<string> whereOperators = new List<string>();
        List<string> whereValues = new List<string>();
        List<string> whereAndOr = new List<string>();
        string sql = "";
        public DataTable dtOut;

        public frmQueryEditor(SQLiteConnectionStringBuilder cnsbIn, List<string> fields)
        {
            InitializeComponent();
            cnsb = cnsbIn;
            fillCombos(cmbFields, fields);
            fillCombos(cmbFurtherFields, fields);
        }

        void fillCombos(ComboBox cmb, List<string> flds)
        {
            foreach (string item in flds)
            {
                cmb.Items.Add(item);
            }
        }


        DataTable Query(string sql)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = sql;
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }
            }
            return dt;
        }

        DataTable Query(string field, string oper, string val)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;

                    SQLiteParameter par = cmd.CreateParameter();
                    par.ParameterName = field;
                    //par.DbType = DbType.;
                    par.Value = val;
                    //cmd.Parameters.Add(par);
                    cmd.Parameters.AddWithValue(field, val);
                    sql = "select * from images where " + field + " " + oper + " '" + @par.Value + "'";
                    cmd.CommandText = sql;
                    try
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
                    catch (SQLiteException err)
                    {
                        MessageBox.Show("Error in Sql command: " + err.Message, "Sql error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dt = null;
                    }
                }
            }
            return dt;
        }

        DataTable Query(List<string> field, List<string> oper, List<string> val, List<string> AndOr)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    List<SQLiteParameter> pars = new List<SQLiteParameter>();

                    for (int i = 0; i < field.Count; i++)
                    {
                        SQLiteParameter par = cmd.CreateParameter();
                        par = cmd.CreateParameter();
                        par.ParameterName = field[i];
                        par.Value = val[i];
                        cmd.Parameters.Add(par);
                        pars.Add(par);
                    }
                    string wh = "";

                    for (int j = 0; j < field.Count; j++)
                    {
                        wh += " " + field[j] + " " + oper[j] + " '" + @pars[j].Value + "' " + AndOr[j];
                    }

                    sql = "SELECT * FROM images WHERE " + wh;

                    cmd.CommandText = sql;
                    try
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
                    catch (SQLiteException err)
                    {
                        MessageBox.Show("Error in Sql command: " + err.Message, "Sql error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dt = null;
                    }
                }
            }
            return dt;
        }

        private void bttnAddFurtherWhere_Click(object sender, EventArgs e)
        {
            whereFields.Add(cmbFurtherFields.SelectedItem.ToString());
            whereOperators.Add(cmbFurtherOperator.SelectedItem.ToString());
            whereValues.Add(tbFurtherValue.Text);
            whereAndOr.Add(cmbAndOr.SelectedItem.ToString());
            string condit = cmbFurtherFields.SelectedItem.ToString() + " " + cmbFurtherOperator.SelectedItem.ToString() + " " + tbFurtherValue.Text;
            //lblSql.Text = "WHERE " + condit;
            lblSql.Text = lblSql.Text + " " + cmbAndOr.SelectedItem + " " + condit;
        }


        private void bttnGenerateWhere_Click(object sender, EventArgs e)
        {
            if (cmbFields.SelectedIndex == -1)
            {
                MessageBox.Show("No column name is selected", "Missing column name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmbOperator.SelectedIndex == -1)
            {
                MessageBox.Show("No operator is selected", "Missing operator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (grpAddWhere.Enabled) // ha több where feltétel van
            {
                if ((cmbFurtherFields.SelectedIndex == -1) || (cmbFurtherOperator.SelectedIndex == -1) || (tbFurtherValue.Text == ""))
                {
                    MessageBox.Show("Missing field name, operator or value in further WHERE condition");
                    return;
                }
                whereFields.Insert(0, cmbFields.SelectedItem.ToString());
                whereOperators.Insert(0, cmbOperator.SelectedItem.ToString());
                whereValues.Insert(0, tbValue.Text);
                whereAndOr.Add("");
                for (int i = 0; i < whereFields.Count; i++)
                {
                    where += whereFields[i].ToString() + " " + whereOperators[i].ToString() + " " + whereValues[i].ToString() + " " + whereAndOr[i] + " ";
                }
            }
            else // csak egy where feltétel van
            {
                where = cmbFields.SelectedItem.ToString() + " " + cmbOperator.SelectedItem.ToString() + " " + tbValue.Text;
            }
            sql = " SELECT * FROM images WHERE " + where;
            lblSql.Text = sql;
            bttnExecuteQuery.Enabled = true;
            bttnAddFurtherWhere.Enabled = false;
        }


        private void bttnClearWhere_Click(object sender, EventArgs e)
        {
            sql = "";
            lblSql.Text = "";
            chbAddFurtherWhere.Checked = false;
            //cmbAndOr.SelectedIndex = -1;
            //cmbFields.SelectedIndex = -1;
            //tbValue.Text = "";
            where = "";
            whereFields.Clear();
            whereOperators.Clear();
            whereValues.Clear();
            whereAndOr.Clear();
            bttnExecuteQuery.Enabled = false;
            bttnCloseReturn.Enabled = false;
            bttnAddFurtherWhere.Enabled = true;
        }

        private void ExecuteQuery_Click(object sender, EventArgs e)
        {
            //if (whereFields.Count==0 || whereOperators.Count==0 || whereValues.Count ==0)
            //{
            //    MessageBox.Show("WHERE condition is incomplete in your Sql command: " + sql, "Incomplete WHERE condition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (grpAddWhere.Enabled) // ha több feltétel van
            {
                dgv.DataSource = Query(whereFields, whereOperators, whereValues, whereAndOr);
            }
            else // ha csak egy feltétel van, és nem látszik a további feltétel hozzáadása fül
            {
                dgv.DataSource = Query(cmbFields.SelectedItem.ToString(), cmbOperator.SelectedItem.ToString(), tbValue.Text);
            }
            lblRowsCount.Text = "Query result: " + dgv.Rows.Count.ToString() + " rows";
            bttnCloseReturn.Enabled = true;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnCloseReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            dtOut = (DataTable)(dgv.DataSource);
        }

        private void chbAddFurtherWhere_CheckedChanged(object sender, EventArgs e)
        {
            grpAddWhere.Enabled = !grpAddWhere.Enabled;
            //cmbAndOr.Visible = !cmbAndOr.Visible;
            cmbAndOr.SelectedIndex = 0;
            if (!grpAddWhere.Visible)
            {
                cmbFurtherFields.SelectedIndex = -1;
                tbFurtherValue.Text = "";
                cmbFurtherOperator.SelectedIndex = -1;
            }

        }
    }

}
