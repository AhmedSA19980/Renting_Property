using ApiClient;
using Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Property.Discount
{


    public partial class CreateUpdateAnOffer : Form
    {


        private int _PropertyID;
        private int _DiscountID;



        private   Task<DataTable> _dtDiscount;
        public    CreateUpdateAnOffer(int PropertyID, int DiscountID = -1)
        {
            InitializeComponent();

            if (DiscountID != -1)
            {
                ctrlDiscountObject4.SetMode = controls.ctrlDiscountObject.enMode.Update;

            }
            ctrlDiscountObject4.DataAddOrUpdate += ctrlDiscountObject4_DataAddOrUpdate;
            _PropertyID = PropertyID;
            ctrlDiscountObject4.PropertyID = PropertyID;
            ctrlDiscountObject4.DiscountID = DiscountID;
            _DiscountID = DiscountID;
            _dtDiscount = GetHistoryOfPropertysDiscounts(_PropertyID);
          
             _RefreshDiscountInfo();
        }

 


       
        public async Task< DataTable> GetHistoryOfPropertysDiscounts(int PropertyID)
        {
            try
            {
             List<Models.PropertyDiscount>  DiscountDetail = await ApiClient.clsAPIFunctions<List<Models.PropertyDiscount>>.GetAsync("Discount/GetAllDiscountsBelongToAproperty?PropertyID=", PropertyID);

                if (DiscountDetail == null)
                {
                    return new DataTable(); 
                }

                DataTable dt = PropertyRenting.ClassGlobal.clsConvertListToDataTable<Models.PropertyDiscount>.ToDataTable(DiscountDetail);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetHistoryOfPropertysDiscounts: {ex.Message}");
                return new DataTable(); 

            }
        }


       

        public async  void _RefreshDiscountInfo()
        {
            try
            {
                _dtDiscount = GetHistoryOfPropertysDiscounts(_PropertyID);
                DataTable dt = await _dtDiscount;

                dgvDiscounts.DataSource = dt;
                if (dt != null)
                {


                    lblTotalRecords.Text = dt.Rows.Count.ToString();
                }else
                {

                    lblTotalRecords.Text = "0";
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error refreshing discounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalRecords.Text = "Error"; 
            }
        }

        private async void CreateUpdateAnOffer_Load(object sender, EventArgs e)
        {
       
            DataTable dt = await _dtDiscount;
            dgvDiscounts.DataSource = dt;
            cbFilterBy.SelectedIndex = 0;
            lblTotalRecords.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count > 0)
            {

                CustomiseDataGridView(dgvDiscounts);

            }
            
        }

        private  void CustomiseDataGridView(DataGridView dataGridView)
        {
            Dictionary<string, (string headerText, int width)> columnSettings = new Dictionary<string, (string, int)>
                {
                    { "DiscountID", ("Discount ID", 110) },
                    { "PropertyID", ("Property ID", 110) },
                    { "Country", ("Country", 120) },
                    { "City", ("City", 120) },
                    { "Address", ("Address", 140) },
                    { "PropertyOriginalPrice", ("Property_Original_Price", 150) },
                    { "DiscountPercentage", ("Discount Precentage", 150) },
                    { "StartDate", ("Start Date", 100) },
                    { "EndDate", ("End Date", 100) },
                    { "IsCompeleted", ("Is Compeleted", 100) },
                    { "IsPropertyDeleted", ("Is_Property_Deleted", 120) }
                };


            foreach (var columnSetting in columnSettings) {

                if (dataGridView.Columns.Contains(columnSetting.Key)) { 
                
                    dataGridView.Columns[columnSetting.Key].HeaderText = columnSetting.Value.headerText;
                    dataGridView.Columns[columnSetting.Key].Width = columnSetting.Value.width;
                }
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text != "None")
            {
                if (cbFilterBy.Text == "IsCompeleted")
                {
                    txtFilterValue.Visible = false;
                    cbIsCompleted.Visible = true;
                    cbIsCompleted.Focus();
                    cbIsCompleted.SelectedIndex = 0;
                }
                else
                {

                    
                    txtFilterValue.Visible = true;

                    cbIsCompleted.Visible = false;
                    txtFilterValue.Text = "";
                    txtFilterValue.Focus();

                }


            }
            else
            {
                txtFilterValue.Visible = false;
                cbIsCompleted.Visible = false;
            }

        }

        private async void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = await _dtDiscount;
            string FilterColumn = "";
           
            switch (cbFilterBy.Text)
            {
                case "DiscountID":
                    FilterColumn = "DiscountID";
                    break;

                case "Discount Percentage":
                    FilterColumn = "DiscountPercentage";
                    break;

                case "IsCompeleted":
                    FilterColumn = "IsCompeleted";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

           
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDiscounts.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DiscountID" || FilterColumn == "DiscountPercentage")
            

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
           

            lblTotalRecords.Text = dgvDiscounts.Rows.Count.ToString();
        }

        private void CreateUpdateAnOffer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "DiscountID" || cbFilterBy.Text == "Discount Percentage")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void cbFilterByComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = await _dtDiscount;
            string FilterColumn = "IsCompeleted";
            string FilterValue = cbIsCompleted.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                dt.DefaultView.RowFilter = "";
            else
         
                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblTotalRecords.Text = dt.Rows.Count.ToString();
        }

        private async Task<int> GetPropertyId(int propertyID)
        {
            return await clsAPIFunctions<int>.GetAsync("Property/GetPropertyID?PropertyID=", propertyID);
        }

        private async Task<int> GetDiscountId(int discountId)
        {
            return await clsAPIFunctions<int>.GetAsync("Property/GetPropertyID?PropertyID=", discountId);
        }

        private async Task<bool> RemoveDiscount(int discountId)
        {
            return ApiClient.clsAPIFunctions<string>.DeleteAsync("Discount/Cancel/", discountId) != null;
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

            int PropertyId =await GetPropertyId(_PropertyID); 

            int getDiscountId = (int)dgvDiscounts.CurrentRow.Cells[0].Value;
            int discountId =await GetDiscountId(getDiscountId) ;


       
            ctrlDiscountObject4.DiscountID = discountId;
            ctrlDiscountObject4.PropertyID = PropertyId;

            CreateUpdateAnOffer fr = new CreateUpdateAnOffer(PropertyId, discountId);

            fr.ShowDialog();


        }

      
        private async void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DiscountID = (int)dgvDiscounts.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to Deactivate This Offer [" + dgvDiscounts.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

             
                if ( await RemoveDiscount(DiscountID) )
                {
                    MessageBox.Show("Offer deactivated Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshDiscountInfo();
                }

                else
                    MessageBox.Show("Offer was not Deactivated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DiscountID = (int)dgvDiscounts.CurrentRow.Cells[0].Value;
            frmShowOffer frm = new frmShowOffer(DiscountID);
            frm.ShowDialog();
        }

        private void cmMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updateToolStripMenuItem.Enabled = (int)dgvDiscounts.CurrentRow.Cells[0].Value != -1;
            delToolStripMenuItem.Enabled = (int)dgvDiscounts.CurrentRow.Cells[0].Value != -1;

            bool isCompeleted = Convert.ToBoolean(dgvDiscounts.CurrentRow.Cells["IsCompeleted"].Value);
            updateToolStripMenuItem.Enabled = !isCompeleted;
            delToolStripMenuItem.Enabled = !isCompeleted;
        }

        private void ctrlDiscountObject4_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDiscountObject4_DataAddOrUpdate(object sender, EventArgs e)
        {
            _RefreshDiscountInfo();
        }
    }
}
