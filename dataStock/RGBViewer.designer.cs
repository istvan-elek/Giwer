namespace Giwer.dataStock
{
    partial class RGBViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RGBViewer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbGreen = new System.Windows.Forms.ComboBox();
            this.cmbBlue = new System.Windows.Forms.ComboBox();
            this.cmbRed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttnRGBCreation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnHisto = new System.Windows.Forms.ToolStripButton();
            this.bttnHistoEq = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBttnSaveImage = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(114, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 523);
            this.panel1.TabIndex = 0;
            // 
            // cmbGreen
            // 
            this.cmbGreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGreen.FormattingEnabled = true;
            this.cmbGreen.Location = new System.Drawing.Point(57, 50);
            this.cmbGreen.Name = "cmbGreen";
            this.cmbGreen.Size = new System.Drawing.Size(44, 21);
            this.cmbGreen.TabIndex = 3;
            // 
            // cmbBlue
            // 
            this.cmbBlue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlue.FormattingEnabled = true;
            this.cmbBlue.Location = new System.Drawing.Point(57, 77);
            this.cmbBlue.Name = "cmbBlue";
            this.cmbBlue.Size = new System.Drawing.Size(44, 21);
            this.cmbBlue.TabIndex = 4;
            // 
            // cmbRed
            // 
            this.cmbRed.BackColor = System.Drawing.SystemColors.Window;
            this.cmbRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRed.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbRed.FormattingEnabled = true;
            this.cmbRed.Location = new System.Drawing.Point(57, 23);
            this.cmbRed.Name = "cmbRed";
            this.cmbRed.Size = new System.Drawing.Size(44, 21);
            this.cmbRed.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Blue";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbGreen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbBlue);
            this.groupBox1.Controls.Add(this.cmbRed);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 316);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bands for RGB";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnRGBCreation,
            this.toolStripSeparator2,
            this.bttnHisto,
            this.bttnHistoEq,
            this.toolStripSeparator1,
            this.tsBttnSaveImage});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 138);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(37, 179);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttnRGBCreation
            // 
            this.bttnRGBCreation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnRGBCreation.Image = ((System.Drawing.Image)(resources.GetObject("bttnRGBCreation.Image")));
            this.bttnRGBCreation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnRGBCreation.Name = "bttnRGBCreation";
            this.bttnRGBCreation.Size = new System.Drawing.Size(35, 36);
            this.bttnRGBCreation.Text = "Create RGB";
            this.bttnRGBCreation.Click += new System.EventHandler(this.bttnCreateRGB_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(35, 6);
            // 
            // bttnHisto
            // 
            this.bttnHisto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnHisto.Enabled = false;
            this.bttnHisto.Image = ((System.Drawing.Image)(resources.GetObject("bttnHisto.Image")));
            this.bttnHisto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnHisto.Name = "bttnHisto";
            this.bttnHisto.Size = new System.Drawing.Size(35, 36);
            this.bttnHisto.Text = "Show histogram";
            this.bttnHisto.Click += new System.EventHandler(this.bttnShowHisto_Click);
            // 
            // bttnHistoEq
            // 
            this.bttnHistoEq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnHistoEq.Enabled = false;
            this.bttnHistoEq.Image = ((System.Drawing.Image)(resources.GetObject("bttnHistoEq.Image")));
            this.bttnHistoEq.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnHistoEq.Name = "bttnHistoEq";
            this.bttnHistoEq.Size = new System.Drawing.Size(35, 36);
            this.bttnHistoEq.Text = "Automatic histogram equalisation";
            this.bttnHistoEq.Click += new System.EventHandler(this.bttnHistoEq_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(35, 6);
            // 
            // tsBttnSaveImage
            // 
            this.tsBttnSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBttnSaveImage.Enabled = false;
            this.tsBttnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("tsBttnSaveImage.Image")));
            this.tsBttnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBttnSaveImage.Name = "tsBttnSaveImage";
            this.tsBttnSaveImage.Size = new System.Drawing.Size(35, 36);
            this.tsBttnSaveImage.Text = "Save as image";
            this.tsBttnSaveImage.Click += new System.EventHandler(this.bttnSaveAsImage_Click);
            // 
            // RGBViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RGBViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RGBViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RGBViewer_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbGreen;
        private System.Windows.Forms.ComboBox cmbBlue;
        private System.Windows.Forms.ComboBox cmbRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttnHisto;
        //private System.Windows.Forms.ToolStripButton bttnSaveImage;
        private System.Windows.Forms.ToolStripButton bttnRGBCreation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBttnSaveImage;
        private System.Windows.Forms.ToolStripButton bttnHistoEq;
    }
}