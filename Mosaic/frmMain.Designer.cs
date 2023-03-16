
namespace Giwer.Mosaic
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabtnLoadProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnMakeMosaic = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMakeGauss = new System.Windows.Forms.ToolStripButton();
            this.lstProj = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabtnLoadProject,
            this.toolStripSeparator1,
            this.tsbtnMakeMosaic,
            this.tsbtnMakeGauss});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(753, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabtnLoadProject
            // 
            this.tabtnLoadProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tabtnLoadProject.Image = ((System.Drawing.Image)(resources.GetObject("tabtnLoadProject.Image")));
            this.tabtnLoadProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tabtnLoadProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabtnLoadProject.Name = "tabtnLoadProject";
            this.tabtnLoadProject.Size = new System.Drawing.Size(37, 37);
            this.tabtnLoadProject.Text = "Load project";
            this.tabtnLoadProject.Click += new System.EventHandler(this.tabtnLoadProject_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnMakeMosaic
            // 
            this.tsbtnMakeMosaic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMakeMosaic.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMakeMosaic.Image")));
            this.tsbtnMakeMosaic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnMakeMosaic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMakeMosaic.Name = "tsbtnMakeMosaic";
            this.tsbtnMakeMosaic.Size = new System.Drawing.Size(36, 37);
            this.tsbtnMakeMosaic.Text = "Draw mosaic";
            this.tsbtnMakeMosaic.Click += new System.EventHandler(this.tsbtnMakeMosaic_Click);
            // 
            // tsbtnMakeGauss
            // 
            this.tsbtnMakeGauss.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMakeGauss.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMakeGauss.Image")));
            this.tsbtnMakeGauss.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnMakeGauss.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMakeGauss.Name = "tsbtnMakeGauss";
            this.tsbtnMakeGauss.Size = new System.Drawing.Size(36, 37);
            this.tsbtnMakeGauss.Text = "Create Gauss pyramid";
            this.tsbtnMakeGauss.Visible = false;
            this.tsbtnMakeGauss.Click += new System.EventHandler(this.tsbtnMakeGauss_Click);
            // 
            // lstProj
            // 
            this.lstProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProj.FormattingEnabled = true;
            this.lstProj.Location = new System.Drawing.Point(0, 0);
            this.lstProj.Name = "lstProj";
            this.lstProj.Size = new System.Drawing.Size(170, 427);
            this.lstProj.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstProj);
            this.splitContainer1.Size = new System.Drawing.Size(753, 427);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 467);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Image mosaic";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tabtnLoadProject;
        private System.Windows.Forms.ListBox lstProj;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnMakeMosaic;
        private System.Windows.Forms.ToolStripButton tsbtnMakeGauss;
    }
}

