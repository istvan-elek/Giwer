namespace Giwer.dataStock
{
    partial class frmSegmenting
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.rbSegByHisto = new System.Windows.Forms.RadioButton();
            this.bttnOk = new System.Windows.Forms.Button();
            this.bttnApply2Image = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbThresh = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbSegByHisto
            // 
            this.rbSegByHisto.AutoSize = true;
            this.rbSegByHisto.Checked = true;
            this.rbSegByHisto.Location = new System.Drawing.Point(15, 12);
            this.rbSegByHisto.Name = "rbSegByHisto";
            this.rbSegByHisto.Size = new System.Drawing.Size(152, 17);
            this.rbSegByHisto.TabIndex = 0;
            this.rbSegByHisto.TabStop = true;
            this.rbSegByHisto.Text = "Segmentation by histogram";
            this.rbSegByHisto.UseVisualStyleBackColor = true;
            this.rbSegByHisto.CheckedChanged += new System.EventHandler(this.rbSegByHisto_CheckedChanged);
            // 
            // bttnOk
            // 
            this.bttnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnOk.Location = new System.Drawing.Point(346, 283);
            this.bttnOk.Name = "bttnOk";
            this.bttnOk.Size = new System.Drawing.Size(72, 30);
            this.bttnOk.TabIndex = 1;
            this.bttnOk.Text = "Compute";
            this.bttnOk.UseVisualStyleBackColor = true;
            this.bttnOk.Click += new System.EventHandler(this.bttnSegmentedComputeHisto_Click);
            // 
            // bttnApply2Image
            // 
            this.bttnApply2Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnApply2Image.Location = new System.Drawing.Point(12, 283);
            this.bttnApply2Image.Name = "bttnApply2Image";
            this.bttnApply2Image.Size = new System.Drawing.Size(91, 30);
            this.bttnApply2Image.TabIndex = 2;
            this.bttnApply2Image.Text = "Apply to image";
            this.bttnApply2Image.UseVisualStyleBackColor = true;
            this.bttnApply2Image.Click += new System.EventHandler(this.bttnDisplayResult_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(196, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 209);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(232, 209);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Threshold:";
            // 
            // tbThresh
            // 
            this.tbThresh.Location = new System.Drawing.Point(75, 40);
            this.tbThresh.Name = "tbThresh";
            this.tbThresh.Size = new System.Drawing.Size(41, 20);
            this.tbThresh.TabIndex = 6;
            this.tbThresh.Text = "15";
            this.tbThresh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbThresh_KeyDown);
            // 
            // frmSegmenting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 322);
            this.Controls.Add(this.tbThresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bttnApply2Image);
            this.Controls.Add(this.bttnOk);
            this.Controls.Add(this.rbSegByHisto);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSegmenting";
            this.Text = "Segmentation";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSegByHisto;
        private System.Windows.Forms.Button bttnOk;
        private System.Windows.Forms.Button bttnApply2Image;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbThresh;
    }
}