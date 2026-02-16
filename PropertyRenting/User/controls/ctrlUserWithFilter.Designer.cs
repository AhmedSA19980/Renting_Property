namespace PropertyRenting.User.controls
{
    partial class ctrlUserWithFilter
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
            components = new System.ComponentModel.Container();
            gbFilter = new System.Windows.Forms.GroupBox();
            btnFind = new System.Windows.Forms.Button();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            txtFilterValue = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ctrlUserCard2 = new ctrlUserCard();
            gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(btnFind);
            gbFilter.Controls.Add(cbFilterBy);
            gbFilter.Controls.Add(txtFilterValue);
            gbFilter.Controls.Add(label1);
            gbFilter.Location = new System.Drawing.Point(115, 34);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new System.Drawing.Size(697, 79);
            gbFilter.TabIndex = 0;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter by";
            // 
            // btnFind
            // 
            btnFind.Location = new System.Drawing.Point(507, 32);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(104, 29);
            btnFind.TabIndex = 1;
            btnFind.Text = "Fiind";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += Find_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "Client ID", "Email" });
            cbFilterBy.Location = new System.Drawing.Point(101, 31);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(165, 29);
            cbFilterBy.TabIndex = 2;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFilterValue.Location = new System.Drawing.Point(287, 32);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new System.Drawing.Size(196, 29);
            txtFilterValue.TabIndex = 1;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            txtFilterValue.Validating += txtFilterValue_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Find By";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlUserCard2
            // 
            ctrlUserCard2.clientId = 0;
            ctrlUserCard2.Location = new System.Drawing.Point(107, 161);
            ctrlUserCard2.Name = "ctrlUserCard2";
            ctrlUserCard2.Size = new System.Drawing.Size(691, 696);
            ctrlUserCard2.TabIndex = 1;
            // 
            // ctrlUserWithFilter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            Controls.Add(ctrlUserCard2);
            Controls.Add(gbFilter);
            Name = "ctrlUserWithFilter";
            Size = new System.Drawing.Size(902, 882);
            Load += ctrlUserWithFilter_Load;
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlUserCard ctrlUserCard2;
    }
}
