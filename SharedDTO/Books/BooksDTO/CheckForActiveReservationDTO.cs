
using System;

namespace SharedDTOLayer.Books.BooksDTO
{

    public class CheckForActiveReservationDTO
    {
        public int BookID { get; set; }
        public int PropertyId { get; set; }

        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }
        public bool IsBooked { get; set; }

        // Constructor with all properties
        public CheckForActiveReservationDTO(int bookID, int propertyId, DateTime expiredDate, DateTime beginDate, bool isBooked)
        {
            BookID = bookID;
            PropertyId = propertyId;

            ExpiredDate = expiredDate;
            BeginDate = beginDate;
            IsBooked = isBooked;
        }
    }
}
