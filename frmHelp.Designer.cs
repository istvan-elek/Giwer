
namespace Giwer
{
    partial class frmHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbUsersguideLanguage = new System.Windows.Forms.ComboBox();
            this.bttnGiwerUG = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTutorLanguage = new System.Windows.Forms.ComboBox();
            this.bttnTutor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbUsersguideLanguage);
            this.groupBox1.Controls.Add(this.bttnGiwerUG);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users\' guides";
            // 
            // cmbUsersguideLanguage
            // 
            this.cmbUsersguideLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsersguideLanguage.FormattingEnabled = true;
            this.cmbUsersguideLanguage.Items.AddRange(new object[] {
            "Magyar",
            "English"});
            this.cmbUsersguideLanguage.Location = new System.Drawing.Point(11, 19);
            this.cmbUsersguideLanguage.Name = "cmbUsersguideLanguage";
            this.cmbUsersguideLanguage.Size = new System.Drawing.Size(133, 21);
            this.cmbUsersguideLanguage.TabIndex = 2;
            this.cmbUsersguideLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbUsersguideLanguage_SelectedIndexChanged);
            // 
            // bttnGiwerUG
            // 
            this.bttnGiwerUG.Location = new System.Drawing.Point(11, 59);
            this.bttnGiwerUG.Name = "bttnGiwerUG";
            this.bttnGiwerUG.Size = new System.Drawing.Size(134, 46);
            this.bttnGiwerUG.TabIndex = 1;
            this.bttnGiwerUG.Text = "Giwer users\' guide";
            this.bttnGiwerUG.UseVisualStyleBackColor = true;
            this.bttnGiwerUG.Click += new System.EventHandler(this.bttnGiwerUG_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbTutorLanguage);
            this.groupBox2.Controls.Add(this.bttnTutor);
            this.groupBox2.Location = new System.Drawing.Point(14, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 115);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tutorials";
            // 
            // cmbTutorLanguage
            // 
            this.cmbTutorLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTutorLanguage.FormattingEnabled = true;
            this.cmbTutorLanguage.Items.AddRange(new object[] {
            "Magyar",
            "English"});
            this.cmbTutorLanguage.Location = new System.Drawing.Point(12, 19);
            this.cmbTutorLanguage.Name = "cmbTutorLanguage";
            this.cmbTutorLanguage.Size = new System.Drawing.Size(133, 21);
            this.cmbTutorLanguage.TabIndex = 5;
            this.cmbTutorLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbTutorLanguage_SelectedIndexChanged);
            // 
            // bttnTutor
            // 
            this.bttnTutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnTutor.Location = new System.Drawing.Point(12, 61);
            this.bttnTutor.Name = "bttnTutor";
            this.bttnTutor.Size = new System.Drawing.Size(134, 48);
            this.bttnTutor.TabIndex = 4;
            this.bttnTutor.Text = "Tutorial";
            this.bttnTutor.UseVisualStyleBackColor = true;
            this.bttnTutor.Click += new System.EventHandler(this.bttnTutor_Click);
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 276);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Help";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bttnTutor;
        private System.Windows.Forms.Button bttnGiwerUG;
        private System.Windows.Forms.ComboBox cmbUsersguideLanguage;
        private System.Windows.Forms.ComboBox cmbTutorLanguage;
    }
}