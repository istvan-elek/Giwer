using System;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmRasterCalculator : Form
    {
        byte[] byIn;
        public byte[] byOut;
        public frmRasterCalculator(byte[] bIn)
        {
            InitializeComponent();
            byIn = bIn;
            byOut = new byte[byIn.Length];
        }

        void VerifyInputText(string val, object Sender)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(val, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                ((TextBox)Sender).Text = ((TextBox)Sender).Text.Remove(((TextBox)Sender).Text.Length - 1);
            }
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            VerifyInputText(tbValue.Text, sender);
        }

        private void bttnGo_Click(object sender, EventArgs e)
        {
            if (tbValue.Text=="" )
            {
                MessageBox.Show("Selection value has not been set"); return;
            }
            if (Convert.ToInt16(tbSelectedIntValue.Text) >255 || Convert.ToInt16(tbElseValue.Text) >255)
            {
                MessageBox.Show("The given value is biger then 255"); return;
            }
            if (Convert.ToInt16(tbSelectedIntValue.Text) <  0 || Convert.ToInt16(tbElseValue.Text) <0)
            {
                MessageBox.Show("The marked value (selected) is smaller then 0"); return;
            }
            if (cmbMuvelet.SelectedIndex == -1)
            {
                MessageBox.Show("=, <, > characters must be set"); return;
            }
            this.Cursor = Cursors.WaitCursor;
            switch (cmbMuvelet.SelectedItem.ToString())
            {
                case "=":
                    for (Int32 i = 0; i < byIn.Length; i++)
                    {
                        if (byIn[i] == Convert.ToByte(tbValue.Text)) 
                        { byOut[i] = Convert.ToByte(tbSelectedIntValue.Text); }
                        else { byOut[i] = Convert.ToByte(tbElseValue.Text); }
                    }                    
                    break;
                case "!=":
                    for (Int32 i = 0; i < byIn.Length; i++)
                    {
                        if (byIn[i] != Convert.ToByte(tbValue.Text)) 
                        { byOut[i] = Convert.ToByte(tbSelectedIntValue.Text); }
                        else { byOut[i] = Convert.ToByte(tbElseValue.Text); }
                    }
                    break;
                case "<":
                    for (Int32 i = 0; i < byIn.Length; i++)
                    {
                        if (byIn[i] < Convert.ToByte(tbValue.Text))
                        { byOut[i] = Convert.ToByte(tbSelectedIntValue.Text); }
                        else { byOut[i] = Convert.ToByte(tbElseValue.Text); } 
                    }
                    break;
                case ">":
                    for (Int32 i = 0; i < byIn.Length; i++)
                    {
                        if (byIn[i] > Convert.ToByte(tbValue.Text)) 
                        { byOut[i] = Convert.ToByte(tbSelectedIntValue.Text); }
                        else { byOut[i] = Convert.ToByte(tbElseValue.Text); } 
                    }
                    break;
            }
            this.Cursor = Cursors.Default;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbSelectedIntValue_TextChanged(object sender, EventArgs e)
        {
            VerifyInputText(tbSelectedIntValue.Text, sender);
        }

        private void frmRasterCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK) this.Close();
        }

        private void tbLowerValue_TextChanged(object sender, EventArgs e)
        {
            VerifyInputText(tbLowerValue.Text, sender);
        }

        private void tbUpperValue_TextChanged(object sender, EventArgs e)
        {
            VerifyInputText(tbUpperValue.Text, sender);
        }

        private void tbValueIntBetween_TextChanged(object sender, EventArgs e)
        {
            VerifyInputText(tbValueIntBetween.Text, sender);
        }

        private void bttnGoBetween_Click(object sender, EventArgs e)
        {
            if (tbUpperValue.Text == "" || tbLowerValue.Text == "")
            {
                MessageBox.Show("Upper or Lower values have not been set"); return;
            }
            if (Convert.ToInt16(tbUpperValue.Text) > 255 || Convert.ToInt16(tbLowerValue.Text) > 255 )
            {
                MessageBox.Show("Upper or Lower value is biger then 255"); return;
            }
            if (Convert.ToInt16(tbValueIntBetween.Text) > 255 )
            {
                MessageBox.Show("The marked value (selected) is biger then 255"); return;
            }
            this.Cursor = Cursors.WaitCursor;
            for (Int32 i = 0; i < byIn.Length; i++)
            {
                if (byIn[i] > Convert.ToByte(tbLowerValue.Text) && byIn[i] < Convert.ToByte(tbUpperValue.Text))
                { byOut[i] = Convert.ToByte(tbValueIntBetween.Text); }
            }
            this.Cursor = Cursors.Default;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
