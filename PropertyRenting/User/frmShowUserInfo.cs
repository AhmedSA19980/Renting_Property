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
    public partial class frmShowUserInfo : Form
    {
        private int _clientID;
        public frmShowUserInfo(int clientID)
        {
            InitializeComponent();
            _clientID = clientID;

        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {

            ctrlUserCard1.PersonDataLoad(_clientID);

        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int clientid = clsGlobal.CurrentUser.ClientID;
            frmAddUpdateUser frm = new frmAddUpdateUser(clientid);
            frm.ShowDialog();
            frmShowUserInfo_Load(null , null);
        }
    }
}
