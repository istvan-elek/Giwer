namespace dataStock
{
    partial class histogram
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnRecalcHisto = new System.Windows.Forms.Button();
            this.lblIntensityMax = new System.Windows.Forms.Label();
            this.lblIntensityMin = new System.Windows.Forms.Label();
            this.bttnRecalcEqualiz = new System.Windows.Forms.Button();
            this.ch1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bttnRecalcHisto);
            this.groupBox1.Controls.Add(this.lblIntensityMax);
            this.groupBox1.Controls.Add(this.lblIntensityMin);
            this.groupBox1.Location = new System.Drawing.Point(439, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(173, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set min/max intensity";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 78);
            this.label2.TabIndex = 4;
            this.label2.Text = "asd";
            // 
            // bttnRecalcHisto
            // 
            this.bttnRecalcHisto.Location = new System.Drawing.Point(39, 192);
            this.bttnRecalcHisto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnRecalcHisto.Name = "bttnRecalcHisto";
            this.bttnRecalcHisto.Size = new System.Drawing.Size(111, 49);
            this.bttnRecalcHisto.TabIndex = 3;
            this.bttnRecalcHisto.Text = "Recalculate histogram";
            this.bttnRecalcHisto.UseVisualStyleBackColor = true;
            this.bttnRecalcHisto.Click += new System.EventHandler(this.bttnRecalcHisto_Click);
            // 
            // lblIntensityMax
            // 
            this.lblIntensityMax.AutoSize = true;
            this.lblIntensityMax.Location = new System.Drawing.Point(8, 54);
            this.lblIntensityMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntensityMax.Name = "lblIntensityMax";
            this.lblIntensityMax.Size = new System.Drawing.Size(87, 17);
            this.lblIntensityMax.TabIndex = 1;
            this.lblIntensityMax.Text = "Max value: 0";
            // 
            // lblIntensityMin
            // 
            this.lblIntensityMin.AutoSize = true;
            this.lblIntensityMin.Location = new System.Drawing.Point(8, 38);
            this.lblIntensityMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntensityMin.Name = "lblIntensityMin";
            this.lblIntensityMin.Size = new System.Drawing.Size(84, 17);
            this.lblIntensityMin.TabIndex = 0;
            this.lblIntensityMin.Text = "Min value: 0";
            // 
            // bttnRecalcEqualiz
            // 
            this.bttnRecalcEqualiz.Location = new System.Drawing.Point(477, 377);
            this.bttnRecalcEqualiz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnRecalcEqualiz.Name = "bttnRecalcEqualiz";
            this.bttnRecalcEqualiz.Size = new System.Drawing.Size(111, 57);
            this.bttnRecalcEqualiz.TabIndex = 2;
            this.bttnRecalcEqualiz.Text = "Recalculate equalization";
            this.bttnRecalcEqualiz.UseVisualStyleBackColor = true;
            this.bttnRecalcEqualiz.Click += new System.EventHandler(this.bttnRecalcEqualize_Click);
            // 
            // ch1
            // 
            chartArea1.Name = "ChartArea2";
            this.ch1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ch1.Legends.Add(legend1);
            this.ch1.Location = new System.Drawing.Point(0, 0);
            this.ch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ch1.Name = "ch1";
            series1.ChartArea = "ChartArea2";
            series1.Legend = "Legend1";
            series1.Name = "Gray";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Cumulative";
            series3.ChartArea = "ChartArea2";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "MinMax";
            this.ch1.Series.Add(series1);
            this.ch1.Series.Add(series2);
            this.ch1.Series.Add(series3);
            this.ch1.Size = new System.Drawing.Size(612, 530);
            this.ch1.TabIndex = 3;
            this.ch1.Text = "chart1";
            this.ch1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ch1_MouseDown);
            // 
            // histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 533);
            this.Controls.Add(this.bttnRecalcEqualiz);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ch1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "histogram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Histogram";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIntensityMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnRecalcHisto;
        private System.Windows.Forms.Label lblIntensityMax;
        private System.Windows.Forms.Button bttnRecalcEqualiz;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch1;
    }
}