namespace PropertyRenting.Property.controls
{
    partial class ctrlPropertyCard
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
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lblName = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lblPrice = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblIdName = new System.Windows.Forms.Label();
            lblID = new System.Windows.Forms.Label();
            lblCity2 = new System.Windows.Forms.Label();
            label = new System.Windows.Forms.Label();
            lblView = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(236, 146);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblName.Location = new System.Drawing.Point(70, 174);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(22, 15);
            lblName.TabIndex = 1;
            lblName.Text = "???";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(21, 204);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 15);
            label2.TabIndex = 2;
            label2.Text = "Price";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblPrice.Location = new System.Drawing.Point(62, 204);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(22, 15);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "???";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(21, 174);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // lblIdName
            // 
            lblIdName.AutoSize = true;
            lblIdName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblIdName.Location = new System.Drawing.Point(21, 152);
            lblIdName.Name = "lblIdName";
            lblIdName.Size = new System.Drawing.Size(23, 15);
            lblIdName.TabIndex = 6;
            lblIdName.Text = "ID:";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblID.Location = new System.Drawing.Point(50, 152);
            lblID.Name = "lblID";
            lblID.Size = new System.Drawing.Size(22, 15);
            lblID.TabIndex = 5;
            lblID.Text = "???";
            // 
            // lblCity2
            // 
            lblCity2.AutoSize = true;
            lblCity2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCity2.Location = new System.Drawing.Point(62, 231);
            lblCity2.Name = "lblCity2";
            lblCity2.Size = new System.Drawing.Size(22, 15);
            lblCity2.TabIndex = 8;
            lblCity2.Text = "???";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label.Location = new System.Drawing.Point(21, 231);
            label.Name = "label";
            label.Size = new System.Drawing.Size(31, 15);
            label.TabIndex = 7;
            label.Text = "City:";
            // 
            // lblView
            // 
            lblView.AutoSize = true;
            lblView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblView.Location = new System.Drawing.Point(183, 231);
            lblView.Name = "lblView";
            lblView.Size = new System.Drawing.Size(35, 15);
            lblView.TabIndex = 9;
            lblView.Text = "View";
            lblView.Click += lblView_Click;
            // 
            // ctrlPropertyCard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.HighlightText;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(lblView);
            Controls.Add(lblCity2);
            Controls.Add(label);
            Controls.Add(lblIdName);
            Controls.Add(lblID);
            Controls.Add(label1);
            Controls.Add(lblPrice);
            Controls.Add(label2);
            Controls.Add(lblName);
            Controls.Add(pictureBox1);
            Name = "ctrlPropertyCard";
            Size = new System.Drawing.Size(242, 265);
            Load += ctrlPropertyCard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIdName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCity2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblView;
    }
}
