using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_DataAccessLayer
{

    public class PaymentsDTO
    {

        public PaymentsDTO(int id, DateTime startDate, DateTime endDate, decimal pricePerDay, decimal totalAmount, int clientID, int propertyID,
            int carID, byte status, decimal returnAmount, string note, DateTime returnDate, DateTime paidDate , int BookingID) {

            this.ID = id;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PricePerDay = pricePerDay;
            this.TotalAmount = totalAmount;
            this.ClientID = clientID;
            this.PropertyID = propertyID;
            this.CardID = carID;
            this.Status = status;
            this.ReturnAmount = returnAmount;
            this.Note = note;
            this.ReturnDate = returnDate;
            this.PaidDate = paidDate;
            this.BookingID = BookingID;
        }
        public  int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal TotalAmount { get; set; }

        public int ClientID { get; set; }
        public int PropertyID { get; set; }
        public int CardID { get; set; }

        public byte Status { get; set; }
        public decimal ReturnAmount { get; set; }

        public string Note { get; set; }
        public DateTime ReturnDate { get; set; }


        public DateTime PaidDate { get; set; }

        public int BookingID { get; set; }
    }


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
                                       reader.GetInt32(reader.GetOrdinal("CardID")),
                                           reader.GetByte(reader.GetOrdinal("Status")),
                                             reader.GetDecimal(reader.GetOrdinal("ReturnAmount")),
                                              reader.GetString(reader.GetOrdinal("Note")),
                                               reader.GetDateTime(reader.GetOrdinal("ReturnDate")),
                                               reader.GetDateTime(reader.GetOrdinal("PaidDate")),
                                                reader.GetInt32(reader.GetOrdinal("BookingID"))



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





        public static List<PaymentsDTO> GetAllClientPaymentsByClientID(int ClientID)
        {

            List<PaymentsDTO> Payments = new List<PaymentsDTO>();
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
                               Payments.Add(new PaymentsDTO
                                 (
                              reader.GetInt32(reader.GetOrdinal("ID")),

                                reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                   reader.GetDateTime(reader.GetOrdinal("EndDate")),

                                  reader.GetDecimal(reader.GetOrdinal("PricePerDay")),
                                   reader.GetDecimal(reader.GetOrdinal("TotalAmount")),

                                     reader.GetInt32(reader.GetOrdinal("ClientID")),
                                      reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                      reader.GetInt32(reader.GetOrdinal("CardID")),
                                          reader.GetByte(reader.GetOrdinal("Status")),
                                            reader.GetDecimal(reader.GetOrdinal("ReturnAmount")),
                                             reader.GetString(reader.GetOrdinal("Note")),
                                              reader.GetDateTime(reader.GetOrdinal("ReturnDate")),
                                              reader.GetDateTime(reader.GetOrdinal("PaidDate")),
                                               reader.GetInt32(reader.GetOrdinal("BookingID"))



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
                                       reader.GetInt32(reader.GetOrdinal("CardID")),
                                           reader.GetByte(reader.GetOrdinal("Status")),
                                             reader.GetDecimal(reader.GetOrdinal("ReturnAmount")),
                                              reader.GetString(reader.GetOrdinal("Note")),
                                               reader.GetDateTime(reader.GetOrdinal("ReturnDate")),
                                               reader.GetDateTime(reader.GetOrdinal("PaidDate")),
                                                 reader.GetInt32(reader.GetOrdinal("BookingID"))

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

                        cmd.Parameters.AddWithValue("@ID", Payments.ID);
                        cmd.Parameters.AddWithValue("@StartDate", Payments.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", Payments.EndDate);
                        cmd.Parameters.AddWithValue("@PricePerDay", Payments.PricePerDay);


                        cmd.Parameters.AddWithValue("@TotalAmount", Payments.TotalAmount);
                        cmd.Parameters.AddWithValue("@ClientID", Payments.ClientID);
                        cmd.Parameters.AddWithValue("@PropertyID", Payments.PropertyID);
                        cmd.Parameters.AddWithValue("@CardID", (object)Payments.CardID ?? DBNull.Value);
                      //  cmd.Parameters.AddWithValue("@Status", Payments.Status);



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
