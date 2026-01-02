using System;

namespace SharedDTOLayer.Payments.PaymentsDTO
{
    public class PaymentsDTO
    {

        public PaymentsDTO(int PaymentID, DateTime startDate, DateTime endDate, decimal pricePerDay, decimal totalAmount, int clientID, int propertyID
            , byte status,  DateTime paidDate, int BookingID, decimal? returnAmount, string? note, DateTime? returnDate)
        {

            this.ID = PaymentID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PricePerDay = pricePerDay;
            this.TotalAmount = totalAmount;
            this.ClientID = clientID;
            this.PropertyID = propertyID;
        
            this.Status = status;
           
            this.PaidDate = paidDate;
            this.BookingID = BookingID;
            this.ReturnAmount = returnAmount ?? 0;
            this.Note = note;
            this.ReturnDate =returnDate;
        }
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal TotalAmount { get; set; }

        public int ClientID { get; set; }
        public int PropertyID { get; set; }
     

        public byte Status { get; set; }
        public decimal? ReturnAmount { get; set; }

        public string? Note { get; set; }
        public DateTime? ReturnDate { get; set; }


        public DateTime PaidDate { get; set; }

        public int BookingID { get; set; }
    }



}
