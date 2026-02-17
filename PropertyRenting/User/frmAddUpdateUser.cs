
using PropertyRenting.ClassGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing;
using System.Resources;
using PropertyRenting.Properties;
using System.IO;
using Models;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PropertyRenting.User
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };
        private enMode _Mode;
        
        private int _ClientId = -1;
       private  Models.Client _client = new Models.Client();


        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int ClientId)
        {
            InitializeComponent();
            _ClientId = ClientId;
            _Mode = enMode.Update;
        }

        private async Task<List<Models.Country>> ListCountries()
        {
            return await ApiClient.clsAPIFunctions<List<Models.Country>>.GetAsync("Country/All");
        }
        private async void _FillCountriesInComoboBox()
        {
            try
            {
                List<Models.Country> countries =await ListCountries() ;//await ApiClient.clsAPIFunctions<List<Models.Country>>.GetAsync("Country/All"); ;
                if (countries != null)
                {
                    DataTable dtCountries = PropertyRenting.ClassGlobal.clsConvertListToDataTable<Models.Country>.ToDataTable(countries);
                    foreach (DataRow row in dtCountries.Rows)
                    {
                        cbCountry.Items.Add(row["CountryName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobal.SaveToEventLog($"{ex.Message}", EventLogEntryType.Error);
            
            }
        }


        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of a Form to EnableAllowFocusChange 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }


        }


     

        private void DefaulImage()
        {
            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {

                pbPersonImage.Image = Resources.Female_512; 
            }
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
          

            _FillCountriesInComoboBox();
            tbClient.Enabled = false;

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
            }
            else
            {
                lblTitle.Text = "Update Person";
                LoadClientData(_ClientId);
              
            }



            btnremoveImage.Visible = (pbPersonImage.Image != null);



            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

            txtFirstName.Text = "";
            txtLastName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";


          

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
           
            if (txtEmail.Text.Trim() == "")
                return;

            
            if (!clsValidations.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            ClassGlobal.ImageFormat.LLopenFileDialog_Click(sender, e, pbPersonImage, btnremoveImage, openFileDialog1);


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveToNextPage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtAddress.Text)

                ) { MessageBox.Show("Please, Fill the empty field/s ", "Error", MessageBoxButtons.OK); return; }
            else
            {

                tbClient.Enabled = true;
                tbUserInfo.SelectedTab = tbUserInfo.TabPages["tbClient"];
            }


        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()) && _Mode == enMode.AddNew)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtRepeatPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtRepeatPassword.Text.Trim() != txtPassword.Text.Trim() && _Mode == enMode.AddNew)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRepeatPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtRepeatPassword, null);
            };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private async Task<Models.Client> GetClientInfo(int clientId)
        {
            return await ApiClient.clsAPIFunctions<Models.Client>.GetAsync("Clients/getPersonInfo?clientID=", clientId);
        }

        private async Task<string> GetCountry(int nationalId) {
          return   await ApiClient.clsAPIFunctions<string>.GetAsync("Country/CountryNameByID?CountryID=", nationalId);
        }
        private async void LoadClientData(int clientid)
        {
            try
            {

                _client =await GetClientInfo(clientid) ;
                string countryName = await GetCountry(_client.NationalityCountryID);
                if (_client != null)
                {
                    lblClientID.Text = _client.ClientID.ToString();

                    txtUserName.Text = _client.UserName;
                    txtFirstName.Text = _client.FirstName;
                    txtLastName.Text = _client.LastName;
                    txtAddress.Text = _client.Address;

                   

                    txtPhone.Text = _client.Phone;
                    txtEmail.Text = _client.email;
                    dtpDateOfBirth.Value = _client.DateOfBirth;
                    cbCountry.Text = countryName;
                    if (_client.Gender) rbMale.Checked = true;
                    else rbFemale.Checked = true;

                    if (_client.personalImage != null)
                    {
                        pbPersonImage.ImageLocation = _client.personalImage;
                    }

                }
                else
                {
                    MessageBox.Show("Failed to load offer data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error loading offer data: {ex}");
                clsGlobal.SaveToEventLog($"Error loading offer data: {ex}", EventLogEntryType.Error);
                MessageBox.Show("An error occurred while loading offer data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<int> GetCountryIdByCountryName(string country)
        {
            return await ApiClient.clsAPIFunctions<int>.GetAsync("Country/CountryName?Name=", country);
        }


        private async Task<Models.Client> AddClient( Models.Client client)
        {
            return await ApiClient.clsAPIFunctions<Models.Client>.PostAsync("Clients/Add", client);
        }

        private async Task<Models.Client> UpdateClient(int clientId, Models.Client client)
        {
            return await ApiClient.clsAPIFunctions<Models.Client>.PutAsync($"Clients/UpdateClientById?UpdateClientById={clientId}", client);
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {

            
            if (!ValidateChildren()) return;
            if (!ImageFormat.HandlePersonImage(pbPersonImage, _client.personalImage))
                return;

            try
            {
                int CountryID =await GetCountryIdByCountryName(cbCountry.Text);
                 _client = new Models.Client
                {
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,

                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Gender = rbMale.Checked ? true : false,
                    Address = txtAddress.Text,
                    NationalityCountryID = CountryID,
                    Phone = txtPhone.Text,
                    email = txtEmail.Text,

                    personalImage = pbPersonImage.ImageLocation != null ? pbPersonImage.ImageLocation : "",

                
                 
                 };


               
                Models.Client ResultClient = _Mode == enMode.AddNew ?await AddClient(_client): 
                   await UpdateClient(_ClientId , _client); 

                
                if (_client == null)
                {
                    MessageBox.Show("client Failed to create", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;

                }
                if (pbPersonImage.ImageLocation != null)
                {
                    _client.personalImage = pbPersonImage.ImageLocation;
                }
                else
                {
                    DefaulImage();
                }

                string result = _Mode == enMode.AddNew ? "Created" : "Update";
                
                MessageBox.Show($"client {result} Successfully", "Success", MessageBoxButtons.OK , MessageBoxIcon.Information);

                lblClientID.Text = ResultClient.ClientID.ToString();
                _Mode = enMode.Update;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading offer data: {ex}");
                clsGlobal.SaveToEventLog($"Error loading offer data: {ex}", EventLogEntryType.Error);
                MessageBox.Show("An error occurred while loading offer data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {

            pbPersonImage.ImageLocation = null;
            // DefaulImage();
           if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {

                pbPersonImage.Image =Resources.Female_512 ; 
            }

            btnremoveImage.Visible = false;

        }

 

        private void rbFemale_Click(object sender, EventArgs e)
        {

            if (pbPersonImage.ImageLocation== null)
               pbPersonImage.Image = Resources.Female_512;

        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)

                pbPersonImage.Image = Resources.Male_512;

        }
    }
}
