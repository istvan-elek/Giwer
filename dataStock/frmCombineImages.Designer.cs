namespace Giwer.dataStock
{
    partial class frmCombineImages
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
            this.bttnCombineOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBand1 = new System.Windows.Forms.ComboBox();
            this.cmbBand2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOperationType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnCombineOK
            // 
            this.bttnCombineOK.Location = new System.Drawing.Point(180, 32);
            this.bttnCombineOK.Name = "bttnCombineOK";
            this.bttnCombineOK.Size = new System.Drawing.Size(75, 54);
            this.bttnCombineOK.TabIndex = 0;
            this.bttnCombineOK.Text = "OK";
            this.bttnCombineOK.UseVisualStyleBackColor = true;
            this.bttnCombineOK.Click += new System.EventHandler(this.bttnCombineOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Band #1:";
            // 
            // cmbBand1
            // 
            this.cmbBand1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBand1.FormattingEnabled = true;
            this.cmbBand1.Location = new System.Drawing.Point(79, 34);
            this.cmbBand1.Name = "cmbBand1";
            this.cmbBand1.Size = new System.Drawing.Size(64, 21);
            this.cmbBand1.TabIndex = 2;
            // 
            // cmbBand2
            // 
            this.cmbBand2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBand2.FormattingEnabled = true;
            this.cmbBand2.Location = new System.Drawing.Point(79, 70);
            this.cmbBand2.Name = "cmbBand2";
            this.cmbBand2.Size = new System.Drawing.Size(64, 21);
            this.cmbBand2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Band #2:";
            // 
            // cmbOperationType
            // 
            this.cmbOperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperationType.FormattingEnabled = true;
            this.cmbOperationType.Items.AddRange(new object[] {
            "Plus",
            "Minus",
            "Exor"});
            this.cmbOperationType.Location = new System.Drawing.Point(79, 115);
            this.cmbOperationType.Name = "cmbOperationType";
            this.cmbOperationType.Size = new System.Drawing.Size(64, 21);
            this.cmbOperationType.TabIndex = 5;
            this.cmbOperationType.SelectedIndexChanged += new System.EventHandler(this.cmbOperationType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Operation:";
            // 
            // bttnCancel
            // 
            this.bttnCancel.Location = new System.Drawing.Point(180, 113);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 7;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // frmCombineImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 165);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbOperationType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBand2);
            this.Controls.Add(this.cmbBand1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnCombineOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCombineImages";
            this.Text = "Combine image bands";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnCombineOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBand1;
        private System.Windows.Forms.ComboBox cmbBand2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOperationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bttnCancel;
    }
}