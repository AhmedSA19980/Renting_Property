namespace PropertyRenting.Role
{
    partial class frmLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogs));
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            txtFilterValue = new System.Windows.Forms.TextBox();
            dgvProperties = new System.Windows.Forms.DataGridView();
            lblTotalRecords = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvProperties).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(434, 69);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(247, 40);
            label3.TabIndex = 21;
            label3.Text = "Role Logs History";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(18, 274);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 21);
            label2.TabIndex = 20;
            label2.Text = "Filter By";
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Id", "AdminCommiteeId", "AdminCommiteeName" });
            cbFilterBy.Location = new System.Drawing.Point(90, 271);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(169, 29);
            cbFilterBy.TabIndex = 19;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            cbFilterBy.KeyPress += TextLogsId_KeyPress;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(278, 271);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(190, 29);
            txtFilterValue.TabIndex = 18;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += TextLogsId_KeyPress;
            // 
            // dgvProperties
            // 
            dgvProperties.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProperties.ContextMenuStrip = contextMenuStrip1;
            dgvProperties.Location = new System.Drawing.Point(12, 306);
            dgvProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvProperties.Name = "dgvProperties";
            dgvProperties.Size = new System.Drawing.Size(995, 318);
            dgvProperties.TabIndex = 17;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new System.Drawing.Point(90, 638);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new System.Drawing.Size(17, 15);
            lblTotalRecords.TabIndex = 23;
            lblTotalRecords.Text = "??";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 638);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 22;
            label1.Text = "Total Record\r\n";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(123, 30);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("showToolStripMenuItem.Image");
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // frmLogs
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1082, 692);
            Controls.Add(lblTotalRecords);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvProperties);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmLogs";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmLogs";
            Load += frmLogs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProperties).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    }
}