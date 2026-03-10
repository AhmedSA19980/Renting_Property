namespace PropertyRenting.Property.Discount
{
    partial class frmShowOffer
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
            button2 = new System.Windows.Forms.Button();
            ctrlShowDiscount1 = new controls.ctrlShowDiscount();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.Location = new System.Drawing.Point(145, 9);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(306, 39);
            lblTitle.TabIndex = 29;
            lblTitle.Text = "Show Offer Details";
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button2.Location = new System.Drawing.Point(237, 322);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(98, 33);
            button2.TabIndex = 32;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ctrlShowDiscount1
            // 
            ctrlShowDiscount1.Location = new System.Drawing.Point(82, 67);
            ctrlShowDiscount1.Name = "ctrlShowDiscount1";
            ctrlShowDiscount1.Size = new System.Drawing.Size(489, 235);
            ctrlShowDiscount1.TabIndex = 33;
            // 
            // frmShowOffer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(591, 367);
            Controls.Add(ctrlShowDiscount1);
            Controls.Add(button2);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmShowOffer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmShowOffer";
            Load += frmShowOffer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private controls.ctrlShowDiscount showDiscount1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button2;
        private controls.ctrlShowDiscount ctrlShowDiscount1;
    }
}