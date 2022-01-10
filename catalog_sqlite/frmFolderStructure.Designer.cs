namespace catalog
{
    partial class frmFolderStructure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFolderStructure));
            this.dirsTreeView = new System.Windows.Forms.TreeView();
            this.lsv = new System.Windows.Forms.ListView();
            this.lblSelectedFolder = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttnDisplayImage = new System.Windows.Forms.ToolStripButton();
            this.bttnExif = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnCopy2FileSystem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnSelectDestinationFolder = new System.Windows.Forms.ToolStripButton();
            this.bttnBandAligner = new System.Windows.Forms.ToolStripButton();
            this.progb = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDestination = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dirsTreeView
            // 
            this.dirsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dirsTreeView.Location = new System.Drawing.Point(0, 13);
            this.dirsTreeView.Name = "dirsTreeView";
            this.dirsTreeView.Size = new System.Drawing.Size(339, 439);
            this.dirsTreeView.TabIndex = 0;
            this.dirsTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.dirsTreeView_BeforeExpand);
            this.dirsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dirsTreeView_NodeMouseClick);
            // 
            // lsv
            // 
            this.lsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsv.GridLines = true;
            this.lsv.HideSelection = false;
            this.lsv.Location = new System.Drawing.Point(0, 39);
            this.lsv.Name = "lsv";
            this.lsv.Size = new System.Drawing.Size(378, 400);
            this.lsv.TabIndex = 1;
            this.lsv.UseCompatibleStateImageBehavior = false;
            this.lsv.View = System.Windows.Forms.View.List;
            this.lsv.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsv_ItemSelectionChanged);
            // 
            // lblSelectedFolder
            // 
            this.lblSelectedFolder.AutoSize = true;
            this.lblSelectedFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectedFolder.Location = new System.Drawing.Point(0, 0);
            this.lblSelectedFolder.Name = "lblSelectedFolder";
            this.lblSelectedFolder.Size = new System.Drawing.Size(41, 13);
            this.lblSelectedFolder.TabIndex = 2;
            this.lblSelectedFolder.Text = "Folders";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dirsTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.lblSelectedFolder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lsv);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.lblDestination);
            this.splitContainer1.Size = new System.Drawing.Size(721, 452);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnDisplayImage,
            this.bttnExif,
            this.toolStripSeparator1,
            this.bttnCopy2FileSystem,
            this.toolStripSeparator2,
            this.bttnSelectDestinationFolder,
            this.bttnBandAligner,
            this.progb,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(378, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttnDisplayImage
            // 
            this.bttnDisplayImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnDisplayImage.Image = ((System.Drawing.Image)(resources.GetObject("bttnDisplayImage.Image")));
            this.bttnDisplayImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bttnDisplayImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnDisplayImage.Name = "bttnDisplayImage";
            this.bttnDisplayImage.Size = new System.Drawing.Size(36, 36);
            this.bttnDisplayImage.Text = "Display image";
            this.bttnDisplayImage.Click += new System.EventHandler(this.bttnDisplayImage_Click);
            // 
            // bttnExif
            // 
            this.bttnExif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnExif.Image = ((System.Drawing.Image)(resources.GetObject("bttnExif.Image")));
            this.bttnExif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bttnExif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnExif.Name = "bttnExif";
            this.bttnExif.Size = new System.Drawing.Size(36, 36);
            this.bttnExif.Text = "Show exif data";
            this.bttnExif.Click += new System.EventHandler(this.bttnExif_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bttnCopy2FileSystem
            // 
            this.bttnCopy2FileSystem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnCopy2FileSystem.Image = ((System.Drawing.Image)(resources.GetObject("bttnCopy2FileSystem.Image")));
            this.bttnCopy2FileSystem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bttnCopy2FileSystem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnCopy2FileSystem.Name = "bttnCopy2FileSystem";
            this.bttnCopy2FileSystem.Size = new System.Drawing.Size(36, 36);
            this.bttnCopy2FileSystem.Text = "Copy to file system";
            this.bttnCopy2FileSystem.Click += new System.EventHandler(this.bttnCopy2FileSystem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // bttnSelectDestinationFolder
            // 
            this.bttnSelectDestinationFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bttnSelectDestinationFolder.Image = ((System.Drawing.Image)(resources.GetObject("bttnSelectDestinationFolder.Image")));
            this.bttnSelectDestinationFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnSelectDestinationFolder.Name = "bttnSelectDestinationFolder";
            this.bttnSelectDestinationFolder.Size = new System.Drawing.Size(123, 36);
            this.bttnSelectDestinationFolder.Text = "Set destination folder";
            this.bttnSelectDestinationFolder.Click += new System.EventHandler(this.bttnSelectDestinationFolder_Click);
            // 
            // bttnBandAligner
            // 
            this.bttnBandAligner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnBandAligner.Image = ((System.Drawing.Image)(resources.GetObject("bttnBandAligner.Image")));
            this.bttnBandAligner.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bttnBandAligner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnBandAligner.Name = "bttnBandAligner";
            this.bttnBandAligner.Size = new System.Drawing.Size(36, 36);
            this.bttnBandAligner.Text = "Band aligner";
            this.bttnBandAligner.Visible = false;
            // 
            // progb
            // 
            this.progb.AutoSize = false;
            this.progb.Name = "progb";
            this.progb.Size = new System.Drawing.Size(60, 16);
            this.progb.Step = 1;
            this.progb.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDestination.Location = new System.Drawing.Point(0, 439);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(95, 13);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "Destination folder -";
            this.lblDestination.Click += new System.EventHandler(this.lblDestination_Click);
            // 
            // frmFolderStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 452);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFolderStructure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Folder structure";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFolderStructure_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView dirsTreeView;
        private System.Windows.Forms.ListView lsv;
        private System.Windows.Forms.Label lblSelectedFolder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttnDisplayImage;
        private System.Windows.Forms.ToolStripButton bttnExif;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bttnCopy2FileSystem;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bttnSelectDestinationFolder;
        private System.Windows.Forms.ToolStripProgressBar progb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bttnBandAligner;
    }
}