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

namespace PropertyRenting.Role
{
    public partial class frmSetRole : Form
    {

        public enum enRole
        {
            Admin = 1, Provider = 2, Cutomer = 3,
            AdminAndProvider = 4, Accountant = 5,
            Customer_Support_Agent = 7, Moderator_TrustAnd_Safety = 6
        }

       
        byte Role = 0;

       
        public frmSetRole()
        {
            InitializeComponent();
        }


        private SetRole FillRole()
        {
            return new SetRole
            {
                AdminCommiteeId = clsGlobal.CurrentUser.ClientID,
                RecipientId = ctrlUserWithFilter1.ClientID,
                RecipientRole = Role,
                Report = txtReport.Text
            };
        }



        private async Task<SetRole> SetRole(Models.SetRole Role)
        {
            return await ApiClient.clsAPIFunctions<SetRole>.PutAsync($"Role/SetRole", Role);
        }

        private async void SetRole_Click(object sender, EventArgs e)
        {
            Models.SetRole Role = FillRole();
            var setRole = await SetRole(Role);
            if (setRole != null)
            {
                MessageBox.Show($"{CBRole.Text} Role set successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show($"{CBRole.Text} Role has failed Failed ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CBRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBRole.Text)
            {

                case "Admin":
                    Role = (int)enRole.Admin;
                    break;

                case "Provider":
                    Role = (int)enRole.Provider;
                    break;
                case "Customer":
                    Role = (int)enRole.Cutomer;
                    break;
                case "Admin_Provider":
                    Role = (int)enRole.AdminAndProvider;
                    break;

                case "Accountant":
                    Role = (int)enRole.Accountant;
                    break;
                case "Customer Support Agent":
                    Role = (int)enRole.Customer_Support_Agent;
                    break;
                case "Moderator / Trust & Safety":
                    Role = (int)enRole.Moderator_TrustAnd_Safety;
                    break;
            }

        }

        private void txtReport_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty( txtReport.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtReport, "Report is empty !");
            }
            if (txtReport.Text.Trim().Length > 300)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtReport, "Report length must not exceed 300 charachter!");
            }
            else
            {
                errorProvider1.SetError(txtReport, null);
            };
        }
    }
}
