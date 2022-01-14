using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace catalog
{
    public partial class frmFolderStructure : Form
    {
        frmImageViewer imageViewer;
        frmDisplayExif exifViewer;
        string selectedFile = "";
        string destinationFolder;
        //string initialDir;

        public frmFolderStructure(int loc)
        {
            InitializeComponent();
            LoadDrives();
            this.Location = new Point(loc, 0);
            this.destinationFolder = Properties.Settings.Default.destinationFolder;
            lblDestination.Text = "Destination folder -> " + destinationFolder;
            bttnCopy2FileSystem.ToolTipText = "Save files to '" + destinationFolder + "' folder";
            dirsTreeView.ExpandAll();
        }


        private void LoadDrives()
        {
            loadDrives();
        }

        void loadDrives()
        {
            string[] drives = Environment.GetLogicalDrives();
            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                TreeNode node = new TreeNode(drive);
                node.Tag = drive;
                node.Name = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");
                dirsTreeView.Nodes.Add(node);
            }
        }
        private void dirsTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    for (int i = 0; i < dirs.Length; i++)
                    {
                        DirectoryInfo di = new DirectoryInfo(dirs[i]);
                        TreeNode node = new TreeNode(di.FullName);   //new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dirs[i];

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            node.Text = Path.GetFileName(dirs[i]);
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }


        private void dirsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lsv.Items.Clear();
            try
            {
                List<string> flist = new List<string>();
                lblSelectedFolder.Text = "Selected folder: " + e.Node.Text;
                flist = Directory.GetFiles(e.Node.Tag.ToString(), "*.tif").ToList();
                flist.AddRange(Directory.GetFiles(e.Node.Tag.ToString(), "*.jpg").ToList());
                string[] files = flist.ToArray();
                for (int j = 0; j < files.Length; j++)
                {
                    {
                        lsv.Items.Add(Path.GetFileName(files[j]));
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Sorry, you are not authorized to enter this folder", "Unauthorized access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                selectedFile = dirsTreeView.SelectedNode.Tag.ToString() + "\\" + lsv.Items[lsv.FocusedItem.Index].Text;
                if (imageViewer != null)
                {
                    imageViewer.loadImage(selectedFile);
                }
                if (exifViewer != null)
                {
                    exifViewer.loadExif(selectedFile);
                }
            }
        }


        private void bttnDisplayImage_Click(object sender, EventArgs e)
        {
            if (selectedFile == "")
            {
                MessageBox.Show("No image file is selected to display. Select one.", "No selected file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            imageViewer = new frmImageViewer(selectedFile);
            imageViewer.Location = new Point(this.Location.X, this.Location.Y + this.Height);
            imageViewer.Show();
        }

        private void bttnExif_Click(object sender, EventArgs e)
        {
            if (selectedFile == "")
            {
                MessageBox.Show("No image file is selected to display EXIF data. Select one.", "No selected file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            exifViewer = new frmDisplayExif(selectedFile);
            exifViewer.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
            exifViewer.Show();
        }

        private void bttnCopy2FileSystem_Click(object sender, EventArgs e)
        {
            if (lsv.Items.Count == 0) { MessageBox.Show("There is no files in the selected folder"); return; }
            string file0 = dirsTreeView.SelectedNode.Tag.ToString() + "\\" + lsv.Items[0].Text;
            string createdTime = File.GetLastWriteTime(file0).ToString();
            string[] d = createdTime.Trim().Split(' ', '_');
            string destiDir = destinationFolder + "\\" + d[0].Replace('.', '-') + d[1].Replace('.', '-') + d[2].Replace('.', '-') + d[3].Replace(':', '-') + "\\";
            Directory.CreateDirectory(destiDir);

            progb.Maximum = lsv.Items.Count;
            progb.Visible = true;
            for (int i = 0; i < lsv.Items.Count; i++)
            {
                progb.PerformStep();
                string SourceFile = dirsTreeView.SelectedNode.Tag.ToString() + "\\" + lsv.Items[i].Text;
                string destiFile = destiDir + "\\" + Path.GetFileName(destiDir + "\\" + lsv.Items[i].Text);
                try
                {
                    File.Copy(SourceFile, destiFile, true);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Existing files:" + err.Message);
                }
            }
            progb.Visible = false;
        }


        private void frmFolderStructure_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default["destinationFolder"] = destinationFolder;
            Properties.Settings.Default.Save();
        }

        private void bttnSelectDestinationFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = false;
            fb.SelectedPath = destinationFolder;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                destinationFolder = fb.SelectedPath;
            }
            lblDestination.Text = "Destination folder -> " + destinationFolder;
        }

        private TreeNode GetNodeByName(TreeNodeCollection nodes, string searchtext)
        {
            TreeNode n_found_node = null;
            bool b_node_found = false;

            foreach (TreeNode node in nodes)
            {

                if (node.Name == searchtext)
                {
                    b_node_found = true;
                    n_found_node = node;

                    return n_found_node;
                }

                if (!b_node_found)
                {
                    n_found_node = GetNodeByName(node.Nodes, searchtext);

                    if (n_found_node != null)
                    {
                        return n_found_node;
                    }
                }
            }
            return null;
        }

        private void lblDestination_Click(object sender, EventArgs e)
        {
            string tex = lblDestination.Text.Split('>')[1].Trim();
        }


    }
}
