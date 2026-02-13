namespace PropertyRenting
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addDiscountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            PropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            updateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            searchForAPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            blockUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            unBlockUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setAdminRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            roleLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            earningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showAllEarningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            incomesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            wallletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            accountantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            customerSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moderatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { applicationToolStripMenuItem, searchForAPlaceToolStripMenuItem, signInToolStripMenuItem, userToolStripMenuItem, paymentsToolStripMenuItem, earningsToolStripMenuItem, accountantToolStripMenuItem, moderatorToolStripMenuItem, customerSupportToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1491, 56);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { bookToolStripMenuItem, addDiscountToolStripMenuItem, PropertyToolStripMenuItem });
            applicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            applicationToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("applicationToolStripMenuItem.Image");
            applicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            applicationToolStripMenuItem.Size = new System.Drawing.Size(159, 52);
            applicationToolStripMenuItem.Text = "Application";
            // 
            // bookToolStripMenuItem
            // 
            bookToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("bookToolStripMenuItem.Image");
            bookToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            bookToolStripMenuItem.Size = new System.Drawing.Size(212, 54);
            bookToolStripMenuItem.Text = "Book";
            bookToolStripMenuItem.Click += bookToolStripMenuItem_Click;
            // 
            // addDiscountToolStripMenuItem
            // 
            addDiscountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { addToolStripMenuItem, updateToolStripMenuItem });
            addDiscountToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("addDiscountToolStripMenuItem.Image");
            addDiscountToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            addDiscountToolStripMenuItem.Name = "addDiscountToolStripMenuItem";
            addDiscountToolStripMenuItem.Size = new System.Drawing.Size(212, 54);
            addDiscountToolStripMenuItem.Text = "discount";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("addToolStripMenuItem.Image");
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addDiscountToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("updateToolStripMenuItem.Image");
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += updateDiscountToolStripMenuItem_Click;
            // 
            // PropertyToolStripMenuItem
            // 
            PropertyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { addToolStripMenuItem1, updateToolStripMenuItem1 });
            PropertyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("PropertyToolStripMenuItem.Image");
            PropertyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            PropertyToolStripMenuItem.Name = "PropertyToolStripMenuItem";
            PropertyToolStripMenuItem.Size = new System.Drawing.Size(212, 54);
            PropertyToolStripMenuItem.Text = "Property";
            PropertyToolStripMenuItem.Click += findAPalaceToolStripMenuItem_Click;
            // 
            // addToolStripMenuItem1
            // 
            addToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("addToolStripMenuItem1.Image");
            addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            addToolStripMenuItem1.Size = new System.Drawing.Size(180, 26);
            addToolStripMenuItem1.Text = "Add";
            addToolStripMenuItem1.Click += addToolStripMenuItem1_Click;
            // 
            // updateToolStripMenuItem1
            // 
            updateToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("updateToolStripMenuItem1.Image");
            updateToolStripMenuItem1.Name = "updateToolStripMenuItem1";
            updateToolStripMenuItem1.Size = new System.Drawing.Size(180, 26);
            updateToolStripMenuItem1.Text = "Update";
            updateToolStripMenuItem1.Click += updateToolStripMenuItem1_Click;
            // 
            // searchForAPlaceToolStripMenuItem
            // 
            searchForAPlaceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            searchForAPlaceToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("searchForAPlaceToolStripMenuItem.Image");
            searchForAPlaceToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            searchForAPlaceToolStripMenuItem.Name = "searchForAPlaceToolStripMenuItem";
            searchForAPlaceToolStripMenuItem.Size = new System.Drawing.Size(207, 52);
            searchForAPlaceToolStripMenuItem.Text = "Search for A place";
            searchForAPlaceToolStripMenuItem.Click += searchForAPlaceToolStripMenuItem_Click;
            // 
            // signInToolStripMenuItem
            // 
            signInToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            signInToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("signInToolStripMenuItem.Image");
            signInToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            signInToolStripMenuItem.Size = new System.Drawing.Size(123, 52);
            signInToolStripMenuItem.Text = "Sign In";
            signInToolStripMenuItem.Click += signInToolStripMenuItem_Click;
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { showInfoToolStripMenuItem, changePasswordToolStripMenuItem, logOutToolStripMenuItem, blockUserToolStripMenuItem, unBlockUserToolStripMenuItem, setAdminRoleToolStripMenuItem, roleLogsToolStripMenuItem });
            userToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            userToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("userToolStripMenuItem.Image");
            userToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new System.Drawing.Size(128, 52);
            userToolStripMenuItem.Text = "Sign up";
            userToolStripMenuItem.Click += userToolStripMenuItem_Click;
            // 
            // showInfoToolStripMenuItem
            // 
            showInfoToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("showInfoToolStripMenuItem.Image");
            showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            showInfoToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            showInfoToolStripMenuItem.Text = "Show Info";
            showInfoToolStripMenuItem.Click += showInfoToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("changePasswordToolStripMenuItem.Image");
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("logOutToolStripMenuItem.Image");
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // blockUserToolStripMenuItem
            // 
            blockUserToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("blockUserToolStripMenuItem.Image");
            blockUserToolStripMenuItem.Name = "blockUserToolStripMenuItem";
            blockUserToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            blockUserToolStripMenuItem.Text = "Block User";
            blockUserToolStripMenuItem.Click += blockUserToolStripMenuItem_Click;
            // 
            // unBlockUserToolStripMenuItem
            // 
            unBlockUserToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("unBlockUserToolStripMenuItem.Image");
            unBlockUserToolStripMenuItem.Name = "unBlockUserToolStripMenuItem";
            unBlockUserToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            unBlockUserToolStripMenuItem.Text = "UnBlock User";
            unBlockUserToolStripMenuItem.Click += unBlockUserToolStripMenuItem_Click;
            // 
            // setAdminRoleToolStripMenuItem
            // 
            setAdminRoleToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("setAdminRoleToolStripMenuItem.Image");
            setAdminRoleToolStripMenuItem.Name = "setAdminRoleToolStripMenuItem";
            setAdminRoleToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            setAdminRoleToolStripMenuItem.Text = "Set Role";
            setAdminRoleToolStripMenuItem.Click += setAdminRoleToolStripMenuItem_Click;
            // 
            // roleLogsToolStripMenuItem
            // 
            roleLogsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("roleLogsToolStripMenuItem.Image");
            roleLogsToolStripMenuItem.Name = "roleLogsToolStripMenuItem";
            roleLogsToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            roleLogsToolStripMenuItem.Text = "Role Logs";
            roleLogsToolStripMenuItem.Click += roleLogsToolStripMenuItem_Click;
            // 
            // paymentsToolStripMenuItem
            // 
            paymentsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            paymentsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("paymentsToolStripMenuItem.Image");
            paymentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            paymentsToolStripMenuItem.Size = new System.Drawing.Size(145, 52);
            paymentsToolStripMenuItem.Text = "Payments";
            paymentsToolStripMenuItem.Click += paymentsToolStripMenuItem_Click;
            // 
            // earningsToolStripMenuItem
            // 
            earningsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { showAllEarningsToolStripMenuItem, incomesToolStripMenuItem, wallletToolStripMenuItem });
            earningsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            earningsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("earningsToolStripMenuItem.Image");
            earningsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            earningsToolStripMenuItem.Name = "earningsToolStripMenuItem";
            earningsToolStripMenuItem.Size = new System.Drawing.Size(136, 52);
            earningsToolStripMenuItem.Text = "Earnings";
            // 
            // showAllEarningsToolStripMenuItem
            // 
            showAllEarningsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("showAllEarningsToolStripMenuItem.Image");
            showAllEarningsToolStripMenuItem.Name = "showAllEarningsToolStripMenuItem";
            showAllEarningsToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            showAllEarningsToolStripMenuItem.Text = "Show All Earnings";
            showAllEarningsToolStripMenuItem.Click += showAllEarningsToolStripMenuItem_Click;
            // 
            // incomesToolStripMenuItem
            // 
            incomesToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("incomesToolStripMenuItem.Image");
            incomesToolStripMenuItem.Name = "incomesToolStripMenuItem";
            incomesToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            incomesToolStripMenuItem.Text = "Incomes";
            incomesToolStripMenuItem.Click += incomesToolStripMenuItem_Click;
            // 
            // wallletToolStripMenuItem
            // 
            wallletToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("wallletToolStripMenuItem.Image");
            wallletToolStripMenuItem.Name = "wallletToolStripMenuItem";
            wallletToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            wallletToolStripMenuItem.Text = "Wallet";
            wallletToolStripMenuItem.Click += wallletToolStripMenuItem_Click;
            // 
            // accountantToolStripMenuItem
            // 
            accountantToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            accountantToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("accountantToolStripMenuItem.Image");
            accountantToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            accountantToolStripMenuItem.Name = "accountantToolStripMenuItem";
            accountantToolStripMenuItem.Size = new System.Drawing.Size(158, 52);
            accountantToolStripMenuItem.Text = "Accountant";
            accountantToolStripMenuItem.Click += accountantToolStripMenuItem_Click;
            // 
            // customerSupportToolStripMenuItem
            // 
            customerSupportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customerSupportToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("customerSupportToolStripMenuItem.Image");
            customerSupportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            customerSupportToolStripMenuItem.Name = "customerSupportToolStripMenuItem";
            customerSupportToolStripMenuItem.Size = new System.Drawing.Size(208, 52);
            customerSupportToolStripMenuItem.Text = "Customer Support";
            customerSupportToolStripMenuItem.Click += customerSupportToolStripMenuItem_Click;
            // 
            // moderatorToolStripMenuItem
            // 
            moderatorToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            moderatorToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("moderatorToolStripMenuItem.Image");
            moderatorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            moderatorToolStripMenuItem.Name = "moderatorToolStripMenuItem";
            moderatorToolStripMenuItem.Size = new System.Drawing.Size(151, 52);
            moderatorToolStripMenuItem.Text = "Moderator";
            moderatorToolStripMenuItem.Click += moderatorToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1491, 801);
            Controls.Add(menuStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Main form";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDiscountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForAPlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unBlockUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem earningsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllEarningsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAdminRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wallletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roleLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moderatorToolStripMenuItem;
    }
}

