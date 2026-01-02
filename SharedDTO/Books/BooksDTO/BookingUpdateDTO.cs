using System;

namespace SharedDTOLayer.Books.BooksDTO
{
    public class BookingUpdateDTO
    {
        public int BookID { get; set; }

        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }

        // Constructor with all properties
        public BookingUpdateDTO(int bookID, DateTime expiredDate, DateTime beginDate)
        {
            BookID = bookID;
            ExpiredDate = expiredDate;
            BeginDate = beginDate;

        }
    }


}
