using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Payment.controls
{
    public partial class ctrlTotalIncomeByPeriod : UserControl
    {
        private int _ClientID; 

        public int ClientId { get { return _ClientID; } }
        public ctrlTotalIncomeByPeriod()
        {
            InitializeComponent();
        }

        public async Task LoadTotalIncomeInfo(Models.IncomesByPeriodsValues Values)
        {
            _ClientID = Values.ClientId;

            var TotalIncome = await ApiClient.clsAPIFunctions<Models.IncomesByPeriod>.PostAsync("Earning/SettleClientIncomeByPeriod", Values);
            // clsDiscount Bill = clsDiscount.Find(BookingID);
            if (TotalIncome != null)
            {

                lblTotalIncome.Text = TotalIncome.TotalIncome.ToString("0.00");
                lblFee.Text = TotalIncome.Fee.ToString("0.00");
                lblTax.Text = TotalIncome.Tax.ToString("0.00");
                lblNet.Text = TotalIncome.NetAfterTaxAndFee.ToString("0.00");

            }
            else {
                _RestValues();
                MessageBox.Show($"Data Records not found with ClientID {_ClientID}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                    
              };

        }

        private void _RestValues()
        {

            lblTotalIncome.Text ="??";
            lblFee.Text = "??";
            lblTax.Text ="??";
            lblNet.Text = "??";
        }


    }
}
