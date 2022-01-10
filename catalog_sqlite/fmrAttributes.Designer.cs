namespace catalog
{
    partial class frmAttributes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttributes));
            this.dgvattributes = new System.Windows.Forms.DataGridView();
            this.Attribute_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.bttnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvattributes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvattributes
            // 
            this.dgvattributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvattributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvattributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Attribute_name,
            this.Value});
            this.dgvattributes.Location = new System.Drawing.Point(0, 0);
            this.dgvattributes.Name = "dgvattributes";
            this.dgvattributes.Size = new System.Drawing.Size(313, 267);
            this.dgvattributes.TabIndex = 0;
            this.dgvattributes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvattributes_CellClick);
            this.dgvattributes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvattributes_CellValueChanged);
            // 
            // Attribute_name
            // 
            this.Attribute_name.HeaderText = "Attribute name";
            this.Attribute_name.Name = "Attribute_name";
            this.Attribute_name.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // bttnCancel
            // 
            this.bttnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(12, 290);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 1;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnOk
            // 
            this.bttnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnOk.Location = new System.Drawing.Point(226, 273);
            this.bttnOk.Name = "bttnOk";
            this.bttnOk.Size = new System.Drawing.Size(75, 40);
            this.bttnOk.TabIndex = 2;
            this.bttnOk.Text = "OK";
            this.bttnOk.UseVisualStyleBackColor = true;
            this.bttnOk.Click += new System.EventHandler(this.bttnOk_Click);
            // 
            // frmAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 325);
            this.Controls.Add(this.bttnOk);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.dgvattributes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAttributes";
            this.Text = "Editable image attributes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvattributes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Button bttnOk;
        private System.Windows.Forms.DataGridView dgvattributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}