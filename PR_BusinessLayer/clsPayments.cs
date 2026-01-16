using PR_DataAccessLayer;
using SharedDTOLayer.Payments.PaymentsDTO;
using System.Data;


namespace PR_BusinessLayer
{
    public class clsPayments
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public enum enPaymentStatus  {IsPaid = 1 ,Cancelled = 2 , BrokeAgreement =3 , ViolateRule  =4 }

        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal TotalAmount { get; set; }

        public int ClientID { get; set; }
        public int PropertyID { get; set; }
        public int CardID { get; set; }

        public byte Status { get; set; }
        public decimal ReturnAmount { get; set; }

        public string Note { get; set; }
        public DateTime ReturnDate { get; set; }


        public DateTime PaidDate { get; set; }

        public int BookingID { get; set; }

        public PaymentsDTO PDTO
        {
            get
            {
                return (new PaymentsDTO(
                this.ID,
                this.StartDate,
                this.EndDate,
                this.PricePerDay,
                this.TotalAmount,
                this.ClientID,
                this.PropertyID,
      
                (byte)(enPaymentStatus)this.Status,
               
                this.PaidDate,
                this.BookingID,
                 this.ReturnAmount,
                this.Note,
                this.ReturnDate
               ));
            }
        }

        public clsPayments(PaymentsDTO PDTO, enMode cMode = enMode.AddNew)
        {
            this.ID = PDTO.ID;
            this.StartDate = PDTO.StartDate;
            this.EndDate = PDTO.EndDate;
            this.PricePerDay = PDTO.PricePerDay;
            this.TotalAmount = PDTO.TotalAmount;
            this.ClientID = PDTO.ClientID;
            this.PropertyID = PDTO.PropertyID;
    
            this.Status =(byte)(enPaymentStatus) PDTO.Status;
  
            this.PaidDate = PDTO.PaidDate;
            this.BookingID = PDTO.BookingID;
            this.ReturnAmount = (decimal)PDTO.ReturnAmount;
            this.Note = PDTO.Note;
            this.ReturnDate =(DateTime) PDTO.ReturnDate;
            _Mode = cMode;
        
        }






        public static clsPayments Find(int ID)
        {
            PaymentsDTO PDTO = clsPaymentsData.GetPaymentByID(ID);

            if (PDTO != null)
            {
                return new clsPayments(PDTO, enMode.Update);
            }
            else
                return null;
        }

        private bool _AddNewPayment()
        {
           

            this.ID = clsPaymentsData.AddNewPayment(PDTO);

            return (this.ID != -1);
        }




        public DataTable GetClientPayments(int ClientID)
        {
           return   clsPaymentsData.GetClientPaymentsByClientID(ClientID);
      
        }

        public static List<ClientPayments> GetAllClientPayments(int ClientID)
        {
            return clsPaymentsData.GetAllClientPaymentsByClientID(ClientID);

        }

        public static PaymentDetailDTO PaymentDetail (int BookingID)
        {
            return clsPaymentsData.GetPaymentDetailByBookingID(BookingID);
        }
        public List<PaymentsDTO> GetCustomersPayments()
        {
            return clsPaymentsData.GetCustomersPayments();
        }


        private bool _UpdatePayment()
        {
            
            return clsPaymentsData.AppropriateRefund(PDTO);

        }


        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePayment();
            }


            return false;
        }

    }
}
