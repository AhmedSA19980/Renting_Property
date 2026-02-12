using PR_BusinessLayer;
using SharedDTOLayer.Payments.PaymentsDTO;
using SharedDTOLayer.Properties_.PropertiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripePayment
{
    public class savePayment
    {
        public static  bool PaymentLog(int bookID,DateTime paymetDate )
        {
   
            clsBooking Reservation =clsBooking.Find(bookID);
            if (Reservation == null) return false;



            DateTime StartDate = Reservation.BeginDate;
            DateTime exTime = Reservation.ExpiredDate;
            decimal Price = Reservation.Price;
            int ClientID = Reservation.BookedByClientId;
            
            int PropertyID = Reservation.PropertyId;
            int BookingID = bookID;

            byte status = 0;// paid

            PR_BusinessLayer.clsPayments payment = new PR_BusinessLayer.clsPayments(new PaymentsDTO(
              PaymentID: 0 ,
               startDate : StartDate  ,
                endDate : exTime,
                 pricePerDay:Price,
                //paymentsdto.TotalAmount,
                0,
                 clientID:ClientID,
                propertyID: PropertyID,
            
                status
                ,
               
                 paymetDate,
                BookingID: BookingID
                , 0,// default for total
                null,
                DateTime.MinValue
                ));

          var success  =  payment.Save();
            if(!success) return false;

            Console.WriteLine($"Payment is saved through {payment.ID}!");

            return true;
        }
    }
}
