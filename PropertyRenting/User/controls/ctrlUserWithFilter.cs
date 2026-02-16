using ApiClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.User.controls
{
    public partial class ctrlUserWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
       
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); 
            }
        }
        int clientId = -1;
        int personId = -1;
        public int ClientID
        {
            get { return ctrlUserCard2.clientId; }
        }

     

        public int PersonId
        {
            get { return  personId; }set {  personId =  value; }
        }

        public ctrlUserWithFilter()
        {
            InitializeComponent();
        }

        private async Task<int>GetClient(string email)
        {
          return  await ApiClient.clsAPIFunctions<int>.GetAsync("Clients/GetClientIdByEmail?email=", email);
        }
        private async void FindNow()
        {
            int currPersonId = -1;
            switch (cbFilterBy.Text)
            {
                case "Client ID":

                    clientId = int.Parse(txtFilterValue.Text);
                    ctrlUserCard2.PersonDataLoad(clientId);

                    break;

                case "Email":
                    string email = txtFilterValue.Text;
                    clientId = await GetClient(email);
                    ctrlUserCard2.PersonDataLoad(clientId);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null)
               
                OnPersonSelected(ctrlUserCard2.clientId);
        }

        private void ctrlUserWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
               
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

           
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
               
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
              
                errorProvider1.SetError(txtFilterValue, null);
            }
        }
    }
}
