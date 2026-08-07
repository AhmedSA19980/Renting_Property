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
    public partial class frmClientPayments : Form
    {
        private int ClientId;
        private int PropertyId;
        private int _currentUser = clsGlobal.CurrentUser.ClientID;
        private Task<DataTable> _dtPayments;
        public frmClientPayments()
        {
            InitializeComponent();
            ClientId = _currentUser;
            _dtPayments = GetProperties(ClientId);
            _RefreshPropertiesInfo();

        }


        public async void _RefreshPropertiesInfo()
        {
            try
            {
                _dtPayments = GetProperties(ClientId);
                DataTable dt = await _dtPayments;

                dgvPayments.DataSource = dt;
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
                MessageBox.Show($"Error refreshing discounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalRecords.Text = "Error"; // show error.
            }
        }


        private void CustomiseDataGridView(DataGridView dataGridView)
        {
            Dictionary<string, (string headerText, int width)> columnSettings = new Dictionary<string, (string, int)>
                {
                    { "ID", ("ID", 130) },
                    { "startDate", ("startDate", 130) },
                    { "EndDate", ("EndDate", 120) },
                    { "PricePerDay", ("PricePerDay", 130) },
                    { "totalAmount", ("TotalAmount", 150) },
                    { "PropertyTypeName", ("PropertyTypeName", 170) },
                    { "Name", ("Name", 150) },
                    { "PaymentStatus", ("PaymentStatus", 130) },
                     { "Note", ("Note", 130) },
                      { "PaidDate", ("PaidDate", 130) },
                      { "BookingID", ("BookingID", 130) },
                      { "ClientID", ("ClientID", 130) },

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
            if (cbFilterBy.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public async Task<DataTable> GetProperties(int ClientId)
        {
            try
            {
                List<Models.ClientPayment> PaymentsRecords = await ApiClient.clsAPIFunctions<List<Models.ClientPayment>>.GetAsync("Payment/GetAllPaymentsByClientID?ClientID=", ClientId);

                if (PaymentsRecords == null)
                {
                    return new DataTable(); // Handle null result
                }

                DataTable dt = PropertyRenting.ClassGlobal.clsConvertListToDataTable<Models.ClientPayment>.ToDataTable(PaymentsRecords);
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
            DataTable dt = await _dtPayments;
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "ID":
                    FilterColumn = "ID";
                    break;

                case "startDate":
                    FilterColumn = "startDate";
                    break;

                case "EndDate":
                    FilterColumn = "EndDate";

                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvPayments.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("CONVERT([{0}], 'System.String') LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = dgvPayments.Rows.Count.ToString();
        }

        private async void ClientPayments_Load(object sender, EventArgs e)
        {

            DataTable dt = await _dtPayments;
            
            dgvPayments.DataSource = dt;
            cbFilterBy.SelectedIndex = 0;
            lblTotalRecords.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count > 0) CustomiseDataGridView(dgvPayments);
            else
            {
                MessageBox.Show($"You don't Have any Payment Records :", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }


        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingId =  (int)dgvPayments.CurrentRow.Cells[10].Value;
            frmBill frm = new frmBill(BookingId);
            frm.ShowDialog();
        }
    }
}
