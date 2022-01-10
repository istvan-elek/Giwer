using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catalog
{
    public partial class frmBandAlign : Form
    {
        string currentFolder;
        int cropMargin = 500; // margin around the image in pixels. Image will be croped outside of this mrgin
        //int offset = 100;  // buffer for image aligning in pixels
        public frmBandAlign()
        {
            InitializeComponent();
            stLabFolder.Text = "";
            tslblSelectedGroup.Text = "";

        }

        private void bttnOpenBands_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image files|*.jpg;*.tif";
            of.Multiselect = true;
            if (of.ShowDialog()==DialogResult.OK)
            {
                bttnOK.Enabled = true;
                currentFolder = System.IO.Path.GetDirectoryName(of.FileNames[0]);
                stLabFolder.Text = "Current folder: " + currentFolder ;
                foreach (string item in of.FileNames)
                {
                    lstFiles.Items.Add(System.IO.Path.GetFileName(item));
                }
            }
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            if (lstFiles.Items.Count>1)
            {
                this.Cursor = Cursors.WaitCursor;
                MatchBands bandMatching = new MatchBands(cropMargin, currentFolder, lstFiles.Items.Cast<String>().ToList());
                this.Cursor = Cursors.Default;
                pbPicView.Image = null;
            }
            else { MessageBox.Show("There is only one file on the list. You need two files at least. Add another one or more","Too few files",MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }


        }

        private void bttnClearList_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            bttnOK.Enabled = false;
            pbPicView.Image = null;
        }

        private void bttnClearSelected_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex != -1)
            {
                lstFiles.Items.RemoveAt(lstFiles.SelectedIndex);
                pbPicView.Image = null;
                if (lstFiles.Items.Count==0) bttnOK.Enabled = false;
            }
            else { MessageBox.Show("There is no selected item"); }

        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null)
            {
                tslblSelectedGroup.Text = getFileGroup(lstFiles.SelectedItem.ToString());
                string fn = currentFolder + @"\" + lstFiles.SelectedItem;
                MatchBands mb = new MatchBands();
                Image im = Image.FromFile(fn);
                pbPicView.Image = im; //mb.ClipImage((Bitmap)im, new Point(cropMargin, cropMargin));
            }
            else { tslblSelectedGroup.Text = ""; }
        }

        string getFileGroup(string item)
        {
            string groupName = System.IO.Path.GetFileNameWithoutExtension(item);
            groupName = "Selected file group: " + groupName.Substring(0, groupName.Length - 1);
            if (groupName.LastIndexOf('_') < groupName.Length - 2) groupName = "This is probably not a file group";
            return groupName;
        }

        private void bttnClearSelectedFileGroup_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex != -1)
            {
                List<string> flist = new List<string>();
                foreach(string item in lstFiles.Items)
                {
                    string tag=tslblSelectedGroup.Text.Split(':')[1].Trim();
                    if (item.Contains(tag)) flist.Add(item);
                }
                foreach (string itemm in flist) lstFiles.Items.Remove(itemm);
                pbPicView.Image = null;
                if (lstFiles.Items.Count == 0) bttnOK.Enabled = false;
            }
            else { MessageBox.Show("There is no selected item"); }
        }
    }
}
