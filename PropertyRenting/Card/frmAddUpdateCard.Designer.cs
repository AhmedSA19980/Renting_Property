namespace PropertyRenting.Card
{
    partial class frmAddUpdateCard
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtCardno = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            lblClientID = new System.Windows.Forms.Label();
            lblCardID = new System.Windows.Forms.Label();
            DTPEndD = new System.Windows.Forms.DateTimePicker();
            DTPEStablishedD = new System.Windows.Forms.DateTimePicker();
            txtCardName = new System.Windows.Forms.TextBox();
            txtCvv = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCardno);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblClientID);
            groupBox1.Controls.Add(lblCardID);
            groupBox1.Controls.Add(DTPEndD);
            groupBox1.Controls.Add(DTPEStablishedD);
            groupBox1.Controls.Add(txtCardName);
            groupBox1.Controls.Add(txtCvv);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(156, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(571, 325);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Card";
            // 
            // txtCardno
            // 
            txtCardno.Location = new System.Drawing.Point(120, 159);
            txtCardno.Name = "txtCardno";
            txtCardno.Size = new System.Drawing.Size(239, 23);
            txtCardno.TabIndex = 14;
            txtCardno.Validating += txtCardno_Validating;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(31, 160);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(54, 17);
            label7.TabIndex = 13;
            label7.Text = "CardNo";
            // 
            // lblClientID
            // 
            lblClientID.AutoSize = true;
            lblClientID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblClientID.Location = new System.Drawing.Point(342, 66);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new System.Drawing.Size(20, 17);
            lblClientID.TabIndex = 12;
            lblClientID.Text = "??";
            // 
            // lblCardID
            // 
            lblCardID.AutoSize = true;
            lblCardID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCardID.Location = new System.Drawing.Point(68, 66);
            lblCardID.Name = "lblCardID";
            lblCardID.Size = new System.Drawing.Size(20, 17);
            lblCardID.TabIndex = 11;
            lblCardID.Text = "??";
            // 
            // DTPEndD
            // 
            DTPEndD.Location = new System.Drawing.Point(144, 261);
            DTPEndD.MinDate = new System.DateTime(2024, 12, 25, 0, 0, 0, 0);
            DTPEndD.Name = "DTPEndD";
            DTPEndD.Size = new System.Drawing.Size(176, 23);
            DTPEndD.TabIndex = 10;
            DTPEndD.Validating += DTPEndD_Validating;
            // 
            // DTPEStablishedD
            // 
            DTPEStablishedD.Location = new System.Drawing.Point(144, 206);
            DTPEStablishedD.MaxDate = new System.DateTime(2024, 12, 25, 0, 0, 0, 0);
            DTPEStablishedD.MinDate = new System.DateTime(2019, 12, 25, 23, 59, 59, 999);
            DTPEStablishedD.Name = "DTPEStablishedD";
            DTPEStablishedD.Size = new System.Drawing.Size(176, 23);
            DTPEStablishedD.TabIndex = 9;
            DTPEStablishedD.Value = new System.DateTime(2024, 12, 25, 0, 0, 0, 0);
            // 
            // txtCardName
            // 
            txtCardName.Location = new System.Drawing.Point(120, 116);
            txtCardName.Name = "txtCardName";
            txtCardName.Size = new System.Drawing.Size(239, 23);
            txtCardName.TabIndex = 8;
            txtCardName.Validating += txtCardName_Validating;
            // 
            // txtCvv
            // 
            txtCvv.Location = new System.Drawing.Point(374, 206);
            txtCvv.Name = "txtCvv";
            txtCvv.Size = new System.Drawing.Size(120, 23);
            txtCvv.TabIndex = 6;
            txtCvv.KeyPress += txtCvv_KeyPress;
            txtCvv.Validating += txtCvv_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(274, 66);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(62, 17);
            label6.TabIndex = 5;
            label6.Text = "Client ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(334, 207);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(34, 17);
            label5.TabIndex = 4;
            label5.Text = "CVV";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(31, 261);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 17);
            label4.TabIndex = 3;
            label4.Text = "ExpiryDate";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(31, 207);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(107, 17);
            label3.TabIndex = 2;
            label3.Text = "EstablishedDate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(31, 66);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(22, 17);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(31, 117);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 17);
            label1.TabIndex = 0;
            label1.Text = "CardName";
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(276, 393);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(401, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateCard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmAddUpdateCard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Card";
            Load += Card_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPEndD;
        private System.Windows.Forms.DateTimePicker DTPEStablishedD;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.TextBox txtCvv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label lblCardID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtCardno;
        private System.Windows.Forms.Label label7;
    }
}