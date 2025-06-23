using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_DataAccessLayer
{
    public class CustomersPaymentsCardsDTO
    {

        public CustomersPaymentsCardsDTO(int id, string cardName, string cardNo,
            DateTime establishedDate,
            DateTime ExpiryDate, int clientid)
        {

            this.ID = id;
            this.CardName = cardName;
            this.CardNo = cardNo;
            this.EstablishedDate = establishedDate;
            this.ExpiryDate = ExpiryDate;
       //     this.CVV = cvv;
            this.ClientID = clientid;

        }

        public int ID { get; set; }
        public string CardName { get; set; }
        public string CardNo { get; set; }
        public DateTime EstablishedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
     //   private string CVV { get; set; }

        public int ClientID { get; set; }
    }

    public class CustomersPaymentsCardsDataSettingCVVDTO:CustomersPaymentsCardsDTO
    {
        public CustomersPaymentsCardsDataSettingCVVDTO(int id, string cardName, string cardNo,
                                        DateTime establishedDate,
                                        DateTime expiryDate, int clientid, string cvv):base (id, cardName, cardNo, establishedDate, expiryDate, clientid)
        { 
       
             this.CVV=cvv;
        }
        public string CVV { get; set; }


    }
    

    public class clsCustomersPaymentsCardsData
    {

        

        public static List<CustomersPaymentsCardsDTO> GetCustomersPaymentsCards()
        {
            var CustomersCardsList = new List<CustomersPaymentsCardsDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetCustomersPaymentsCards", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            CustomersCardsList.Add(new CustomersPaymentsCardsDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("ID")),
                                  
                                    reader.GetString(reader.GetOrdinal("CardName")),
                                     reader.GetString(reader.GetOrdinal("CardNo")),

                                       reader.GetDateTime(reader.GetOrdinal("EstablishedDate")),
                                    
                                        reader.GetDateTime(reader.GetOrdinal("ExpDate")),
                                       
                                        reader.GetInt32(reader.GetOrdinal("ClientID"))



                            ));
                        }
                    }
                }


                return CustomersCardsList;
            }

        }




        public static DataTable GetCards()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCustomersPaymentsCards", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                     

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



        public static CustomersPaymentsCardsDTO GetCustomersPaymentsCardsByID(int ID)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCustomersPaymentsCardsByID", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CusCardID", (object)ID ?? DBNull.Value);





                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                              

                                return new CustomersPaymentsCardsDTO(
                                   reader.GetInt32(reader.GetOrdinal("ID")),

                                    reader.GetString(reader.GetOrdinal("CardName")),
                                     reader.GetString(reader.GetOrdinal("CardNo")),

                                       reader.GetDateTime(reader.GetOrdinal("EstablishedDate")),

                                        reader.GetDateTime(reader.GetOrdinal("ExpDate")),
                                          
                                        reader.GetInt32(reader.GetOrdinal("ClientID"))

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


        public static CustomersPaymentsCardsDataSettingCVVDTO GetCustomersPaymentsCardsByID_2(int ID)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCustomersPaymentsCardsByID", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CusCardID", (object)ID ?? DBNull.Value);





                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {



                                return new CustomersPaymentsCardsDataSettingCVVDTO(
                                   reader.GetInt32(reader.GetOrdinal("ID")),

                                    reader.GetString(reader.GetOrdinal("CardName")),
                                     reader.GetString(reader.GetOrdinal("CardNo")),

                                       reader.GetDateTime(reader.GetOrdinal("EstablishedDate")),

                                        reader.GetDateTime(reader.GetOrdinal("ExpDate")),
                                        
                                        reader.GetInt32(reader.GetOrdinal("ClientID")),
                                          reader.GetString(reader.GetOrdinal("CVV"))

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


        public static CustomersPaymentsCardsDTO GetCustomersPaymentsCardsByCardName(string CardName)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCustomersPaymentsCardsByCardName", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CardName", (object)CardName ?? DBNull.Value);





                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {



                                return new CustomersPaymentsCardsDTO(
                                   reader.GetInt32(reader.GetOrdinal("ID")),

                                    reader.GetString(reader.GetOrdinal("CardName")),
                                     reader.GetString(reader.GetOrdinal("CardNo")),

                                       reader.GetDateTime(reader.GetOrdinal("EstablishedDate")),

                                        reader.GetDateTime(reader.GetOrdinal("ExpDate")),

                                        reader.GetInt32(reader.GetOrdinal("ClientID"))

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


        public static int AddCard(CustomersPaymentsCardsDataSettingCVVDTO CardProperties)
        {

            int ID = -1;

            try
            {
                using (var connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SP_AddCustomerPaymentCard", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                       // command.Parameters.AddWithValue("@CustomerPaymentID", CardProperties.ID);

                        command.Parameters.AddWithValue("@CardName", CardProperties.CardName);

                       
                       
                        command.Parameters.AddWithValue("@CardNo" ,  CardProperties.CardNo);

                        command.Parameters.AddWithValue("@EstablishedDate", CardProperties.EstablishedDate);

                        command.Parameters.AddWithValue("@ExpDate", CardProperties.ExpiryDate);
                        command.Parameters.AddWithValue("@cvv", CardProperties.CVV);
                        command.Parameters.AddWithValue("@ClientID",CardProperties.ClientID);
                     


                        SqlParameter outputIdParam = new SqlParameter("@CustomerPaymentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);


                        command.ExecuteScalar();



                        ID = (int)command.Parameters["@CustomerPaymentID"].Value;

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ID;

        }




        public static bool UpdateCard(CustomersPaymentsCardsDataSettingCVVDTO CardProperties)
        {
            int RowAffected = -1;



            try
            {
                using (var connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SP_UpdateCustomerPaymentCard", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerPaymentID", CardProperties.ID);

                        command.Parameters.AddWithValue("@CardName", CardProperties.CardName);



                        command.Parameters.AddWithValue("@CardNo", CardProperties.CardNo);

                        command.Parameters.AddWithValue("@EstablishedDate", CardProperties.EstablishedDate);

                        command.Parameters.AddWithValue("@ExpDate", CardProperties.ExpiryDate);
                        command.Parameters.AddWithValue("@cvv", CardProperties.CVV);
                        command.Parameters.AddWithValue("@ClientID", CardProperties.ClientID);

                        RowAffected = command.ExecuteNonQuery();


                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (RowAffected > 0);

        }
        public static bool DelCard(int CardID)
        {


            int RowAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DelCustomerCard", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", CardID);



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
