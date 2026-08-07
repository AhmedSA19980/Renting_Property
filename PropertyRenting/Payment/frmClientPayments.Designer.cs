namespace PropertyRenting.Payment
{
    partial class frmClientPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientPayments));
            label3 = new System.Windows.Forms.Label();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            txtFilterValue = new System.Windows.Forms.TextBox();
            dgvPayments = new System.Windows.Forms.DataGridView();
            cmMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblTotalRecords = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            cmMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(821, 66);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(144, 40);
            label3.TabIndex = 20;
            label3.Text = "Payments";
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "ID", "startDate", "EndDate" });
            cbFilterBy.Location = new System.Drawing.Point(110, 393);
            cbFilterBy.Margin = new System.Windows.Forms.Padding(4);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(194, 29);
            cbFilterBy.TabIndex = 19;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(343, 393);
            txtFilterValue.Margin = new System.Windows.Forms.Padding(4);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(270, 29);
            txtFilterValue.TabIndex = 18;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += TextPropertyId_KeyPress;
            // 
            // dgvPayments
            // 
            dgvPayments.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.ContextMenuStrip = cmMenuStrip;
            dgvPayments.Location = new System.Drawing.Point(110, 442);
            dgvPayments.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.Size = new System.Drawing.Size(1689, 445);
            dgvPayments.TabIndex = 17;
            // 
            // cmMenuStrip
            // 
            cmMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cmMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showToolStripMenuItem });
            cmMenuStrip.Name = "cmMenuStrip";
            cmMenuStrip.Size = new System.Drawing.Size(139, 42);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("showToolStripMenuItem.Image");
            showToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new System.Drawing.Size(138, 38);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new System.Drawing.Point(221, 913);
            lblTotalRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new System.Drawing.Size(24, 21);
            lblTotalRecords.TabIndex = 22;
            lblTotalRecords.Text = "??";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(110, 913);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 21);
            label1.TabIndex = 21;
            label1.Text = "Total Record\r\n";
            // 
            // frmClientPayments
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1909, 998);
            Controls.Add(lblTotalRecords);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvPayments);
            Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmClientPayments";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ClientPayments";
            Load += ClientPayments_Load;
            KeyPress += TextPropertyId_KeyPress;
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            cmMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    }
}