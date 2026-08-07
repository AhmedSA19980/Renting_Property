namespace PropertyRenting.Property.Discount
{
    partial class CreateUpdateAnOffer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUpdateAnOffer));
            dgvDiscounts = new System.Windows.Forms.DataGridView();
            cmMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ctrlDiscountObject4 = new controls.ctrlDiscountObject();
            label1 = new System.Windows.Forms.Label();
            lblTotalRecords = new System.Windows.Forms.Label();
            txtFilterValue = new System.Windows.Forms.TextBox();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cbIsCompleted = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDiscounts).BeginInit();
            cmMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDiscounts
            // 
            dgvDiscounts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiscounts.ContextMenuStrip = cmMenuStrip;
            dgvDiscounts.Location = new System.Drawing.Point(40, 485);
            dgvDiscounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvDiscounts.Name = "dgvDiscounts";
            dgvDiscounts.Size = new System.Drawing.Size(1182, 318);
            dgvDiscounts.TabIndex = 1;
            // 
            // cmMenuStrip
            // 
            cmMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cmMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showToolStripMenuItem, updateToolStripMenuItem, delToolStripMenuItem });
            cmMenuStrip.Name = "cmMenuStrip";
            cmMenuStrip.Size = new System.Drawing.Size(181, 104);
            cmMenuStrip.Opening += cmMenuStrip_Opening;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("showToolStripMenuItem.Image");
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("updateToolStripMenuItem.Image");
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // delToolStripMenuItem
            // 
            delToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("delToolStripMenuItem.Image");
            delToolStripMenuItem.Name = "delToolStripMenuItem";
            delToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            delToolStripMenuItem.Text = "Del";
            delToolStripMenuItem.Click += delToolStripMenuItem_Click;
            // 
            // ctrlDiscountObject4
            // 
            ctrlDiscountObject4.AllowDrop = true;
            ctrlDiscountObject4.DiscountID = -1;
            ctrlDiscountObject4.Location = new System.Drawing.Point(354, 12);
            ctrlDiscountObject4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ctrlDiscountObject4.Name = "ctrlDiscountObject4";
            ctrlDiscountObject4.PercentOFF = "";
            ctrlDiscountObject4.PropertyID = -1;
            ctrlDiscountObject4.SetMode = controls.ctrlDiscountObject.enMode.AddNew;
            ctrlDiscountObject4.Size = new System.Drawing.Size(624, 432);
            ctrlDiscountObject4.TabIndex = 2;
            ctrlDiscountObject4.DataAddOrUpdate += ctrlDiscountObject4_DataAddOrUpdate;
            ctrlDiscountObject4.Load += ctrlDiscountObject4_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(100, 806);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Total Record\r\n";
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new System.Drawing.Point(178, 806);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new System.Drawing.Size(17, 15);
            lblTotalRecords.TabIndex = 4;
            lblTotalRecords.Text = "??";
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(255, 450);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(190, 29);
            txtFilterValue.TabIndex = 5;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += CreateUpdateAnOffer_KeyPress;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "DiscountID", "Discount Percentage", "IsCompeleted" });
            cbFilterBy.Location = new System.Drawing.Point(112, 450);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(137, 29);
            cbFilterBy.TabIndex = 6;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(40, 453);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 21);
            label2.TabIndex = 7;
            label2.Text = "Filter By";
            // 
            // cbIsCompleted
            // 
            cbIsCompleted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbIsCompleted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbIsCompleted.FormattingEnabled = true;
            cbIsCompleted.Items.AddRange(new object[] { "All", "Yes", "No" });
            cbIsCompleted.Location = new System.Drawing.Point(255, 450);
            cbIsCompleted.Name = "cbIsCompleted";
            cbIsCompleted.Size = new System.Drawing.Size(137, 29);
            cbIsCompleted.TabIndex = 8;
            cbIsCompleted.SelectedIndexChanged += cbFilterByComplete_SelectedIndexChanged;
            // 
            // CreateUpdateAnOffer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.HighlightText;
            ClientSize = new System.Drawing.Size(1249, 879);
            Controls.Add(cbIsCompleted);
            Controls.Add(label2);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(lblTotalRecords);
            Controls.Add(label1);
            Controls.Add(ctrlDiscountObject4);
            Controls.Add(dgvDiscounts);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CreateUpdateAnOffer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "7";
            Load += CreateUpdateAnOffer_Load;
            KeyPress += CreateUpdateAnOffer_KeyPress;
            ((System.ComponentModel.ISupportInitialize)dgvDiscounts).EndInit();
            cmMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private controls.ctrlDiscountObject ctrlDiscountObject1;
        private controls.ctrlDiscountObject ctrlDiscountObject2;
        private controls.ctrlDiscountObject ctrlDiscountObject3;
        private System.Windows.Forms.DataGridView dgvDiscounts;
        private controls.ctrlDiscountObject ctrlDiscountObject4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbIsCompleted;
        private System.Windows.Forms.ContextMenuStrip cmMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
    }
}