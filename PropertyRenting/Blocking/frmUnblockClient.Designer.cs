namespace PropertyRenting.Blocking
{
    partial class frmUnblockClient
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
            ctrlUserWithFilter1 = new User.controls.ctrlUserWithFilter();
            btnunblock = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ctrlUserWithFilter1
            // 
            ctrlUserWithFilter1.Location = new System.Drawing.Point(56, 29);
            ctrlUserWithFilter1.Name = "ctrlUserWithFilter1";
            ctrlUserWithFilter1.PersonId = -1;
            ctrlUserWithFilter1.Size = new System.Drawing.Size(827, 842);
            ctrlUserWithFilter1.TabIndex = 0;
            // 
            // btnunblock
            // 
            btnunblock.Location = new System.Drawing.Point(767, 822);
            btnunblock.Name = "btnunblock";
            btnunblock.Size = new System.Drawing.Size(121, 31);
            btnunblock.TabIndex = 1;
            btnunblock.Text = "Unblock";
            btnunblock.UseVisualStyleBackColor = true;
            btnunblock.Click += btnunblock_Click;
            // 
            // frmUnblockClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(895, 864);
            Controls.Add(btnunblock);
            Controls.Add(ctrlUserWithFilter1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmUnblockClient";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmUnblockClient";
            ResumeLayout(false);
        }

        #endregion

        private User.controls.ctrlUserWithFilter ctrlUserWithFilter1;
        private System.Windows.Forms.Button btnunblock;
    }
}