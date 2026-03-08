
using Models;
using PropertyRenting.ClassGlobal;
using PropertyRenting.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Property
{
    public partial class frmAddUpdateProperty : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private Models.Property _Property = new Models.Property(); 
        private Models.Container _Images = new Models.Container(); 
        private int _PropertyID = -1;
        private int _ContainerID = -1;
        public frmAddUpdateProperty()
        {
            InitializeComponent();
        }


        public frmAddUpdateProperty(int PropertyID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PropertyID = PropertyID;



        }

      

        private async void _FillCountriesInComoboBox()
        {
            try
            {
                List<Models.Country> countries = await ApiClient.clsAPIFunctions<List<Models.Country>>.GetAsync("Country/All"); ;
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

        private async void _FillPropertiesTypeInCombox()
        {
            
            try
            {
                List<Models.PropertyType> PropertyTypes = await ApiClient.clsAPIFunctions<List<Models.PropertyType>>.GetAsync("PropertyType/All"); ;
                if (PropertyTypes != null)
                {
                    DataTable dtPropertyType = PropertyRenting.ClassGlobal.clsConvertListToDataTable<Models.PropertyType>.ToDataTable(PropertyTypes);
                    foreach (DataRow row in dtPropertyType.Rows)
                    {

                        cbPropertyType.Items.Add(row["PropertyTypeName"]);

                    }
                }

            }
            catch (Exception ex)
            {
                clsGlobal.SaveToEventLog($"{ex.Message}", EventLogEntryType.Error);
            }

        }

        private void btnDownload9_Click(object sender, EventArgs e)
        {
            LLopenFileDialog_Click(sender, e, pbNine, btnDelete_9);
        }

        private void ValidateEmptyImagepath()
        {

            _Images.ImageFourPath = pbFour.ImageLocation != null ? pbFour.ImageLocation : "";

            _Images.ImageFivePath = pbFive.ImageLocation != null ? pbFive.ImageLocation : "";

            _Images.ImageSixPath = pbSix.ImageLocation != null ? pbSix.ImageLocation : "";

            _Images.ImageSevenPath = pbSeven.ImageLocation != null ? pbSeven.ImageLocation : "";

            _Images.ImageEightPath = pbEight.ImageLocation != null ? pbEight.ImageLocation : "";

            _Images.ImageNinePath = pbNine.ImageLocation != null ? pbNine.ImageLocation : "";



        }



     
        private void LLopenFileDialog_Click(object sender, EventArgs e, PictureBox Photo, Button BtnRemoveImage)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {



                string selectedFilePath = openFileDialog1.FileName;


                Photo.Load(selectedFilePath);

                BtnRemoveImage.Visible = true;
            }


        }

        private void btnDownload_1_Click(object sender, EventArgs e)
        {
            LLopenFileDialog_Click(sender, e, pbOne, btnDelete_1);
        }

        private void btnDelete_1_Click(object sender, EventArgs e)
        {
            pbOne.ImageLocation = null;
            btnDelete_1.Visible = false;
            pbOne.Image = Resources.info;
        }

        private void ValidateEmptyPictureBoxIcon(PictureBox pictureBox, Button button)
        {
            if (_Mode == enMode.Update)
            {
                if (pictureBox.ImageLocation == "" || pictureBox.Image == Resources.info)
                {

          
                    button.Visible = false;
                    return;
                }
            }
            else
            {
              
                if (pictureBox.ImageLocation == null)
                {
                  
                    button.Visible = false;
                    return;
                }
            }


            button.Visible = true;
        }
        private async void _LoadPropertyData()
        {
            try
            {
              
                _Mode = enMode.Update;


                _Property = await ApiClient.clsAPIFunctions<Models.Property>.GetAsync("Property/GetPropertyByID?PropertyID=", _PropertyID);

            
                if (_Property != null)
                {
                    _PropertyID = _Property.PropertyID;

                    lblPropertyID.Text = _Property.PropertyID.ToString();
                    cbCountry.SelectedIndex = _Property.CountryID - 1;
                    cbBathrooms.SelectedIndex = _Property.NumberOfBathrooms ;
                    cbBedrooms.SelectedIndex = _Property.NumberOfBedrooms ;
                    cbPropertyType.SelectedIndex = _Property.PropertyTypeID-1;
                    txtDescription.Text = _Property.PlaceDescription ;
                
                    _Images = await ApiClient.clsAPIFunctions<Models.Container>.GetAsync("Container/GetContainerByID?ContainerID=", _Property.ContainerID);
                    if (_Images != null)
                    {

                        pbOne.ImageLocation = _Images.ImageOnePath;
                        pbTwo.ImageLocation = _Images.ImageTwoPath;
                        pbThree.ImageLocation = _Images.ImageThreePath;
                        pbFour.ImageLocation = _Images.ImageFourPath;
                        pbFive.ImageLocation = _Images.ImageFivePath;
                        pbSix.ImageLocation = _Images.ImageSixPath;
                        pbSeven.ImageLocation = _Images.ImageSevenPath;
                        pbEight.ImageLocation = _Images.ImageEightPath;
                        pbNine.ImageLocation = _Images.ImageNinePath;
                    }
                    groupBox1.Text = string.Concat("Container number is  ", _Property.ContainerID);
                    _ContainerID = _Property.ContainerID;
                    txtAddress.Text = _Property.Address;
                    txtCity.Text = _Property.City;
                    txtDescription.Text = _Property.PlaceDescription;
                    txtPropertyPrice.Text = Convert.ToString(_Property.Price) != "0" ? Convert.ToString(_Property.Price) : "0";
                    txtName.Text = _Property.Name;

                }
                else
                {
                    MessageBox.Show($"Property not found with id{_Property.PropertyID}", "Error", MessageBoxButtons.OK);
                }


            }
            catch (Exception ex)
            {

                clsGlobal.SaveToEventLog($"{ex.Message}", EventLogEntryType.Error);
            }
        }
        private void frmAddUpdateProperty_Load(object sender, EventArgs e)
        {
            _FillCountriesInComoboBox();
            _FillPropertiesTypeInCombox();
            _ResetPropertyValues();
            if (_Mode == enMode.Update)
                _LoadPropertyData();




            ValidateEmptyPictureBoxIcon(pbOne, btnDelete_1);
            ValidateEmptyPictureBoxIcon(pbTwo, btnDelete_2);
            ValidateEmptyPictureBoxIcon(pbThree, btnDelete_3);
            ValidateEmptyPictureBoxIcon(pbFour, btnDelete_4);
            ValidateEmptyPictureBoxIcon(pbFive, btnDelete_5);
            ValidateEmptyPictureBoxIcon(pbSix, btnDelete_6);
            ValidateEmptyPictureBoxIcon(pbSeven, btnDelete_7);
            ValidateEmptyPictureBoxIcon(pbEight, btnDelete_8);
            ValidateEmptyPictureBoxIcon(pbNine, btnDelete_9);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ResetPropertyValues()
        {

          
            if (_Mode == enMode.AddNew)
            {


                lblTitle.Text = "Add New Property";
                _Property = new Models.Property
                {
                };
                _Images = new Models.Container
                {
                };

            }
            else
            {
                lblTitle.Text = "Update Property";
            }


            txtAddress.Text = "";
            txtCity.Text = "";
            txtDescription.Text = "";
            txtPropertyPrice.Text = "";
            pbOne.Image = Resources.info;
            pbTwo.Image = Resources.info;
            pbThree.Image = Resources.info;
            pbFour.Image = Resources.info;
            pbFive.Image = Resources.info;
            pbSix.Image = Resources.info;
            pbSeven.Image = Resources.info;
            pbEight.Image = Resources.info;
            pbNine.Image = Resources.info;
        }

        private async Task<(int  ,  sbyte)> LoadLookupDataAsync( ) {

            var CountryIdTask =  ApiClient.clsAPIFunctions<int>.GetAsync("Country/CountryName?Name=", cbCountry.Text);
            var PropertyTypeIdTask=  ApiClient.clsAPIFunctions<int>.GetAsync("PropertyType/PropertyName?PropertyTypeName=", cbPropertyType.Text);  

            await Task.WhenAll(CountryIdTask ,  PropertyTypeIdTask);

            return (CountryIdTask.Result, (sbyte)PropertyTypeIdTask.Result);
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren())
                {
                    return;
                }

                if (ValidatePictureBox(pbOne)) return;

                if (ValidatePictureBox(pbTwo)) return;

                if (ValidatePictureBox(pbThree)) return;


                await SaveProperty();
           
             

            }
            catch (Exception ex)
            {

                clsGlobal.SaveToEventLog($"{ex.Message}", EventLogEntryType.Error);

            }

        }

        private async Task SaveProperty()
        {

            var (countryId, PropertyTypeId) = await LoadLookupDataAsync();

            var container = BuildContainerFromUI();
            ValidateEmptyImagepath();
            var saveContainer =await SaveContainerAsync(container);


            var Property = BuildPropertyFromUI(countryId, (byte)PropertyTypeId , _ContainerID);


            var saveProperty =await SavePropertyAsync(Property);


       
            if(saveProperty == null || saveProperty.PropertyID ==-1)
            {
                await ApiClient.clsAPIFunctions<string>.DeleteAsync("Container/DeleteContainerImages?ContainerId=", _ContainerID);
                MessageBox.Show("Property Failed to Create !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Result = _Mode == enMode.AddNew ? "Created" : "Update";
            MessageBox.Show($"Property's {Result} Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mode = enMode.Update;
            lblTitle.Text = "Update Property";
            lblPropertyID.Text = saveProperty.PropertyID.ToString();
            _PropertyID = saveProperty.PropertyID;



        }

        private Models.Property BuildPropertyFromUI(int CountryId , byte PropertyTypeId , int containerid )
        {
            Models.Property _Property = new Models.Property
            {

                CountryID = CountryId,
                Address = txtAddress.Text,
                City = txtCity.Text,
                PlaceDescription = string.IsNullOrWhiteSpace(txtDescription.Text) ? "" : txtDescription.Text,
                Price = Convert.ToDecimal(txtPropertyPrice.Text),
                ContainerID = containerid,
                NumberOfBedrooms = byte.Parse( cbBedrooms.SelectedIndex.ToString()),
                NumberOfBathrooms = byte.Parse( cbBathrooms.SelectedIndex.ToString()),
                PropertyTypeID = PropertyTypeId,

                Name = txtName.Text,


            };

            return  _Property;
        }

        private Models.Container BuildContainerFromUI()
        {
            Models.Container _Images = new Models.Container
            {

                ImageOnePath = pbOne.ImageLocation,
                ImageTwoPath = pbTwo.ImageLocation,
                ImageThreePath = pbThree.ImageLocation,


                ImageFourPath = pbFour.ImageLocation,
                ImageFivePath = pbFive.ImageLocation,
                ImageSixPath = pbSix.ImageLocation,
                ImageSevenPath = pbSeven.ImageLocation,
                ImageEightPath = pbEight.ImageLocation,
                ImageNinePath = pbNine.ImageLocation,

            };
            

            return _Images;
        }

        private async Task<Models.Container> SaveContainerAsync(Models.Container Container)
        {

            var result = _Mode == enMode.AddNew ? await ApiClient.clsAPIFunctions<Models.Container>.AddMediaAsync("Container/AddContainer", Container)
                        : await ApiClient.clsAPIFunctions<Models.Container>.PutMediaAsync($"Container/UpdateContainer?containerid=", _ContainerID, Container);
            _ContainerID = result.ContainerID;
            return result;
        }

        private async Task<Models.Property> SavePropertyAsync(Models.Property Property)
        {
            var result = new Models.Property { }  ;
            if (_Mode  == enMode.AddNew)
            {
                result = await ApiClient.clsAPIFunctions<Models.Property>
                           .PostAsync("Property/Add", Property);
                _PropertyID = result.PropertyID;

            }
            else
            {
               
                result.PropertyID = _PropertyID;
                result.ContainerID = _ContainerID;

                Property.ContainerID = _ContainerID;
                Property.PropertyID = _PropertyID;
                await ApiClient.clsAPIFunctions<Models.Property>.PutAsync("Property/UpdateProperty", Property);
               
            }
           
                           
           
            return result;
        }

           
      
        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCity, "Field! City cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCity, null);
            };



        }

     

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "Address! City cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAddress, null);
            };
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidations.IsNumber(txtPropertyPrice.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPropertyPrice, "Invalid Number.");
            }else if(string.IsNullOrEmpty(txtPropertyPrice.Text)){
                e.Cancel = true;
                errorProvider1.SetError(txtPropertyPrice, "you must set price  !.");
            }
            else
            {
                errorProvider1.SetError(txtPropertyPrice, null);
            };
        }

        private void txtPropertyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private bool ValidatePictureBox(PictureBox ImageContainer)
        {

       
            if (ImageContainer.ImageLocation == null)
            {

                errorProvider1.SetError(ImageContainer, "Image cannot be empty! Set An Images");
                return true;
            }
            else
            {
                errorProvider1.SetError(ImageContainer, "");
                return false;
            }


        }

        private void btnDownload_2_Click(object sender, EventArgs e)
        {
            ImageFormat.LLopenFileDialog_Click(sender, e, pbTwo, btnDelete_2, openFileDialog1);
        }

        private void btnDelete_2_Click(object sender, EventArgs e)
        {
            pbTwo.ImageLocation = null;
            btnDelete_2.Visible = false;
            pbTwo.Image = Resources.info;
        }

        private void btnDownload_3_Click(object sender, EventArgs e)
        {
        
            ImageFormat.LLopenFileDialog_Click(sender, e, pbThree, btnDelete_3, openFileDialog1);
        }

        private void btnDelete_3_Click(object sender, EventArgs e)
        {
            pbThree.ImageLocation = null;
            btnDelete_3.Visible = false;
            pbThree.Image = Resources.info;
        }

        private void btnDownload_4_Click(object sender, EventArgs e)
        {

      
            ImageFormat.LLopenFileDialog_Click(sender, e, pbFour, btnDelete_4, openFileDialog1);
        }

        private void btnDelete_4_Click(object sender, EventArgs e)
        {

            pbFour.ImageLocation = null;
            btnDelete_4.Visible = false;
            pbFour.Image = Resources.info;

        }

        private void btnDownload_5_Click(object sender, EventArgs e)
        {
        
            ImageFormat.LLopenFileDialog_Click(sender, e, pbFive, btnDelete_5, openFileDialog1);
        }

        private void btnDelete_5_Click(object sender, EventArgs e)
        {

            pbFive.ImageLocation = null;
            btnDelete_5.Visible = false;
            pbFive.Image = Resources.info;
        }

        private void btnDownload_6_Click(object sender, EventArgs e)
        {
           
            ImageFormat.LLopenFileDialog_Click(sender, e, pbSix, btnDelete_6, openFileDialog1);
        }

        private void btnDelete_6_Click(object sender, EventArgs e)
        {

            pbSix.ImageLocation = null;
            btnDelete_6.Visible = false;
            pbSix.Image = Resources.info;
        }

        private void btnDownload_7_Click(object sender, EventArgs e)
        {
         
            ImageFormat.LLopenFileDialog_Click(sender, e, pbSeven, btnDelete_7, openFileDialog1);
        }

        private void btnDelete_7_Click(object sender, EventArgs e)
        {

            pbSeven.ImageLocation = null;
            btnDelete_7.Visible = false;
            pbSeven.Image = Resources.info;
        }

        private void btnDownload_8_Click(object sender, EventArgs e)
        {
          
            ImageFormat.LLopenFileDialog_Click(sender, e, pbEight, btnDelete_8, openFileDialog1);
        }

        private void btnDelete_8_Click(object sender, EventArgs e)
        {

            pbEight.ImageLocation = null;
            btnDelete_8.Visible = false;
            pbEight.Image = Resources.info;
        }

        private void btnDelete_9_Click(object sender, EventArgs e)
        {

            pbNine.ImageLocation = null;
            btnDelete_9.Visible = false;
            pbNine.Image = Resources.info;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
