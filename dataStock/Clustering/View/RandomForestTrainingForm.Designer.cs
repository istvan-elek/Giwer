namespace Giwer.dataStock.Clustering.View
{
    partial class RandomForestTrainingForm
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
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.btnSelectClustering = new System.Windows.Forms.Button();
            this.comboBoxClusteringBand = new System.Windows.Forms.ComboBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.labelSelectedImage = new System.Windows.Forms.Label();
            this.groupBoxIncludedBands = new System.Windows.Forms.GroupBox();
            this.bandSelectorControl = new Giwer.dataStock.Clustering.View.BandSelectorControl();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.labelClusteringBand = new System.Windows.Forms.Label();
            this.groupBoxTrainingParameters = new System.Windows.Forms.GroupBox();
            this.chkBoxIsParallel = new System.Windows.Forms.CheckBox();
            this.labelBootstrappingRatio = new System.Windows.Forms.Label();
            this.labelBandNum = new System.Windows.Forms.Label();
            this.labelMaxTreeHeight = new System.Windows.Forms.Label();
            this.labelMinNodeSize = new System.Windows.Forms.Label();
            this.numBootstrappingRatio = new System.Windows.Forms.NumericUpDown();
            this.numBandCountPerSplit = new Giwer.dataStock.Clustering.View.RandomForestTrainingForm.BandCountNumericUpDown();
            this.numMaxTreeHeight = new System.Windows.Forms.NumericUpDown();
            this.numMinNodeSize = new System.Windows.Forms.NumericUpDown();
            this.numTreeCount = new System.Windows.Forms.NumericUpDown();
            this.labelTreeNum = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.labelSelectedClustering = new System.Windows.Forms.Label();
            this.groupBoxClustering = new System.Windows.Forms.GroupBox();
            this.groupBoxIncludedBands.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            this.groupBoxTrainingParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBootstrappingRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBandCountPerSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTreeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinNodeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTreeCount)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.groupBoxClustering.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectImage.Location = new System.Drawing.Point(6, 46);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(189, 23);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Text = "Select Image...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // btnSelectClustering
            // 
            this.btnSelectClustering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectClustering.Location = new System.Drawing.Point(6, 45);
            this.btnSelectClustering.Name = "btnSelectClustering";
            this.btnSelectClustering.Size = new System.Drawing.Size(189, 23);
            this.btnSelectClustering.TabIndex = 1;
            this.btnSelectClustering.Text = "Select Image...";
            this.btnSelectClustering.UseVisualStyleBackColor = true;
            this.btnSelectClustering.Click += new System.EventHandler(this.btnSelectClustering_Click);
            // 
            // comboBoxClusteringBand
            // 
            this.comboBoxClusteringBand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClusteringBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClusteringBand.FormattingEnabled = true;
            this.comboBoxClusteringBand.Location = new System.Drawing.Point(120, 74);
            this.comboBoxClusteringBand.Name = "comboBoxClusteringBand";
            this.comboBoxClusteringBand.Size = new System.Drawing.Size(75, 21);
            this.comboBoxClusteringBand.TabIndex = 3;
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrain.Location = new System.Drawing.Point(335, 396);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(132, 23);
            this.btnTrain.TabIndex = 4;
            this.btnTrain.Text = "Train Model and Apply";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // labelSelectedImage
            // 
            this.labelSelectedImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedImage.AutoEllipsis = true;
            this.labelSelectedImage.Location = new System.Drawing.Point(6, 23);
            this.labelSelectedImage.Name = "labelSelectedImage";
            this.labelSelectedImage.Size = new System.Drawing.Size(189, 13);
            this.labelSelectedImage.TabIndex = 5;
            this.labelSelectedImage.Text = "Selected: None";
            this.labelSelectedImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxIncludedBands
            // 
            this.groupBoxIncludedBands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxIncludedBands.Controls.Add(this.bandSelectorControl);
            this.groupBoxIncludedBands.Location = new System.Drawing.Point(6, 75);
            this.groupBoxIncludedBands.Name = "groupBoxIncludedBands";
            this.groupBoxIncludedBands.Size = new System.Drawing.Size(189, 218);
            this.groupBoxIncludedBands.TabIndex = 6;
            this.groupBoxIncludedBands.TabStop = false;
            this.groupBoxIncludedBands.Text = "Included Bands";
            // 
            // bandSelectorControl
            // 
            this.bandSelectorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandSelectorControl.Location = new System.Drawing.Point(6, 19);
            this.bandSelectorControl.Name = "bandSelectorControl";
            this.bandSelectorControl.RequiredSelectionCount = 0;
            this.bandSelectorControl.Size = new System.Drawing.Size(174, 193);
            this.bandSelectorControl.TabIndex = 2;
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImage.Controls.Add(this.labelSelectedImage);
            this.groupBoxImage.Controls.Add(this.groupBoxIncludedBands);
            this.groupBoxImage.Controls.Add(this.btnSelectImage);
            this.groupBoxImage.Location = new System.Drawing.Point(12, 12);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(204, 299);
            this.groupBoxImage.TabIndex = 7;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Training Image";
            // 
            // labelClusteringBand
            // 
            this.labelClusteringBand.AutoSize = true;
            this.labelClusteringBand.Location = new System.Drawing.Point(6, 77);
            this.labelClusteringBand.Name = "labelClusteringBand";
            this.labelClusteringBand.Size = new System.Drawing.Size(114, 13);
            this.labelClusteringBand.TabIndex = 9;
            this.labelClusteringBand.Text = "Band of the Clustering:";
            // 
            // groupBoxTrainingParameters
            // 
            this.groupBoxTrainingParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTrainingParameters.Controls.Add(this.chkBoxIsParallel);
            this.groupBoxTrainingParameters.Controls.Add(this.labelBootstrappingRatio);
            this.groupBoxTrainingParameters.Controls.Add(this.labelBandNum);
            this.groupBoxTrainingParameters.Controls.Add(this.labelMaxTreeHeight);
            this.groupBoxTrainingParameters.Controls.Add(this.labelMinNodeSize);
            this.groupBoxTrainingParameters.Controls.Add(this.numBootstrappingRatio);
            this.groupBoxTrainingParameters.Controls.Add(this.numBandCountPerSplit);
            this.groupBoxTrainingParameters.Controls.Add(this.numMaxTreeHeight);
            this.groupBoxTrainingParameters.Controls.Add(this.numMinNodeSize);
            this.groupBoxTrainingParameters.Controls.Add(this.numTreeCount);
            this.groupBoxTrainingParameters.Controls.Add(this.labelTreeNum);
            this.groupBoxTrainingParameters.Location = new System.Drawing.Point(227, 12);
            this.groupBoxTrainingParameters.Name = "groupBoxTrainingParameters";
            this.groupBoxTrainingParameters.Size = new System.Drawing.Size(240, 178);
            this.groupBoxTrainingParameters.TabIndex = 8;
            this.groupBoxTrainingParameters.TabStop = false;
            this.groupBoxTrainingParameters.Text = "Training Parameters";
            // 
            // chkBoxIsParallel
            // 
            this.chkBoxIsParallel.AutoSize = true;
            this.chkBoxIsParallel.Location = new System.Drawing.Point(9, 151);
            this.chkBoxIsParallel.Name = "chkBoxIsParallel";
            this.chkBoxIsParallel.Size = new System.Drawing.Size(165, 17);
            this.chkBoxIsParallel.TabIndex = 14;
            this.chkBoxIsParallel.Text = "Run Training in Parallel Mode";
            this.chkBoxIsParallel.UseVisualStyleBackColor = true;
            // 
            // labelBootstrappingRatio
            // 
            this.labelBootstrappingRatio.AutoSize = true;
            this.labelBootstrappingRatio.Location = new System.Drawing.Point(6, 127);
            this.labelBootstrappingRatio.Name = "labelBootstrappingRatio";
            this.labelBootstrappingRatio.Size = new System.Drawing.Size(103, 13);
            this.labelBootstrappingRatio.TabIndex = 11;
            this.labelBootstrappingRatio.Text = "Bootstrapping Ratio:";
            // 
            // labelBandNum
            // 
            this.labelBandNum.AutoSize = true;
            this.labelBandNum.Location = new System.Drawing.Point(6, 49);
            this.labelBandNum.Name = "labelBandNum";
            this.labelBandNum.Size = new System.Drawing.Size(154, 13);
            this.labelBandNum.TabIndex = 9;
            this.labelBandNum.Text = "Number of Bands in Each Split:";
            // 
            // labelMaxTreeHeight
            // 
            this.labelMaxTreeHeight.AutoSize = true;
            this.labelMaxTreeHeight.Location = new System.Drawing.Point(6, 75);
            this.labelMaxTreeHeight.Name = "labelMaxTreeHeight";
            this.labelMaxTreeHeight.Size = new System.Drawing.Size(113, 13);
            this.labelMaxTreeHeight.TabIndex = 8;
            this.labelMaxTreeHeight.Text = "Maximum Tree Height:";
            // 
            // labelMinNodeSize
            // 
            this.labelMinNodeSize.AutoSize = true;
            this.labelMinNodeSize.Location = new System.Drawing.Point(6, 101);
            this.labelMinNodeSize.Name = "labelMinNodeSize";
            this.labelMinNodeSize.Size = new System.Drawing.Size(103, 13);
            this.labelMinNodeSize.TabIndex = 7;
            this.labelMinNodeSize.Text = "Minimum Node Size:";
            // 
            // numBootstrappingRatio
            // 
            this.numBootstrappingRatio.DecimalPlaces = 2;
            this.numBootstrappingRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numBootstrappingRatio.Location = new System.Drawing.Point(166, 125);
            this.numBootstrappingRatio.Name = "numBootstrappingRatio";
            this.numBootstrappingRatio.Size = new System.Drawing.Size(68, 20);
            this.numBootstrappingRatio.TabIndex = 6;
            // 
            // numBandCountPerSplit
            // 
            this.numBandCountPerSplit.Location = new System.Drawing.Point(166, 47);
            this.numBandCountPerSplit.Name = "numBandCountPerSplit";
            this.numBandCountPerSplit.Size = new System.Drawing.Size(68, 20);
            this.numBandCountPerSplit.TabIndex = 4;
            // 
            // numMaxTreeHeight
            // 
            this.numMaxTreeHeight.Location = new System.Drawing.Point(166, 73);
            this.numMaxTreeHeight.Name = "numMaxTreeHeight";
            this.numMaxTreeHeight.Size = new System.Drawing.Size(68, 20);
            this.numMaxTreeHeight.TabIndex = 3;
            // 
            // numMinNodeSize
            // 
            this.numMinNodeSize.Location = new System.Drawing.Point(166, 99);
            this.numMinNodeSize.Name = "numMinNodeSize";
            this.numMinNodeSize.Size = new System.Drawing.Size(68, 20);
            this.numMinNodeSize.TabIndex = 2;
            // 
            // numTreeCount
            // 
            this.numTreeCount.Location = new System.Drawing.Point(166, 21);
            this.numTreeCount.Name = "numTreeCount";
            this.numTreeCount.Size = new System.Drawing.Size(68, 20);
            this.numTreeCount.TabIndex = 1;
            // 
            // labelTreeNum
            // 
            this.labelTreeNum.AutoSize = true;
            this.labelTreeNum.Location = new System.Drawing.Point(6, 23);
            this.labelTreeNum.Name = "labelTreeNum";
            this.labelTreeNum.Size = new System.Drawing.Size(89, 13);
            this.labelTreeNum.TabIndex = 0;
            this.labelTreeNum.Text = "Number of Trees:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 429);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip.Size = new System.Drawing.Size(479, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(362, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // labelSelectedClustering
            // 
            this.labelSelectedClustering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedClustering.AutoEllipsis = true;
            this.labelSelectedClustering.Location = new System.Drawing.Point(6, 23);
            this.labelSelectedClustering.Name = "labelSelectedClustering";
            this.labelSelectedClustering.Size = new System.Drawing.Size(189, 13);
            this.labelSelectedClustering.TabIndex = 12;
            this.labelSelectedClustering.Text = "Selected: None";
            this.labelSelectedClustering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxClustering
            // 
            this.groupBoxClustering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxClustering.Controls.Add(this.labelClusteringBand);
            this.groupBoxClustering.Controls.Add(this.labelSelectedClustering);
            this.groupBoxClustering.Controls.Add(this.comboBoxClusteringBand);
            this.groupBoxClustering.Controls.Add(this.btnSelectClustering);
            this.groupBoxClustering.Location = new System.Drawing.Point(12, 317);
            this.groupBoxClustering.Name = "groupBoxClustering";
            this.groupBoxClustering.Size = new System.Drawing.Size(204, 102);
            this.groupBoxClustering.TabIndex = 12;
            this.groupBoxClustering.TabStop = false;
            this.groupBoxClustering.Text = "Clustering Image";
            // 
            // RandomForestTrainingForm
            // 
            this.AcceptButton = this.btnTrain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 451);
            this.Controls.Add(this.groupBoxClustering);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxTrainingParameters);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.btnTrain);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(491, 484);
            this.Name = "RandomForestTrainingForm";
            this.Text = "Train New Random Forest Model";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RandomForestTrainingForm_FormClosing);
            this.groupBoxIncludedBands.ResumeLayout(false);
            this.groupBoxImage.ResumeLayout(false);
            this.groupBoxTrainingParameters.ResumeLayout(false);
            this.groupBoxTrainingParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBootstrappingRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBandCountPerSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTreeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinNodeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTreeCount)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxClustering.ResumeLayout(false);
            this.groupBoxClustering.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnSelectClustering;
        private BandSelectorControl bandSelectorControl;
        private System.Windows.Forms.ComboBox comboBoxClusteringBand;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Label labelSelectedImage;
        private System.Windows.Forms.GroupBox groupBoxIncludedBands;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.GroupBox groupBoxTrainingParameters;
        private System.Windows.Forms.NumericUpDown numTreeCount;
        private System.Windows.Forms.Label labelTreeNum;
        private System.Windows.Forms.Label labelBootstrappingRatio;
        private System.Windows.Forms.Label labelBandNum;
        private System.Windows.Forms.Label labelMaxTreeHeight;
        private System.Windows.Forms.Label labelMinNodeSize;
        private System.Windows.Forms.NumericUpDown numBootstrappingRatio;
        private RandomForestTrainingForm.BandCountNumericUpDown numBandCountPerSplit;
        private System.Windows.Forms.NumericUpDown numMaxTreeHeight;
        private System.Windows.Forms.NumericUpDown numMinNodeSize;
        private System.Windows.Forms.Label labelClusteringBand;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label labelSelectedClustering;
        private System.Windows.Forms.GroupBox groupBoxClustering;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.CheckBox chkBoxIsParallel;
    }
}