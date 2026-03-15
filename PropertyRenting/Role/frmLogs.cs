using Models;
using PropertyRenting.Property;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Role
{
    public partial class frmLogs : Form
    {


        private Task<DataTable> _dtLogs;

        public frmLogs()
        {
            InitializeComponent();
            _dtLogs = GetRoleLogs();
        }

        public async void _RefreshLogs()
        {
            try
            {
                _dtLogs = GetRoleLogs();
                DataTable dt = await _dtLogs;

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
                    { "Id", ("Id", 130) },
                    { "AdminCommiteeId", ("AdminCommiteeId", 130) },
                    { "AdminCommiteeName", ("AdminCommiteeName", 120) },
                    { "RecipientId", ("RecipientId", 130) },
                    { "RecipientName", ("RecipientName", 150) },
                    { "OldRole", ("OldRole", 170) },
                    { "RecipientRole", ("RecipientRole", 150) },
                    { "DateRoleModified", ("DateRoleModified", 130) },
                     { "Report", ("Report", 130) }

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
        public async Task<DataTable> GetRoleLogs()
        {
            try
            {
                List<Models.RoleLogs> RoleLogs = await ApiClient.clsAPIFunctions<List<Models.RoleLogs>>.GetAsync("Role/RoleLogs");

                if (RoleLogs == null)
                {
                    return new DataTable(); 
                }

                DataTable dt = PropertyRenting.ClassGlobal.clsConvertListToDataTable<Models.RoleLogs>.ToDataTable(RoleLogs);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Getting All Properties !: {ex.Message}");
                return new DataTable(); 

            }
        }

        private void TextLogsId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Id" || cbFilterBy.Text == "AdminCommiteeId")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private async void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = await _dtLogs;
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Id":
                    FilterColumn = "Id";
                    break;

                case "AdminCommiteeId":
                    FilterColumn = "AdminCommiteeId";
                    break;

                case "AdminCommiteeName":
                    FilterColumn = "AdminCommiteeName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvProperties.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "Id" || FilterColumn == "AdminCommiteeId")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = dgvProperties.Rows.Count.ToString();
        }

        private async void frmLogs_Load(object sender, EventArgs e)
        {
            DataTable dt = await _dtLogs;
            dgvProperties.DataSource = dt;
            cbFilterBy.SelectedIndex = 0;
            lblTotalRecords.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count > 0) CustomiseDataGridView(dgvProperties);

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LogId = (int)dgvProperties.CurrentRow.Cells[0].Value;
            frmShowRoleLogs frm = new frmShowRoleLogs(LogId);
            frm.ShowDialog(this);
        }
    }
}
