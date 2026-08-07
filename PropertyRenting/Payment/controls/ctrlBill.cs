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
    public partial class ctrlBill : UserControl
    {
        public ctrlBill()
        {
            InitializeComponent();
        }
    
        private void _RestValues()
        {
            lblCountryName.Text = "???";
            lblCustomerID.Text = "???";
            lblDiscount.Text = "???";
            lblExDate.Text = "???";
            lblName.Text = "???";
            lblNote.Text = "???";
            lblOriginalPrice.Text = "???";
            lblPaidDate.Text = "???";
            lblPaymentId.Text = "???";
            lblPaymentStatus.Text = "???";
            lblPropertyTypeName.Text = "???";
            lblStDate.Text = "???";
           lblTotal.Text = "???";  
        }


        public async Task LoadBillInfo(int BookingID)
        {

            var Bill = await ApiClient.clsAPIFunctions<Models.PaymentDetail>.GetAsync("Payment/GetPaymentDetailByBookingId?BookingId=", BookingID);
            if (Bill != null)
            {

                lblCountryName.Text = Bill.CountryName;
                lblCustomerID.Text = Bill.BookedByClientId.ToString();
                lblDiscount.Text = Bill.DiscountPer;
                lblExDate.Text = Bill.EndDate.ToString();
                lblName.Text = Bill.Name;
                lblNote.Text = Bill.Note == "" ? "." : Bill.Note;
                lblOriginalPrice.Text = Bill.OriginalPrice.ToString("0.00");
                lblPaidDate.Text = Bill.PaidDate.ToString();
                lblPaymentId.Text = Bill.Id.ToString();
                lblPaymentStatus.Text = Bill.PaymentStatus;
                lblPropertyTypeName.Text = Bill.PropertyTypeName;
                lblStDate.Text = Bill.StartDate.ToString();
                lblTotal.Text = Bill.TotalAmount.ToString("0.00");
                lblBooking_ID.Text = Bill.BookingID.ToString();
                lblPricePerDay.Text = Bill.PricePerDay.ToString("0.00");

            }
            else _RestValues();

        }
    }
}
