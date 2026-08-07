namespace PropertyRenting.Card
{
    partial class ShowClientCards
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
            ctrlCardDetail1 = new ctrlCardDetail();
            label2 = new System.Windows.Forms.Label();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            txtFilterValue = new System.Windows.Forms.TextBox();
            DgvCards = new System.Windows.Forms.DataGridView();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblTotalRecords = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)DgvCards).BeginInit();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlCardDetail1
            // 
            ctrlCardDetail1.EnableCvv = false;
            ctrlCardDetail1.EnableLableCvv = false;
            ctrlCardDetail1.Location = new System.Drawing.Point(197, 71);
            ctrlCardDetail1.Name = "ctrlCardDetail1";
            ctrlCardDetail1.Size = new System.Drawing.Size(523, 320);
            ctrlCardDetail1.TabIndex = 1;
            ctrlCardDetail1.DataDeleted += ctrlCardDetail1_DataDeleted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(27, 414);
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
            cbFilterBy.Items.AddRange(new object[] { "None", "Card ID", "Card Name", "Card No" });
            cbFilterBy.Location = new System.Drawing.Point(111, 415);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(148, 29);
            cbFilterBy.TabIndex = 11;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(299, 414);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(178, 29);
            txtFilterValue.TabIndex = 10;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += ShowClientCards_KeyPress;
            // 
            // DgvCards
            // 
            DgvCards.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            DgvCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvCards.ContextMenuStrip = contextMenuStrip2;
            DgvCards.Location = new System.Drawing.Point(27, 455);
            DgvCards.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvCards.Name = "DgvCards";
            DgvCards.Size = new System.Drawing.Size(766, 283);
            DgvCards.TabIndex = 9;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showToolStripMenuItem, editToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new System.Drawing.Point(143, 741);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new System.Drawing.Size(17, 15);
            lblTotalRecords.TabIndex = 14;
            lblTotalRecords.Text = "??";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(65, 741);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 15);
            label1.TabIndex = 13;
            label1.Text = "Total Record\r\n";
            // 
            // ShowClientCards
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(897, 814);
            Controls.Add(lblTotalRecords);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(DgvCards);
            Controls.Add(ctrlCardDetail1);
            Name = "ShowClientCards";
            Text = "ShowClientCards";
            Load += ShowClientCards_Load;
            KeyPress += ShowClientCards_KeyPress;
            ((System.ComponentModel.ISupportInitialize)DgvCards).EndInit();
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ctrlCardDetail ctrlCardDetail1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView DgvCards;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}