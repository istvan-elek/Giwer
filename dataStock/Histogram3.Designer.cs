namespace Giwer.dataStock
{
    partial class Histogram3
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Histogram3));
            this.grpHistoRGB = new System.Windows.Forms.GroupBox();
            this.ch1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblRedMinMax = new System.Windows.Forms.Label();
            this.lblGreenMinMax = new System.Windows.Forms.Label();
            this.lblBlueMinMax = new System.Windows.Forms.Label();
            this.ch3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ch2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bttnRecalcEqualizeRGB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpHistoOneBand = new System.Windows.Forms.GroupBox();
            this.bttnRecalcEqualiz = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblIntensityMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIntensityMin = new System.Windows.Forms.Label();
            this.grpHistoRGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2)).BeginInit();
            this.grpHistoOneBand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpHistoRGB
            // 
            this.grpHistoRGB.Controls.Add(this.ch1);
            this.grpHistoRGB.Controls.Add(this.lblRedMinMax);
            this.grpHistoRGB.Controls.Add(this.lblGreenMinMax);
            this.grpHistoRGB.Controls.Add(this.lblBlueMinMax);
            this.grpHistoRGB.Controls.Add(this.ch3);
            this.grpHistoRGB.Controls.Add(this.ch2);
            this.grpHistoRGB.Controls.Add(this.bttnRecalcEqualizeRGB);
            this.grpHistoRGB.Controls.Add(this.label1);
            this.grpHistoRGB.Location = new System.Drawing.Point(8, 12);
            this.grpHistoRGB.Name = "grpHistoRGB";
            this.grpHistoRGB.Size = new System.Drawing.Size(377, 571);
            this.grpHistoRGB.TabIndex = 4;
            this.grpHistoRGB.TabStop = false;
            this.grpHistoRGB.Text = "Histograms of RGB bands";
            // 
            // ch1
            // 
            this.ch1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartAreaRGB";
            this.ch1.ChartAreas.Add(chartArea1);
            this.ch1.Location = new System.Drawing.Point(9, 22);
            this.ch1.Name = "ch1";
            series1.ChartArea = "ChartAreaRGB";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series1.Name = "Red";
            series2.ChartArea = "ChartAreaRGB";
            series2.Name = "RMinMax";
            series2.Points.Add(dataPoint1);
            series2.Points.Add(dataPoint2);
            this.ch1.Series.Add(series1);
            this.ch1.Series.Add(series2);
            this.ch1.Size = new System.Drawing.Size(348, 140);
            this.ch1.TabIndex = 8;
            this.ch1.Text = "chart1";
            this.ch1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ch1_MouseDown);
            // 
            // lblRedMinMax
            // 
            this.lblRedMinMax.AutoSize = true;
            this.lblRedMinMax.Location = new System.Drawing.Point(258, 485);
            this.lblRedMinMax.Name = "lblRedMinMax";
            this.lblRedMinMax.Size = new System.Drawing.Size(97, 13);
            this.lblRedMinMax.TabIndex = 13;
            this.lblRedMinMax.Text = "RedMinMax: 0,255";
            // 
            // lblGreenMinMax
            // 
            this.lblGreenMinMax.AutoSize = true;
            this.lblGreenMinMax.Location = new System.Drawing.Point(258, 511);
            this.lblGreenMinMax.Name = "lblGreenMinMax";
            this.lblGreenMinMax.Size = new System.Drawing.Size(106, 13);
            this.lblGreenMinMax.TabIndex = 12;
            this.lblGreenMinMax.Text = "GreenMinMax: 0,255";
            // 
            // lblBlueMinMax
            // 
            this.lblBlueMinMax.AutoSize = true;
            this.lblBlueMinMax.Location = new System.Drawing.Point(259, 537);
            this.lblBlueMinMax.Name = "lblBlueMinMax";
            this.lblBlueMinMax.Size = new System.Drawing.Size(98, 13);
            this.lblBlueMinMax.TabIndex = 11;
            this.lblBlueMinMax.Text = "BlueMinMax: 0,255";
            // 
            // ch3
            // 
            this.ch3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartAreaRGB";
            this.ch3.ChartAreas.Add(chartArea2);
            this.ch3.Location = new System.Drawing.Point(9, 320);
            this.ch3.Name = "ch3";
            series3.ChartArea = "ChartAreaRGB";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.Name = "Blue";
            series4.ChartArea = "ChartAreaRGB";
            series4.Name = "BMinMax";
            series4.Points.Add(dataPoint3);
            series4.Points.Add(dataPoint4);
            this.ch3.Series.Add(series3);
            this.ch3.Series.Add(series4);
            this.ch3.Size = new System.Drawing.Size(348, 140);
            this.ch3.TabIndex = 10;
            this.ch3.Text = "chart1";
            this.ch3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ch3_MouseDown);
            // 
            // ch2
            // 
            this.ch2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartAreaRGB";
            this.ch2.ChartAreas.Add(chartArea3);
            this.ch2.Location = new System.Drawing.Point(9, 171);
            this.ch2.Name = "ch2";
            series5.ChartArea = "ChartAreaRGB";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series5.Name = "Green";
            series6.ChartArea = "ChartAreaRGB";
            series6.Name = "GMinMax";
            series6.Points.Add(dataPoint5);
            series6.Points.Add(dataPoint6);
            this.ch2.Series.Add(series5);
            this.ch2.Series.Add(series6);
            this.ch2.Size = new System.Drawing.Size(348, 140);
            this.ch2.TabIndex = 9;
            this.ch2.Text = "chart1";
            this.ch2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ch2_MouseDown);
            // 
            // bttnRecalcEqualizeRGB
            // 
            this.bttnRecalcEqualizeRGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnRecalcEqualizeRGB.Location = new System.Drawing.Point(9, 522);
            this.bttnRecalcEqualizeRGB.Name = "bttnRecalcEqualizeRGB";
            this.bttnRecalcEqualizeRGB.Size = new System.Drawing.Size(79, 43);
            this.bttnRecalcEqualizeRGB.TabIndex = 7;
            this.bttnRecalcEqualizeRGB.Text = "Equalize";
            this.bttnRecalcEqualizeRGB.UseVisualStyleBackColor = true;
            this.bttnRecalcEqualizeRGB.Click += new System.EventHandler(this.bttnRecalcEqualizeRGB_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "asd";
            // 
            // grpHistoOneBand
            // 
            this.grpHistoOneBand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHistoOneBand.Controls.Add(this.bttnRecalcEqualiz);
            this.grpHistoOneBand.Controls.Add(this.chart1);
            this.grpHistoOneBand.Controls.Add(this.groupBox3);
            this.grpHistoOneBand.Location = new System.Drawing.Point(28, 12);
            this.grpHistoOneBand.Name = "grpHistoOneBand";
            this.grpHistoOneBand.Size = new System.Drawing.Size(363, 498);
            this.grpHistoOneBand.TabIndex = 5;
            this.grpHistoOneBand.TabStop = false;
            this.grpHistoOneBand.Text = "Histogram for one band";
            // 
            // bttnRecalcEqualiz
            // 
            this.bttnRecalcEqualiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnRecalcEqualiz.Location = new System.Drawing.Point(276, 352);
            this.bttnRecalcEqualiz.Name = "bttnRecalcEqualiz";
            this.bttnRecalcEqualiz.Size = new System.Drawing.Size(81, 38);
            this.bttnRecalcEqualiz.TabIndex = 5;
            this.bttnRecalcEqualiz.Text = "Equalize";
            this.bttnRecalcEqualiz.UseVisualStyleBackColor = true;
            this.bttnRecalcEqualiz.Click += new System.EventHandler(this.bttnRecalcEqualiz_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(6, 22);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Name = "Series1";
            series8.ChartArea = "ChartArea1";
            series8.MarkerSize = 1;
            series8.Name = "Series2";
            dataPoint7.MarkerSize = 20;
            dataPoint8.MarkerSize = 20;
            series8.Points.Add(dataPoint7);
            series8.Points.Add(dataPoint8);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(335, 300);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Controls.Add(this.lblIntensityMax);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblIntensityMin);
            this.groupBox3.Location = new System.Drawing.Point(6, 397);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 93);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set min/max intensity";
            // 
            // lblIntensityMax
            // 
            this.lblIntensityMax.AutoSize = true;
            this.lblIntensityMax.Location = new System.Drawing.Point(267, 54);
            this.lblIntensityMax.Name = "lblIntensityMax";
            this.lblIntensityMax.Size = new System.Drawing.Size(80, 13);
            this.lblIntensityMax.TabIndex = 1;
            this.lblIntensityMax.Text = "Max value: 255";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 54);
            this.label2.TabIndex = 4;
            this.label2.Text = "asd";
            // 
            // lblIntensityMin
            // 
            this.lblIntensityMin.AutoSize = true;
            this.lblIntensityMin.Location = new System.Drawing.Point(270, 29);
            this.lblIntensityMin.Name = "lblIntensityMin";
            this.lblIntensityMin.Size = new System.Drawing.Size(65, 13);
            this.lblIntensityMin.TabIndex = 0;
            this.lblIntensityMin.Text = "Min value: 0";
            // 
            // Histogram3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 595);
            this.Controls.Add(this.grpHistoOneBand);
            this.Controls.Add(this.grpHistoRGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Histogram3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histogram3";
            this.grpHistoRGB.ResumeLayout(false);
            this.grpHistoRGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2)).EndInit();
            this.grpHistoOneBand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpHistoRGB;
        private System.Windows.Forms.GroupBox grpHistoOneBand;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIntensityMax;
        private System.Windows.Forms.Label lblIntensityMin;
        private System.Windows.Forms.Button bttnRecalcEqualizeRGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch3;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblRedMinMax;
        private System.Windows.Forms.Label lblGreenMinMax;
        private System.Windows.Forms.Label lblBlueMinMax;
        public System.Windows.Forms.Button bttnRecalcEqualiz;
    }
}