
using System;

namespace SharedDTOLayer.Books.BooksDTO
{
    public class BookingDTO : BookingUpsertDTO
    {
        public int BookID { get; set; }
        public int PropertyId { get; set; }
        public int BookedByClientId { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }
        public bool IsBooked { get; set; }

        // Constructor with all properties
        public BookingDTO(int bookID, int propertyId, int bookedByClientId, decimal price, DateTime expiredDate, DateTime beginDate, bool IsBooked):
            base( bookID,  propertyId,  bookedByClientId,  price,  expiredDate,  beginDate)
        {
            this.BookID = bookID;
            this.PropertyId = propertyId;
            this.BookedByClientId = bookedByClientId;
            this.Price = price;
            this.ExpiredDate = expiredDate;
            this.BeginDate = beginDate;
            this.IsBooked = IsBooked;
           
        }
    }



}
