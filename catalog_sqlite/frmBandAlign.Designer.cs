
namespace catalog
{
    partial class frmBandAlign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBandAlign));
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.bttnClose = new System.Windows.Forms.Button();
            this.bttnOK = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLabFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnClearFileList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnClearSelectedGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblSelectedGroup = new System.Windows.Forms.ToolStripLabel();
            this.pbPicView = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(2, 28);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(171, 121);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // bttnClose
            // 
            this.bttnClose.Location = new System.Drawing.Point(179, 116);
            this.bttnClose.Name = "bttnClose";
            this.bttnClose.Size = new System.Drawing.Size(94, 33);
            this.bttnClose.TabIndex = 2;
            this.bttnClose.Text = "Close";
            this.bttnClose.UseVisualStyleBackColor = true;
            this.bttnClose.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnOK
            // 
            this.bttnOK.Enabled = false;
            this.bttnOK.Location = new System.Drawing.Point(179, 28);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(94, 66);
            this.bttnOK.TabIndex = 3;
            this.bttnOK.Text = "Start aligner";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stLabFolder});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(541, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stLabFolder
            // 
            this.stLabFolder.Name = "stLabFolder";
            this.stLabFolder.Size = new System.Drawing.Size(118, 17);
            this.stLabFolder.Text = "toolStripStatusLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnOpen,
            this.toolStripSeparator1,
            this.bttnClearFileList,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.bttnClearSelectedGroup,
            this.toolStripSeparator4,
            this.tslblSelectedGroup});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(541, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttnOpen
            // 
            this.bttnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnOpen.Image = ((System.Drawing.Image)(resources.GetObject("bttnOpen.Image")));
            this.bttnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnOpen.Name = "bttnOpen";
            this.bttnOpen.Size = new System.Drawing.Size(23, 22);
            this.bttnOpen.Text = "Load files for band alining";
            this.bttnOpen.Click += new System.EventHandler(this.bttnOpenBands_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bttnClearFileList
            // 
            this.bttnClearFileList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnClearFileList.Image = ((System.Drawing.Image)(resources.GetObject("bttnClearFileList.Image")));
            this.bttnClearFileList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnClearFileList.Name = "bttnClearFileList";
            this.bttnClearFileList.Size = new System.Drawing.Size(23, 22);
            this.bttnClearFileList.Text = "Clear file list";
            this.bttnClearFileList.Click += new System.EventHandler(this.bttnClearList_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Remove selected item";
            this.toolStripButton2.Click += new System.EventHandler(this.bttnClearSelected_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bttnClearSelectedGroup
            // 
            this.bttnClearSelectedGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnClearSelectedGroup.Image = ((System.Drawing.Image)(resources.GetObject("bttnClearSelectedGroup.Image")));
            this.bttnClearSelectedGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnClearSelectedGroup.Name = "bttnClearSelectedGroup";
            this.bttnClearSelectedGroup.Size = new System.Drawing.Size(23, 22);
            this.bttnClearSelectedGroup.Text = "Remove selected group";
            this.bttnClearSelectedGroup.Click += new System.EventHandler(this.bttnClearSelectedFileGroup_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tslblSelectedGroup
            // 
            this.tslblSelectedGroup.Name = "tslblSelectedGroup";
            this.tslblSelectedGroup.Size = new System.Drawing.Size(89, 22);
            this.tslblSelectedGroup.Text = "Selected group:";
            // 
            // pbPicView
            // 
            this.pbPicView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPicView.Location = new System.Drawing.Point(279, 28);
            this.pbPicView.Name = "pbPicView";
            this.pbPicView.Size = new System.Drawing.Size(250, 235);
            this.pbPicView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPicView.TabIndex = 10;
            this.pbPicView.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 244);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmBandAlign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 424);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbPicView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.bttnClose);
            this.Controls.Add(this.lstFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBandAlign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Band aligner";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button bttnClose;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLabFolder;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bttnClearFileList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bttnClearSelectedGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel tslblSelectedGroup;
        private System.Windows.Forms.PictureBox pbPicView;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}