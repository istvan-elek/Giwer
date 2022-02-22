namespace Giwer.dataStock
{
    partial class CrossPlot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrossPlot));
            this.cmbXaxis = new System.Windows.Forms.ComboBox();
            this.cmbYaxis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnDrawPlot = new System.Windows.Forms.Button();
            this.ch1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bttnPointColor = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.grBox = new System.Windows.Forms.GroupBox();
            this.chkDisplayInNewWindow = new System.Windows.Forms.CheckBox();
            this.bttnApply2Image = new System.Windows.Forms.Button();
            this.bttnAbove = new System.Windows.Forms.Button();
            this.bttnBelow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.grBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbXaxis
            // 
            this.cmbXaxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXaxis.FormattingEnabled = true;
            this.cmbXaxis.Location = new System.Drawing.Point(12, 25);
            this.cmbXaxis.Name = "cmbXaxis";
            this.cmbXaxis.Size = new System.Drawing.Size(121, 21);
            this.cmbXaxis.TabIndex = 1;
            this.cmbXaxis.SelectedIndexChanged += new System.EventHandler(this.cmbXaxis_SelectedIndexChanged);
            // 
            // cmbYaxis
            // 
            this.cmbYaxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYaxis.FormattingEnabled = true;
            this.cmbYaxis.Location = new System.Drawing.Point(12, 74);
            this.cmbYaxis.Name = "cmbYaxis";
            this.cmbYaxis.Size = new System.Drawing.Size(121, 21);
            this.cmbYaxis.TabIndex = 2;
            this.cmbYaxis.SelectedIndexChanged += new System.EventHandler(this.cmbYaxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select band for X axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select band for Y axis";
            // 
            // bttnDrawPlot
            // 
            this.bttnDrawPlot.Location = new System.Drawing.Point(15, 118);
            this.bttnDrawPlot.Name = "bttnDrawPlot";
            this.bttnDrawPlot.Size = new System.Drawing.Size(118, 42);
            this.bttnDrawPlot.TabIndex = 5;
            this.bttnDrawPlot.Text = "Draw plot";
            this.bttnDrawPlot.UseVisualStyleBackColor = true;
            this.bttnDrawPlot.Click += new System.EventHandler(this.DrawPlot_Click);
            // 
            // ch1
            // 
            this.ch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Interval = 50D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.IsMarksNextToAxis = false;
            chartArea1.AxisX.Maximum = 256D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Interval = 50D;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.Maximum = 256D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.ch1.ChartAreas.Add(chartArea1);
            this.ch1.Location = new System.Drawing.Point(165, 9);
            this.ch1.Name = "ch1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerColor = System.Drawing.Color.Blue;
            series1.MarkerSize = 1;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Name = "Series2";
            this.ch1.Series.Add(series1);
            this.ch1.Series.Add(series2);
            this.ch1.Size = new System.Drawing.Size(414, 390);
            this.ch1.TabIndex = 6;
            this.ch1.Text = "chart1";
            this.ch1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ch1_MouseDown);
            this.ch1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ch1_MouseMove);
            this.ch1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ch1_MouseUp);
            // 
            // bttnPointColor
            // 
            this.bttnPointColor.Location = new System.Drawing.Point(15, 175);
            this.bttnPointColor.Name = "bttnPointColor";
            this.bttnPointColor.Size = new System.Drawing.Size(90, 24);
            this.bttnPointColor.TabIndex = 7;
            this.bttnPointColor.Text = "Set point color";
            this.bttnPointColor.UseVisualStyleBackColor = true;
            this.bttnPointColor.Click += new System.EventHandler(this.bttnPointColor_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(75, 200);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Point size: ";
            // 
            // grBox
            // 
            this.grBox.Controls.Add(this.chkDisplayInNewWindow);
            this.grBox.Controls.Add(this.bttnApply2Image);
            this.grBox.Controls.Add(this.bttnAbove);
            this.grBox.Controls.Add(this.bttnBelow);
            this.grBox.Location = new System.Drawing.Point(7, 236);
            this.grBox.Name = "grBox";
            this.grBox.Size = new System.Drawing.Size(136, 163);
            this.grBox.TabIndex = 11;
            this.grBox.TabStop = false;
            this.grBox.Text = "Select pixels";
            this.grBox.Visible = false;
            // 
            // chkDisplayInNewWindow
            // 
            this.chkDisplayInNewWindow.AutoSize = true;
            this.chkDisplayInNewWindow.Checked = true;
            this.chkDisplayInNewWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplayInNewWindow.Location = new System.Drawing.Point(8, 140);
            this.chkDisplayInNewWindow.Name = "chkDisplayInNewWindow";
            this.chkDisplayInNewWindow.Size = new System.Drawing.Size(96, 17);
            this.chkDisplayInNewWindow.TabIndex = 16;
            this.chkDisplayInNewWindow.Text = "in new window";
            this.chkDisplayInNewWindow.UseVisualStyleBackColor = true;
            // 
            // bttnApply2Image
            // 
            this.bttnApply2Image.Location = new System.Drawing.Point(6, 89);
            this.bttnApply2Image.Name = "bttnApply2Image";
            this.bttnApply2Image.Size = new System.Drawing.Size(115, 31);
            this.bttnApply2Image.TabIndex = 15;
            this.bttnApply2Image.Text = "Apply to image";
            this.bttnApply2Image.UseVisualStyleBackColor = true;
            this.bttnApply2Image.Click += new System.EventHandler(this.bttnApply2Image_Click);
            // 
            // bttnAbove
            // 
            this.bttnAbove.Location = new System.Drawing.Point(3, 19);
            this.bttnAbove.Name = "bttnAbove";
            this.bttnAbove.Size = new System.Drawing.Size(118, 23);
            this.bttnAbove.TabIndex = 14;
            this.bttnAbove.Text = "Above line";
            this.bttnAbove.UseVisualStyleBackColor = true;
            this.bttnAbove.Click += new System.EventHandler(this.bttnAbove_Click);
            // 
            // bttnBelow
            // 
            this.bttnBelow.Location = new System.Drawing.Point(3, 48);
            this.bttnBelow.Name = "bttnBelow";
            this.bttnBelow.Size = new System.Drawing.Size(118, 23);
            this.bttnBelow.TabIndex = 13;
            this.bttnBelow.Text = "Below line";
            this.bttnBelow.UseVisualStyleBackColor = true;
            this.bttnBelow.Click += new System.EventHandler(this.bttnBelow_Click);
            // 
            // CrossPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 411);
            this.Controls.Add(this.grBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.bttnPointColor);
            this.Controls.Add(this.ch1);
            this.Controls.Add(this.bttnDrawPlot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYaxis);
            this.Controls.Add(this.cmbXaxis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CrossPlot";
            this.Text = "CrossPlot";
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.grBox.ResumeLayout(false);
            this.grBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbXaxis;
        private System.Windows.Forms.ComboBox cmbYaxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnDrawPlot;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch1;
        private System.Windows.Forms.Button bttnPointColor;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grBox;
        private System.Windows.Forms.Button bttnApply2Image;
        private System.Windows.Forms.Button bttnAbove;
        private System.Windows.Forms.Button bttnBelow;
        public System.Windows.Forms.CheckBox chkDisplayInNewWindow;
    }
}