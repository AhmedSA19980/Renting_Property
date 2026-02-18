using ApiClient;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Blocking
{
    public partial class frmUnblockClient : Form
    {
        public frmUnblockClient()
        {
            InitializeComponent();
        }


        private async Task<bool> IsClientUnblocked()
        {
            int clientId = ctrlUserWithFilter1.ClientID;
            bool isClientUnblocked = await clsAPIFunctions<bool>.GetAsync("Clients/IsUserBlocked?ClientID=", clientId);
            return isClientUnblocked;
        }
      
        private async Task UnblockClient()
        {
            bool isUserUnblocked = await IsClientUnblocked();

            if (isUserUnblocked) {

                MessageBox.Show($"User with {ctrlUserWithFilter1.ClientID} is already Unblocked ", "Successfull", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            var BlockUser = await clsAPIFunctions<bool>.PutAsync($"Clients/UnBlockClient?ClientID={ctrlUserWithFilter1.ClientID}", null);
            if (BlockUser)
            {
                MessageBox.Show($"you've Unblocked user {ctrlUserWithFilter1.ClientID}", "Successfull", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
        }

        private async void  btnunblock_Click(object sender, EventArgs e)
        {
            await UnblockClient();
           
        }

      
    }
}
