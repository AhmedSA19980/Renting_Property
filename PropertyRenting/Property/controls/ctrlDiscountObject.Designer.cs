namespace PropertyRenting.Property.controls
{
    partial class ctrlDiscountObject
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
            components = new System.ComponentModel.Container();
            label = new System.Windows.Forms.Label();
            lblPropertyID = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblDiscountID = new System.Windows.Forms.Label();
            dtpStartDate = new System.Windows.Forms.DateTimePicker();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            dtpEndDate = new System.Windows.Forms.DateTimePicker();
            label7 = new System.Windows.Forms.Label();
            txtPercentOff = new System.Windows.Forms.TextBox();
            lblTitle = new System.Windows.Forms.Label();
            btnCreate = new System.Windows.Forms.Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label.Location = new System.Drawing.Point(99, 180);
            label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label.Name = "label";
            label.Size = new System.Drawing.Size(100, 20);
            label.TabIndex = 0;
            label.Text = "PropertyID:";
            // 
            // lblPropertyID
            // 
            lblPropertyID.AutoSize = true;
            lblPropertyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            lblPropertyID.Location = new System.Drawing.Point(217, 180);
            lblPropertyID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPropertyID.Name = "lblPropertyID";
            lblPropertyID.Size = new System.Drawing.Size(39, 20);
            lblPropertyID.TabIndex = 1;
            lblPropertyID.Text = "???";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(99, 122);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 20);
            label3.TabIndex = 2;
            label3.Text = "DiscountID:";
            // 
            // lblDiscountID
            // 
            lblDiscountID.AutoSize = true;
            lblDiscountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            lblDiscountID.Location = new System.Drawing.Point(217, 122);
            lblDiscountID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDiscountID.Name = "lblDiscountID";
            lblDiscountID.Size = new System.Drawing.Size(39, 20);
            lblDiscountID.TabIndex = 3;
            lblDiscountID.Text = "???";
            
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new System.Drawing.Point(222, 240);
            dtpStartDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpStartDate.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
            dtpStartDate.MinDate = new System.DateTime(2024, 11, 20, 0, 0, 0, 0);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new System.Drawing.Size(233, 23);
            dtpStartDate.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(99, 240);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(93, 20);
            label5.TabIndex = 5;
            label5.Text = "StartDate:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(99, 291);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(85, 20);
            label6.TabIndex = 7;
            label6.Text = "EndDate:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new System.Drawing.Point(222, 291);
            dtpEndDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpEndDate.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
            dtpEndDate.MinDate = new System.DateTime(2024, 11, 20, 0, 0, 0, 0);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new System.Drawing.Size(231, 23);
            dtpEndDate.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(310, 122);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(139, 20);
            label7.TabIndex = 8;
            label7.Text = "Set Precent Off:";
            // 
            // txtPercentOff
            // 
            txtPercentOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtPercentOff.Location = new System.Drawing.Point(461, 122);
            txtPercentOff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtPercentOff.Name = "txtPercentOff";
            txtPercentOff.Size = new System.Drawing.Size(139, 24);
            txtPercentOff.TabIndex = 9;
            txtPercentOff.KeyPress += txtPercentOff_KeyPress;
            txtPercentOff.Validating += txtPercentOff_Validating;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.Location = new System.Drawing.Point(128, 25);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(279, 39);
            lblTitle.TabIndex = 29;
            lblTitle.Text = "Make A Discount";
            // 
            // btnCreate
            // 
            btnCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnCreate.Location = new System.Drawing.Point(250, 343);
            btnCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(144, 39);
            btnCreate.TabIndex = 30;
            btnCreate.Text = "Create\r\n";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreateUpdate_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlDiscountObject
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btnCreate);
            Controls.Add(lblTitle);
            Controls.Add(txtPercentOff);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dtpEndDate);
            Controls.Add(label5);
            Controls.Add(dtpStartDate);
            Controls.Add(lblDiscountID);
            Controls.Add(label3);
            Controls.Add(lblPropertyID);
            Controls.Add(label);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ctrlDiscountObject";
            Size = new System.Drawing.Size(624, 432);
            Load += ctrlDiscountObject_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblPropertyID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDiscountID;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPercentOff;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCreate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
