using Microsoft.Data.SqlClient;
using SharedDTOLayer.Payments.PaymentsDTO;
using System.Data;



namespace PR_DataAccessLayer
{

   
    public class clsPaymentsData
    {

        public static List<PaymentsDTO> GetCustomersPayments()
        {
            var PaymentList = new List<PaymentsDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetPayments", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            PaymentList.Add(new PaymentsDTO
                           (
                               reader.GetInt32(reader.GetOrdinal("ID")),

                                 reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    reader.GetDateTime(reader.GetOrdinal("EndDate")),

                                   reader.GetDecimal(reader.GetOrdinal("PricePerDay")),
                                    reader.GetDecimal(reader.GetOrdinal("TotalAmount")),

                                      reader.GetInt32(reader.GetOrdinal("ClientID")),
                                       reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                //       reader.GetInt32(reader.GetOrdinal("CardID")),
                                           reader.GetByte(reader.GetOrdinal("Status")),
                                          
                                               reader.GetDateTime(reader.GetOrdinal("PaidDate")),
                                                reader.GetInt32(reader.GetOrdinal("BookingID")),
                                                reader.GetDecimal(reader.GetOrdinal("ReturnAmount")),
                                              reader.GetString(reader.GetOrdinal("Note")),
                                               reader.GetDateTime(reader.GetOrdinal("ReturnDate"))

                           ));
                        }
                    }
                }


                return PaymentList;
            }

        }


        public static DataTable GetClientPaymentsByClientID(int ClientID)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetClientPaymentsByClientID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", ClientID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);

                            }

                            reader.Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return dt;
        }





        public static List<ClientPayments> GetAllClientPaymentsByClientID(int ClientID)
        {

            List<ClientPayments> Payments = new List<ClientPayments>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetClientPaymentsByClientID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", ClientID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            

                            while (reader.Read())
                            {
                                string Note = reader.IsDBNull(reader.GetOrdinal("Note")) ? "" : reader.GetString(reader.GetOrdinal("Note"));



                                Payments.Add(new ClientPayments
                                 (
                                    reader.GetInt32(reader.GetOrdinal("ID")),

                                    reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                       reader.GetDateTime(reader.GetOrdinal("EndDate")),

                                      reader.GetDecimal(reader.GetOrdinal("PricePerDay")),
                                       reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                                        reader.GetString(reader.GetOrdinal("PropertyTypeName")),
                                          reader.GetString(reader.GetOrdinal("Name")),
                                            reader.GetString(reader.GetOrdinal("PaymentStatus")),
                                            Note,
                                                reader.GetDateTime(reader.GetOrdinal("PaidDate")),
                                                  reader.GetInt32(reader.GetOrdinal("BookingID")),
                                         reader.GetInt32(reader.GetOrdinal("ClientID"))
                                     
                                            
                                ));

                            }

                            reader.Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return Payments;
        }

        public static PaymentsDTO GetPaymentByID(int ID)
        {

            
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPaymentByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID",ID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                return new PaymentsDTO(

                                    reader.GetInt32(reader.GetOrdinal("ID")),

                                     reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                        reader.GetDateTime(reader.GetOrdinal("EndDate")),

                                       reader.GetDecimal(reader.GetOrdinal("PricePerDay")),
                                        reader.GetDecimal(reader.GetOrdinal("TotalAmount")),

                                          reader.GetInt32(reader.GetOrdinal("ClientID")),
                                           reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                               reader.GetByte(reader.GetOrdinal("Status")),
                                                   reader.GetDateTime(reader.GetOrdinal("PaidDate")),
                                                     reader.GetInt32(reader.GetOrdinal("BookingID")),
                                                        reader.GetDecimal(reader.GetOrdinal("ReturnAmount")),
                                                  reader.GetString(reader.GetOrdinal("Note")),
                                                   reader.GetDateTime(reader.GetOrdinal("ReturnDate"))

                                );


                            }

                            reader.Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return null;
        }



        public static PaymentDetailDTO GetPaymentDetailByBookingID(int BookingID)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPaymentDetailByBookingID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookID", BookingID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string note = reader.IsDBNull(reader.GetOrdinal("Note")) ? "" : reader.GetString(reader.GetOrdinal("Note"));


                                return new PaymentDetailDTO(

                                    reader.GetInt32(reader.GetOrdinal("ID")),
                                      reader.GetString(reader.GetOrdinal("CountryName")),
                                 reader.GetDateTime(reader.GetOrdinal("startDate")),
                                    reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                     reader.GetDecimal(reader.GetOrdinal("OriginalPrice")),
                                      reader.GetString(reader.GetOrdinal("DiscountPer")),

                                   reader.GetDecimal(reader.GetOrdinal("PricePerDay")),
                                    reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                                      reader.GetString(reader.GetOrdinal("PropertyTypeName")),
                                       reader.GetString(reader.GetOrdinal("Name")),
                                           reader.GetString(reader.GetOrdinal("PaymentStatus")),

                                             note,

                                               reader.GetDateTime(reader.GetOrdinal("PaidDate")),
                                                reader.GetInt32(reader.GetOrdinal("BookingID")),
                                                 reader.GetInt32(reader.GetOrdinal("BookedByClientId"))
                                       

                                );


                            }

                            reader.Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return null;
        }


        public static int AddNewPayment(PaymentsDTO Payments)
        {
            int discountID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {

                    using (SqlCommand cmd = new SqlCommand("SP_AddPayment", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                       
                        cmd.Parameters.AddWithValue("@StartDate", Payments.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", Payments.EndDate);
                        cmd.Parameters.AddWithValue("@PricePerDay", Payments.PricePerDay);


                     
                        cmd.Parameters.AddWithValue("@ClientID", Payments.ClientID);
                        cmd.Parameters.AddWithValue("@PropertyID", Payments.PropertyID);
                      
                
                        cmd.Parameters.AddWithValue("@BookingID", Payments.BookingID);


                        SqlParameter outputIdParam = new SqlParameter("@ID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);

                        connection.Open();
                        cmd.ExecuteScalar();

                        discountID = (int)cmd.Parameters["@ID"].Value;
                        connection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return discountID;
        }


        public static bool AppropriateRefund(PaymentsDTO Payment)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_AppropriateRefund", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", Payment.ID);
                        cmd.Parameters.AddWithValue("@Status", Payment.Status);
                        cmd.Parameters.AddWithValue("@ReturnAmount", Payment.ReturnAmount);
                        cmd.Parameters.AddWithValue("@Note", Payment.Note);


                        rowsAffected = cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return rowsAffected > 0;
        }


    }
}
