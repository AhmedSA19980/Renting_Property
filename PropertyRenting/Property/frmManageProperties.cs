using ApiClient;
using PropertyRenting.ClassGlobal;
using PropertyRenting.Property.controls;
using PropertyRenting.Property.Discount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Property
{


    public partial class frmManageProperties : Form
    {

        private int ClientId;
        private int PropertyId;
        private int _currentUser = clsGlobal.CurrentUser.ClientID;
        private Task<DataTable> _dtProperties;
        public frmManageProperties()
        {
            InitializeComponent();
            ClientId = _currentUser;
            _dtProperties = GetProperties(ClientId);
            _RefreshPropertiesInfo();
        }


        public async void _RefreshPropertiesInfo()
        {
            try
            {
                _dtProperties = GetProperties(ClientId);
                DataTable dt = await _dtProperties;

                dgvProperties.DataSource = dt;
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
                    { "PropertyId", ("PropertyID", 130) },
                    { "Name", ("Name", 130) },
                    { "CountryName", ("CountryName", 120) },
                    { "City", ("City", 130) },
                    { "Address", ("Address", 150) },
                    { "PropertyTypeName", ("PropertyTypeName", 170) },
                    { "Price", ("Price", 150) },
                    { "PropertyStatus", ("PropertyStatus", 130) }

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


        public async Task<DataTable> GetProperties(int ClientId)
        {
            try
            {
                List<Models.PropertyStatusDTO> PropertiesStatus = await ApiClient.clsAPIFunctions<List<Models.PropertyStatusDTO>>.GetAsync("Property/GetPropertiesAndStatusByClientID?ClientID=", ClientId);

                if (PropertiesStatus == null)
                {
                    return new DataTable(); // Handle null result
                }

                DataTable dt = PropertyRenting.ClassGlobal.clsConvertListToDataTable<Models.PropertyStatusDTO>.ToDataTable(PropertiesStatus);
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
            DataTable dt = await _dtProperties;
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "PropertyID":
                    FilterColumn = "PropertyID";
                    break;

                case "CountryName":
                    FilterColumn = "CountryName";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;

                case "PropertyTypeName":
                    FilterColumn = "PropertyTypeName";
                    break;

                case "PropertyStatus":
                    FilterColumn = "PropertyStatus";
                    break;

                case "Address":
                    FilterColumn = "Address";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvProperties.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PropertyID")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = dgvProperties.Rows.Count.ToString();
        }

        private void TextPropertyId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "PropertyID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private async void ManageProperties_Load(object sender, EventArgs e)
        {


            DataTable dt = await _dtProperties;
            dgvProperties.DataSource = dt;
            cbFilterBy.SelectedIndex = 0;
            lblTotalRecords.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count > 0) CustomiseDataGridView(dgvProperties);

        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            PropertyId = (int)dgvProperties.CurrentRow.Cells[0].Value;
           
            frmAddUpdateProperty fr = new frmAddUpdateProperty(PropertyId);


            fr.ShowDialog();
            _RefreshPropertiesInfo();
        }

        

        private async Task DeletePropertyAsync()
        {
            int PropertyId = (int)dgvProperties.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to Deactivate This Property [" + dgvProperties.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

            
                if (await ApiClient.clsAPIFunctions<int>.DeleteAsync("/Property/", PropertyId) != null)
                {
                    MessageBox.Show("Property deactivated Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPropertiesInfo();
                }

                else
                    MessageBox.Show("Property was not Deactivated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void addOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PropertyId = (int)dgvProperties.CurrentRow.Cells[0].Value;
            CreateUpdateAnOffer frm = new CreateUpdateAnOffer(PropertyId);
            frm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PropertyId = (int)dgvProperties.CurrentRow.Cells[0].Value;
            BookAProperty frm = new BookAProperty(PropertyId);
            frm.ShowDialog(this);
        }

        private async void delToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            await DeletePropertyAsync();
        }
    }
}
