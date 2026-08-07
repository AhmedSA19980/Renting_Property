namespace PropertyRenting.Payment
{
    partial class frmEarnings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEarnings));
            lblTotalRecords = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            txtFilterValue = new System.Windows.Forms.TextBox();
            dgvEarnings = new System.Windows.Forms.DataGridView();
            CMSEarnings = new System.Windows.Forms.ContextMenuStrip(components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            billToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            incomesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvEarnings).BeginInit();
            CMSEarnings.SuspendLayout();
            SuspendLayout();
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new System.Drawing.Point(184, 634);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new System.Drawing.Size(17, 15);
            lblTotalRecords.TabIndex = 28;
            lblTotalRecords.Text = "??";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(106, 634);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 27;
            label1.Text = "Total Record\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(604, 29);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(180, 40);
            label3.TabIndex = 26;
            label3.Text = "My Earnings";
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Property ID", "Country Name", "Payment Status", "Booking ID" });
            cbFilterBy.Location = new System.Drawing.Point(106, 263);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(137, 29);
            cbFilterBy.TabIndex = 25;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(269, 263);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(190, 29);
            txtFilterValue.TabIndex = 24;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += TextEarning_KeyPress;
            // 
            // dgvEarnings
            // 
            dgvEarnings.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dgvEarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEarnings.ContextMenuStrip = CMSEarnings;
            dgvEarnings.Location = new System.Drawing.Point(106, 298);
            dgvEarnings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvEarnings.Name = "dgvEarnings";
            dgvEarnings.Size = new System.Drawing.Size(1182, 318);
            dgvEarnings.TabIndex = 23;
            // 
            // CMSEarnings
            // 
            CMSEarnings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            CMSEarnings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showToolStripMenuItem, billToolStripMenuItem, incomesToolStripMenuItem });
            CMSEarnings.Name = "CMSEarnings";
            CMSEarnings.Size = new System.Drawing.Size(161, 118);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("showToolStripMenuItem.Image");
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new System.Drawing.Size(160, 38);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // billToolStripMenuItem
            // 
            billToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("billToolStripMenuItem.Image");
            billToolStripMenuItem.Name = "billToolStripMenuItem";
            billToolStripMenuItem.Size = new System.Drawing.Size(160, 38);
            billToolStripMenuItem.Text = "Bill";
            billToolStripMenuItem.Click += billToolStripMenuItem_Click;
            // 
            // incomesToolStripMenuItem
            // 
            incomesToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("incomesToolStripMenuItem.Image");
            incomesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            incomesToolStripMenuItem.Name = "incomesToolStripMenuItem";
            incomesToolStripMenuItem.Size = new System.Drawing.Size(160, 38);
            incomesToolStripMenuItem.Text = "Incomes";
            incomesToolStripMenuItem.Click += incomesToolStripMenuItem_Click;
            // 
            // frmEarnings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size(1394, 678);
            Controls.Add(lblTotalRecords);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvEarnings);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmEarnings";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmEarnings";
            Load += frmEarnings_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEarnings).EndInit();
            CMSEarnings.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvEarnings;
        private System.Windows.Forms.ContextMenuStrip CMSEarnings;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomesToolStripMenuItem;
    }
}