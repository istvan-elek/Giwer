namespace Giwer.dataStock.Clustering.View
{
    partial class ClusteringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClusteringForm));
            this.labelMethod = new System.Windows.Forms.Label();
            this.btnCompute = new System.Windows.Forms.Button();
            this.groupBoxMethodParams = new System.Windows.Forms.GroupBox();
            this.manualClusterSelectControl1 = new Giwer.dataStock.Clustering.View.ManualClusterSelectControl();
            this.usrCtrlKmeansParams = new Giwer.dataStock.Clustering.View.KmeansParamsControl();
            this.usrCtrlIsodataParams = new Giwer.dataStock.Clustering.View.IsodataParamsControl();
            this.usrCtrlRandomForestParams = new Giwer.dataStock.Clustering.View.RandomForestParamsControl();
            this.panelImg = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imgWindow = new Giwer.dataStock.ImageWindow();
            this.labelColorPalettes = new System.Windows.Forms.Label();
            this.cmbColorPalettes = new System.Windows.Forms.ComboBox();
            this.panelMethod = new System.Windows.Forms.Panel();
            this.clusteringMethodSelector = new Giwer.dataStock.Clustering.View.ClusteringMethodSelectorControl();
            this.btnApplyResult = new System.Windows.Forms.Button();
            this.groupBoxInclBands = new System.Windows.Forms.GroupBox();
            this.groupBoxCurrentGwh = new System.Windows.Forms.GroupBox();
            this.bandSelectorControl = new Giwer.dataStock.Clustering.View.BandSelectorControl();
            this.radioBtnCurrentGwh = new System.Windows.Forms.RadioButton();
            this.radioBtnCurrentBand = new System.Windows.Forms.RadioButton();
            this.groupBoxMethodParams.SuspendLayout();
            this.panelImg.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelMethod.SuspendLayout();
            this.groupBoxInclBands.SuspendLayout();
            this.groupBoxCurrentGwh.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMethod
            // 
            this.labelMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(9, 6);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(95, 13);
            this.labelMethod.TabIndex = 10;
            this.labelMethod.Text = "Clustering Method:";
            // 
            // btnCompute
            // 
            this.btnCompute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompute.Location = new System.Drawing.Point(9, 655);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(242, 23);
            this.btnCompute.TabIndex = 12;
            this.btnCompute.Text = "Compute Clustering";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // groupBoxMethodParams
            // 
            this.groupBoxMethodParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMethodParams.Controls.Add(this.manualClusterSelectControl1);
            this.groupBoxMethodParams.Controls.Add(this.usrCtrlKmeansParams);
            this.groupBoxMethodParams.Controls.Add(this.usrCtrlIsodataParams);
            this.groupBoxMethodParams.Controls.Add(this.usrCtrlRandomForestParams);
            this.groupBoxMethodParams.Location = new System.Drawing.Point(7, 42);
            this.groupBoxMethodParams.Name = "groupBoxMethodParams";
            this.groupBoxMethodParams.Size = new System.Drawing.Size(242, 487);
            this.groupBoxMethodParams.TabIndex = 13;
            this.groupBoxMethodParams.TabStop = false;
            this.groupBoxMethodParams.Text = "Method Parameters";
            // 
            // manualClusterSelectControl1
            // 
            this.manualClusterSelectControl1.Location = new System.Drawing.Point(6, 19);
            this.manualClusterSelectControl1.Name = "manualClusterSelectControl1";
            this.manualClusterSelectControl1.SampleAreasIndexes = ((System.Collections.Generic.List<System.Collections.Generic.List<int>>)(resources.GetObject("manualClusterSelectControl1.SampleAreasIndexes")));
            this.manualClusterSelectControl1.SamplePointIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("manualClusterSelectControl1.SamplePointIndexes")));
            this.manualClusterSelectControl1.Size = new System.Drawing.Size(227, 462);
            this.manualClusterSelectControl1.TabIndex = 22;
            // 
            // usrCtrlKmeansParams
            // 
            this.usrCtrlKmeansParams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usrCtrlKmeansParams.Location = new System.Drawing.Point(6, 75);
            this.usrCtrlKmeansParams.Name = "usrCtrlKmeansParams";
            this.usrCtrlKmeansParams.Size = new System.Drawing.Size(230, 134);
            this.usrCtrlKmeansParams.TabIndex = 0;
            // 
            // usrCtrlIsodataParams
            // 
            this.usrCtrlIsodataParams.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usrCtrlIsodataParams.Location = new System.Drawing.Point(6, 19);
            this.usrCtrlIsodataParams.Name = "usrCtrlIsodataParams";
            this.usrCtrlIsodataParams.Size = new System.Drawing.Size(230, 181);
            this.usrCtrlIsodataParams.TabIndex = 1;
            // 
            // usrCtrlRandomForestParams
            // 
            this.usrCtrlRandomForestParams.Location = new System.Drawing.Point(6, 19);
            this.usrCtrlRandomForestParams.Name = "usrCtrlRandomForestParams";
            this.usrCtrlRandomForestParams.Size = new System.Drawing.Size(227, 191);
            this.usrCtrlRandomForestParams.TabIndex = 21;
            // 
            // panelImg
            // 
            this.panelImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImg.AutoScroll = true;
            this.panelImg.Controls.Add(this.statusStrip);
            this.panelImg.Controls.Add(this.imgWindow);
            this.panelImg.Location = new System.Drawing.Point(126, 3);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(565, 711);
            this.panelImg.TabIndex = 14;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelResult,
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 689);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip.Size = new System.Drawing.Size(565, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabelResult
            // 
            this.toolStripStatusLabelResult.Name = "toolStripStatusLabelResult";
            this.toolStripStatusLabelResult.Size = new System.Drawing.Size(448, 17);
            this.toolStripStatusLabelResult.Spring = true;
            this.toolStripStatusLabelResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.MarqueeAnimationSpeed = 20;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // imgWindow
            // 
            this.imgWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgWindow.Location = new System.Drawing.Point(0, 0);
            this.imgWindow.Name = "imgWindow";
            this.imgWindow.Size = new System.Drawing.Size(565, 711);
            this.imgWindow.TabIndex = 0;
            // 
            // labelColorPalettes
            // 
            this.labelColorPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelColorPalettes.AutoSize = true;
            this.labelColorPalettes.Location = new System.Drawing.Point(9, 631);
            this.labelColorPalettes.Name = "labelColorPalettes";
            this.labelColorPalettes.Size = new System.Drawing.Size(74, 13);
            this.labelColorPalettes.TabIndex = 18;
            this.labelColorPalettes.Text = "Color palettes:";
            // 
            // cmbColorPalettes
            // 
            this.cmbColorPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbColorPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorPalettes.FormattingEnabled = true;
            this.cmbColorPalettes.Location = new System.Drawing.Point(113, 628);
            this.cmbColorPalettes.Name = "cmbColorPalettes";
            this.cmbColorPalettes.Size = new System.Drawing.Size(136, 21);
            this.cmbColorPalettes.TabIndex = 17;
            this.cmbColorPalettes.SelectedIndexChanged += new System.EventHandler(this.cmbColorPalettes_SelectedIndexChanged);
            // 
            // panelMethod
            // 
            this.panelMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMethod.Controls.Add(this.clusteringMethodSelector);
            this.panelMethod.Controls.Add(this.btnApplyResult);
            this.panelMethod.Controls.Add(this.cmbColorPalettes);
            this.panelMethod.Controls.Add(this.labelColorPalettes);
            this.panelMethod.Controls.Add(this.labelMethod);
            this.panelMethod.Controls.Add(this.groupBoxMethodParams);
            this.panelMethod.Controls.Add(this.btnCompute);
            this.panelMethod.Location = new System.Drawing.Point(697, 3);
            this.panelMethod.Name = "panelMethod";
            this.panelMethod.Size = new System.Drawing.Size(254, 711);
            this.panelMethod.TabIndex = 2;
            // 
            // clusteringMethodSelector
            // 
            this.clusteringMethodSelector.Location = new System.Drawing.Point(106, 3);
            this.clusteringMethodSelector.Name = "clusteringMethodSelector";
            this.clusteringMethodSelector.Size = new System.Drawing.Size(136, 23);
            this.clusteringMethodSelector.TabIndex = 20;
            // 
            // btnApplyResult
            // 
            this.btnApplyResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyResult.Location = new System.Drawing.Point(9, 684);
            this.btnApplyResult.Name = "btnApplyResult";
            this.btnApplyResult.Size = new System.Drawing.Size(242, 23);
            this.btnApplyResult.TabIndex = 19;
            this.btnApplyResult.Text = "Apply Result to Image";
            this.btnApplyResult.UseVisualStyleBackColor = true;
            this.btnApplyResult.Click += new System.EventHandler(this.btnApplyResult_Click);
            // 
            // groupBoxInclBands
            // 
            this.groupBoxInclBands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxInclBands.Controls.Add(this.groupBoxCurrentGwh);
            this.groupBoxInclBands.Controls.Add(this.radioBtnCurrentBand);
            this.groupBoxInclBands.Location = new System.Drawing.Point(3, 3);
            this.groupBoxInclBands.Name = "groupBoxInclBands";
            this.groupBoxInclBands.Size = new System.Drawing.Size(117, 711);
            this.groupBoxInclBands.TabIndex = 2;
            this.groupBoxInclBands.TabStop = false;
            this.groupBoxInclBands.Text = "Included Bands";
            // 
            // groupBoxCurrentGwh
            // 
            this.groupBoxCurrentGwh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxCurrentGwh.Controls.Add(this.bandSelectorControl);
            this.groupBoxCurrentGwh.Controls.Add(this.radioBtnCurrentGwh);
            this.groupBoxCurrentGwh.Location = new System.Drawing.Point(6, 42);
            this.groupBoxCurrentGwh.Name = "groupBoxCurrentGwh";
            this.groupBoxCurrentGwh.Size = new System.Drawing.Size(104, 663);
            this.groupBoxCurrentGwh.TabIndex = 17;
            this.groupBoxCurrentGwh.TabStop = false;
            // 
            // bandSelectorControl
            // 
            this.bandSelectorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bandSelectorControl.Location = new System.Drawing.Point(3, 23);
            this.bandSelectorControl.Name = "bandSelectorControl";
            this.bandSelectorControl.RequiredSelectionCount = 0;
            this.bandSelectorControl.Size = new System.Drawing.Size(97, 634);
            this.bandSelectorControl.TabIndex = 17;
            // 
            // radioBtnCurrentGwh
            // 
            this.radioBtnCurrentGwh.AutoSize = true;
            this.radioBtnCurrentGwh.Location = new System.Drawing.Point(3, 0);
            this.radioBtnCurrentGwh.Name = "radioBtnCurrentGwh";
            this.radioBtnCurrentGwh.Size = new System.Drawing.Size(85, 17);
            this.radioBtnCurrentGwh.TabIndex = 2;
            this.radioBtnCurrentGwh.TabStop = true;
            this.radioBtnCurrentGwh.Text = "Current .gwh";
            this.radioBtnCurrentGwh.UseVisualStyleBackColor = true;
            this.radioBtnCurrentGwh.Click += new System.EventHandler(this.radioBtnCurrentGwh_Click);
            // 
            // radioBtnCurrentBand
            // 
            this.radioBtnCurrentBand.AutoSize = true;
            this.radioBtnCurrentBand.Location = new System.Drawing.Point(9, 19);
            this.radioBtnCurrentBand.Name = "radioBtnCurrentBand";
            this.radioBtnCurrentBand.Size = new System.Drawing.Size(87, 17);
            this.radioBtnCurrentBand.TabIndex = 2;
            this.radioBtnCurrentBand.TabStop = true;
            this.radioBtnCurrentBand.Text = "Current Band";
            this.radioBtnCurrentBand.UseVisualStyleBackColor = true;
            this.radioBtnCurrentBand.Click += new System.EventHandler(this.radioBtnCurrentBand_Click);
            // 
            // ClusteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 722);
            this.Controls.Add(this.panelMethod);
            this.Controls.Add(this.panelImg);
            this.Controls.Add(this.groupBoxInclBands);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "ClusteringForm";
            this.Text = "Clustering";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClusteringForm_FormClosing);
            this.groupBoxMethodParams.ResumeLayout(false);
            this.panelImg.ResumeLayout(false);
            this.panelImg.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelMethod.ResumeLayout(false);
            this.panelMethod.PerformLayout();
            this.groupBoxInclBands.ResumeLayout(false);
            this.groupBoxInclBands.PerformLayout();
            this.groupBoxCurrentGwh.ResumeLayout(false);
            this.groupBoxCurrentGwh.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.GroupBox groupBoxMethodParams;
        private System.Windows.Forms.Panel panelImg;
        private KmeansParamsControl usrCtrlKmeansParams;
        private IsodataParamsControl usrCtrlIsodataParams;
        private System.Windows.Forms.Label labelColorPalettes;
        private System.Windows.Forms.ComboBox cmbColorPalettes;
        private System.Windows.Forms.Panel panelMethod;
        private System.Windows.Forms.GroupBox groupBoxInclBands;
        private Giwer.dataStock.ImageWindow imgWindow;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button btnApplyResult;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelResult;
        private ClusteringMethodSelectorControl clusteringMethodSelector;
        private System.Windows.Forms.RadioButton radioBtnCurrentGwh;
        private System.Windows.Forms.RadioButton radioBtnCurrentBand;
        private System.Windows.Forms.GroupBox groupBoxCurrentGwh;
        private RandomForestParamsControl usrCtrlRandomForestParams;
        private BandSelectorControl bandSelectorControl;
        private ManualClusterSelectControl manualClusterSelectControl1;
    }
}