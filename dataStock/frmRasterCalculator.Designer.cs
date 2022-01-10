namespace Giwer.dataStock
{
    partial class frmRasterCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRasterCalculator));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMuvelet = new System.Windows.Forms.ComboBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.bttnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSelectedIntValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bttnGoBetween = new System.Windows.Forms.Button();
            this.tbValueIntBetween = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUpperValue = new System.Windows.Forms.TextBox();
            this.tbLowerValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbElseValueBetween = new System.Windows.Forms.TextBox();
            this.tbElseValue = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECT PIXELS WHERE Intensity values ARE ";
            // 
            // cmbMuvelet
            // 
            this.cmbMuvelet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMuvelet.FormattingEnabled = true;
            this.cmbMuvelet.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "!="});
            this.cmbMuvelet.Location = new System.Drawing.Point(257, 22);
            this.cmbMuvelet.Name = "cmbMuvelet";
            this.cmbMuvelet.Size = new System.Drawing.Size(49, 21);
            this.cmbMuvelet.TabIndex = 1;
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(318, 22);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(42, 20);
            this.tbValue.TabIndex = 2;
            this.tbValue.TextChanged += new System.EventHandler(this.tbValue_TextChanged);
            // 
            // bttnGo
            // 
            this.bttnGo.Location = new System.Drawing.Point(424, 13);
            this.bttnGo.Name = "bttnGo";
            this.bttnGo.Size = new System.Drawing.Size(58, 50);
            this.bttnGo.TabIndex = 3;
            this.bttnGo.Text = "Go";
            this.bttnGo.UseVisualStyleBackColor = true;
            this.bttnGo.Click += new System.EventHandler(this.bttnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Let the selected intensity values be: ";
            // 
            // tbSelectedIntValue
            // 
            this.tbSelectedIntValue.Location = new System.Drawing.Point(186, 47);
            this.tbSelectedIntValue.Name = "tbSelectedIntValue";
            this.tbSelectedIntValue.Size = new System.Drawing.Size(35, 20);
            this.tbSelectedIntValue.TabIndex = 5;
            this.tbSelectedIntValue.Text = "255";
            this.tbSelectedIntValue.TextChanged += new System.EventHandler(this.tbSelectedIntValue_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbElseValue);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbSelectedIntValue);
            this.groupBox1.Controls.Add(this.cmbMuvelet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbValue);
            this.groupBox1.Controls.Add(this.bttnGo);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 113);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single value selection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbElseValueBetween);
            this.groupBox2.Controls.Add(this.bttnGoBetween);
            this.groupBox2.Controls.Add(this.tbValueIntBetween);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbUpperValue);
            this.groupBox2.Controls.Add(this.tbLowerValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(2, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 119);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Between value selection";
            // 
            // bttnGoBetween
            // 
            this.bttnGoBetween.Location = new System.Drawing.Point(424, 13);
            this.bttnGoBetween.Name = "bttnGoBetween";
            this.bttnGoBetween.Size = new System.Drawing.Size(58, 50);
            this.bttnGoBetween.TabIndex = 8;
            this.bttnGoBetween.Text = "Go";
            this.bttnGoBetween.UseVisualStyleBackColor = true;
            this.bttnGoBetween.Click += new System.EventHandler(this.bttnGoBetween_Click);
            // 
            // tbValueIntBetween
            // 
            this.tbValueIntBetween.Location = new System.Drawing.Point(186, 47);
            this.tbValueIntBetween.Name = "tbValueIntBetween";
            this.tbValueIntBetween.Size = new System.Drawing.Size(35, 20);
            this.tbValueIntBetween.TabIndex = 7;
            this.tbValueIntBetween.Text = "255";
            this.tbValueIntBetween.TextChanged += new System.EventHandler(this.tbValueIntBetween_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Let the selected intensity values be: ";
            // 
            // tbUpperValue
            // 
            this.tbUpperValue.Location = new System.Drawing.Point(365, 22);
            this.tbUpperValue.Name = "tbUpperValue";
            this.tbUpperValue.Size = new System.Drawing.Size(34, 20);
            this.tbUpperValue.TabIndex = 4;
            this.tbUpperValue.TextChanged += new System.EventHandler(this.tbUpperValue_TextChanged);
            // 
            // tbLowerValue
            // 
            this.tbLowerValue.Location = new System.Drawing.Point(299, 22);
            this.tbLowerValue.Name = "tbLowerValue";
            this.tbLowerValue.Size = new System.Drawing.Size(35, 20);
            this.tbLowerValue.TabIndex = 3;
            this.tbLowerValue.TextChanged += new System.EventHandler(this.tbLowerValue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "AND";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SELECT PIXELS WHERE Intensity values ARE BETWEEN ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "else value: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "else value: ";
            // 
            // tbElseValueBetween
            // 
            this.tbElseValueBetween.Location = new System.Drawing.Point(73, 73);
            this.tbElseValueBetween.Name = "tbElseValueBetween";
            this.tbElseValueBetween.Size = new System.Drawing.Size(37, 20);
            this.tbElseValueBetween.TabIndex = 7;
            this.tbElseValueBetween.Text = "0";
            // 
            // tbElseValue
            // 
            this.tbElseValue.Location = new System.Drawing.Point(73, 73);
            this.tbElseValue.Name = "tbElseValue";
            this.tbElseValue.Size = new System.Drawing.Size(37, 20);
            this.tbElseValue.TabIndex = 8;
            this.tbElseValue.Text = "0";
            // 
            // frmRasterCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 243);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRasterCalculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raster calculator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRasterCalculator_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMuvelet;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button bttnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSelectedIntValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bttnGoBetween;
        private System.Windows.Forms.TextBox tbValueIntBetween;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUpperValue;
        private System.Windows.Forms.TextBox tbLowerValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbElseValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbElseValueBetween;
    }
}