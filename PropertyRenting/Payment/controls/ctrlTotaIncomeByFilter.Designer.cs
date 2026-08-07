namespace PropertyRenting.Payment.controls
{
    partial class ctrlTotaIncomeByFilter
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
            dtpExDate = new System.Windows.Forms.DateTimePicker();
            dtpStDate = new System.Windows.Forms.DateTimePicker();
            button1 = new System.Windows.Forms.Button();
            ctrlTotalIncomeByPeriod1 = new ctrlTotalIncomeByPeriod();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtbox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(31, 56);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 10;
            label1.Text = "ClientId:";
            // 
            // dtpExDate
            // 
            dtpExDate.Location = new System.Drawing.Point(346, 91);
            dtpExDate.Name = "dtpExDate";
            dtpExDate.Size = new System.Drawing.Size(197, 23);
            dtpExDate.TabIndex = 9;
            dtpExDate.Value = new System.DateTime(2025, 12, 25, 0, 0, 0, 0);
            // 
            // dtpStDate
            // 
            dtpStDate.Location = new System.Drawing.Point(346, 48);
            dtpStDate.Name = "dtpStDate";
            dtpStDate.Size = new System.Drawing.Size(197, 23);
            dtpStDate.TabIndex = 8;
            dtpStDate.Value = new System.DateTime(2025, 12, 25, 0, 0, 0, 0);
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button1.Location = new System.Drawing.Point(586, 54);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(87, 33);
            button1.TabIndex = 7;
            button1.Text = "Show";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ctrlTotalIncomeByPeriod1
            // 
            ctrlTotalIncomeByPeriod1.Location = new System.Drawing.Point(75, 120);
            ctrlTotalIncomeByPeriod1.Name = "ctrlTotalIncomeByPeriod1";
            ctrlTotalIncomeByPeriod1.Size = new System.Drawing.Size(561, 127);
            ctrlTotalIncomeByPeriod1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(240, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 12;
            label2.Text = "Start Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(240, 97);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 15);
            label3.TabIndex = 13;
            label3.Text = "Expired Date:";
            // 
            // txtbox
            // 
            txtbox.Location = new System.Drawing.Point(90, 51);
            txtbox.Name = "txtbox";
            txtbox.Size = new System.Drawing.Size(144, 23);
            txtbox.TabIndex = 14;
            // 
            // ctrlTotaIncomeByFilter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpExDate);
            Controls.Add(dtpStDate);
            Controls.Add(button1);
            Controls.Add(ctrlTotalIncomeByPeriod1);
            Name = "ctrlTotaIncomeByFilter";
            Size = new System.Drawing.Size(709, 257);
            Load += ctrlTotaIncomeByFilter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpExDate;
        private System.Windows.Forms.DateTimePicker dtpStDate;
        private System.Windows.Forms.Button button1;
        private ctrlTotalIncomeByPeriod ctrlTotalIncomeByPeriod1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox;
    }
}
