using ApiClient;
using Models;
using PropertyRenting.ClassGlobal;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropertyRenting.Reservation
{
    public partial class frmAddUpdateReservation : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };
        private enMode _Mode = enMode.AddNew;

        private int _ReservationID;
        private int _PropertyID;
       
        private string _ClientName;
        private string _PropertyName;
        private decimal _PropertyPrice;
        private Models.PaymentSession webLink;
       
        public frmAddUpdateReservation(int PropertyID)
        {
            InitializeComponent();
            _PropertyID = PropertyID;
        }

        public frmAddUpdateReservation(int reservationID, int PropertyID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ReservationID = reservationID;
            _PropertyID = PropertyID;
            _Mode = enMode.Update;
        }

      
        private async Task <Models.Reservation> ActivateReservationDate() {

          Models.Reservation ActiveDate =   await ApiClient.clsAPIFunctions<Models.Reservation>.GetAsync($"Reservation/getActiveReservationDate?PropertyId={_PropertyID}&stDate={dtpStartDate.Value.ToShortDateString()}&exDate={dtpExpDate.Value.ToShortDateString()}");
        
          return ActiveDate;
        
        }

        private async Task<Models.Reservation> AddReserevation(Models.Reservation reservation) {

            return await ApiClient.clsAPIFunctions<Models.Reservation>.PostAsync("Reservation/Add", reservation);

        }

        private async Task<Models.Reservation> UpdateReservation(int reservationId ,Models.Reservation reservation)
        {
            return   await ApiClient.clsAPIFunctions<Models.Reservation>.PutAsync($"Reservation/UpdateReservationDate?UpdateReservationById={reservationId}", reservation);
        }
        private async void btnReserve_Click(object sender, EventArgs e)
        {

            try
            {
                
               
                Models.Reservation ResultResrvation;
                Models.Reservation ActiveReservationDate =await ActivateReservationDate(); 

                if (ActiveReservationDate != null)
                {
                    MessageBox.Show($"Selected Reservation Date Time {ActiveReservationDate.BeginDate}-{ActiveReservationDate.ExpiredDate} is Already Token !  ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Models.Reservation reservation = new Models.Reservation
                {

                    PropertyId = _PropertyID,
                    BookedByClientId = clsGlobal.CurrentUser.ClientID,
                    Price = _PropertyPrice,
                    BeginDate = dtpStartDate.Value,
                    ExpiredDate = dtpExpDate.Value,

                };


                if (_Mode == enMode.AddNew) ResultResrvation =await AddReserevation(reservation);
                {
                    reservation.BookID = _ReservationID;
                    ResultResrvation = await UpdateReservation(_ReservationID , reservation);

                }

                _ReservationID = ResultResrvation.BookID;
                var propertName =await GetPropertyNameByid(reservation.PropertyId) ; 
                var Payment = new { PropertyName = propertName, Price = ResultResrvation.Price , BookId = ResultResrvation.BookID.ToString()  };
                
                if (_ReservationID != -1)
                {
                    string result = _Mode == enMode.AddNew ? "Created" : "Update";
                    webLink = await ApiClient.clsAPIFunctions<Models.PaymentSession>.PostAsync("Payment/CreateCheckoutSessionAsync", Payment);
                    if (webLink != null)
                    {
                        linkl1.Visible = true;
                        linkl1.Text = "Pay";
                        MessageBox.Show($"Reservation {result} Successfully, Confirm your payment in order to compeleted the process open the link (Pay)!", "Success", MessageBoxButtons.OK , MessageBoxIcon.Information);

                    
                      
                    }
                  

                }
                lblBookId.Text = ResultResrvation.BookID.ToString();        
                _Mode = enMode.Update;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                clsGlobal.SaveToEventLog($"error{ex.Message}", System.Diagnostics.EventLogEntryType.Error);

            }

        }

        private async Task<string> GetPropertyNameByid(int propertyId)
        {
           return  await ApiClient.clsAPIFunctions<string>.GetAsync("Property/GetPropertyNameByID?PropertyID=", propertyId);
        }
        private async Task<string> ClientName()
        {
           string  clientName =  await ApiClient.clsAPIFunctions<string>.GetAsync("Clients/GetClientUserNameById?id=", clsGlobal.CurrentUser.ClientID);
            return clientName;
        }

        private async Task<string> GetPropertyName(int propertyId) 
        {
            string propertyName = await ApiClient.clsAPIFunctions<string>.GetAsync("Clients/GetClientUserNameById?id=", propertyId);
            return propertyName;
        }


        private async Task<decimal> GetPropertyPrice(int propertyId)
        {
            decimal propertyPrice = await ApiClient.clsAPIFunctions<decimal>.GetAsync("Property/GetPropertyPriceByID?PropertyID=", propertyId);
            return propertyPrice;
        }


        private async void frmAddUpdateReservation_Load(object sender, EventArgs e)
        {
           
            dtpExpDate.MinDate = DateTime.Today.AddDays(2);
            dtpStartDate.MinDate = DateTime.Today.AddDays(1);
            linkl1.Visible = false;




            _ClientName =await ClientName() ;

            _PropertyName = await GetPropertyName(_PropertyID);  ;
            _PropertyPrice =await GetPropertyPrice(_PropertyID) ;

            lblClientName.Text = _ClientName;
            lblPropertyName.Text = _PropertyName;
            lblPrice.Text = _PropertyPrice.ToString();

            if (_Mode == enMode.Update)
            {
                var Reservation = await GetReservation(_ReservationID);

                lblBookId.Text = Reservation.BookID.ToString();
                dtpStartDate.Text = Reservation.BeginDate.ToShortDateString();
                dtpExpDate.Text = Reservation.ExpiredDate.ToShortDateString();
            }

        }

        private async Task<Models.Reservation> GetReservation(int reservationId)
        {
            Models.Reservation reservation = await ApiClient.clsAPIFunctions<Models.Reservation>.GetAsync($"Reservation/GetReservationById?BookId={reservationId}");
            return reservation;
        }


        private void linkl1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            try
            {
                
                string url = webLink.url;
                var psi = new ProcessStartInfo
                {
                    FileName =url,
                    UseShellExecute = true   // <— IMPORTANT
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the link: {ex.Message}");
            }
        }
    }
}
