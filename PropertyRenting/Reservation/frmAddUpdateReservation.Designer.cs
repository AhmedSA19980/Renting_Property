namespace PropertyRenting.Reservation
{
    partial class frmAddUpdateReservation
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
            dtpStartDate = new System.Windows.Forms.DateTimePicker();
            dtpExpDate = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            lblPropertyName = new System.Windows.Forms.Label();
            lblClientName = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lblPrice = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblBookId = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            btnReserve = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            linkl1 = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dtpStartDate.Location = new System.Drawing.Point(263, 236);
            dtpStartDate.MinDate = new System.DateTime(2025, 4, 26, 0, 0, 0, 0);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new System.Drawing.Size(200, 25);
            dtpStartDate.TabIndex = 0;
            // 
            // dtpExpDate
            // 
            dtpExpDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dtpExpDate.Location = new System.Drawing.Point(263, 286);
            dtpExpDate.MinDate = new System.DateTime(2025, 4, 26, 0, 0, 0, 0);
            dtpExpDate.Name = "dtpExpDate";
            dtpExpDate.Size = new System.Drawing.Size(200, 25);
            dtpExpDate.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(131, 140);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(126, 21);
            label1.TabIndex = 2;
            label1.Text = "PropertyName:";
            // 
            // lblPropertyName
            // 
            lblPropertyName.AutoSize = true;
            lblPropertyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPropertyName.Location = new System.Drawing.Point(252, 140);
            lblPropertyName.Name = "lblPropertyName";
            lblPropertyName.Size = new System.Drawing.Size(24, 21);
            lblPropertyName.TabIndex = 3;
            lblPropertyName.Text = "??";
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblClientName.Location = new System.Drawing.Point(252, 188);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new System.Drawing.Size(24, 21);
            lblClientName.TabIndex = 5;
            lblClientName.Text = "??";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(131, 188);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(105, 21);
            label4.TabIndex = 4;
            label4.Text = "ClientName:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPrice.Location = new System.Drawing.Point(509, 188);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(24, 21);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "??";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(447, 188);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 21);
            label3.TabIndex = 6;
            label3.Text = "Price:";
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblBookId.Location = new System.Drawing.Point(252, 101);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new System.Drawing.Size(24, 21);
            lblBookId.TabIndex = 9;
            lblBookId.Text = "??";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(131, 101);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(126, 21);
            label5.TabIndex = 8;
            label5.Text = "Reservation ID:";
            // 
            // btnReserve
            // 
            btnReserve.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnReserve.Location = new System.Drawing.Point(432, 338);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new System.Drawing.Size(101, 30);
            btnReserve.TabIndex = 10;
            btnReserve.Text = "Reserve";
            btnReserve.UseVisualStyleBackColor = true;
            btnReserve.Click += btnReserve_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(135, 238);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(69, 21);
            label2.TabIndex = 11;
            label2.Text = "St Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(135, 288);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 21);
            label6.TabIndex = 12;
            label6.Text = "Ex Date:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.White;
            label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.ForeColor = System.Drawing.Color.Teal;
            label7.Location = new System.Drawing.Point(208, 23);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(242, 32);
            label7.TabIndex = 13;
            label7.Text = "Make A Reservation";
            // 
            // linkl1
            // 
            linkl1.AutoSize = true;
            linkl1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            linkl1.Location = new System.Drawing.Point(447, 133);
            linkl1.Name = "linkl1";
            linkl1.Size = new System.Drawing.Size(31, 30);
            linkl1.TabIndex = 14;
            linkl1.TabStop = true;
            linkl1.Text = "??";
            linkl1.VisitedLinkColor = System.Drawing.Color.Red;
            linkl1.LinkClicked += linkl1_LinkClicked;
            // 
            // frmAddUpdateReservation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(662, 450);
            Controls.Add(linkl1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(btnReserve);
            Controls.Add(lblBookId);
            Controls.Add(label5);
            Controls.Add(lblPrice);
            Controls.Add(label3);
            Controls.Add(lblClientName);
            Controls.Add(label4);
            Controls.Add(lblPropertyName);
            Controls.Add(label1);
            Controls.Add(dtpExpDate);
            Controls.Add(dtpStartDate);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmAddUpdateReservation";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmAddUpdateReservation";
            Load += frmAddUpdateReservation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPropertyName;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkl1;
    }
}