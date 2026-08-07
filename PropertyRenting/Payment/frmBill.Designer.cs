namespace PropertyRenting.Payment
{
    partial class frmBill
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
            ctrlBill1 = new controls.ctrlBill();
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ctrlBill1
            // 
            ctrlBill1.Location = new System.Drawing.Point(49, 60);
            ctrlBill1.Name = "ctrlBill1";
            ctrlBill1.Size = new System.Drawing.Size(427, 517);
            ctrlBill1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(161, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(135, 30);
            label1.TabIndex = 1;
            label1.Text = "Payment Bill";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(401, 607);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "close\r\n";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmBill
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(520, 642);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(ctrlBill1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmBill";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmBill";
            Load += frmBill_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private controls.ctrlBill ctrlBill1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}