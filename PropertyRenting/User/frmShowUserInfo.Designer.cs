namespace PropertyRenting.User
{
    partial class frmShowUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowUserInfo));
            ctrlUserCard1 = new controls.ctrlUserCard();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ctrlUserCard1
            // 
            ctrlUserCard1.clientId = 0;
            ctrlUserCard1.Location = new System.Drawing.Point(22, 109);
            ctrlUserCard1.Name = "ctrlUserCard1";
            ctrlUserCard1.Size = new System.Drawing.Size(588, 555);
            ctrlUserCard1.TabIndex = 0;
            ctrlUserCard1.Load += ctrlUserCard1_Load;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
            button1.Location = new System.Drawing.Point(568, 143);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(29, 36);
            button1.TabIndex = 49;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Location = new System.Drawing.Point(199, 45);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(257, 32);
            label1.TabIndex = 50;
            label1.Text = "Personal Information";
            // 
            // frmShowUserInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(642, 774);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(ctrlUserCard1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmShowUserInfo";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmShowUserInfo";
            Load += frmShowUserInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private controls.ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}