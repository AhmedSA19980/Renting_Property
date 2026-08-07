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

namespace PropertyRenting.Payment
{
    public partial class frmIncomeByPeriods : Form
    {
        private int _clientId;
        private enum userRole { Admin = 1, Provider = 2, AdminClient = 4 }

    
        public frmIncomeByPeriods(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
        }


        private void frmIncomeByPeriods_Load(object sender, EventArgs e)
        {
            string usRole = clsGlobal.CurrentUser.userRoles[1];
            if (Convert.ToInt32(usRole) == (int)userRole.Admin || Convert.ToInt32(usRole) == (int)userRole.AdminClient)
            {
                ctrlTotaIncomeByFilter1.EnabledFilterClientId = true;
              
                ctrlTotaIncomeByFilter1.frmClientLoad();
                ctrlTotaIncomeByFilter1.ClientId = clsGlobal.CurrentUser.ClientID;

            }
            else
            {
                ctrlTotaIncomeByFilter1.EnabledFilterClientId = false;
                ctrlTotaIncomeByFilter1.ClientId = _clientId;
                ctrlTotaIncomeByFilter1.frmClientLoad();
            }
        }

        private void ctrlTotaIncomeByFilter1_OnClientSelected(int obj)
        {
            _clientId = obj;
        }
    }
}
