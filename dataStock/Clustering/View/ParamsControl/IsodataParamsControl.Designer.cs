namespace Giwer.dataStock.Clustering.View
{
    partial class IsodataParamsControl
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
            this.labelInitClusterNum = new System.Windows.Forms.Label();
            this.numInitClusterNum = new System.Windows.Forms.NumericUpDown();
            this.numMinClusterSize = new System.Windows.Forms.NumericUpDown();
            this.numSDLimit = new System.Windows.Forms.NumericUpDown();
            this.numMaxMergePerIter = new System.Windows.Forms.NumericUpDown();
            this.numMinCentroidDist = new System.Windows.Forms.NumericUpDown();
            this.labelMaxCentroidDist = new System.Windows.Forms.Label();
            this.labelMinCentroidDist = new System.Windows.Forms.Label();
            this.labelSDLimit = new System.Windows.Forms.Label();
            this.labelMinClusterSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitClusterNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinClusterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSDLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMergePerIter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCentroidDist)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMaxClust
            // 
            this.labelMaxClust.Location = new System.Drawing.Point(3, 57);
            // 
            // numMaxClust
            // 
            this.numMaxClust.Location = new System.Drawing.Point(161, 55);
            this.numMaxClust.ValueChanged += new System.EventHandler(this.numMaxClust_ValueChanged);
            // 
            // labelInitClusterNum
            // 
            this.labelInitClusterNum.AutoSize = true;
            this.labelInitClusterNum.Location = new System.Drawing.Point(3, 31);
            this.labelInitClusterNum.Name = "labelInitClusterNum";
            this.labelInitClusterNum.Size = new System.Drawing.Size(126, 13);
            this.labelInitClusterNum.TabIndex = 2;
            this.labelInitClusterNum.Text = "Initial Number of Clusters:";
            // 
            // numInitClusterNum
            // 
            this.numInitClusterNum.Location = new System.Drawing.Point(161, 29);
            this.numInitClusterNum.Name = "numInitClusterNum";
            this.numInitClusterNum.Size = new System.Drawing.Size(63, 20);
            this.numInitClusterNum.TabIndex = 3;
            // 
            // numMinClusterSize
            // 
            this.numMinClusterSize.Location = new System.Drawing.Point(161, 81);
            this.numMinClusterSize.Name = "numMinClusterSize";
            this.numMinClusterSize.Size = new System.Drawing.Size(63, 20);
            this.numMinClusterSize.TabIndex = 7;
            // 
            // numSDLimit
            // 
            this.numSDLimit.DecimalPlaces = 5;
            this.numSDLimit.Location = new System.Drawing.Point(161, 107);
            this.numSDLimit.Name = "numSDLimit";
            this.numSDLimit.Size = new System.Drawing.Size(63, 20);
            this.numSDLimit.TabIndex = 8;
            // 
            // numMaxMergePerIter
            // 
            this.numMaxMergePerIter.Location = new System.Drawing.Point(161, 159);
            this.numMaxMergePerIter.Name = "numMaxMergePerIter";
            this.numMaxMergePerIter.Size = new System.Drawing.Size(63, 20);
            this.numMaxMergePerIter.TabIndex = 9;
            // 
            // numMinCentroidDist
            // 
            this.numMinCentroidDist.DecimalPlaces = 2;
            this.numMinCentroidDist.Location = new System.Drawing.Point(161, 133);
            this.numMinCentroidDist.Name = "numMinCentroidDist";
            this.numMinCentroidDist.Size = new System.Drawing.Size(63, 20);
            this.numMinCentroidDist.TabIndex = 10;
            // 
            // labelMaxCentroidDist
            // 
            this.labelMaxCentroidDist.AutoSize = true;
            this.labelMaxCentroidDist.Location = new System.Drawing.Point(3, 161);
            this.labelMaxCentroidDist.Name = "labelMaxCentroidDist";
            this.labelMaxCentroidDist.Size = new System.Drawing.Size(151, 13);
            this.labelMaxCentroidDist.TabIndex = 11;
            this.labelMaxCentroidDist.Text = "Maximum Merges per Iteration:";
            // 
            // labelMinCentroidDist
            // 
            this.labelMinCentroidDist.AutoSize = true;
            this.labelMinCentroidDist.Location = new System.Drawing.Point(3, 135);
            this.labelMinCentroidDist.Name = "labelMinCentroidDist";
            this.labelMinCentroidDist.Size = new System.Drawing.Size(143, 13);
            this.labelMinCentroidDist.TabIndex = 12;
            this.labelMinCentroidDist.Text = "Minimum Centroid Distances:";
            // 
            // labelSDLimit
            // 
            this.labelSDLimit.AutoSize = true;
            this.labelSDLimit.Location = new System.Drawing.Point(3, 109);
            this.labelSDLimit.Name = "labelSDLimit";
            this.labelSDLimit.Size = new System.Drawing.Size(125, 13);
            this.labelSDLimit.TabIndex = 13;
            this.labelSDLimit.Text = "Standard Deviation Limit:";
            // 
            // labelMinClusterSize
            // 
            this.labelMinClusterSize.AutoSize = true;
            this.labelMinClusterSize.Location = new System.Drawing.Point(3, 83);
            this.labelMinClusterSize.Name = "labelMinClusterSize";
            this.labelMinClusterSize.Size = new System.Drawing.Size(109, 13);
            this.labelMinClusterSize.TabIndex = 14;
            this.labelMinClusterSize.Text = "Minimum Cluster Size:";
            // 
            // UserControlIsodataParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.numMinClusterSize);
            this.Controls.Add(this.labelMinClusterSize);
            this.Controls.Add(this.labelSDLimit);
            this.Controls.Add(this.labelMinCentroidDist);
            this.Controls.Add(this.labelMaxCentroidDist);
            this.Controls.Add(this.numMinCentroidDist);
            this.Controls.Add(this.numMaxMergePerIter);
            this.Controls.Add(this.numSDLimit);
            this.Controls.Add(this.numInitClusterNum);
            this.Controls.Add(this.labelInitClusterNum);
            this.Name = "UserControlIsodataParams";
            this.Controls.SetChildIndex(this.labelMaxClust, 0);
            this.Controls.SetChildIndex(this.numMaxClust, 0);
            this.Controls.SetChildIndex(this.labelInitClusterNum, 0);
            this.Controls.SetChildIndex(this.numInitClusterNum, 0);
            this.Controls.SetChildIndex(this.numSDLimit, 0);
            this.Controls.SetChildIndex(this.numMaxMergePerIter, 0);
            this.Controls.SetChildIndex(this.numMinCentroidDist, 0);
            this.Controls.SetChildIndex(this.labelMaxCentroidDist, 0);
            this.Controls.SetChildIndex(this.labelMinCentroidDist, 0);
            this.Controls.SetChildIndex(this.labelSDLimit, 0);
            this.Controls.SetChildIndex(this.labelMinClusterSize, 0);
            this.Controls.SetChildIndex(this.numMinClusterSize, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitClusterNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinClusterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSDLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMergePerIter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCentroidDist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInitClusterNum;
        private System.Windows.Forms.NumericUpDown numInitClusterNum;
        private System.Windows.Forms.NumericUpDown numMinClusterSize;
        private System.Windows.Forms.NumericUpDown numSDLimit;
        private System.Windows.Forms.NumericUpDown numMaxMergePerIter;
        private System.Windows.Forms.NumericUpDown numMinCentroidDist;
        private System.Windows.Forms.Label labelMaxCentroidDist;
        private System.Windows.Forms.Label labelMinCentroidDist;
        private System.Windows.Forms.Label labelSDLimit;
        private System.Windows.Forms.Label labelMinClusterSize;
    }
}
