using System.Threading.Tasks;

namespace PropertyRenting.Property
{
    partial class FindProperty
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ctrlFindProperty1 = new controls.ctrlFindProperty();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new System.Drawing.Point(181, 96);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1030, 586);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // ctrlFindProperty1
            // 
            ctrlFindProperty1.Location = new System.Drawing.Point(339, 23);
            ctrlFindProperty1.Name = "ctrlFindProperty1";
            ctrlFindProperty1.SearchText = null;
            ctrlFindProperty1.Size = new System.Drawing.Size(446, 44);
            ctrlFindProperty1.TabIndex = 2;
            ctrlFindProperty1.OnPropertySelected += ctrlFindProperty1_OnPropertySelected;
            ctrlFindProperty1.Load += ctrlFindProperty1_Load;
            // 
            // FindProperty
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1261, 685);
            Controls.Add(ctrlFindProperty1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "FindProperty";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FindProperty";
            Load += FindProperty_Load;
            Click += FindProperty_Click;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private controls.ctrlFindProperty ctrlFindProperty1;
    }
}