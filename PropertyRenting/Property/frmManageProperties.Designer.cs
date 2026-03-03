namespace PropertyRenting.Property
{
    partial class frmManageProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageProperties));
            label2 = new System.Windows.Forms.Label();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            txtFilterValue = new System.Windows.Forms.TextBox();
            dgvProperties = new System.Windows.Forms.DataGridView();
            cmMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addOfferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblTotalRecords = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvProperties).BeginInit();
            cmMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(26, 259);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 21);
            label2.TabIndex = 12;
            label2.Text = "Filter By";
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "PropertyID", "Name", "CountryName", "City", "Address", "PropertyTypeName", "PropertyStatus" });
            cbFilterBy.Location = new System.Drawing.Point(98, 256);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(137, 29);
            cbFilterBy.TabIndex = 11;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(241, 256);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(190, 29);
            txtFilterValue.TabIndex = 10;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += TextPropertyId_KeyPress;
            // 
            // dgvProperties
            // 
            dgvProperties.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProperties.ContextMenuStrip = cmMenuStrip;
            dgvProperties.Location = new System.Drawing.Point(26, 291);
            dgvProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvProperties.Name = "dgvProperties";
            dgvProperties.Size = new System.Drawing.Size(1182, 318);
            dgvProperties.TabIndex = 9;
            // 
            // cmMenuStrip
            // 
            cmMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cmMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showToolStripMenuItem, updateToolStripMenuItem, delToolStripMenuItem, addOfferToolStripMenuItem });
            cmMenuStrip.Name = "cmMenuStrip";
            cmMenuStrip.Size = new System.Drawing.Size(181, 130);
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
            delToolStripMenuItem.Click += delToolStripMenuItem_Click_1;
            // 
            // addOfferToolStripMenuItem
            // 
            addOfferToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("addOfferToolStripMenuItem.Image");
            addOfferToolStripMenuItem.Name = "addOfferToolStripMenuItem";
            addOfferToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            addOfferToolStripMenuItem.Text = "Add Offer";
            addOfferToolStripMenuItem.Click += addOfferToolStripMenuItem_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new System.Drawing.Point(104, 626);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new System.Drawing.Size(17, 15);
            lblTotalRecords.TabIndex = 15;
            lblTotalRecords.Text = "??";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 626);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 14;
            label1.Text = "Total Record\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(510, 54);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(233, 40);
            label3.TabIndex = 16;
            label3.Text = "Update Property";
            // 
            // frmManageProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1267, 655);
            Controls.Add(label3);
            Controls.Add(lblTotalRecords);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvProperties);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmManageProperties";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ManageProperties";
            Load += ManageProperties_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProperties).EndInit();
            cmMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOfferToolStripMenuItem;
    }
}