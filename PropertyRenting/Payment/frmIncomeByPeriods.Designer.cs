namespace PropertyRenting.Payment
{
    partial class frmIncomeByPeriods
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
            ctrlTotaIncomeByFilter1 = new controls.ctrlTotaIncomeByFilter();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ctrlTotaIncomeByFilter1
            // 
            ctrlTotaIncomeByFilter1.ClientId = -1;
            ctrlTotaIncomeByFilter1.EnabledFilterClientId = false;
            ctrlTotaIncomeByFilter1.Location = new System.Drawing.Point(27, 126);
            ctrlTotaIncomeByFilter1.Name = "ctrlTotaIncomeByFilter1";
            ctrlTotaIncomeByFilter1.Size = new System.Drawing.Size(688, 257);
            ctrlTotaIncomeByFilter1.TabIndex = 0;
            ctrlTotaIncomeByFilter1.OnClientSelected += ctrlTotaIncomeByFilter1_OnClientSelected;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(184, 37);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(369, 32);
            label1.TabIndex = 1;
            label1.Text = "Total Income History By Period";
            // 
            // frmIncomeByPeriods
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(727, 471);
            Controls.Add(label1);
            Controls.Add(ctrlTotaIncomeByFilter1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmIncomeByPeriods";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmIncomeByPeriods";
            Load += frmIncomeByPeriods_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private controls.ctrlTotaIncomeByFilter ctrlTotaIncomeByFilter1;
        private System.Windows.Forms.Label label1;
    }
}