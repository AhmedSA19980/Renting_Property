using Models;
using PropertyRenting.ClassGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.User
{
    public partial class frmChangePassword : Form
    {
        private int _ClientID = -1;
        public frmChangePassword()
        {
            InitializeComponent();
            _ClientID = clsGlobal.CurrentUser.ClientID;
        }
        


        private void NewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPass, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPass, null);
            };
        }

        private void txtRepeatPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPass.Text.Trim() != txtRepeatPass.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRepeatPass, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtRepeatPass, null);
            };

        }

        private async Task<Models.Client> ModifyPassword(Models.Client currClient)
        {
          return  await ApiClient.clsAPIFunctions<Models.Client>.PutAsync("Clients/ChangePassword", currClient);
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            
            Models.Client currclient = new Models.Client
            {
                ClientID = clsGlobal.CurrentUser.ClientID,
                UserName = clsGlobal.CurrentUser.UserName,
                Password = txtNewPass.Text.Trim(),
            };

            var Client = await ModifyPassword(currclient); 


            if (Client != null)
            {
                MessageBox.Show("Password Chnage successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else
            {
                MessageBox.Show($"Failed to change {clsGlobal.CurrentUser.UserName} Password", "errpr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          


        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.PersonDataLoad(_ClientID);
        }
    }
}
