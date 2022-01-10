namespace Giwer.dataStock
{
    partial class frmLookUpTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookUpTables));
            this.cmbColPaletteTables = new System.Windows.Forms.ComboBox();
            this.bttnSaveColorPalette = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCP = new System.Windows.Forms.DataGridView();
            this.bttnCreateNewLut = new System.Windows.Forms.Button();
            this.bttnRemoveSelectedCP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumOfColors = new System.Windows.Forms.TextBox();
            this.dgvLUT = new System.Windows.Forms.DataGridView();
            this.bttnGenerateCP = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttnSaveLUT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLUT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbColPaletteTables
            // 
            this.cmbColPaletteTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColPaletteTables.FormattingEnabled = true;
            this.cmbColPaletteTables.Location = new System.Drawing.Point(152, 12);
            this.cmbColPaletteTables.Name = "cmbColPaletteTables";
            this.cmbColPaletteTables.Size = new System.Drawing.Size(207, 21);
            this.cmbColPaletteTables.TabIndex = 1;
            this.cmbColPaletteTables.SelectedIndexChanged += new System.EventHandler(this.cmbColPalette_SelectedIndexChanged);
            // 
            // bttnSaveColorPalette
            // 
            this.bttnSaveColorPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnSaveColorPalette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttnSaveColorPalette.Location = new System.Drawing.Point(287, 351);
            this.bttnSaveColorPalette.Name = "bttnSaveColorPalette";
            this.bttnSaveColorPalette.Size = new System.Drawing.Size(75, 48);
            this.bttnSaveColorPalette.TabIndex = 2;
            this.bttnSaveColorPalette.Text = "Save color palette";
            this.bttnSaveColorPalette.UseVisualStyleBackColor = false;
            this.bttnSaveColorPalette.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Available color palettes:";
            // 
            // dgvCP
            // 
            this.dgvCP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCP.Location = new System.Drawing.Point(12, 42);
            this.dgvCP.Name = "dgvCP";
            this.dgvCP.Size = new System.Drawing.Size(350, 292);
            this.dgvCP.TabIndex = 4;
            this.dgvCP.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCP_CellValueChanged);
            // 
            // bttnCreateNewLut
            // 
            this.bttnCreateNewLut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnCreateNewLut.Location = new System.Drawing.Point(12, 351);
            this.bttnCreateNewLut.Name = "bttnCreateNewLut";
            this.bttnCreateNewLut.Size = new System.Drawing.Size(73, 48);
            this.bttnCreateNewLut.TabIndex = 5;
            this.bttnCreateNewLut.Text = "Create new color palette";
            this.bttnCreateNewLut.UseVisualStyleBackColor = true;
            this.bttnCreateNewLut.Click += new System.EventHandler(this.bttnCreateNewCP_Click);
            // 
            // bttnRemoveSelectedCP
            // 
            this.bttnRemoveSelectedCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnRemoveSelectedCP.Location = new System.Drawing.Point(107, 351);
            this.bttnRemoveSelectedCP.Name = "bttnRemoveSelectedCP";
            this.bttnRemoveSelectedCP.Size = new System.Drawing.Size(76, 48);
            this.bttnRemoveSelectedCP.TabIndex = 6;
            this.bttnRemoveSelectedCP.Text = "Remove selecled color palette";
            this.bttnRemoveSelectedCP.UseVisualStyleBackColor = true;
            this.bttnRemoveSelectedCP.Click += new System.EventHandler(this.bttnRemoveSelectedCP_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of base colors:";
            // 
            // tbNumOfColors
            // 
            this.tbNumOfColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNumOfColors.Location = new System.Drawing.Point(132, 28);
            this.tbNumOfColors.Name = "tbNumOfColors";
            this.tbNumOfColors.Size = new System.Drawing.Size(23, 20);
            this.tbNumOfColors.TabIndex = 8;
            this.tbNumOfColors.Text = "8";
            this.tbNumOfColors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumOfColors_KeyDown);
            // 
            // dgvLUT
            // 
            this.dgvLUT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLUT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLUT.Location = new System.Drawing.Point(13, 57);
            this.dgvLUT.Name = "dgvLUT";
            this.dgvLUT.Size = new System.Drawing.Size(196, 265);
            this.dgvLUT.TabIndex = 9;
            this.dgvLUT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaseColors_CellClick);
            this.dgvLUT.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLUT_CellValueChanged);
            // 
            // bttnGenerateCP
            // 
            this.bttnGenerateCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnGenerateCP.Location = new System.Drawing.Point(201, 351);
            this.bttnGenerateCP.Name = "bttnGenerateCP";
            this.bttnGenerateCP.Size = new System.Drawing.Size(75, 48);
            this.bttnGenerateCP.TabIndex = 10;
            this.bttnGenerateCP.Text = "Generate palette  colors";
            this.bttnGenerateCP.UseVisualStyleBackColor = true;
            this.bttnGenerateCP.Click += new System.EventHandler(this.bttnGenerateCP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLUT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNumOfColors);
            this.groupBox1.Location = new System.Drawing.Point(384, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 331);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lookup table";
            // 
            // bttnSaveLUT
            // 
            this.bttnSaveLUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttnSaveLUT.Location = new System.Drawing.Point(464, 351);
            this.bttnSaveLUT.Name = "bttnSaveLUT";
            this.bttnSaveLUT.Size = new System.Drawing.Size(86, 41);
            this.bttnSaveLUT.TabIndex = 12;
            this.bttnSaveLUT.Text = "Save lookup table";
            this.bttnSaveLUT.UseVisualStyleBackColor = false;
            this.bttnSaveLUT.Click += new System.EventHandler(this.bttnSaveLUT_Click);
            // 
            // frmLookUpTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 404);
            this.Controls.Add(this.bttnSaveLUT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttnGenerateCP);
            this.Controls.Add(this.bttnRemoveSelectedCP);
            this.Controls.Add(this.bttnCreateNewLut);
            this.Controls.Add(this.dgvCP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnSaveColorPalette);
            this.Controls.Add(this.cmbColPaletteTables);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLookUpTables";
            this.Text = "Color palettes (CP) and lookup tables (LUT)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLookUpTables_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLUT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbColPaletteTables;
        private System.Windows.Forms.Button bttnSaveColorPalette;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCP;
        private System.Windows.Forms.Button bttnCreateNewLut;
        private System.Windows.Forms.Button bttnRemoveSelectedCP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumOfColors;
        private System.Windows.Forms.DataGridView dgvLUT;
        private System.Windows.Forms.Button bttnGenerateCP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttnSaveLUT;
    }
}