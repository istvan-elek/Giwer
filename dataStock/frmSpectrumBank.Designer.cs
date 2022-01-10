
namespace Giwer.dataStock
{
    partial class frmSpectrumBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpectrumBank));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbttnOpenSpectrumBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbttnCreateNewBankCollection = new System.Windows.Forms.ToolStripButton();
            this.tsbttnCreateNewBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tscmbAvailableSpectrums = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbttnOpenSpectrumBank,
            this.toolStripSeparator1,
            this.tsbttnCreateNewBankCollection,
            this.tsbttnCreateNewBank,
            this.toolStripSeparator2,
            this.toolStripTextBox1,
            this.tscmbAvailableSpectrums});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbttnOpenSpectrumBank
            // 
            this.tsbttnOpenSpectrumBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbttnOpenSpectrumBank.Image = ((System.Drawing.Image)(resources.GetObject("tsbttnOpenSpectrumBank.Image")));
            this.tsbttnOpenSpectrumBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbttnOpenSpectrumBank.Name = "tsbttnOpenSpectrumBank";
            this.tsbttnOpenSpectrumBank.Size = new System.Drawing.Size(23, 22);
            this.tsbttnOpenSpectrumBank.Text = "Open spectrum bank";
            this.tsbttnOpenSpectrumBank.Click += new System.EventHandler(this.tsbttnOpenSpectrumBank_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbttnCreateNewBankCollection
            // 
            this.tsbttnCreateNewBankCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbttnCreateNewBankCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbttnCreateNewBankCollection.Image")));
            this.tsbttnCreateNewBankCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbttnCreateNewBankCollection.Name = "tsbttnCreateNewBankCollection";
            this.tsbttnCreateNewBankCollection.Size = new System.Drawing.Size(23, 22);
            this.tsbttnCreateNewBankCollection.Text = "Create new spectrum bank collection as file";
            this.tsbttnCreateNewBankCollection.Click += new System.EventHandler(this.tsbttnCreateNewBankCollectionFile_Click);
            // 
            // tsbttnCreateNewBank
            // 
            this.tsbttnCreateNewBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbttnCreateNewBank.Enabled = false;
            this.tsbttnCreateNewBank.Image = ((System.Drawing.Image)(resources.GetObject("tsbttnCreateNewBank.Image")));
            this.tsbttnCreateNewBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbttnCreateNewBank.Name = "tsbttnCreateNewBank";
            this.tsbttnCreateNewBank.Size = new System.Drawing.Size(23, 22);
            this.tsbttnCreateNewBank.Text = "Create new bank";
            this.tsbttnCreateNewBank.Click += new System.EventHandler(this.tsbttnCreateNewBank_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 25);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(633, 382);
            this.dgv.TabIndex = 1;
            // 
            // tscmbAvailableSpectrums
            // 
            this.tscmbAvailableSpectrums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbAvailableSpectrums.Name = "tscmbAvailableSpectrums";
            this.tscmbAvailableSpectrums.Size = new System.Drawing.Size(121, 25);
            this.tscmbAvailableSpectrums.SelectedIndexChanged += new System.EventHandler(this.tscmbAvailableSpectrums_SelectedIndexChanged);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 25);
            this.toolStripTextBox1.Text = "Select your spectrum bank:";
            // 
            // frmSpectrumBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 407);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSpectrumBank";
            this.Text = "Spectrum bank editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbttnOpenSpectrumBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbttnCreateNewBankCollection;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripButton tsbttnCreateNewBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox tscmbAvailableSpectrums;
    }
}