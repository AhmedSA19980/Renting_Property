using Microsoft.Data.SqlClient;
using SharedDTOLayer.Books.BooksDTO;
using System.Data;


namespace PR_DataAccessLayer
{
   

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
                            if (reader.Read()) 
                            {
                                return new BookingDTO(
                                 reader.GetInt32(reader.GetOrdinal("BookID")),
                                 reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                 reader.GetInt32(reader.GetOrdinal("BookedByClientId")), 
                                 reader.GetDecimal(reader.GetOrdinal("Price")),
                                  reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                                 reader.GetDateTime(reader.GetOrdinal("BeginDate")),
                                 reader.GetBoolean(reader.GetOrdinal("IsBooked"))
                                 );
                            }
                        }
                    }
                }
                return null; 
            }



            public static List<BookingDTO> GetBookings()
            {
                var bookingList = new List<BookingDTO>(); 

                using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GetALLReservation", conn)) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                                bookingList.Add(new BookingDTO( 
                                 reader.GetInt32(reader.GetOrdinal("BookID")),
                                 reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                 reader.GetInt32(reader.GetOrdinal("BookedByClientId")), 
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

        public static CheckForActiveReservationDTO CheckForActiveReservationDate(int PropertyID, DateTime stDate , DateTime exDate)
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
                        if (reader.Read()) 
                        {
                            return new CheckForActiveReservationDTO(
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),

                              reader.GetDateTime(reader.GetOrdinal("ExpiredDate")),
                             reader.GetDateTime(reader.GetOrdinal("BeginDate")),
                             reader.GetBoolean(reader.GetOrdinal("IsBooked"))
                             );
                        }
                    }
                }
            }
            return null; 
        }


        public static List<BookingDTO> GetAllReservationByClientID(int ClientID)
        {
            var bookingList = new List<BookingDTO>(); 

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) 
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllClientReservationsByClientID", conn)) 
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookedByClientID", ClientID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                            bookingList.Add(new BookingDTO( 
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),
                             reader.GetInt32(reader.GetOrdinal("BookedByClientId")), 
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
            var bookingList = new List<BookingDTO>(); 

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) 
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllUnbookedClientReservationsByClientID", conn)) 
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookedByClientID", ClientID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                            bookingList.Add(new BookingDTO( 
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),
                             reader.GetInt32(reader.GetOrdinal("BookedByClientId")), 
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
            var bookingList = new List<BookingDTO>(); 

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) 
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllBookedClientReservationsByClientID", conn)) 
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookedByClientID", ClientID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            bool isBooked = reader.IsDBNull(reader.GetOrdinal("IsBooked")) ? false : reader.GetBoolean(reader.GetOrdinal("IsBooked")); // Default false if NULL

                            bookingList.Add(new BookingDTO( 
                             reader.GetInt32(reader.GetOrdinal("BookID")),
                             reader.GetInt32(reader.GetOrdinal("PropertyID")),
                             reader.GetInt32(reader.GetOrdinal("BookedByClientId")), 
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
            DataTable bookingList = new DataTable(); 

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss)) 
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetALLReservation", conn)) 
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


        public static int AddNewReservation(BookingUpsertDTO booking)
            {
                int ReservationID = -1; 

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss)) 
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("SP_AddBooking", connection)) 
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                         
                            cmd.Parameters.AddWithValue("@PropertyId", booking.PropertyId);
                            cmd.Parameters.AddWithValue("@BookedByClientId", booking.BookedByClientId);
                            cmd.Parameters.AddWithValue("@Price", booking.Price);
                            cmd.Parameters.AddWithValue("@ExpiredDate", booking.ExpiredDate);
                            cmd.Parameters.AddWithValue("@BeginDate", booking.BeginDate);
                         


                        
                            SqlParameter outputIdParam = new SqlParameter("@BookID", SqlDbType.Int) 
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(outputIdParam);

                            cmd.ExecuteNonQuery(); 

                            ReservationID = (int)cmd.Parameters["@BookID"].Value; 

                            
                        }
                    connection.Close();
                }
                }
                catch (Exception ex)
                {
                   // Console.WriteLine("Error adding booking: " + ex.Message); 
                                                                            
                    return -1; // Return -1 to indicate failure (or another appropriate error code)
                }

                return ReservationID; 
            }



            public static bool UpdateReservation(BookingUpsertDTO booking) 
            {
                int rowsAffected = -1;

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand("SP_UpdateBooking", connection)) 
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@BookID", booking.BookID); 
                   
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
