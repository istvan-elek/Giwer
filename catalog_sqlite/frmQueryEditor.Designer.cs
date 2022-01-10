namespace catalog
{
    partial class frmQueryEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryEditor));
            this.bttnCancel = new System.Windows.Forms.Button();
            this.bttnExecuteQuery = new System.Windows.Forms.Button();
            this.lblSql = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpAddWhere = new System.Windows.Forms.GroupBox();
            this.bttnAddFurtherWhere = new System.Windows.Forms.Button();
            this.tbFurtherValue = new System.Windows.Forms.TextBox();
            this.cmbAndOr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFurtherOperator = new System.Windows.Forms.ComboBox();
            this.cmbFurtherFields = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbAddFurtherWhere = new System.Windows.Forms.CheckBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.cmbFields = new System.Windows.Forms.ComboBox();
            this.lblField = new System.Windows.Forms.Label();
            this.bttnClearWhere = new System.Windows.Forms.Button();
            this.bttnGenerateWhere = new System.Windows.Forms.Button();
            this.bttnCloseReturn = new System.Windows.Forms.Button();
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpAddWhere.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttnCancel
            // 
            this.bttnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnCancel.Location = new System.Drawing.Point(518, 546);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 55);
            this.bttnCancel.TabIndex = 0;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnExecuteQuery
            // 
            this.bttnExecuteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnExecuteQuery.Enabled = false;
            this.bttnExecuteQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnExecuteQuery.Location = new System.Drawing.Point(12, 546);
            this.bttnExecuteQuery.Name = "bttnExecuteQuery";
            this.bttnExecuteQuery.Size = new System.Drawing.Size(217, 55);
            this.bttnExecuteQuery.TabIndex = 1;
            this.bttnExecuteQuery.Text = "Execute query";
            this.bttnExecuteQuery.UseVisualStyleBackColor = true;
            this.bttnExecuteQuery.Click += new System.EventHandler(this.ExecuteQuery_Click);
            // 
            // lblSql
            // 
            this.lblSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSql.AutoSize = true;
            this.lblSql.Location = new System.Drawing.Point(12, 530);
            this.lblSql.Name = "lblSql";
            this.lblSql.Size = new System.Drawing.Size(0, 13);
            this.lblSql.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(308, 31);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(530, 478);
            this.dgv.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.grpAddWhere);
            this.groupBox1.Controls.Add(this.chbAddFurtherWhere);
            this.groupBox1.Controls.Add(this.tbValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbOperator);
            this.groupBox1.Controls.Add(this.cmbFields);
            this.groupBox1.Controls.Add(this.lblField);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 430);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit WHERE condition";
            // 
            // grpAddWhere
            // 
            this.grpAddWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAddWhere.Controls.Add(this.label8);
            this.grpAddWhere.Controls.Add(this.label7);
            this.grpAddWhere.Controls.Add(this.bttnAddFurtherWhere);
            this.grpAddWhere.Controls.Add(this.tbFurtherValue);
            this.grpAddWhere.Controls.Add(this.cmbAndOr);
            this.grpAddWhere.Controls.Add(this.label4);
            this.grpAddWhere.Controls.Add(this.label5);
            this.grpAddWhere.Controls.Add(this.cmbFurtherOperator);
            this.grpAddWhere.Controls.Add(this.cmbFurtherFields);
            this.grpAddWhere.Controls.Add(this.label6);
            this.grpAddWhere.Enabled = false;
            this.grpAddWhere.Location = new System.Drawing.Point(9, 186);
            this.grpAddWhere.Name = "grpAddWhere";
            this.grpAddWhere.Size = new System.Drawing.Size(263, 238);
            this.grpAddWhere.TabIndex = 9;
            this.grpAddWhere.TabStop = false;
            // 
            // bttnAddFurtherWhere
            // 
            this.bttnAddFurtherWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnAddFurtherWhere.Location = new System.Drawing.Point(12, 172);
            this.bttnAddFurtherWhere.Name = "bttnAddFurtherWhere";
            this.bttnAddFurtherWhere.Size = new System.Drawing.Size(158, 56);
            this.bttnAddFurtherWhere.TabIndex = 10;
            this.bttnAddFurtherWhere.Text = "Add further condition";
            this.bttnAddFurtherWhere.UseVisualStyleBackColor = true;
            this.bttnAddFurtherWhere.Click += new System.EventHandler(this.bttnAddFurtherWhere_Click);
            // 
            // tbFurtherValue
            // 
            this.tbFurtherValue.Location = new System.Drawing.Point(90, 125);
            this.tbFurtherValue.Name = "tbFurtherValue";
            this.tbFurtherValue.Size = new System.Drawing.Size(100, 20);
            this.tbFurtherValue.TabIndex = 11;
            // 
            // cmbAndOr
            // 
            this.cmbAndOr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAndOr.FormattingEnabled = true;
            this.cmbAndOr.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cmbAndOr.Location = new System.Drawing.Point(6, 10);
            this.cmbAndOr.Name = "cmbAndOr";
            this.cmbAndOr.Size = new System.Drawing.Size(104, 21);
            this.cmbAndOr.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Operator:";
            // 
            // cmbFurtherOperator
            // 
            this.cmbFurtherOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFurtherOperator.FormattingEnabled = true;
            this.cmbFurtherOperator.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">=",
            "!=",
            "like"});
            this.cmbFurtherOperator.Location = new System.Drawing.Point(90, 83);
            this.cmbFurtherOperator.Name = "cmbFurtherOperator";
            this.cmbFurtherOperator.Size = new System.Drawing.Size(47, 21);
            this.cmbFurtherOperator.TabIndex = 8;
            // 
            // cmbFurtherFields
            // 
            this.cmbFurtherFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFurtherFields.FormattingEnabled = true;
            this.cmbFurtherFields.Location = new System.Drawing.Point(90, 47);
            this.cmbFurtherFields.Name = "cmbFurtherFields";
            this.cmbFurtherFields.Size = new System.Drawing.Size(121, 21);
            this.cmbFurtherFields.Sorted = true;
            this.cmbFurtherFields.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Select field:";
            // 
            // chbAddFurtherWhere
            // 
            this.chbAddFurtherWhere.AutoSize = true;
            this.chbAddFurtherWhere.Location = new System.Drawing.Point(9, 163);
            this.chbAddFurtherWhere.Name = "chbAddFurtherWhere";
            this.chbAddFurtherWhere.Size = new System.Drawing.Size(124, 17);
            this.chbAddFurtherWhere.TabIndex = 8;
            this.chbAddFurtherWhere.Text = "Add further condition";
            this.chbAddFurtherWhere.UseVisualStyleBackColor = true;
            this.chbAddFurtherWhere.CheckedChanged += new System.EventHandler(this.chbAddFurtherWhere_CheckedChanged);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(90, 106);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(100, 20);
            this.tbValue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operator:";
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">=",
            "!=",
            "like"});
            this.cmbOperator.Location = new System.Drawing.Point(90, 64);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(47, 21);
            this.cmbOperator.TabIndex = 2;
            // 
            // cmbFields
            // 
            this.cmbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.Location = new System.Drawing.Point(90, 28);
            this.cmbFields.Name = "cmbFields";
            this.cmbFields.Size = new System.Drawing.Size(121, 21);
            this.cmbFields.Sorted = true;
            this.cmbFields.TabIndex = 1;
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(9, 31);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(62, 13);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "Select field:";
            // 
            // bttnClearWhere
            // 
            this.bttnClearWhere.Location = new System.Drawing.Point(308, 546);
            this.bttnClearWhere.Name = "bttnClearWhere";
            this.bttnClearWhere.Size = new System.Drawing.Size(95, 55);
            this.bttnClearWhere.TabIndex = 7;
            this.bttnClearWhere.Text = "Clear WHERE or new command";
            this.bttnClearWhere.UseVisualStyleBackColor = true;
            this.bttnClearWhere.Click += new System.EventHandler(this.bttnClearWhere_Click);
            // 
            // bttnGenerateWhere
            // 
            this.bttnGenerateWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnGenerateWhere.Location = new System.Drawing.Point(12, 468);
            this.bttnGenerateWhere.Name = "bttnGenerateWhere";
            this.bttnGenerateWhere.Size = new System.Drawing.Size(217, 59);
            this.bttnGenerateWhere.TabIndex = 6;
            this.bttnGenerateWhere.Text = "Generate WHERE condition and SQL command";
            this.bttnGenerateWhere.UseVisualStyleBackColor = true;
            this.bttnGenerateWhere.Click += new System.EventHandler(this.bttnGenerateWhere_Click);
            // 
            // bttnCloseReturn
            // 
            this.bttnCloseReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnCloseReturn.Enabled = false;
            this.bttnCloseReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnCloseReturn.Location = new System.Drawing.Point(657, 546);
            this.bttnCloseReturn.Name = "bttnCloseReturn";
            this.bttnCloseReturn.Size = new System.Drawing.Size(170, 55);
            this.bttnCloseReturn.TabIndex = 5;
            this.bttnCloseReturn.Text = "Close and return to main window";
            this.bttnCloseReturn.UseVisualStyleBackColor = true;
            this.bttnCloseReturn.Click += new System.EventHandler(this.bttnCloseReturn_Click);
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.AutoSize = true;
            this.lblRowsCount.Location = new System.Drawing.Point(540, 9);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(63, 13);
            this.lblRowsCount.TabIndex = 6;
            this.lblRowsCount.Text = "Query result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(249, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(240, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(240, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(261, 492);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(261, 565);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "5";
            // 
            // frmQueryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 617);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblRowsCount);
            this.Controls.Add(this.bttnCloseReturn);
            this.Controls.Add(this.bttnClearWhere);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttnGenerateWhere);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblSql);
            this.Controls.Add(this.bttnExecuteQuery);
            this.Controls.Add(this.bttnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQueryEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query editor";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAddWhere.ResumeLayout(false);
            this.grpAddWhere.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Button bttnExecuteQuery;
        private System.Windows.Forms.Label lblSql;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFields;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Button bttnCloseReturn;
        private System.Windows.Forms.Label lblRowsCount;
        private System.Windows.Forms.Button bttnClearWhere;
        private System.Windows.Forms.Button bttnGenerateWhere;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.CheckBox chbAddFurtherWhere;
        private System.Windows.Forms.GroupBox grpAddWhere;
        private System.Windows.Forms.ComboBox cmbAndOr;
        private System.Windows.Forms.Button bttnAddFurtherWhere;
        private System.Windows.Forms.TextBox tbFurtherValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFurtherOperator;
        private System.Windows.Forms.ComboBox cmbFurtherFields;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}