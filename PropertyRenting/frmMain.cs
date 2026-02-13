using ApiClient;
using Models;
using PropertyRenting.Blocking;
using PropertyRenting.ClassGlobal;
using PropertyRenting.Login;
using PropertyRenting.Payment;
using PropertyRenting.Property;
using PropertyRenting.Property.Discount;
using PropertyRenting.Role;
using PropertyRenting.User;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Forms;


namespace PropertyRenting
{

    public partial class frmMain : Form
    {


        private enum EnRole
        {
            Admin = 1, Provider = 2, Cutomer = 3,
            AdminAndProvider = 4, Accountant = 5,
            Customer_Support_Agent = 7, Moderator_TrustAnd_Safety = 6
        };

        private string _Client;
        Models.SessionManager _CurrenUser;
        private bool ShowList;


        public frmMain(Models.SessionManager current) // models.client
        {
            InitializeComponent();

            _CurrenUser = current;

        }

        private void Form1_Load(object sender, EventArgs e)

        {

            this.Refresh();
            if (_CurrenUser == null)
            {
                userToolStripMenuItem.Text = "Sign up";
                _CurrenUser = null;
                ShowList = false;
                blockUserToolStripMenuItem.Visible = false;
                unBlockUserToolStripMenuItem.Visible = false;
                PropertyToolStripMenuItem.Visible = false;
                addDiscountToolStripMenuItem.Visible = false;
                paymentsToolStripMenuItem.Visible = false;
                earningsToolStripMenuItem.Visible = false;
                blockUserToolStripMenuItem.Visible = false;
                unBlockUserToolStripMenuItem.Visible = false;
                setAdminRoleToolStripMenuItem.Visible = false;
                roleLogsToolStripMenuItem.Visible = false;
                accountantToolStripMenuItem.Visible = false;
                moderatorToolStripMenuItem.Visible = false;


               
            }
            else
            {

                userToolStripMenuItem.Text = _CurrenUser.UserName;
                _CurrenUser = clsGlobal.CurrentUser;
                ShowList = true;

                if (_CurrenUser != null)
                {
                    int userRole = int.Parse(clsGlobal.CurrentUser.userRoles[1]);

                    if (userRole == (int)EnRole.Accountant)
                    {
                        accountantToolStripMenuItem.Visible = true;
                        blockUserToolStripMenuItem.Visible = false;
                        unBlockUserToolStripMenuItem.Visible = false;
                        incomesToolStripMenuItem.Visible = true;
                        setAdminRoleToolStripMenuItem.Visible = false;
                        roleLogsToolStripMenuItem.Visible = false;
                        moderatorToolStripMenuItem.Visible = false;

                    }
                    else if (userRole == (int)EnRole.Moderator_TrustAnd_Safety) {


                        accountantToolStripMenuItem.Visible = false;
                        blockUserToolStripMenuItem.Visible = false;
                        unBlockUserToolStripMenuItem.Visible = false;
                        incomesToolStripMenuItem.Visible = false ;
                        setAdminRoleToolStripMenuItem.Visible = false;
                        roleLogsToolStripMenuItem.Visible = false;
                        moderatorToolStripMenuItem.Visible = true;
                    }
                    else if (userRole == (int)EnRole.Admin || userRole == (int)EnRole.AdminAndProvider)
                    {

                        blockUserToolStripMenuItem.Visible = true;
                        unBlockUserToolStripMenuItem.Visible = true;
                        incomesToolStripMenuItem.Visible = true;
                        setAdminRoleToolStripMenuItem.Visible = true;
                        roleLogsToolStripMenuItem.Visible = true;
                        accountantToolStripMenuItem.Visible = true;
                        moderatorToolStripMenuItem.Visible = true;

                    }

                    else if (_CurrenUser != null && _CurrenUser.userRoles[1] == Convert.ToString((int)EnRole.Provider))
                    {

                        incomesToolStripMenuItem.Visible = true;
                        blockUserToolStripMenuItem.Visible = false;
                        unBlockUserToolStripMenuItem.Visible = false;
                        PropertyToolStripMenuItem.Visible = true;
                        addDiscountToolStripMenuItem.Visible = true;
                        setAdminRoleToolStripMenuItem.Visible = false;
                        roleLogsToolStripMenuItem.Visible = false;
                        accountantToolStripMenuItem.Visible = false;
                        moderatorToolStripMenuItem.Visible = false;



                    }
                    else
                    {
                        blockUserToolStripMenuItem.Visible = false;
                        unBlockUserToolStripMenuItem.Visible = false;
                        earningsToolStripMenuItem.Visible = false;
                        addDiscountToolStripMenuItem.Visible = false;
                        updateToolStripMenuItem1.Visible = false;
                        setAdminRoleToolStripMenuItem.Visible = false;
                        roleLogsToolStripMenuItem.Visible = false;
                        accountantToolStripMenuItem.Visible = false;
                        moderatorToolStripMenuItem.Visible = false;
                      

                    }
                }

            }


            signInToolStripMenuItem.Visible = !ShowList;
            showInfoToolStripMenuItem.Visible = ShowList;
            changePasswordToolStripMenuItem.Visible = ShowList;
            logOutToolStripMenuItem.Visible = ShowList;


        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void findAPalaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateProperty();
            frm.ShowDialog();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindProperty frm = new FindProperty();
            frm.ShowDialog();
        }

        private void searchForAPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindProperty frm = new FindProperty();
            frm.ShowDialog();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmAddUpdateProperty frm = new frmAddUpdateProperty();
            frm.ShowDialog();

        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmManageProperties frm = new frmManageProperties();
            frm.ShowDialog();
        }

        private void addDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageProperties frm = new frmManageProperties();
            frm.ShowDialog();
        }

        private void updateDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageProperties frm = new frmManageProperties();
            frm.ShowDialog();
        }


        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {


            var refreshTokenData = new { RefreshToken = clsGlobal.CurrentUser.RefreshToken };
            var RevokeToken = await ApiClient.clsAPIFunctions<string>.PostAsync("Auth/revoke-token", refreshTokenData);


            clsAPIFunctions<object>.ClearAuthorizationToken();
            TokenManager.DeleteTokens();



            _CurrenUser = null;
            clsGlobal.CurrentUser = null;

            this.Hide();


            frmMain frm = new frmMain(_CurrenUser);
            frm.Show(); ;





        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int clientid = clsGlobal.CurrentUser.ClientID;
            frmShowUserInfo frm = new frmShowUserInfo(clientid);
            frm.ShowDialog(this);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog(this);
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrenUser == null)
            {

                this.Hide();


                frmLogin frm = new frmLogin();
                frm.ShowDialog();

            }

        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmClientPayments frm = new frmClientPayments();
            frm.ShowDialog(this);
        }

        private void blockUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBlockClient frm = new frmBlockClient();
            frm.ShowDialog(this);
        }

        private void unBlockUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnblockClient frm = new frmUnblockClient();
            frm.ShowDialog(this);
        }

        private void showAllEarningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEarnings frmEarnings = new frmEarnings();
            frmEarnings.ShowDialog(this);
        }

        private void incomesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int clientId = clsGlobal.CurrentUser.ClientID;
            frmIncomeByPeriods frm = new frmIncomeByPeriods(clientId);
            frm.ShowDialog(this);


        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wallletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature under Development !", "message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void setAdminRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetRole frm = new frmSetRole();
            frm.ShowDialog(this);
        }

        private void roleLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogs frm = new frmLogs();
            frm.ShowDialog(this);
        }

        private void accountantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature under Development !", "message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void customerSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature under Development !", "message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void moderatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature under Development !", "message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
