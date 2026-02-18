namespace PropertyRenting.User
{
    partial class frmChangePassword
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
            components = new System.ComponentModel.Container();
            ctrlUserCard1 = new controls.ctrlUserCard();
            txtNewPass = new System.Windows.Forms.TextBox();
            txtRepeatPass = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // ctrlUserCard1
            // 
            ctrlUserCard1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            ctrlUserCard1.clientId = 0;
            ctrlUserCard1.Location = new System.Drawing.Point(12, 44);
            ctrlUserCard1.Name = "ctrlUserCard1";
            ctrlUserCard1.Size = new System.Drawing.Size(599, 565);
            ctrlUserCard1.TabIndex = 0;
            // 
            // txtNewPass
            // 
            txtNewPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            txtNewPass.Location = new System.Drawing.Point(218, 613);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new System.Drawing.Size(177, 23);
            txtNewPass.TabIndex = 3;
            txtNewPass.Validating += NewPass_Validating;
            // 
            // txtRepeatPass
            // 
            txtRepeatPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            txtRepeatPass.Location = new System.Drawing.Point(218, 663);
            txtRepeatPass.Name = "txtRepeatPass";
            txtRepeatPass.Size = new System.Drawing.Size(177, 23);
            txtRepeatPass.TabIndex = 4;
            txtRepeatPass.Validating += txtRepeatPass_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(87, 615);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(125, 21);
            label2.TabIndex = 6;
            label2.Text = "New Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(75, 663);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(143, 21);
            label3.TabIndex = 7;
            label3.Text = "Repeat Password:";
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button1.Location = new System.Drawing.Point(451, 655);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(116, 28);
            button1.TabIndex = 8;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.Color.SteelBlue;
            label4.Location = new System.Drawing.Point(207, 9);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(214, 32);
            label4.TabIndex = 9;
            label4.Text = "Change Password";
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(623, 693);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtRepeatPass);
            Controls.Add(txtNewPass);
            Controls.Add(ctrlUserCard1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmChangePassword";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmChangePassword";
            Load += frmChangePassword_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private controls.ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtRepeatPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
    }
}