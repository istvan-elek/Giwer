namespace Giwer.dataStock
{
    partial class frmKernel
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
            this.grpMedian = new System.Windows.Forms.GroupBox();
            this.cmbMedianLength = new System.Windows.Forms.ComboBox();
            this.bttnOK = new System.Windows.Forms.Button();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.bttnComputeKernel = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cmbPixelNumber = new System.Windows.Forms.ComboBox();
            this.tbThreshold = new System.Windows.Forms.TextBox();
            this.grpThreshold = new System.Windows.Forms.GroupBox();
            this.bttnShowHisto = new System.Windows.Forms.Button();
            this.grpMedian.SuspendLayout();
            this.grpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grpThreshold.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMedian
            // 
            this.grpMedian.Controls.Add(this.cmbMedianLength);
            this.grpMedian.Location = new System.Drawing.Point(0, 0);
            this.grpMedian.Name = "grpMedian";
            this.grpMedian.Size = new System.Drawing.Size(219, 77);
            this.grpMedian.TabIndex = 0;
            this.grpMedian.TabStop = false;
            this.grpMedian.Text = "Median filter kernel lenght and threshold";
            // 
            // cmbMedianLength
            // 
            this.cmbMedianLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedianLength.FormattingEnabled = true;
            this.cmbMedianLength.Location = new System.Drawing.Point(12, 20);
            this.cmbMedianLength.Name = "cmbMedianLength";
            this.cmbMedianLength.Size = new System.Drawing.Size(58, 21);
            this.cmbMedianLength.TabIndex = 3;
            this.cmbMedianLength.SelectedIndexChanged += new System.EventHandler(this.cmbLenght_SelectedIndexChanged);
            // 
            // bttnOK
            // 
            this.bttnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnOK.Enabled = false;
            this.bttnOK.Location = new System.Drawing.Point(515, 20);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(84, 30);
            this.bttnOK.TabIndex = 3;
            this.bttnOK.Text = "OK";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click_1);
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.bttnComputeKernel);
            this.grpFilters.Controls.Add(this.dgv);
            this.grpFilters.Controls.Add(this.cmbPixelNumber);
            this.grpFilters.Location = new System.Drawing.Point(1, 83);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(218, 204);
            this.grpFilters.TabIndex = 4;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Gauss filter\'s kernel";
            // 
            // bttnComputeKernel
            // 
            this.bttnComputeKernel.Enabled = false;
            this.bttnComputeKernel.Location = new System.Drawing.Point(78, 22);
            this.bttnComputeKernel.Name = "bttnComputeKernel";
            this.bttnComputeKernel.Size = new System.Drawing.Size(98, 23);
            this.bttnComputeKernel.TabIndex = 3;
            this.bttnComputeKernel.Text = "Compute kernel";
            this.bttnComputeKernel.UseVisualStyleBackColor = true;
            this.bttnComputeKernel.Click += new System.EventHandler(this.bttnComputeKernel_Click_1);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(6, 51);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(206, 147);
            this.dgv.TabIndex = 2;
            this.dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_RowHeaderMouseClick);
            // 
            // cmbPixelNumber
            // 
            this.cmbPixelNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPixelNumber.FormattingEnabled = true;
            this.cmbPixelNumber.Location = new System.Drawing.Point(6, 22);
            this.cmbPixelNumber.Name = "cmbPixelNumber";
            this.cmbPixelNumber.Size = new System.Drawing.Size(54, 21);
            this.cmbPixelNumber.TabIndex = 0;
            this.cmbPixelNumber.SelectedIndexChanged += new System.EventHandler(this.cmbPixelNumber_SelectedIndexChanged);
            // 
            // tbThreshold
            // 
            this.tbThreshold.Location = new System.Drawing.Point(6, 28);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(100, 20);
            this.tbThreshold.TabIndex = 4;
            this.tbThreshold.Text = "Threshold value";
            this.tbThreshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbThreshold_KeyDown);
            // 
            // grpThreshold
            // 
            this.grpThreshold.Controls.Add(this.bttnShowHisto);
            this.grpThreshold.Controls.Add(this.tbThreshold);
            this.grpThreshold.Location = new System.Drawing.Point(225, 12);
            this.grpThreshold.Name = "grpThreshold";
            this.grpThreshold.Size = new System.Drawing.Size(166, 144);
            this.grpThreshold.TabIndex = 5;
            this.grpThreshold.TabStop = false;
            this.grpThreshold.Text = "Set threshold";
            // 
            // bttnShowHisto
            // 
            this.bttnShowHisto.Location = new System.Drawing.Point(6, 54);
            this.bttnShowHisto.Name = "bttnShowHisto";
            this.bttnShowHisto.Size = new System.Drawing.Size(99, 23);
            this.bttnShowHisto.TabIndex = 5;
            this.bttnShowHisto.Text = "Show histogram";
            this.bttnShowHisto.UseVisualStyleBackColor = true;
            this.bttnShowHisto.Click += new System.EventHandler(this.bttnShowHisto_Click);
            // 
            // frmKernel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 471);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.grpThreshold);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.grpMedian);
            this.Name = "frmKernel";
            this.Text = "Set kernel length";
            this.grpMedian.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.grpThreshold.ResumeLayout(false);
            this.grpThreshold.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMedian;
        private System.Windows.Forms.ComboBox cmbMedianLength;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Button bttnComputeKernel;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cmbPixelNumber;
        private System.Windows.Forms.TextBox tbThreshold;
        private System.Windows.Forms.GroupBox grpThreshold;
        private System.Windows.Forms.Button bttnShowHisto;
    }
}