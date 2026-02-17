namespace PropertyRenting.User
{
    partial class frmAddUpdateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateUser));
            tbUserInfo = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            btnremoveImage = new System.Windows.Forms.Button();
            btnSelect = new System.Windows.Forms.Button();
            label10 = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            pbPersonImage = new System.Windows.Forms.PictureBox();
            label7 = new System.Windows.Forms.Label();
            cbCountry = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            txtPhone = new System.Windows.Forms.TextBox();
            txtAddress = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            txtFirstName = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            rbFemale = new System.Windows.Forms.RadioButton();
            rbMale = new System.Windows.Forms.RadioButton();
            label4 = new System.Windows.Forms.Label();
            dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tbClient = new System.Windows.Forms.TabPage();
            lblClientID = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            label12 = new System.Windows.Forms.Label();
            txtRepeatPassword = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            txtUserName = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            lblTitle = new System.Windows.Forms.Label();
            btnCancel = new System.Windows.Forms.Button();
            tbUserInfo.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).BeginInit();
            tbClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tbUserInfo
            // 
            tbUserInfo.Controls.Add(tabPage1);
            tbUserInfo.Controls.Add(tbClient);
            tbUserInfo.Location = new System.Drawing.Point(88, 89);
            tbUserInfo.Name = "tbUserInfo";
            tbUserInfo.SelectedIndex = 0;
            tbUserInfo.Size = new System.Drawing.Size(829, 561);
            tbUserInfo.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.White;
            tabPage1.Controls.Add(btnremoveImage);
            tabPage1.Controls.Add(btnSelect);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(txtEmail);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(pbPersonImage);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(cbCountry);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(txtPhone);
            tabPage1.Controls.Add(txtAddress);
            tabPage1.Controls.Add(txtLastName);
            tabPage1.Controls.Add(txtFirstName);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(rbFemale);
            tabPage1.Controls.Add(rbMale);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(dtpDateOfBirth);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(821, 533);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "PersonInformation";
            tabPage1.Click += tabPage1_Click;
            // 
            // btnremoveImage
            // 
            btnremoveImage.Location = new System.Drawing.Point(425, 201);
            btnremoveImage.Name = "btnremoveImage";
            btnremoveImage.Size = new System.Drawing.Size(75, 23);
            btnremoveImage.TabIndex = 20;
            btnremoveImage.Text = "Remove\r\n";
            btnremoveImage.UseVisualStyleBackColor = true;
            btnremoveImage.Click += btnremove_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new System.Drawing.Point(336, 201);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(75, 23);
            btnSelect.TabIndex = 19;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(443, 375);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(51, 21);
            label10.TabIndex = 18;
            label10.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(510, 371);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(178, 23);
            txtEmail.TabIndex = 17;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(721, 487);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(95, 30);
            button1.TabIndex = 16;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnMoveToNextPage_Click;
            // 
            // pbPersonImage
            // 
            pbPersonImage.Image = (System.Drawing.Image)resources.GetObject("pbPersonImage.Image");
            pbPersonImage.Location = new System.Drawing.Point(336, 34);
            pbPersonImage.Name = "pbPersonImage";
            pbPersonImage.Size = new System.Drawing.Size(167, 152);
            pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbPersonImage.TabIndex = 15;
            pbPersonImage.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(443, 323);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 21);
            label7.TabIndex = 14;
            label7.Text = "Phone:";
            // 
            // cbCountry
            // 
            cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbCountry.FormattingEnabled = true;
            cbCountry.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cbCountry.Location = new System.Drawing.Point(510, 272);
            cbCountry.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbCountry.Name = "cbCountry";
            cbCountry.Size = new System.Drawing.Size(178, 28);
            cbCountry.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(414, 272);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(89, 21);
            label6.TabIndex = 12;
            label6.Text = "Nationality:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new System.Drawing.Point(511, 326);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new System.Drawing.Size(178, 23);
            txtPhone.TabIndex = 11;
            txtPhone.Validating += ValidateEmptyTextBox;
            // 
            // txtAddress
            // 
            txtAddress.Location = new System.Drawing.Point(139, 412);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(139, 23);
            txtAddress.TabIndex = 9;
            txtAddress.Validating += ValidateEmptyTextBox;
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(139, 270);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(139, 23);
            txtLastName.TabIndex = 1;
            txtLastName.Validating += ValidateEmptyTextBox;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(139, 214);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(139, 23);
            txtFirstName.TabIndex = 0;
            txtFirstName.Validating += ValidateEmptyTextBox;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(35, 414);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 21);
            label5.TabIndex = 10;
            label5.Text = "Address:";
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new System.Drawing.Point(194, 376);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new System.Drawing.Size(63, 19);
            rbFemale.TabIndex = 8;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.Click += rbFemale_Click;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new System.Drawing.Point(120, 375);
            rbMale.Name = "rbMale";
            rbMale.Size = new System.Drawing.Size(51, 19);
            rbMale.TabIndex = 7;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.Click += rbMale_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(35, 373);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 21);
            label4.TabIndex = 6;
            label4.Text = "D.OfBirth:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new System.Drawing.Point(139, 323);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new System.Drawing.Size(200, 23);
            dtpDateOfBirth.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(37, 325);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 21);
            label3.TabIndex = 4;
            label3.Text = "D.OfBirth:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(37, 272);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(83, 21);
            label2.TabIndex = 3;
            label2.Text = "LastName:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(37, 213);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 21);
            label1.TabIndex = 2;
            label1.Text = "FirstName:";
            // 
            // tbClient
            // 
            tbClient.Controls.Add(lblClientID);
            tbClient.Controls.Add(label11);
            tbClient.Controls.Add(button2);
            tbClient.Controls.Add(label12);
            tbClient.Controls.Add(txtRepeatPassword);
            tbClient.Controls.Add(label8);
            tbClient.Controls.Add(label9);
            tbClient.Controls.Add(txtPassword);
            tbClient.Controls.Add(txtUserName);
            tbClient.Location = new System.Drawing.Point(4, 24);
            tbClient.Name = "tbClient";
            tbClient.Padding = new System.Windows.Forms.Padding(3);
            tbClient.Size = new System.Drawing.Size(821, 533);
            tbClient.TabIndex = 1;
            tbClient.Text = "UserInformation";
            tbClient.UseVisualStyleBackColor = true;
            // 
            // lblClientID
            // 
            lblClientID.AutoSize = true;
            lblClientID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblClientID.Location = new System.Drawing.Point(155, 25);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new System.Drawing.Size(30, 25);
            lblClientID.TabIndex = 23;
            lblClientID.Text = "??";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label11.Location = new System.Drawing.Point(58, 25);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(91, 25);
            label11.TabIndex = 22;
            label11.Text = "PersonID:";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(703, 480);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(112, 36);
            button2.TabIndex = 11;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSave_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label12.Location = new System.Drawing.Point(18, 183);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(127, 21);
            label12.TabIndex = 10;
            label12.Text = "repeat Password:";
            // 
            // txtRepeatPassword
            // 
            txtRepeatPassword.Location = new System.Drawing.Point(160, 185);
            txtRepeatPassword.Name = "txtRepeatPassword";
            txtRepeatPassword.PasswordChar = '*';
            txtRepeatPassword.Size = new System.Drawing.Size(139, 23);
            txtRepeatPassword.TabIndex = 9;
            txtRepeatPassword.Validating += txtRepeatPassword_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(58, 134);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(79, 21);
            label8.TabIndex = 7;
            label8.Text = "Password:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(58, 75);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(87, 21);
            label9.TabIndex = 6;
            label9.Text = "UserName:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(160, 132);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(139, 23);
            txtPassword.TabIndex = 5;
            txtPassword.Validating += txtPassword_Validating;
            // 
            // txtUserName
            // 
            txtUserName.Location = new System.Drawing.Point(160, 75);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new System.Drawing.Size(139, 23);
            txtUserName.TabIndex = 4;
            txtUserName.Validating += ValidateEmptyTextBox;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            lblTitle.Location = new System.Drawing.Point(435, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(150, 36);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Add Client";
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(801, 652);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(112, 36);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddUpdateUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1037, 693);
            Controls.Add(btnCancel);
            Controls.Add(lblTitle);
            Controls.Add(tbUserInfo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmAddUpdateUser";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmAddUpdateUser";
            Load += frmAddUpdateUser_Load;
            tbUserInfo.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).EndInit();
            tbClient.ResumeLayout(false);
            tbClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tbUserInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbClient;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRepeatPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnremoveImage;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label label11;
    }
}