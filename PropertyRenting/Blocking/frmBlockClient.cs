using ApiClient;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PropertyRenting.Blocking
{
    public partial class frmBlockClient : Form
    {
        public frmBlockClient()
        {
            InitializeComponent();
        }

        private   async Task<bool>  IsClientBlocked()
        {
            int clientid = ctrlUserWithFilter1.ClientID;
            bool isUserBlocked = await clsAPIFunctions<bool>.GetAsync("Clients/IsUserBlocked?ClientID=", clientid);
            return isUserBlocked;

        }

        private async Task BlockClient()
        {
            bool isClientBlocked = await IsClientBlocked();
            if (isClientBlocked)
            {
                MessageBox.Show($"User is already blocked {ctrlUserWithFilter1.ClientID}", "Successfull", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            var BlockUser = await clsAPIFunctions<bool>.PutAsync($"Clients/BlockClient?ClientID={ctrlUserWithFilter1.ClientID}", null);
            if (BlockUser)
            {
                MessageBox.Show($"you've blocked user {ctrlUserWithFilter1.ClientID}", "Successfull", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

        }

        private async void btnBlock_Click(object sender, EventArgs e)
        {
            await BlockClient();
            

        }
    }
}
