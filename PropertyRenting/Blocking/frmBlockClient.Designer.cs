namespace PropertyRenting.Blocking
{
    partial class frmBlockClient
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
            btnBlock = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ctrlUserWithFilter1
            // 
            ctrlUserWithFilter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            ctrlUserWithFilter1.Location = new System.Drawing.Point(-1, 2);
            ctrlUserWithFilter1.Name = "ctrlUserWithFilter1";
            ctrlUserWithFilter1.PersonId = -1;
            ctrlUserWithFilter1.Size = new System.Drawing.Size(812, 817);
            ctrlUserWithFilter1.TabIndex = 0;
            // 
            // btnBlock
            // 
            btnBlock.Location = new System.Drawing.Point(696, 787);
            btnBlock.Name = "btnBlock";
            btnBlock.Size = new System.Drawing.Size(115, 32);
            btnBlock.TabIndex = 1;
            btnBlock.Text = "Block";
            btnBlock.UseVisualStyleBackColor = true;
            btnBlock.Click += btnBlock_Click;
            // 
            // frmBlockClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(822, 830);
            Controls.Add(btnBlock);
            Controls.Add(ctrlUserWithFilter1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmBlockClient";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmBlockClient";
            ResumeLayout(false);
        }

        #endregion

        private User.controls.ctrlUserWithFilter ctrlUserWithFilter1;
        private System.Windows.Forms.Button btnBlock;
    }
}