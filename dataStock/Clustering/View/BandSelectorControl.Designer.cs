
namespace Giwer.dataStock.Clustering.View
{
    partial class BandSelectorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkListBands = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAllBands = new System.Windows.Forms.Button();
            this.btnDeselectAllBands = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkListBands
            // 
            this.chkListBands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListBands.CheckOnClick = true;
            this.chkListBands.FormattingEnabled = true;
            this.chkListBands.IntegralHeight = false;
            this.chkListBands.Location = new System.Drawing.Point(3, 61);
            this.chkListBands.Name = "chkListBands";
            this.chkListBands.Size = new System.Drawing.Size(92, 349);
            this.chkListBands.TabIndex = 4;
            this.chkListBands.SelectedIndexChanged += new System.EventHandler(this.chkListBands_SelectedIndexChanged);
            // 
            // btnSelectAllBands
            // 
            this.btnSelectAllBands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAllBands.Location = new System.Drawing.Point(3, 3);
            this.btnSelectAllBands.Name = "btnSelectAllBands";
            this.btnSelectAllBands.Size = new System.Drawing.Size(92, 23);
            this.btnSelectAllBands.TabIndex = 17;
            this.btnSelectAllBands.Text = "Select All";
            this.btnSelectAllBands.UseVisualStyleBackColor = true;
            this.btnSelectAllBands.Click += new System.EventHandler(this.btnSelectAllBands_Click);
            // 
            // btnDeselectAllBands
            // 
            this.btnDeselectAllBands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselectAllBands.Location = new System.Drawing.Point(3, 32);
            this.btnDeselectAllBands.Name = "btnDeselectAllBands";
            this.btnDeselectAllBands.Size = new System.Drawing.Size(92, 23);
            this.btnDeselectAllBands.TabIndex = 18;
            this.btnDeselectAllBands.Text = "Deselect All";
            this.btnDeselectAllBands.UseVisualStyleBackColor = true;
            this.btnDeselectAllBands.Click += new System.EventHandler(this.btnDeselectAllBands_Click);
            // 
            // BandSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectAllBands);
            this.Controls.Add(this.btnDeselectAllBands);
            this.Controls.Add(this.chkListBands);
            this.Name = "BandSelectorControl";
            this.Size = new System.Drawing.Size(98, 420);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkListBands;
        private System.Windows.Forms.Button btnSelectAllBands;
        private System.Windows.Forms.Button btnDeselectAllBands;
    }
}
