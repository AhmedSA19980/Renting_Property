
using ApiClient;
using PropertyRenting.ClassGlobal;
using PropertyRenting.Property.Discount;
using PropertyRenting.Reservation;
using System;

using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Property
{
    public partial class BookAProperty : Form
    {

        private static Models.Property _Property;
        private int _PropertyID;

        private int _PropertyCardID1;
        private int _PropertyCardID2;
        private int _PropertyCardID3;
        private int _PropertyCardID4;
        

        private string[] ImagesPath;


        private int _CurrentImageIndex = 1;

        public BookAProperty(int PropertyID)
        {
            InitializeComponent();
            _PropertyID = PropertyID;
        }

       

        private async Task<int> GenerateRandomProperty()
        {
            return await ApiClient.clsAPIFunctions<int>.GetAsync("Property/Random");
        }
        private async Task<Models.Property> GetPropertyById(int PropertyId)
        {
           return await ApiClient.clsAPIFunctions<Models.Property>.GetAsync("Property/GetPropertyByID?PropertyID=", PropertyId);
        }

        private async Task<Models.Container> LoadContainerImagesById(int containerId)
        {
          return  await ApiClient.clsAPIFunctions<Models.Container>.GetAsync("Container/GetContainerByID?ContainerID=", containerId);
        }
        private async void BookAProperty_Load(object sender, EventArgs e)
        {

            _PropertyCardID1 = await GenerateRandomProperty(); 
            _PropertyCardID2 = await GenerateRandomProperty();
            _PropertyCardID3 = await GenerateRandomProperty(); 
            _PropertyCardID4 = await GenerateRandomProperty(); 
            ctrlPropertyCard1.LoadPropertyData(_PropertyCardID1);
         
            ctrlPropertyCard1.ID = _PropertyCardID1;
            ctrlPropertyCard2.ID = _PropertyCardID2;
            ctrlPropertyCard3.ID = _PropertyCardID3;
            ctrlPropertyCard4.ID = _PropertyCardID4;
            ctrlPropertyCard2.LoadPropertyData(_PropertyCardID2);

            ctrlPropertyCard3.LoadPropertyData(_PropertyCardID3);

            ctrlPropertyCard4.LoadPropertyData(_PropertyCardID4);

            ctrlShowPropertyInfo1.LoadPropertyData(_PropertyID);
            _Property =await GetPropertyById(_PropertyID); 
            if (_Property == null)
            {
                MessageBox.Show($"Check for proper property id, this {_PropertyID} is not Exist ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            var Images =await LoadContainerImagesById(_Property.ContainerID); 
            if (Images != null)
            {

                ImagesPath = new string[] {

                Images.ImageOnePath,
                Images.ImageTwoPath,
                Images.ImageThreePath ,
                Images.ImageFourPath,
                Images.ImageFivePath,
                Images.ImageSixPath,
                Images.ImageSevenPath,
                Images.ImageEightPath,
                Images.ImageNinePath,
                }
                ;

                pictureBox1.Image = Image.FromFile(ImagesPath[_CurrentImageIndex]);
            }

          

            int propertyOwner =await LoadPropertyOwnerByPropertyId(_PropertyID);
            _ = (clsGlobal.CurrentUser != null &&  clsGlobal.CurrentUser.ClientID == propertyOwner) ? lblCreateOffer.Visible = true : lblCreateOffer.Visible = false;
        }

        private async Task<int>LoadPropertyOwnerByPropertyId(int propertyId)
        {
          return  await clsAPIFunctions<int>.GetAsync("PropertyOwner/getPropertyClientIDbyPropertyID?PropertyID=", propertyId);
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {

            do
            {
                _CurrentImageIndex = (_CurrentImageIndex - 1 + ImagesPath.Length) % ImagesPath.Length;
            } while (ImagesPath[_CurrentImageIndex] == null || ImagesPath[_CurrentImageIndex].Trim() == "");

            if (ImagesPath[_CurrentImageIndex] != null && ImagesPath[_CurrentImageIndex].Trim() != "")
            {
                pictureBox1.Image = Image.FromFile(ImagesPath[_CurrentImageIndex]);
            }
        }

        private void btnNxt_Click(object sender, EventArgs e)
        {
            do
            {
                _CurrentImageIndex = (_CurrentImageIndex + 1) % ImagesPath.Length;
            } while (ImagesPath[_CurrentImageIndex] == null || ImagesPath[_CurrentImageIndex].Trim() == "");

            if (ImagesPath[_CurrentImageIndex] != null && ImagesPath[_CurrentImageIndex].Trim() != "")
            {
                pictureBox1.Image = Image.FromFile(ImagesPath[_CurrentImageIndex]);
            }
        }

       
        private async void lblCreateOffer_Click(object sender, EventArgs e)
        {

            int PropertyId = await ApiClient.clsAPIFunctions<int>.GetAsync("Property/GetPropertyID?PropertyID=", _PropertyID); 
            int discountid = await ApiClient.clsAPIFunctions<int>.GetAsync("Discount/getActiveDicountbyPropertyID?PropertyID=" , _PropertyID);  


            lblCreateOffer.ForeColor = Color.DarkGray;
            CreateUpdateAnOffer frm = new CreateUpdateAnOffer(PropertyId);
            frm.ShowDialog();
           


        }

      
        private void BtnRent_Click(object sender, EventArgs e)
        {

            if (clsGlobal.CurrentUser == null)
            {

                MessageBox.Show("You can't compelete the process, please you need to log in ! ", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            frmAddUpdateReservation fr = new frmAddUpdateReservation(_PropertyID);
            fr.ShowDialog();
        }

 
    }
}
