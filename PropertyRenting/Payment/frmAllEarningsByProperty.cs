using Models;
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
    public partial class frmAllEarningsByProperty : Form
    {

       // private int ClientId;
        private int _PropertyId;
      //  private int _currentUser = clsGlobal.CurrentUser.ClientID;
        private Task<DataTable> _dtEarningsByProperty;
        public frmAllEarningsByProperty(int propertyId)
        {
            InitializeComponent();
         
            _PropertyId = propertyId;
            _dtEarningsByProperty = GetEarningsByProperty(propertyId);
            _RefreshPropertiesInfo();
        }



        public async void _RefreshPropertiesInfo()
        {
            try
            {
                _dtEarningsByProperty = GetEarningsByProperty(_PropertyId);
                DataTable dt = await _dtEarningsByProperty;

                dgvEarningsByProperty.DataSource = dt;
                if (dt != null)
                {


                    lblTotalRecords.Text = dt.Rows.Count.ToString();
                }
                else
                {

                    lblTotalRecords.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Earnings Records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalRecords.Text = "Error"; // show error.
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "None")
            {

                txtFilterValue.Visible = false;

            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();

            }

        }

        private void TextPropertyId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Property ID" || cbFilterBy.Text == "Booking ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void CustomiseDataGridView(DataGridView dataGridView)
        {
            Dictionary<string, (string headerText, int width)> columnSettings = new Dictionary<string, (string, int)>
                {
                    { "ClientID", ("ClientID", 130) },
                    { "PropertyID", ("PropertyID", 130) },
                    { "CountryName", ("CountryName", 130) },
                    { "Price", ("Price", 120) },
                    { "DiscountPer", ("DiscountPer", 130) },
                    { "Name", ("Name", 150) },
                    { "IsPropertyDeleted", ("IsPropertyDeleted", 100) },
                    { "StartDate", ("StartDate", 150) },
                    { "EndDate", ("EndDate", 150) },
                    { "bookingByClientId", ("bookingByClientId", 100) },
                    { "PaymentStaus", ("PaymentStaus", 130) },
                    { "PricePerDay", ("PricePerDay", 130) },
                    { "PriceAfterDiscount", ("PriceAfterDiscount", 130) },
                    { "TotalAmount", ("TotalAmount", 130) },
                    { "PaidDate", ("PaidDate", 130) },
                    { "BookingID", ("BookingID", 130) },

                };


            foreach (var columnSetting in columnSettings)
            {

                if (dataGridView.Columns.Contains(columnSetting.Key))
                {

                    dataGridView.Columns[columnSetting.Key].HeaderText = columnSetting.Value.headerText;
                    dataGridView.Columns[columnSetting.Key].Width = columnSetting.Value.width;

                }
            }

        }

        public async Task<DataTable> GetEarningsByProperty(int PropertyId)
        {
            try
            {
                //Earning/GetTotalIncomeByProperty?PropertyId=
                List<Models.AllEarningsByProperty> EarningRecords = await ApiClient.clsAPIFunctions<List<Models.AllEarningsByProperty>>.GetAsync("Earning/GetAllOwnerEarningsByProperty?PropertyID=", PropertyId);
               
                if (EarningRecords == null)
                {
                    return new DataTable(); // Handle null result
                }

                DataTable dt = PropertyRenting.ClassGlobal.clsConvertListToDataTable<Models.AllEarningsByProperty>.ToDataTable(EarningRecords);

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Getting All Properties !: {ex.Message}");
                return new DataTable(); // Handle exceptions

            }
        }

        private async void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = await _dtEarningsByProperty;
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Start Date":
                    FilterColumn = "startDate";
                    break;

                case "End Date":
                    FilterColumn = "endDate";
                    break;

                case "Paid Date":
                    FilterColumn = "PaidDate";

                    break;

                case "Booking ID":
                    FilterColumn = "BookingID";

                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvEarningsByProperty.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "BookingID")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("CONVERT([{0}], 'System.String') LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = dgvEarningsByProperty.Rows.Count.ToString();
        }
        private async void frmAllEarningsByProperty_Load(object sender, EventArgs e)
        {
            DataTable dt = await _dtEarningsByProperty;
            dgvEarningsByProperty.DataSource = dt;
            cbFilterBy.SelectedIndex = 0;
            lblTotalRecords.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count > 0) { CustomiseDataGridView(dgvEarningsByProperty);

                decimal Total = await ApiClient.clsAPIFunctions<decimal>.GetAsync("Earning/GetTotalIncomeByProperty?PropertyId=", _PropertyId);
                lblInCome.Text = Total.ToString("0.00");
            }
            else
            {
                MessageBox.Show($"You don't Have any Earnings Records :", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void showBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingId = (int)dgvEarningsByProperty.CurrentRow.Cells[15].Value;
            frmBill frm = new frmBill(BookingId);
            frm.ShowDialog();
        }
    }
}
