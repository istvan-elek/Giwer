namespace Giwer.dataStock
{
    partial class frmPCA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPCA));
            this.chkListBands = new System.Windows.Forms.CheckedListBox();
            this.chkbBands = new System.Windows.Forms.CheckBox();
            this.bttnOKCorr = new System.Windows.Forms.Button();
            this.tbCorr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttnComputePCs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWhichPC = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkListBands
            // 
            this.chkListBands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkListBands.FormattingEnabled = true;
            this.chkListBands.Location = new System.Drawing.Point(6, 60);
            this.chkListBands.Name = "chkListBands";
            this.chkListBands.Size = new System.Drawing.Size(104, 304);
            this.chkListBands.TabIndex = 0;
            this.chkListBands.SelectedIndexChanged += new System.EventHandler(this.chkListBands_SelectedIndexChanged);
            // 
            // chkbBands
            // 
            this.chkbBands.AutoSize = true;
            this.chkbBands.Checked = true;
            this.chkbBands.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbBands.Location = new System.Drawing.Point(9, 32);
            this.chkbBands.Name = "chkbBands";
            this.chkbBands.Size = new System.Drawing.Size(101, 17);
            this.chkbBands.TabIndex = 2;
            this.chkbBands.Text = "Select all bands";
            this.chkbBands.UseVisualStyleBackColor = true;
            this.chkbBands.CheckedChanged += new System.EventHandler(this.chkbBands_CheckedChanged);
            // 
            // bttnOKCorr
            // 
            this.bttnOKCorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnOKCorr.Location = new System.Drawing.Point(138, 319);
            this.bttnOKCorr.Name = "bttnOKCorr";
            this.bttnOKCorr.Size = new System.Drawing.Size(112, 33);
            this.bttnOKCorr.TabIndex = 3;
            this.bttnOKCorr.Text = "Compute correlation";
            this.bttnOKCorr.UseVisualStyleBackColor = true;
            this.bttnOKCorr.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // tbCorr
            // 
            this.tbCorr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCorr.Location = new System.Drawing.Point(128, 60);
            this.tbCorr.Multiline = true;
            this.tbCorr.Name = "tbCorr";
            this.tbCorr.ReadOnly = true;
            this.tbCorr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCorr.Size = new System.Drawing.Size(300, 178);
            this.tbCorr.TabIndex = 6;
            this.tbCorr.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Correlation matrix";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bttnComputePCs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbWhichPC);
            this.groupBox1.Controls.Add(this.tbCorr);
            this.groupBox1.Controls.Add(this.bttnOKCorr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkbBands);
            this.groupBox1.Controls.Add(this.chkListBands);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 364);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available bands for PCA";
            // 
            // bttnComputePCs
            // 
            this.bttnComputePCs.Enabled = false;
            this.bttnComputePCs.Location = new System.Drawing.Point(342, 307);
            this.bttnComputePCs.Name = "bttnComputePCs";
            this.bttnComputePCs.Size = new System.Drawing.Size(86, 45);
            this.bttnComputePCs.TabIndex = 10;
            this.bttnComputePCs.Text = "Apply to image";
            this.bttnComputePCs.UseVisualStyleBackColor = true;
            this.bttnComputePCs.Click += new System.EventHandler(this.bttnComputePCs_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Which principal component should be computed:";
            // 
            // cmbWhichPC
            // 
            this.cmbWhichPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWhichPC.FormattingEnabled = true;
            this.cmbWhichPC.Location = new System.Drawing.Point(138, 279);
            this.cmbWhichPC.Name = "cmbWhichPC";
            this.cmbWhichPC.Size = new System.Drawing.Size(47, 21);
            this.cmbWhichPC.TabIndex = 8;
            // 
            // frmPCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 364);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPCA";
            this.Text = "Compute Principal Components";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPCA_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkListBands;
        private System.Windows.Forms.CheckBox chkbBands;
        private System.Windows.Forms.Button bttnOKCorr;
        private System.Windows.Forms.TextBox tbCorr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWhichPC;
        private System.Windows.Forms.Button bttnComputePCs;
    }
}