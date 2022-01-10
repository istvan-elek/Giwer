namespace Giwer.dataStock.Clustering.View
{
    partial class ManualClusterSelectControl
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
            this.numberOfClustersChanger = new System.Windows.Forms.NumericUpDown();
            this.dgvMCS = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.numMaxIter = new System.Windows.Forms.NumericUpDown();
            this.numChangeThreshold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbColPaletteTables = new System.Windows.Forms.ComboBox();
            this.loadLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.typeCmbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClustersChanger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMaxClust
            // 
            this.labelMaxClust.Location = new System.Drawing.Point(9, 145);
            this.labelMaxClust.Visible = false;
            // 
            // numMaxClust
            // 
            this.numMaxClust.Location = new System.Drawing.Point(63, 38);
            this.numMaxClust.Visible = false;
            // 
            // numberOfClustersChanger
            // 
            this.numberOfClustersChanger.Location = new System.Drawing.Point(159, 57);
            this.numberOfClustersChanger.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfClustersChanger.Name = "numberOfClustersChanger";
            this.numberOfClustersChanger.Size = new System.Drawing.Size(65, 20);
            this.numberOfClustersChanger.TabIndex = 10;
            this.numberOfClustersChanger.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfClustersChanger.ValueChanged += new System.EventHandler(this.numberOfClustersChanger_ValueChanged);
            // 
            // dgvMCS
            // 
            this.dgvMCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMCS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMCS.Location = new System.Drawing.Point(5, 111);
            this.dgvMCS.Name = "dgvMCS";
            this.dgvMCS.Size = new System.Drawing.Size(219, 246);
            this.dgvMCS.TabIndex = 9;
            this.dgvMCS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaseColors_CellClick);
            this.dgvMCS.MouseEnter += new System.EventHandler(this.dgvMCS_MouseEnter);
            this.dgvMCS.MouseLeave += new System.EventHandler(this.dgvMCS_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of clusters:";
            // 
            // numMaxIter
            // 
            this.numMaxIter.Location = new System.Drawing.Point(146, 111);
            this.numMaxIter.Name = "numMaxIter";
            this.numMaxIter.Size = new System.Drawing.Size(65, 20);
            this.numMaxIter.TabIndex = 13;
            // 
            // numChangeThreshold
            // 
            this.numChangeThreshold.DecimalPlaces = 3;
            this.numChangeThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numChangeThreshold.Location = new System.Drawing.Point(159, 31);
            this.numChangeThreshold.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numChangeThreshold.Name = "numChangeThreshold";
            this.numChangeThreshold.Size = new System.Drawing.Size(65, 20);
            this.numChangeThreshold.TabIndex = 15;
            this.numChangeThreshold.Value = new decimal(new int[] {
            990,
            0,
            0,
            196608});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(4, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Relative Distortion Threshold:";
            // 
            // cmbColPaletteTables
            // 
            this.cmbColPaletteTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColPaletteTables.FormattingEnabled = true;
            this.cmbColPaletteTables.Location = new System.Drawing.Point(61, 373);
            this.cmbColPaletteTables.Name = "cmbColPaletteTables";
            this.cmbColPaletteTables.Size = new System.Drawing.Size(161, 21);
            this.cmbColPaletteTables.TabIndex = 18;
            this.cmbColPaletteTables.SelectedIndexChanged += new System.EventHandler(this.cmbColPaletteTables_SelectedIndexChanged);
            // 
            // loadLabel
            // 
            this.loadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadLabel.AutoSize = true;
            this.loadLabel.Location = new System.Drawing.Point(4, 376);
            this.loadLabel.Name = "loadLabel";
            this.loadLabel.Size = new System.Drawing.Size(34, 13);
            this.loadLabel.TabIndex = 19;
            this.loadLabel.Text = "Load:";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(5, 429);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(217, 23);
            this.saveBtn.TabIndex = 21;
            this.saveBtn.Text = "Save Colorpalette and LUT";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(5, 400);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(217, 23);
            this.newBtn.TabIndex = 22;
            this.newBtn.Text = "New Colorpalette and LUT";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // typeCmbx
            // 
            this.typeCmbx.FormattingEnabled = true;
            this.typeCmbx.Location = new System.Drawing.Point(101, 83);
            this.typeCmbx.Name = "typeCmbx";
            this.typeCmbx.Size = new System.Drawing.Size(121, 21);
            this.typeCmbx.TabIndex = 23;
            this.typeCmbx.SelectedIndexChanged += new System.EventHandler(this.typeCmbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Sample type:";
            // 
            // ManualClusterSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeCmbx);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.loadLabel);
            this.Controls.Add(this.cmbColPaletteTables);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numChangeThreshold);
            this.Controls.Add(this.dgvMCS);
            this.Controls.Add(this.numberOfClustersChanger);
            this.Controls.Add(this.numMaxIter);
            this.Controls.Add(this.label2);
            this.Name = "ManualClusterSelectControl";
            this.Size = new System.Drawing.Size(227, 469);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.numMaxIter, 0);
            this.Controls.SetChildIndex(this.numberOfClustersChanger, 0);
            this.Controls.SetChildIndex(this.dgvMCS, 0);
            this.Controls.SetChildIndex(this.numChangeThreshold, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.labelMaxClust, 0);
            this.Controls.SetChildIndex(this.numMaxClust, 0);
            this.Controls.SetChildIndex(this.cmbColPaletteTables, 0);
            this.Controls.SetChildIndex(this.loadLabel, 0);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            this.Controls.SetChildIndex(this.newBtn, 0);
            this.Controls.SetChildIndex(this.typeCmbx, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClustersChanger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMCS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberOfClustersChanger;
        private System.Windows.Forms.NumericUpDown numMaxIter;
        private System.Windows.Forms.NumericUpDown numChangeThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbColPaletteTables;
        private System.Windows.Forms.Label loadLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.ComboBox typeCmbx;
        private System.Windows.Forms.Label label1;
    }
}
