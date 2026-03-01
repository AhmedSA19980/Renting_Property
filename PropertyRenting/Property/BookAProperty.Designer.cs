namespace PropertyRenting.Property
{
    partial class BookAProperty
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
            lblTitle = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            btnNxt = new System.Windows.Forms.Button();
            btnRight = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            lblCreateOffer = new System.Windows.Forms.Label();
            ctrlShowPropertyInfo1 = new controls.ctrlShowPropertyInfo();
            button1 = new System.Windows.Forms.Button();
            ctrlPropertyCard1 = new controls.ctrlPropertyCard();
            ctrlPropertyCard2 = new controls.ctrlPropertyCard();
            ctrlPropertyCard3 = new controls.ctrlPropertyCard();
            ctrlPropertyCard4 = new controls.ctrlPropertyCard();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.Location = new System.Drawing.Point(607, 31);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(269, 39);
            lblTitle.TabIndex = 28;
            lblTitle.Text = "Book A Property";
         
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(157, 87);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(1021, 358);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // btnNxt
            // 
            btnNxt.Location = new System.Drawing.Point(1186, 208);
            btnNxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNxt.Name = "btnNxt";
            btnNxt.Size = new System.Drawing.Size(26, 133);
            btnNxt.TabIndex = 30;
            btnNxt.Text = ">";
            btnNxt.UseVisualStyleBackColor = true;
            btnNxt.Click += btnNxt_Click;
            // 
            // btnRight
            // 
            btnRight.Location = new System.Drawing.Point(121, 195);
            btnRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRight.Name = "btnRight";
            btnRight.Size = new System.Drawing.Size(28, 137);
            btnRight.TabIndex = 31;
            btnRight.Text = "<";
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnPrev_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(194, 55);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 15);
            label1.TabIndex = 36;
            // 
            // lblCreateOffer
            // 
            lblCreateOffer.AutoSize = true;
            lblCreateOffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCreateOffer.ForeColor = System.Drawing.Color.OrangeRed;
            lblCreateOffer.Location = new System.Drawing.Point(1064, 465);
            lblCreateOffer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCreateOffer.Name = "lblCreateOffer";
            lblCreateOffer.Size = new System.Drawing.Size(114, 20);
            lblCreateOffer.TabIndex = 37;
            lblCreateOffer.Text = "Add An Offer";
            lblCreateOffer.Click += lblCreateOffer_Click;
            // 
            // ctrlShowPropertyInfo1
            // 
            ctrlShowPropertyInfo1.Location = new System.Drawing.Point(257, 465);
            ctrlShowPropertyInfo1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            ctrlShowPropertyInfo1.Name = "ctrlShowPropertyInfo1";
            ctrlShowPropertyInfo1.Size = new System.Drawing.Size(698, 432);
            ctrlShowPropertyInfo1.TabIndex = 32;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(1068, 509);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(110, 31);
            button1.TabIndex = 38;
            button1.Text = "Rent";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnRent_Click;
            // 
            // ctrlPropertyCard1
            // 
            ctrlPropertyCard1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            ctrlPropertyCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ctrlPropertyCard1.city = null;
            ctrlPropertyCard1.ID = 0;
            ctrlPropertyCard1.img = null;
            ctrlPropertyCard1.Location = new System.Drawing.Point(1259, 114);
            ctrlPropertyCard1.Name = "ctrlPropertyCard1";
            ctrlPropertyCard1.Price = new decimal(new int[] { 0, 0, 0, 0 });
            ctrlPropertyCard1.Size = new System.Drawing.Size(229, 267);
            ctrlPropertyCard1.TabIndex = 39;
            // 
            // ctrlPropertyCard2
            // 
            ctrlPropertyCard2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            ctrlPropertyCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ctrlPropertyCard2.city = null;
            ctrlPropertyCard2.ID = 0;
            ctrlPropertyCard2.img = null;
            ctrlPropertyCard2.Location = new System.Drawing.Point(1530, 114);
            ctrlPropertyCard2.Name = "ctrlPropertyCard2";
            ctrlPropertyCard2.Price = new decimal(new int[] { 0, 0, 0, 0 });
            ctrlPropertyCard2.Size = new System.Drawing.Size(220, 267);
            ctrlPropertyCard2.TabIndex = 40;
            // 
            // ctrlPropertyCard3
            // 
            ctrlPropertyCard3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            ctrlPropertyCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ctrlPropertyCard3.city = null;
            ctrlPropertyCard3.ID = 0;
            ctrlPropertyCard3.img = null;
            ctrlPropertyCard3.Location = new System.Drawing.Point(1260, 387);
            ctrlPropertyCard3.Name = "ctrlPropertyCard3";
            ctrlPropertyCard3.Price = new decimal(new int[] { 0, 0, 0, 0 });
            ctrlPropertyCard3.Size = new System.Drawing.Size(228, 266);
            ctrlPropertyCard3.TabIndex = 41;
            // 
            // ctrlPropertyCard4
            // 
            ctrlPropertyCard4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            ctrlPropertyCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ctrlPropertyCard4.city = null;
            ctrlPropertyCard4.ID = 0;
            ctrlPropertyCard4.img = null;
            ctrlPropertyCard4.Location = new System.Drawing.Point(1531, 387);
            ctrlPropertyCard4.Name = "ctrlPropertyCard4";
            ctrlPropertyCard4.Price = new decimal(new int[] { 0, 0, 0, 0 });
            ctrlPropertyCard4.Size = new System.Drawing.Size(219, 266);
            ctrlPropertyCard4.TabIndex = 42;
            // 
            // BookAProperty
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1848, 1061);
            Controls.Add(ctrlPropertyCard4);
            Controls.Add(ctrlPropertyCard3);
            Controls.Add(ctrlPropertyCard2);
            Controls.Add(ctrlPropertyCard1);
            Controls.Add(button1);
            Controls.Add(lblCreateOffer);
            Controls.Add(label1);
            Controls.Add(ctrlShowPropertyInfo1);
            Controls.Add(btnRight);
            Controls.Add(btnNxt);
            Controls.Add(pictureBox1);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "BookAProperty";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "BookAProperty";
            Load += BookAProperty_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNxt;
        private System.Windows.Forms.Button btnRight;
        private controls.ctrlShowPropertyInfo ctrlShowPropertyInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreateOffer;
        private System.Windows.Forms.Button button1;
        private controls.ctrlPropertyCard ctrlPropertyCard1;
        private controls.ctrlPropertyCard ctrlPropertyCard2;
        private controls.ctrlPropertyCard ctrlPropertyCard3;
        private controls.ctrlPropertyCard ctrlPropertyCard4;
    }
}