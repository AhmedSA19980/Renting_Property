namespace PropertyRenting.Payment
{
    partial class frmAllEarningsByProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllEarningsByProperty));
            lblTotalRecords = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            txtFilterValue = new System.Windows.Forms.TextBox();
            dgvEarningsByProperty = new System.Windows.Forms.DataGridView();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            showBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label2 = new System.Windows.Forms.Label();
            lblInCome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvEarningsByProperty).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new System.Drawing.Point(145, 647);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new System.Drawing.Size(17, 15);
            lblTotalRecords.TabIndex = 34;
            lblTotalRecords.Text = "??";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(67, 647);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 33;
            label1.Text = "Total Record\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(565, 42);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(343, 40);
            label3.TabIndex = 32;
            label3.Text = "My Earnings By Property";
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Start Date", "End Date", "Paid Date", "Booking ID" });
            cbFilterBy.Location = new System.Drawing.Point(67, 276);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(137, 29);
            cbFilterBy.TabIndex = 31;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(230, 276);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(190, 29);
            txtFilterValue.TabIndex = 30;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += TextPropertyId_KeyPress;
            // 
            // dgvEarningsByProperty
            // 
            dgvEarningsByProperty.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dgvEarningsByProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEarningsByProperty.ContextMenuStrip = contextMenuStrip1;
            dgvEarningsByProperty.Location = new System.Drawing.Point(67, 311);
            dgvEarningsByProperty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvEarningsByProperty.Name = "dgvEarningsByProperty";
            dgvEarningsByProperty.Size = new System.Drawing.Size(1182, 318);
            dgvEarningsByProperty.TabIndex = 29;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showBillToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(103, 30);
            // 
            // showBillToolStripMenuItem
            // 
            showBillToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            showBillToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("showBillToolStripMenuItem.Image");
            showBillToolStripMenuItem.Name = "showBillToolStripMenuItem";
            showBillToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            showBillToolStripMenuItem.Text = "Bill";
            showBillToolStripMenuItem.Click += showBillToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(1035, 276);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(113, 21);
            label2.TabIndex = 35;
            label2.Text = "Total Income:";
            // 
            // lblInCome
            // 
            lblInCome.AutoSize = true;
            lblInCome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblInCome.Location = new System.Drawing.Point(1154, 276);
            lblInCome.Name = "lblInCome";
            lblInCome.Size = new System.Drawing.Size(31, 21);
            lblInCome.TabIndex = 36;
            lblInCome.Text = "???";
            // 
            // frmAllEarningsByProperty
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1316, 705);
            Controls.Add(lblInCome);
            Controls.Add(label2);
            Controls.Add(lblTotalRecords);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvEarningsByProperty);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmAllEarningsByProperty";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmAllEarningsByProperty";
            Load += frmAllEarningsByProperty_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEarningsByProperty).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvEarningsByProperty;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showBillToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInCome;
    }
}