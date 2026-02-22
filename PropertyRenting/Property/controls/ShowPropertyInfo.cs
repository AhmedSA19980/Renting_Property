using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PropertyRenting.Property.controls
{
    public partial class ctrlShowPropertyInfo : UserControl
    {

        private int _PropertyID;
        Models.Property _Property;

        public ctrlShowPropertyInfo()
        {
            InitializeComponent();

        }


        public int PropertyID
        {
            get { return _PropertyID; }
        }


      
        private int ImagesContainer = -1;

        private async Task<Models.Property> GetPropertyInfo(int propertyId)
        {
            Models.Property Property = await ApiClient.clsAPIFunctions<Models.Property>.GetAsync("Property/GetPropertyByID?PropertyID=", propertyId);
            return Property;
        }

        private async Task <string> GetCountryNameById(int countryId)
        {
            return await ApiClient.clsAPIFunctions<string>.GetAsync("Country/CountryNameByID?CountryID=", countryId);
        }

        private async Task<string> GetPropertyTypeById(int propertyTypeId)
        {
            return await ApiClient.clsAPIFunctions<string>.GetAsync("PropertyType/PropertyNameByID?PropertyTypeID=", propertyTypeId);
        }
        private async Task<int> FindValidOffer(int PropertyId)
        {
            return await ApiClient.clsAPIFunctions<int>.GetAsync("Discount/getActiveDicountbyPropertyID?PropertyID=", PropertyId);
        }
        public async void LoadPropertyData(int PropertyID)
        {
            _PropertyID = PropertyID;

            _Property = await GetPropertyInfo(_PropertyID) ;

            if (_Property != null)
            {

               
                lblBathroomsNo.Text = Convert.ToString(_Property.NumberOfBathrooms);
                lblShowBedroomsNo.Text = Convert.ToString(_Property.NumberOfBedrooms);

                ImagesContainer = _Property.ContainerID;
                
                lblName.Text = _Property.Name;
                lblShowCountry.Text = await GetCountryNameById(_Property.CountryID);
                lblShowPropertyType.Text = await GetPropertyTypeById(_Property.PropertyTypeID); 
                lblShowAddress.Text = _Property.Address;
                lblShowCity.Text = _Property.City;
                bool DescriptionIsnotNull = !string.IsNullOrEmpty(_Property.PlaceDescription) ? gbBoxDescription.Visible = true : gbBoxDescription.Visible = false;
                lblShowDesc.Visible = DescriptionIsnotNull;
                lblShowDesc.Text = _Property.PlaceDescription ;
                lblShowPrice.Text =  _Property.Price.ToString("0.00");


                int ValidDiscountID =await FindValidOffer(_PropertyID);
                Models.Discount discount;
                if (ValidDiscountID != -1)
                {
                    discount = await GetDiscountInfo(ValidDiscountID);
                    if (discount != null && discount.EndDate >= DateTime.Now)
                    {

                        lblShowPrecentOff.Text = discount.DiscountPercentage.ToString().Substring(0,2) + "%off";
                        
                    }
                    else { 
                        lblShowPrecentOff.Visible = false;
                       
                    }
                }

              

            }
        }

        private async Task< Models.Discount> GetDiscountInfo(int DiscountId)
        {
            return await ApiClient.clsAPIFunctions<Models.Discount>.GetAsync("Discount/getDicountbyID?DicountID=", DiscountId);
        }
       
        private void lblShowCity_Click(object sender, EventArgs e)
        {

        }

        private void ctrlShowPropertyInfo_Load(object sender, EventArgs e)
        {
          gbBoxDescription.Visible = true;
        }
    }
}
