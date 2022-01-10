namespace Giwer.dataStock.Clustering.View
{
    partial class KmeansParamsControl
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
            this.numChangeThreshold = new System.Windows.Forms.NumericUpDown();
            this.labelChangeThreshold = new System.Windows.Forms.Label();
            this.labelMinClust = new System.Windows.Forms.Label();
            this.numMinClust = new System.Windows.Forms.NumericUpDown();
            this.numChangeElbow = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinClust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeElbow)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMaxClust
            // 
            this.labelMaxClust.Location = new System.Drawing.Point(3, 83);
            // 
            // numMaxClust
            // 
            this.numMaxClust.Location = new System.Drawing.Point(161, 81);
            this.numMaxClust.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numChangeThreshold
            // 
            this.numChangeThreshold.DecimalPlaces = 3;
            this.numChangeThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numChangeThreshold.Location = new System.Drawing.Point(161, 29);
            this.numChangeThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeThreshold.Name = "numChangeThreshold";
            this.numChangeThreshold.Size = new System.Drawing.Size(63, 20);
            this.numChangeThreshold.TabIndex = 2;
            this.numChangeThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // labelChangeThreshold
            // 
            this.labelChangeThreshold.AutoSize = true;
            this.labelChangeThreshold.Location = new System.Drawing.Point(3, 31);
            this.labelChangeThreshold.Name = "labelChangeThreshold";
            this.labelChangeThreshold.Size = new System.Drawing.Size(146, 13);
            this.labelChangeThreshold.TabIndex = 3;
            this.labelChangeThreshold.Text = "Relative Distortion Threshold:";
            // 
            // labelMinClust
            // 
            this.labelMinClust.AutoSize = true;
            this.labelMinClust.Location = new System.Drawing.Point(3, 57);
            this.labelMinClust.Name = "labelMinClust";
            this.labelMinClust.Size = new System.Drawing.Size(91, 13);
            this.labelMinClust.TabIndex = 2;
            this.labelMinClust.Text = "Minimum Clusters:";
            // 
            // numMinClust
            // 
            this.numMinClust.Location = new System.Drawing.Point(161, 55);
            this.numMinClust.Name = "numMinClust";
            this.numMinClust.Size = new System.Drawing.Size(63, 20);
            this.numMinClust.TabIndex = 6;
            // 
            // numChangeElbow
            // 
            this.numChangeElbow.DecimalPlaces = 3;
            this.numChangeElbow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numChangeElbow.Location = new System.Drawing.Point(161, 107);
            this.numChangeElbow.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeElbow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numChangeElbow.Name = "numChangeElbow";
            this.numChangeElbow.Size = new System.Drawing.Size(63, 20);
            this.numChangeElbow.TabIndex = 7;
            this.numChangeElbow.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Relative Elbow Threshold:";
            // 
            // KmeansParamsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numChangeElbow);
            this.Controls.Add(this.numMinClust);
            this.Controls.Add(this.labelMinClust);
            this.Controls.Add(this.labelChangeThreshold);
            this.Controls.Add(this.numChangeThreshold);
            this.Name = "KmeansParamsControl";
            this.Controls.SetChildIndex(this.labelMaxClust, 0);
            this.Controls.SetChildIndex(this.numMaxClust, 0);
            this.Controls.SetChildIndex(this.numChangeThreshold, 0);
            this.Controls.SetChildIndex(this.labelChangeThreshold, 0);
            this.Controls.SetChildIndex(this.labelMinClust, 0);
            this.Controls.SetChildIndex(this.numMinClust, 0);
            this.Controls.SetChildIndex(this.numChangeElbow, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinClust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeElbow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numChangeThreshold;
        private System.Windows.Forms.Label labelChangeThreshold;
        private System.Windows.Forms.Label labelMinClust;
        private System.Windows.Forms.NumericUpDown numMinClust;
        private System.Windows.Forms.NumericUpDown numChangeElbow;
        private System.Windows.Forms.Label label1;
    }
}
