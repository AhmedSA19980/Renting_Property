using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PR_DataAccessLayer
{
    public class ReservationDTO
    {
        public int BookID { get; set; }
        public int PropertyId { get; set; }
    
        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }
        public bool IsBooked { get; set; }

        // Constructor with all properties
        public ReservationDTO(int bookID, int propertyId,  DateTime expiredDate, DateTime beginDate, bool isBooked)
        {
            BookID = bookID;
            PropertyId = propertyId;
           // BookedByClientId = bookedByClientId;
            //Price = price;
            ExpiredDate = expiredDate;
            BeginDate = beginDate;
            IsBooked = isBooked;
        }
    }

    public class BookingDTO
    {
        public int BookID { get; set; }
        public int PropertyId { get; set; }
        public int BookedByClientId { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }
        public bool IsBooked { get; set; }

        // Constructor with all properties
        public BookingDTO(int bookID, int propertyId, int bookedByClientId, decimal price, DateTime expiredDate, DateTime beginDate, bool isBooked)
        {
            BookID = bookID;
            PropertyId = propertyId;
            BookedByClientId = bookedByClientId;
            Price = price;
            ExpiredDate = expiredDate;
            BeginDate = beginDate;
            IsBooked = isBooked;
        }
    }

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



    public  class clsBookData
        {

            public static BookingDTO GetBookingById(int bookId)
            {
         
          

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetBookByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookID", bookId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if any rows were returned
                            {
                                return new BookingDTO(
                                 reader.GetInt32(reader.GetOrdinal("BookID")),
                                 reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                 reader.GetInt32(reader.GetOrdinal("BookedByClientId")), // Correctly maps to DTO property
                                 reader.GetDecimal(reader.GetOrdinal("Price")),
                                  reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                                 reader.GetDateTime(reader.GetOrdinal("BeginDate")),
                                 reader.GetBoolean(reader.GetOrdinal("IsBooked"))
                                 );
                            }
                        }
                    }
                }
                return null; // Return the BookingDTO object (or null if not found)
            }



            public static List<BookingDTO> GetBookings()
            {
                var bookingList = new List<BookingDTO>(); // Consistent naming

                using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) // Use your connection string source
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GetALLReservation", conn)) // Your stored procedure name
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                                bookingList.Add(new BookingDTO( // Use your constructor
                                 reader.GetInt32(reader.GetOrdinal("BookID")),
                                 reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                 reader.GetInt32(reader.GetOrdinal("BookedByClientId")), // Correctly maps to DTO property
                                 reader.GetDecimal(reader.GetOrdinal("Price")),
                                  reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                                 reader.GetDateTime(reader.GetOrdinal("BeginDate")),

                                 isBooked
                            ));
                            }
                        }
                    }
                    return bookingList;
                }
            }

        public static ReservationDTO CheckForActiveReservationDate(int PropertyID, DateTime stDate , DateTime exDate)
        {
          


            using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_CheckforActiveReservation", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PropertyID", PropertyID);
                    command.Parameters.AddWithValue("@StartDate", stDate);
                    command.Parameters.AddWithValue("@EndDate", exDate);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if any rows were returned
                        {
                            return new ReservationDTO(
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),
                             //reader.GetInt32(reader.GetOrdinal("BookedByClientId")), // Correctly maps to DTO property
                           //  reader.GetDecimal(reader.GetOrdinal("Price")),
                              reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                             reader.GetDateTime(reader.GetOrdinal("BeginDate")),
                             reader.GetBoolean(reader.GetOrdinal("IsBooked"))
                             );
                        }
                    }
                }
            }
            return null; // Return the BookingDTO object (or null if not found)
        }


        public static List<BookingDTO> GetAllReservationByClientID(int ClientID)
        {
            var bookingList = new List<BookingDTO>(); // Consistent naming

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) // Use your connection string source
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllClientReservationsByClientID", conn)) // Your stored procedure name
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookedByClientID", ClientID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                            bookingList.Add(new BookingDTO( // Use your constructor
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),
                             reader.GetInt32(reader.GetOrdinal("BookedByClientId")), // Correctly maps to DTO property
                             reader.GetDecimal(reader.GetOrdinal("Price")),
                              reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                             reader.GetDateTime(reader.GetOrdinal("BeginDate")),

                             isBooked
                        ));
                        }
                    }
                }
                return bookingList;
            }
        }

        public static List<BookingDTO> GetAllUnbookedReservationsByClientID(int ClientID)
        {
            var bookingList = new List<BookingDTO>(); // Consistent naming

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) // Use your connection string source
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllUnbookedClientReservationsByClientID", conn)) // Your stored procedure name
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookedByClientID", ClientID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                            bookingList.Add(new BookingDTO( // Use your constructor
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),
                             reader.GetInt32(reader.GetOrdinal("BookedByClientId")), // Correctly maps to DTO property
                             reader.GetDecimal(reader.GetOrdinal("Price")),
                              reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                             reader.GetDateTime(reader.GetOrdinal("BeginDate")),

                             isBooked
                        ));
                        }
                    }
                }
                return bookingList;
            }
        }


        public static List<BookingDTO> GetAllBookedReservationByClientID(int ClientID)
        {
            var bookingList = new List<BookingDTO>(); // Consistent naming

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) // Use your connection string source
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllBookedClientReservationsByClientID", conn)) // Your stored procedure name
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookedByClientID", ClientID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                            bookingList.Add(new BookingDTO( // Use your constructor
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),
                             reader.GetInt32(reader.GetOrdinal("BookedByClientId")), // Correctly maps to DTO property
                             reader.GetDecimal(reader.GetOrdinal("Price")),
                              reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                             reader.GetDateTime(reader.GetOrdinal("BeginDate")),

                             isBooked
                        ));
                        }
                    }
                }
                return bookingList;
            }
        }

        public static DataTable GetBookingsInDataTable()
        {
            DataTable bookingList = new DataTable(); // Consistent naming

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) // Use your connection string source
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetALLReservation", conn)) // Your stored procedure name
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            if (reader.HasRows)
                            {
                                bookingList.Load(reader);

                            }

                            reader.Close();
                        
                        }
                    }
                }
                return bookingList;
            }
        }


        public static int AddNewReservation(BookingDTO booking)
            {
                int ReservationID = -1; // Initialize to a default value

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss)) // Your connection string source
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("SP_AddBooking", connection)) // Your stored procedure name
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters, handling potential NULLs:
                            cmd.Parameters.AddWithValue("@PropertyId", booking.PropertyId);
                            cmd.Parameters.AddWithValue("@BookedByClientId", booking.BookedByClientId);
                            cmd.Parameters.AddWithValue("@Price", booking.Price);
                            cmd.Parameters.AddWithValue("@ExpiredDate", booking.ExpiredDate);
                            cmd.Parameters.AddWithValue("@BeginDate", booking.BeginDate);
                            cmd.Parameters.AddWithValue("@IsBooked", booking.IsBooked);


                            // Output parameter for the new BookID:
                            SqlParameter outputIdParam = new SqlParameter("@BookID", SqlDbType.Int) // Match the data type in your DB
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(outputIdParam);

                            cmd.ExecuteNonQuery(); // Use ExecuteNonQuery for INSERTs with output parameters

                            ReservationID = (int)cmd.Parameters["@BookID"].Value; // Retrieve the output value

                            
                        }
                    connection.Close();
                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding booking: " + ex.Message); // Handle the exception
                                                                              // Optionally re-throw the exception:  throw;  (If you want calling code to handle it)
                    return -1; // Return -1 to indicate failure (or another appropriate error code)
                }

                return ReservationID; // Return the new booking ID
            }



            public static bool UpdateReservation(BookingUpdateDTO booking)
            {
                int rowsAffected = -1;

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand("SP_UpdateBooking", connection)) // Your stored procedure name
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@BookID", booking.BookID); // Crucial: Add BookID for the WHERE clause
                   
                            cmd.Parameters.AddWithValue("@ExpiredDate", booking.ExpiredDate);
                            cmd.Parameters.AddWithValue("@BeginDate", booking.BeginDate);
                       
                            rowsAffected = cmd.ExecuteNonQuery();
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating booking: " + ex.Message);
                    // Optionally re-throw:  throw;
                }

                return rowsAffected > 0;
            }



            public static bool ConfirmReservation(int BookID)
            {


                int RowAffected = -1;

                try
                {

                    using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("SP_ConfirmBooking", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@BookID", BookID);



                            RowAffected = cmd.ExecuteNonQuery();

                        }
                        connection.Close();

                    }



                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                return (RowAffected > 0);

            }


            public static bool DeleteReservation(int BookID)
            {


                int RowAffected = -1;

                try
                {

                    using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("SP_DeleteBooking", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@BookID", BookID);



                            RowAffected = cmd.ExecuteNonQuery();

                        }

                        connection.Close();
                    }

                

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }



                return (RowAffected > 0);

            }


    }

  

}
