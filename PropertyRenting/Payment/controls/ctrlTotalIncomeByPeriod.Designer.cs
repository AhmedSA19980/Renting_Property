namespace PropertyRenting.Payment.controls
{
    partial class ctrlTotalIncomeByPeriod
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lblNet = new System.Windows.Forms.Label();
            lblTotalIncome = new System.Windows.Forms.Label();
            lblFee = new System.Windows.Forms.Label();
            lblTax = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(64, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(113, 21);
            label1.TabIndex = 0;
            label1.Text = "Total Income:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(278, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 21);
            label2.TabIndex = 1;
            label2.Text = "Fee:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(414, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(40, 21);
            label3.TabIndex = 2;
            label3.Text = "Tax:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(64, 72);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 21);
            label4.TabIndex = 3;
            label4.Text = "Net:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTax);
            groupBox1.Controls.Add(lblFee);
            groupBox1.Controls.Add(lblTotalIncome);
            groupBox1.Controls.Add(lblNet);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(3, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(553, 101);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "TotalIncome";
            // 
            // lblNet
            // 
            lblNet.AutoSize = true;
            lblNet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblNet.Location = new System.Drawing.Point(112, 72);
            lblNet.Name = "lblNet";
            lblNet.Size = new System.Drawing.Size(31, 21);
            lblNet.TabIndex = 4;
            lblNet.Text = "???";
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTotalIncome.Location = new System.Drawing.Point(183, 19);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new System.Drawing.Size(31, 21);
            lblTotalIncome.TabIndex = 5;
            lblTotalIncome.Text = "???";
            // 
            // lblFee
            // 
            lblFee.AutoSize = true;
            lblFee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblFee.Location = new System.Drawing.Point(324, 19);
            lblFee.Name = "lblFee";
            lblFee.Size = new System.Drawing.Size(31, 21);
            lblFee.TabIndex = 6;
            lblFee.Text = "???";
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTax.Location = new System.Drawing.Point(470, 19);
            lblTax.Name = "lblTax";
            lblTax.Size = new System.Drawing.Size(31, 21);
            lblTax.TabIndex = 7;
            lblTax.Text = "???";
            // 
            // ctrlTotalIncomeByPeriod
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ctrlTotalIncomeByPeriod";
            Size = new System.Drawing.Size(561, 127);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblNet;
    }
}
