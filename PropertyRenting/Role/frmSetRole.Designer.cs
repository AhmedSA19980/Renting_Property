namespace PropertyRenting.Role
{
    partial class frmSetRole
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
            label1 = new System.Windows.Forms.Label();
            txtReport = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            ctrlUserWithFilter1 = new User.controls.ctrlUserWithFilter();
            label3 = new System.Windows.Forms.Label();
            CBRole = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(554, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(152, 32);
            label1.TabIndex = 0;
            label1.Text = "Role Setting";
            // 
            // txtReport
            // 
            txtReport.Location = new System.Drawing.Point(857, 380);
            txtReport.Multiline = true;
            txtReport.Name = "txtReport";
            txtReport.Size = new System.Drawing.Size(271, 117);
            txtReport.TabIndex = 1;
            txtReport.Validating += txtReport_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(773, 378);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 21);
            label2.TabIndex = 2;
            label2.Text = "Report\r\n";
            // 
            // ctrlUserWithFilter1
            // 
            ctrlUserWithFilter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            ctrlUserWithFilter1.Location = new System.Drawing.Point(0, 103);
            ctrlUserWithFilter1.Name = "ctrlUserWithFilter1";
            ctrlUserWithFilter1.PersonId = -1;
            ctrlUserWithFilter1.Size = new System.Drawing.Size(766, 708);
            ctrlUserWithFilter1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(790, 298);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 21);
            label3.TabIndex = 4;
            label3.Text = "Role";
            // 
            // CBRole
            // 
            CBRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CBRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            CBRole.FormattingEnabled = true;
            CBRole.Items.AddRange(new object[] { "Admin", "Provider", "Customer", "Admin_Provider", "Accountant", "Customer Support Agent", "Moderator / Trust & Safety" });
            CBRole.Location = new System.Drawing.Point(857, 296);
            CBRole.Name = "CBRole";
            CBRole.Size = new System.Drawing.Size(165, 29);
            CBRole.TabIndex = 5;
            CBRole.SelectedIndexChanged += CBRole_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button1.Location = new System.Drawing.Point(993, 531);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(135, 40);
            button1.TabIndex = 6;
            button1.Text = "Set";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SetRole_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmSetRole
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1208, 932);
            Controls.Add(button1);
            Controls.Add(CBRole);
            Controls.Add(label3);
            Controls.Add(ctrlUserWithFilter1);
            Controls.Add(label2);
            Controls.Add(txtReport);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmSetRole";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmSetRole";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Label label2;
        private User.controls.ctrlUserWithFilter ctrlUserWithFilter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBRole;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}