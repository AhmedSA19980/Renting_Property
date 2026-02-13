using ApiClient;
using Models;
using PropertyRenting.ClassGlobal;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PropertyRenting.Login
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
       

        }

        private Models.Login FillFields()
        {
            var userInfo = new Models.Login
            {
                UserName = txtusername.Text.Trim(),
                Password = txtpass.Text.Trim(),
            };
            return userInfo;
        }

        private async Task<Models.Token> GetCurrentAuthClient(Models.Login userInfo)
        {

            Models.Token currUser = await ApiClient.clsAPIFunctions<Models.Token>.PostAsync("auth/Login", userInfo);
            return currUser;


        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {


           
            var userinfo = FillFields();

            var currentAuthUser = await GetCurrentAuthClient(userinfo); 
            if (currentAuthUser != null)
            {

               
               if(clsGlobal.CurrentUser == null)
                {
                    clsGlobal.CurrentUser = new Models.SessionManager();
                }
                clsAPIFunctions<string>.setAuthorizationToken(currentAuthUser.AccessToken); 
                
                clsGlobal.CurrentUser.AccessToken = currentAuthUser.AccessToken;
                clsGlobal.CurrentUser.RefreshToken = currentAuthUser.RefreshToken;
               

                var userToken =await clsAPIFunctions<Models.userData>.getUserData();  

                var userSession = await ApiClient.clsAPIFunctions<Models.Client>.GetAsync("Clients/getPersonInfo?clientID=",Convert.ToInt32( userToken.userId));
           
                clsGlobal.CurrentUser.UserName = userSession.UserName;
                clsGlobal.CurrentUser.email = userSession.email;
                clsGlobal.CurrentUser.ClientID = userSession.ClientID;


                clsGlobal.CurrentUser.userRoles = userToken.userRoles;
                
                TokenManager.SaveToken(currentAuthUser.AccessToken, currentAuthUser.RefreshToken);

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPassword(txtusername.Text.Trim(), txtpass.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");

                }
                //incase the user is not active
                if (await ApiClient.clsAPIFunctions<bool>.GetAsync("Clients/IsUserBlocked?personID=", userToken.userId) == true)
                {

                    txtusername.Focus();
                    MessageBox.Show("Your accound is Banned, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                
            
                this.Hide();
             
                frmMain frm = new  frmMain(clsGlobal.CurrentUser);
                
                frm.ShowDialog();
               

            }
            else
            {
                txtusername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain(clsGlobal.CurrentUser);
            frm.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtusername.Text = UserName;
                txtpass.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        
        }

       
    }
}
