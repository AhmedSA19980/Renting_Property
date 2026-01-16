using PR_DataAccessLayer;
using SharedDTOLayer.Books.BooksDTO;
using System.Data;


namespace PR_BusinessLayer
{


   
    public class clsBooking
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public int BookID { get; set; }
        public int PropertyId { get; set; }
        public int BookedByClientId { get; set; }
        public decimal Price { get; set; } // Use decimal for price
        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }
        public bool IsBooked { get; set; }


        public BookingDTO BDTO
        {
            get
            {
                return new BookingDTO(
                    this.BookID,
                    this.PropertyId,
                    this.BookedByClientId,
                    this.Price,
                    this.ExpiredDate,
                    this.BeginDate,
                    this.IsBooked
                );
            }
        }



        public BookingUpdateDTO BUDTO
        {
            get
            {
                return new BookingUpdateDTO(
                    this.BookID,
                    this.ExpiredDate,
                    this.BeginDate
                );
            }
        }
        public clsBooking(BookingUpsertDTO BDTO, enMode mode = enMode.AddNew)
        {
            this.BookID = BDTO.BookID;
            this.PropertyId = BDTO.PropertyId;
            this.BookedByClientId = BDTO.BookedByClientId;
            this.Price = BDTO.Price;
            this.ExpiredDate = BDTO.ExpiredDate;
            this.BeginDate = BDTO.BeginDate;

            BookingDTO book = BDTO as BookingDTO;
            if (book != null)
            {
                this.IsBooked = book.IsBooked;
            }
            _Mode = mode;
        }

        

        private bool _AddNewBooking()
        {
            this.BookID = clsBookData.AddNewReservation(BDTO); // Get the ID from the data layer
            return (this.BookID != -1);
        }

        private bool _UpdateBooking()
        {
            return clsBookData.UpdateReservation(BDTO);
        }

        public static int DeleteBooking(int bookID)
        {
            return (clsBooking.Find(bookID) != null) ? clsBookData.DeleteReservation(bookID) ? 1 : -1 : -1;
        }

        public static clsBooking Find(int bookID)
        {
            BookingDTO bdto = clsBookData.GetBookingById(bookID);
            if (bdto != null)
            {
                return new clsBooking(bdto, enMode.Update);
            }
            else
            {
                return null;
            }
        }


        public static CheckForActiveReservationDTO CheckForActiveReservationDate(int PropertyID, DateTime stDate , DateTime exDate)
        {
            return clsBookData.CheckForActiveReservationDate(PropertyID, stDate, exDate);
        }
        public static List<BookingDTO> GetAllBookings()
        {
            return clsBookData.GetBookings();
        }

        public static List<BookingDTO> GetAllBookingsByClientID(int ClientID)
        {
            return clsBookData.GetAllReservationByClientID(ClientID);
        }

        public static List<BookingDTO> GetAllUnbookedReservationsByClientID(int ClientID)
        {
            return clsBookData.GetAllUnbookedReservationsByClientID(ClientID);
        }

        public static List<BookingDTO> GetAllBookedReservationsByClientID(int ClientID)
        {
            return clsBookData.GetAllBookedReservationByClientID(ClientID);
        }
        
        public static DataTable GetBookings()
        {
            return clsBookData.GetBookingsInDataTable();
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBooking())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBooking();

                default:
                    return false;
            }
        }
    }

}
