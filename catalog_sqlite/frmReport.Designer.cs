namespace catalog
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.tbReport = new System.Windows.Forms.TextBox();
            this.bttnSave = new System.Windows.Forms.Button();
            this.bttnClose = new System.Windows.Forms.Button();
            this.bttnCreateEmptyReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbReport
            // 
            this.tbReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReport.Location = new System.Drawing.Point(0, 0);
            this.tbReport.Multiline = true;
            this.tbReport.Name = "tbReport";
            this.tbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReport.Size = new System.Drawing.Size(510, 404);
            this.tbReport.TabIndex = 0;
            // 
            // bttnSave
            // 
            this.bttnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnSave.Location = new System.Drawing.Point(400, 410);
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(102, 33);
            this.bttnSave.TabIndex = 1;
            this.bttnSave.Text = "Save and close";
            this.bttnSave.UseVisualStyleBackColor = true;
            this.bttnSave.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // bttnClose
            // 
            this.bttnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnClose.Location = new System.Drawing.Point(12, 410);
            this.bttnClose.Name = "bttnClose";
            this.bttnClose.Size = new System.Drawing.Size(75, 33);
            this.bttnClose.TabIndex = 2;
            this.bttnClose.Text = "Close";
            this.bttnClose.UseVisualStyleBackColor = true;
            this.bttnClose.Click += new System.EventHandler(this.bttnClose_Click);
            // 
            // bttnCreateEmptyReport
            // 
            this.bttnCreateEmptyReport.Location = new System.Drawing.Point(201, 410);
            this.bttnCreateEmptyReport.Name = "bttnCreateEmptyReport";
            this.bttnCreateEmptyReport.Size = new System.Drawing.Size(108, 33);
            this.bttnCreateEmptyReport.TabIndex = 3;
            this.bttnCreateEmptyReport.Text = "Create report file";
            this.bttnCreateEmptyReport.UseVisualStyleBackColor = true;
            this.bttnCreateEmptyReport.Visible = false;
            this.bttnCreateEmptyReport.Click += new System.EventHandler(this.bttnCreateEmptyReport_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 450);
            this.Controls.Add(this.bttnCreateEmptyReport);
            this.Controls.Add(this.bttnClose);
            this.Controls.Add(this.bttnSave);
            this.Controls.Add(this.tbReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.Button bttnSave;
        private System.Windows.Forms.Button bttnClose;
        private System.Windows.Forms.Button bttnCreateEmptyReport;
    }
}