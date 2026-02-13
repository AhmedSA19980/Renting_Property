namespace PropertyRenting.Login
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            btnLogin = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            txtusername = new System.Windows.Forms.TextBox();
            txtpass = new System.Windows.Forms.TextBox();
            chkRememberMe = new System.Windows.Forms.CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnLogin.Image = (System.Drawing.Image)resources.GetObject("btnLogin.Image");
            btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLogin.Location = new System.Drawing.Point(544, 311);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(121, 40);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(477, 67);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(230, 24);
            label1.TabIndex = 3;
            label1.Text = "Login in your account";
            // 
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new System.Drawing.Point(756, -2);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(44, 43);
            btnClose.TabIndex = 4;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panel1.Controls.Add(label2);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(396, 454);
            panel1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label2.Location = new System.Drawing.Point(12, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(341, 24);
            label2.TabIndex = 6;
            label2.Text = "Find a comfortable place to book";
            // 
            // txtusername
            // 
            txtusername.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtusername.Location = new System.Drawing.Point(477, 128);
            txtusername.Name = "txtusername";
            txtusername.Size = new System.Drawing.Size(224, 33);
            txtusername.TabIndex = 6;
            // 
            // txtpass
            // 
            txtpass.BackColor = System.Drawing.SystemColors.ControlLightLight;
            txtpass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtpass.Location = new System.Drawing.Point(477, 197);
            txtpass.Name = "txtpass";
            txtpass.PasswordChar = '*';
            txtpass.Size = new System.Drawing.Size(224, 33);
            txtpass.TabIndex = 7;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Checked = true;
            chkRememberMe.CheckState = System.Windows.Forms.CheckState.Checked;
            chkRememberMe.Location = new System.Drawing.Point(544, 255);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new System.Drawing.Size(104, 19);
            chkRememberMe.TabIndex = 8;
            chkRememberMe.Text = "Remember Me\r\n";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(chkRememberMe);
            Controls.Add(txtpass);
            Controls.Add(txtusername);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmLogin";
            Load += frmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.CheckBox chkRememberMe;
    }
}