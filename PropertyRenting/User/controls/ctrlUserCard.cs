using PropertyRenting.ClassGlobal;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PropertyRenting.User.controls
{
    public partial class ctrlUserCard : UserControl
    {
        private int _PersonID = -1;

        public int clientId { get; set; }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }

        public async Task<Models.Client> LoadClientInfo(int clientId)
        {
            return await ApiClient.clsAPIFunctions<Models.Client>.GetAsync("Clients/getPersonInfo?clientID=", clientId);
        }
        public async void PersonDataLoad(int clientID)
        {
            clientId = clientID;

            if (clientID != -1)
            {
                var person = await LoadClientInfo(clientId); //await ApiClient.clsAPIFunctions<Models.Client>.GetAsync("Clients/getPersonInfo?clientID=", _LogId);
                lblClientId.Text = person.ClientID.ToString();
                lblUsername.Text = person.UserName;



                lblFirstname.Text = person.FirstName;
                lblLastname.Text = person.LastName;
                lblAddress.Text = person.Address;
                lblDateOfBirth.Text = clsFormat.DateToShort(person.DateOfBirth);
                //lblEmail.Text = clsGlobal.CurrentUser.email;
                lblGender.Text = person.Gender ? "Male" : "Female";
                lblPhone.Text = person.Phone;
                string Nationality = await loadNationality(person.NationalityCountryID);
                lblnationality.Text = Nationality;
                lblEmail.Text = person.email;


                if (pbPersonal.ImageLocation != "")
                {
                    pbPersonal.ImageLocation = person.personalImage;
                }
                else
                {
                    if (person.Gender)
                        pbPersonal.ImageLocation = "D:\\DestopsApplications\\PropertyRenting\\Resources\\Male 512.png";
                    else
                        pbPersonal.ImageLocation = "D:\\DestopsApplications\\PropertyRenting\\Resources\\Female 512.png";

                }
            }
            else
            {
                MessageBox.Show("Person is  not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

     
        private async Task<string> loadNationality(int CountryID)
        {
            string Natoinality = await ApiClient.clsAPIFunctions<string>.GetAsync("Country/CountryNameByID?CountryID=", CountryID);
            return Natoinality;
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    
    }
}
