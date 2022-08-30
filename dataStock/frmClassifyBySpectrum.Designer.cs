
namespace Giwer.dataStock
{
    partial class frmClassifyBySpectrum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassifyBySpectrum));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.btnOpenProjFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenSpectrumBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSpecBanks = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbConfidenceValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStartClassification = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblBankFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblGiwerFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsPb = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenFile,
            this.btnOpenProjFile,
            this.toolStripSeparator1,
            this.btnOpenSpectrumBank,
            this.toolStripLabel1,
            this.cmbSpecBanks,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tbConfidenceValue,
            this.toolStripSeparator3,
            this.btnStartClassification});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(23, 22);
            this.btnOpenFile.Text = "Open image in gwr format";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnOpenProjFile
            // 
            this.btnOpenProjFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenProjFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenProjFile.Image")));
            this.btnOpenProjFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenProjFile.Name = "btnOpenProjFile";
            this.btnOpenProjFile.Size = new System.Drawing.Size(23, 22);
            this.btnOpenProjFile.Text = "Open project file (*.proj)";
            this.btnOpenProjFile.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpenSpectrumBank
            // 
            this.btnOpenSpectrumBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenSpectrumBank.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSpectrumBank.Image")));
            this.btnOpenSpectrumBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenSpectrumBank.Name = "btnOpenSpectrumBank";
            this.btnOpenSpectrumBank.Size = new System.Drawing.Size(23, 22);
            this.btnOpenSpectrumBank.Text = "Open spectrum bank";
            this.btnOpenSpectrumBank.Click += new System.EventHandler(this.btnOpenSpectrumBank_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(132, 22);
            this.toolStripLabel1.Text = "Choose spectrum bank:";
            // 
            // cmbSpecBanks
            // 
            this.cmbSpecBanks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecBanks.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbSpecBanks.Name = "cmbSpecBanks";
            this.cmbSpecBanks.Size = new System.Drawing.Size(121, 25);
            this.cmbSpecBanks.SelectedIndexChanged += new System.EventHandler(this.cmbSpecBanks_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(122, 22);
            this.toolStripLabel2.Text = "Correlation threshold:";
            // 
            // tbConfidenceValue
            // 
            this.tbConfidenceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConfidenceValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbConfidenceValue.Name = "tbConfidenceValue";
            this.tbConfidenceValue.Size = new System.Drawing.Size(100, 25);
            this.tbConfidenceValue.Text = "0.9";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStartClassification
            // 
            this.btnStartClassification.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartClassification.Image = ((System.Drawing.Image)(resources.GetObject("btnStartClassification.Image")));
            this.btnStartClassification.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartClassification.Name = "btnStartClassification";
            this.btnStartClassification.Size = new System.Drawing.Size(23, 22);
            this.btnStartClassification.Text = "Run classification process";
            this.btnStartClassification.Click += new System.EventHandler(this.btnStartClassification_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblBankFile,
            this.tslblGiwerFileName,
            this.tsPb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblBankFile
            // 
            this.tslblBankFile.Name = "tslblBankFile";
            this.tslblBankFile.Size = new System.Drawing.Size(112, 17);
            this.tslblBankFile.Text = "Spectrum bank file: ";
            // 
            // tslblGiwerFileName
            // 
            this.tslblGiwerFileName.Name = "tslblGiwerFileName";
            this.tslblGiwerFileName.Size = new System.Drawing.Size(107, 17);
            this.tslblGiwerFileName.Text = "    Giwer file name: ";
            // 
            // tsPb
            // 
            this.tsPb.Name = "tsPb";
            this.tsPb.Size = new System.Drawing.Size(100, 16);
            this.tsPb.Step = 1;
            this.tsPb.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 403);
            this.panel1.TabIndex = 2;
            // 
            // frmClassifyBySpectrum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClassifyBySpectrum";
            this.Text = "Classification by spectrum";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpenFile;
        private System.Windows.Forms.ToolStripButton btnOpenProjFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnOpenSpectrumBank;
        private System.Windows.Forms.ToolStripComboBox cmbSpecBanks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnStartClassification;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblBankFile;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbConfidenceValue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel tslblGiwerFileName;
        private System.Windows.Forms.ToolStripProgressBar tsPb;
        private System.Windows.Forms.Panel panel1;
    }
}