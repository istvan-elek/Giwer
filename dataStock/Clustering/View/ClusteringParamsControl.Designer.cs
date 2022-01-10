namespace Giwer.dataStock.Clustering.View
{
    partial class ClusteringParamsControl
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
            this.labelMaxIter = new System.Windows.Forms.Label();
            this.numMaxIter = new System.Windows.Forms.NumericUpDown();
            this.labelMaxClust = new System.Windows.Forms.Label();
            this.numMaxClust = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMaxIter
            // 
            this.labelMaxIter.AutoSize = true;
            this.labelMaxIter.Location = new System.Drawing.Point(3, 5);
            this.labelMaxIter.Name = "labelMaxIter";
            this.labelMaxIter.Size = new System.Drawing.Size(100, 13);
            this.labelMaxIter.TabIndex = 0;
            this.labelMaxIter.Text = "Maximum Iterations:";
            // 
            // numMaxIter
            // 
            this.numMaxIter.Location = new System.Drawing.Point(161, 3);
            this.numMaxIter.Name = "numMaxIter";
            this.numMaxIter.Size = new System.Drawing.Size(63, 20);
            this.numMaxIter.TabIndex = 1;
            // 
            // labelMaxClust
            // 
            this.labelMaxClust.AutoSize = true;
            this.labelMaxClust.Name = "labelMaxClust";
            this.labelMaxClust.Size = new System.Drawing.Size(94, 13);
            this.labelMaxClust.TabIndex = 0;
            this.labelMaxClust.Text = "Maximum Clusters:";
            // 
            // numMaxClust
            // 
            this.numMaxClust.Name = "numMaxClust";
            this.numMaxClust.Size = new System.Drawing.Size(63, 20);
            this.numMaxClust.TabIndex = 1;
            // 
            // UserControlClusteringParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numMaxIter);
            this.Controls.Add(this.labelMaxIter);
            this.Controls.Add(this.numMaxClust);
            this.Controls.Add(this.labelMaxClust);
            this.Name = "UserControlClusteringParams";
            this.Size = new System.Drawing.Size(227, 590);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMaxIter;
        private System.Windows.Forms.NumericUpDown numMaxIter;
        protected System.Windows.Forms.Label labelMaxClust;
        protected System.Windows.Forms.NumericUpDown numMaxClust;
    }
}
