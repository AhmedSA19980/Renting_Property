namespace PropertyRenting.Property.controls
{
    partial class ctrlFindProperty
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
            txtFind = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtFind
            // 
            txtFind.CausesValidation = false;
            txtFind.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtFind.Location = new System.Drawing.Point(94, 12);
            txtFind.Name = "txtFind";
            txtFind.PlaceholderText = "Search by Name or city..";
            txtFind.Size = new System.Drawing.Size(288, 27);
            txtFind.TabIndex = 0;
            txtFind.TextChanged += txtFind_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(21, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 21);
            label1.TabIndex = 1;
            label1.Text = "Enter : ";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlFindProperty
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(txtFind);
            Name = "ctrlFindProperty";
            Size = new System.Drawing.Size(482, 55);
            Load += ctrlFindProperty_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
