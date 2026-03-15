using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PropertyRenting.Role
{
    public partial class frmShowRoleLogs : Form
    {
        public frmShowRoleLogs(int logId)
        {
            InitializeComponent();
            _LogId = logId;
        }

        private int _LogId;

        private async void frmShowRoleLogs_Load(object sender, EventArgs e)
        {
            LogDataLoad(_LogId);
        }

        public async Task<Models.RoleLogs> LoadRoleLogInfo(int logId)
        {
            return await ApiClient.clsAPIFunctions<Models.RoleLogs>.GetAsync("Role/GetRoleById?logsId=", logId);
        }

        public string GetRole(int RoleInt)
        {
            string Role = "";
            switch (RoleInt)
            {

                case 1:
                    return Role = "Admin";


                case 2:
                    return Role = "Provider";

                case 3:
                    return Role = "Customer";

                case 4:
                    return Role = "Admin&Provider";


                case 5:
                    return Role = "Accountant";

                case 6:
                    return Role = "Customer_Support_Agent";

                case 7:
                    return Role = "Moderator_TrustAnd_Safety";

                default:
                    return "None";

            }
        }
        public async Task LogDataLoad(int logId)
        {
            _LogId = logId;
            int MaxLengthLine = 50;

            if (logId != -1)
            {
                var logs = await LoadRoleLogInfo(_LogId); 
                lblId.Text = logs.Id.ToString();
                lblCommiteeName.Text = logs.AdminCommiteeName;
                lblCommiteeId.Text = logs.AdminCommiteeId.ToString();
                lblDateMod.Text = logs.DateRoleModified.ToString();
                lblUserId.Text = logs.RecipientId.ToString();
                lblUserName.Text = logs.RecipientName;
                lblPreviousRole.Text = GetRole(logs.PrevRole);
                lblNewRole.Text = GetRole(logs.NewRole);
                lblReport.Text = Regex.Replace(logs.Report, $@"(.{{{MaxLengthLine}}})\s", "$1\n");

            }
            else
            {
                MessageBox.Show("Person is  not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
