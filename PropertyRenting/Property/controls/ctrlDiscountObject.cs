
using PropertyRenting.ClassGlobal;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Property.controls
{
    public partial class ctrlDiscountObject : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public event EventHandler DataAddOrUpdate;

        Models.Property _Property;
     
        Models.Discount _Offer;
        private int _PropertyID = -1;
        private int _DiscountID = -1;

        public ctrlDiscountObject()
        {
            InitializeComponent();


        }
        public enMode SetMode
        {
            set { _Mode = value; }
            get { return _Mode; }
        }

        public int PropertyID
        {
            get { return _PropertyID; }
            set { _PropertyID = value; }
        }

        public int DiscountID
        {
            set { _DiscountID = value; }
            get { return _DiscountID; }
        }

        public string PercentOFF
        {
            set { txtPercentOff.Text = value; }
            get { return txtPercentOff.Text; }
        }

        public Models.Property PropertyInfo 
        {
            get { return _Property; }
        }
       
        private async Task<bool> _DeleteExisingOffer()
        {
            try {
                if (_Mode == enMode.AddNew)
                {
                    var discountid = await ApiClient.clsAPIFunctions<int>.GetAsync("Discount/getActiveDicountbyPropertyID?PropertyID=", _PropertyID);
                    if (discountid != 0)
                    {
                        if (MessageBox.Show("Active Offer is found, Do you want to Delete the current offer to create new One ?",
                                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            var DeletePrevDiscount = await ApiClient.clsAPIFunctions<string>.DeleteAsync("Discount/Cancel/", discountid);

                            if (DeletePrevDiscount != null)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete existing offer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else return false;


                    }
                    else
                    {
                        return true;
                    }

                }
                else if (_Mode == enMode.Update) return true;
                
                return false;
            
            } catch (Exception ex) {

                Console.WriteLine($"Error deleting existing offer: {ex}");
               
                return false;
            }


          
        }

        private async Task<Models.Discount> LoadDiscountInfo(int  discountId) {
            return await ApiClient.clsAPIFunctions<Models.Discount>.GetAsync("Discount/getDicountbyID?DicountID=", discountId);

        }

        public async void LoadOffereData()
        {
           
            try
            {
                _Offer = await LoadDiscountInfo(_DiscountID);
                if (_Offer != null && _Offer.DiscountID != -1)
                {
                    lblTitle.Text = "Update An Offer";
                    dtpStartDate.Value = _Offer.StartDate;
                    dtpEndDate.Value = _Offer.EndDate;
                    txtPercentOff.Text = Convert.ToString(_Offer.DiscountPercentage);
                    lblPropertyID.Text = _PropertyID.ToString();
                    lblDiscountID.Text = _Offer.DiscountID.ToString();
                    btnCreate.Text = "Update";
                }
                else if (_Offer == null)
                {
                    MessageBox.Show("Failed to load offer data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
              

                Console.WriteLine($"Error loading offer data: {ex}");
                MessageBox.Show("An error occurred while loading offer data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private async Task<Models.Property> LoadDiscountObject()
        {
            var property = await ApiClient.clsAPIFunctions<Models.Property>.GetAsync("Property/GetPropertyByID?PropertyID=", _PropertyID);
            return property;

        }
        private async void ctrlDiscountObject_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            
                 LoadOffereData();
            try
            {
                var property =  await LoadDiscountObject() ;
                if (property != null)
                {
                    lblPropertyID.Text = _PropertyID.ToString();

                }
                else
                {
                    lblPropertyID.Text = "Property ID not found.";
                   
                    clsGlobal.SaveToEventLog("Property data is not found with Provided ID", System.Diagnostics.EventLogEntryType.Error);
                    MessageBox.Show("Failed to load property data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error loading property data: {ex}");
                clsGlobal.SaveToEventLog("Property data is not found with Provided ID" ,System.Diagnostics.EventLogEntryType.Error );
                MessageBox.Show("An error occurred while loading property data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task<bool> GetProperty(int propertyID)
        {
          return  await ApiClient.clsAPIFunctions<Models.Property>.GetAsync("Property/GetPropertyByID?PropertyID=", _PropertyID) != null;
        }

        private  Models.Discount FillDiscountObject()
        {
            var discount = new Models.Discount
            {
                PropertyID = _PropertyID,
                DiscountPercentage = Convert.ToDecimal(txtPercentOff.Text),
                StartDate = Convert.ToDateTime(clsFormat.DateToShort(dtpStartDate.Value)),
                EndDate = Convert.ToDateTime(clsFormat.DateToShort(dtpEndDate.Value))
            };

            return discount;
        }

        private async Task<Models.Discount> AddDiscount(Models.Discount discount)
        {
          return  await ApiClient.clsAPIFunctions<Models.Discount>.PostAsync($"Discount/AddDiscountToProperty?PropertyID={discount.PropertyID}&PrecentOff={discount.DiscountPercentage}&StartDate={discount.StartDate}&EndDate={discount.EndDate}", discount);
        }

        private async Task<Models.Discount> UpdateDiscount(Models.Discount discount)
        {
            discount.DiscountID= _DiscountID;
            return await ApiClient.clsAPIFunctions<Models.Discount>.PutAsync($"Discount/UpdateDiscontById?DiscontId={_DiscountID}", discount);
        }

        private async void btnCreateUpdate_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (await GetProperty(_PropertyID))
                {
                    bool DeleteExistingOfferSucessfully = await _DeleteExisingOffer();

                    if (!DeleteExistingOfferSucessfully) return;
                   

                    var Discount = FillDiscountObject(); 

                    Models.Discount ResultDiscount;
                    if (_Mode == enMode.AddNew)
                    {

                        ResultDiscount = await AddDiscount(Discount); 
                    }
                    else
                    {

                       
                        ResultDiscount = await UpdateDiscount(Discount); 
                        
                    }

                    if (Discount == null)
                    {
                        MessageBox.Show("Offer Failed to create", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;

                    }
                    string result = _Mode == enMode.AddNew ? "Created" : "Update";
                    MessageBox.Show($"Offer {result} Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DataAddOrUpdate != null) DataAddOrUpdate(this, EventArgs.Empty);
                    lblDiscountID.Text = ResultDiscount.DiscountID.ToString();
                    txtPercentOff.Text = "";
                    btnCreate.Enabled = false;
                    _Mode = enMode.Update;
                  

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                clsGlobal.SaveToEventLog($"error{ex.Message}" , System.Diagnostics.EventLogEntryType.Error);
            }


        }

      

        private void txtPercentOff_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPercentOff.Text.Trim()))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtPercentOff, "Precent Off! City cannot be blank");
                return;
            }

            else
            {
                errorProvider1.SetError(txtPercentOff, null);
            };
        }

        private void txtPercentOff_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)  )
                e.Handled = true;
           
        }
    }
}
