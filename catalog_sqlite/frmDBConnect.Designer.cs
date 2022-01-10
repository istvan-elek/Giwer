namespace catalog
{
    partial class frmDBConnect
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
            this.bttnCancel = new System.Windows.Forms.Button();
            this.bttnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbport = new System.Windows.Forms.TextBox();
            this.tbdbname = new System.Windows.Forms.TextBox();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.tbpw = new System.Windows.Forms.TextBox();
            this.tbhost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bttnCancel
            // 
            this.bttnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(17, 145);
            this.bttnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(56, 26);
            this.bttnCancel.TabIndex = 1;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnConnect
            // 
            this.bttnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnConnect.Location = new System.Drawing.Point(162, 145);
            this.bttnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.bttnConnect.Name = "bttnConnect";
            this.bttnConnect.Size = new System.Drawing.Size(78, 26);
            this.bttnConnect.TabIndex = 2;
            this.bttnConnect.Text = "Connect";
            this.bttnConnect.UseVisualStyleBackColor = true;
            this.bttnConnect.Click += new System.EventHandler(this.bttnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "User name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Database name:";
            // 
            // tbport
            // 
            this.tbport.Location = new System.Drawing.Point(108, 102);
            this.tbport.Margin = new System.Windows.Forms.Padding(2);
            this.tbport.Name = "tbport";
            this.tbport.Size = new System.Drawing.Size(132, 20);
            this.tbport.TabIndex = 8;
            // 
            // tbdbname
            // 
            this.tbdbname.Location = new System.Drawing.Point(108, 11);
            this.tbdbname.Margin = new System.Windows.Forms.Padding(2);
            this.tbdbname.Name = "tbdbname";
            this.tbdbname.Size = new System.Drawing.Size(132, 20);
            this.tbdbname.TabIndex = 9;
            this.tbdbname.Text = "dronimagecatalog";
            // 
            // tbusername
            // 
            this.tbusername.Location = new System.Drawing.Point(108, 34);
            this.tbusername.Margin = new System.Windows.Forms.Padding(2);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(132, 20);
            this.tbusername.TabIndex = 10;
            // 
            // tbpw
            // 
            this.tbpw.Location = new System.Drawing.Point(108, 57);
            this.tbpw.Margin = new System.Windows.Forms.Padding(2);
            this.tbpw.Name = "tbpw";
            this.tbpw.Size = new System.Drawing.Size(132, 20);
            this.tbpw.TabIndex = 11;
            // 
            // tbhost
            // 
            this.tbhost.Location = new System.Drawing.Point(108, 80);
            this.tbhost.Margin = new System.Windows.Forms.Padding(2);
            this.tbhost.Name = "tbhost";
            this.tbhost.Size = new System.Drawing.Size(132, 20);
            this.tbhost.TabIndex = 12;
            // 
            // frmDBConnect
            // 
            this.AcceptButton = this.bttnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(263, 192);
            this.ControlBox = false;
            this.Controls.Add(this.tbhost);
            this.Controls.Add(this.tbpw);
            this.Controls.Add(this.tbusername);
            this.Controls.Add(this.tbdbname);
            this.Controls.Add(this.tbport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnConnect);
            this.Controls.Add(this.bttnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDBConnect";
            this.Text = "Connect to database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Button bttnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbport;
        private System.Windows.Forms.TextBox tbdbname;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.TextBox tbpw;
        private System.Windows.Forms.TextBox tbhost;
    }
}