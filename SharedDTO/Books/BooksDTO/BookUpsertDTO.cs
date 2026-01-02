using System;

namespace SharedDTOLayer.Books.BooksDTO
{
    public class BookingUpsertDTO 
    {

        public int BookID { get; set; }
        public int PropertyId { get; set; }
        public int BookedByClientId { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }


        // Constructor with all properties
        public BookingUpsertDTO(int bookID, int propertyId, int bookedByClientId, decimal price, DateTime expiredDate, DateTime beginDate)
        {
            BookID = bookID;
            PropertyId = propertyId;
            BookedByClientId = bookedByClientId;
            Price = price;
            ExpiredDate = expiredDate;
            BeginDate = beginDate;

        }
    }
}
