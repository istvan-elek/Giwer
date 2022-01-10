namespace Giwer.dataStock
{
    partial class frmNDVI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNDVI));
            this.cmbInfraRed = new System.Windows.Forms.ComboBox();
            this.cmbRed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bttnHisto = new System.Windows.Forms.Button();
            this.bttnSaveAsImage = new System.Windows.Forms.Button();
            this.bttnSaveToGiwerFormat = new System.Windows.Forms.Button();
            this.cmbColorPalettes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbInfraRed
            // 
            this.cmbInfraRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInfraRed.FormattingEnabled = true;
            this.cmbInfraRed.Location = new System.Drawing.Point(60, 9);
            this.cmbInfraRed.Name = "cmbInfraRed";
            this.cmbInfraRed.Size = new System.Drawing.Size(40, 21);
            this.cmbInfraRed.TabIndex = 0;
            // 
            // cmbRed
            // 
            this.cmbRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRed.FormattingEnabled = true;
            this.cmbRed.Location = new System.Drawing.Point(60, 33);
            this.cmbRed.Name = "cmbRed";
            this.cmbRed.Size = new System.Drawing.Size(40, 21);
            this.cmbRed.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Infra Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Red band";
            // 
            // bttnOK
            // 
            this.bttnOK.Location = new System.Drawing.Point(12, 171);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(88, 38);
            this.bttnOK.TabIndex = 5;
            this.bttnOK.Text = "OK";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(106, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 514);
            this.panel1.TabIndex = 6;
            // 
            // bttnHisto
            // 
            this.bttnHisto.Location = new System.Drawing.Point(12, 215);
            this.bttnHisto.Name = "bttnHisto";
            this.bttnHisto.Size = new System.Drawing.Size(88, 37);
            this.bttnHisto.TabIndex = 7;
            this.bttnHisto.Text = "Histogram";
            this.bttnHisto.UseVisualStyleBackColor = true;
            this.bttnHisto.Visible = false;
            this.bttnHisto.Click += new System.EventHandler(this.bttnHisto_Click);
            // 
            // bttnSaveAsImage
            // 
            this.bttnSaveAsImage.Location = new System.Drawing.Point(12, 258);
            this.bttnSaveAsImage.Name = "bttnSaveAsImage";
            this.bttnSaveAsImage.Size = new System.Drawing.Size(88, 39);
            this.bttnSaveAsImage.TabIndex = 8;
            this.bttnSaveAsImage.Text = "Save as image";
            this.bttnSaveAsImage.UseVisualStyleBackColor = true;
            this.bttnSaveAsImage.Visible = false;
            this.bttnSaveAsImage.Click += new System.EventHandler(this.bttnSaveAsImage_Click);
            // 
            // bttnSaveToGiwerFormat
            // 
            this.bttnSaveToGiwerFormat.Location = new System.Drawing.Point(12, 303);
            this.bttnSaveToGiwerFormat.Name = "bttnSaveToGiwerFormat";
            this.bttnSaveToGiwerFormat.Size = new System.Drawing.Size(88, 34);
            this.bttnSaveToGiwerFormat.TabIndex = 9;
            this.bttnSaveToGiwerFormat.Text = "Save to Giwer";
            this.bttnSaveToGiwerFormat.UseVisualStyleBackColor = true;
            this.bttnSaveToGiwerFormat.Visible = false;
            this.bttnSaveToGiwerFormat.Click += new System.EventHandler(this.bttnSaveToGiwerFormat_Click);
            // 
            // cmbColorPalettes
            // 
            this.cmbColorPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorPalettes.FormattingEnabled = true;
            this.cmbColorPalettes.Location = new System.Drawing.Point(12, 102);
            this.cmbColorPalettes.Name = "cmbColorPalettes";
            this.cmbColorPalettes.Size = new System.Drawing.Size(88, 21);
            this.cmbColorPalettes.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Color palettes";
            // 
            // frmNDVI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 524);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbColorPalettes);
            this.Controls.Add(this.bttnSaveToGiwerFormat);
            this.Controls.Add(this.bttnSaveAsImage);
            this.Controls.Add(this.bttnHisto);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRed);
            this.Controls.Add(this.cmbInfraRed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNDVI";
            this.Text = "Compute NDVI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInfraRed;
        private System.Windows.Forms.ComboBox cmbRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttnHisto;
        private System.Windows.Forms.Button bttnSaveAsImage;
        private System.Windows.Forms.Button bttnSaveToGiwerFormat;
        private System.Windows.Forms.ComboBox cmbColorPalettes;
        private System.Windows.Forms.Label label3;
    }
}