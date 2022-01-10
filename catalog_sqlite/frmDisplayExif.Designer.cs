namespace catalog
{
    partial class frmDisplayExif
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplayExif));
            this.lstExif = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstExif
            // 
            this.lstExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstExif.FormattingEnabled = true;
            this.lstExif.Location = new System.Drawing.Point(0, 0);
            this.lstExif.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstExif.Name = "lstExif";
            this.lstExif.Size = new System.Drawing.Size(383, 640);
            this.lstExif.TabIndex = 2;
            // 
            // frmDisplayExif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 640);
            this.Controls.Add(this.lstExif);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDisplayExif";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmDisplayExif";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstExif;
    }
}