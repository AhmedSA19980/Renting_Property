using Microsoft.Data.SqlClient;
using SharedDTOLayer.Income.IncomesDTO;
using SharedDTOLayer.Payments.PaymentsDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PR_DataAccessLayer
{
    public  class clsEarningData
    {


        public static SettleClientIncomeByPeriodDTO SettleClientIncomeByPeriod(SettleClientIncomeByPeriodValuesDTO Values)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_SettleClientIncomeByPeriod", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", Values.ClientId);
                        command.Parameters.AddWithValue("@startDate", Values.StartDate);
                        command.Parameters.AddWithValue("@endDate", Values.EndDate);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                return new SettleClientIncomeByPeriodDTO(

                                    reader.GetDecimal(reader.GetOrdinal("totalIncome")),
                                      reader.GetDecimal(reader.GetOrdinal("fee")),
                                        reader.GetDecimal(reader.GetOrdinal("tax")),
                                         reader.GetDecimal(reader.GetOrdinal("netAfterTaxAndFee"))
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

        public static decimal TotalIncomeByProperty(int PropertyID)
        {

            decimal Total = 0;
            try
            {
              
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetTotalIncomeByProperty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyId", PropertyID);
                       
                       object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value) {

                            Total = Convert.ToDecimal(result);
                        }

                        
                    }
                        connection.Close();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return Total;
        }


        public static List<AllOwnerEarningsDTO> GetAllOwnerEarnings(int ClientID)
        {

            List<AllOwnerEarningsDTO> Payments = new List<AllOwnerEarningsDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllOwnerEarnings", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", ClientID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            while (reader.Read())
                            {
                               

                                Payments.Add(new AllOwnerEarningsDTO
                                 (
                                  reader.GetInt32(reader.GetOrdinal("propertyId")),

                                        reader.GetString(reader.GetOrdinal("countryName")),
                                     reader.GetDecimal(reader.GetOrdinal("price")),
                                       reader.GetString(reader.GetOrdinal("discountPer")),
                                       reader.GetString(reader.GetOrdinal("name")),
                                         reader.GetBoolean(reader.GetOrdinal("isPropertyDeleted")),
                                          reader.GetDateTime(reader.GetOrdinal("startDate")),

                                       reader.GetDateTime(reader.GetOrdinal("endDate")),
                                        reader.GetInt32(reader.GetOrdinal("bookingByClientId")),
                                           reader.GetString(reader.GetOrdinal("paymentStatus")),
                                            reader.GetDecimal(reader.GetOrdinal("pricePerDay")),
                                             reader.GetDecimal(reader.GetOrdinal("PriceAfterDiscount")),

                                                 reader.GetDecimal(reader.GetOrdinal("totalAmount")),
                                                 reader.GetDateTime(reader.GetOrdinal("paidDate")),
                                                    reader.GetInt32(reader.GetOrdinal("bookingId"))
                                 

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


        public static List<AllOwnerEarningsByPropertyDTO> AllOwnerEarningsByProperty(int PropertyID)
        {

            List<AllOwnerEarningsByPropertyDTO> Payments = new List<AllOwnerEarningsByPropertyDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllOwnerEarningsByProperty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyID", PropertyID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            while (reader.Read())
                            {


                                Payments.Add(new AllOwnerEarningsByPropertyDTO
                                 (
                                     reader.GetInt32(reader.GetOrdinal("ClientID")),

                                      reader.GetInt32(reader.GetOrdinal("propertyId")),

                                        reader.GetString(reader.GetOrdinal("countryName")),
                                         reader.GetDecimal(reader.GetOrdinal("price")),
                                           reader.GetString(reader.GetOrdinal("discountPer")),
                                           reader.GetString(reader.GetOrdinal("name")),
                                             reader.GetBoolean(reader.GetOrdinal("isPropertyDeleted")),
                                              reader.GetDateTime(reader.GetOrdinal("startDate")),

                                           reader.GetDateTime(reader.GetOrdinal("endDate")),
                                            reader.GetInt32(reader.GetOrdinal("bookingByClientId")),
                                               reader.GetString(reader.GetOrdinal("paymentStatus")),
                                                reader.GetDecimal(reader.GetOrdinal("pricePerDay")),
                                                 reader.GetDecimal(reader.GetOrdinal("PriceAfterDiscount")),

                                                    reader.GetDecimal(reader.GetOrdinal("totalAmount")),
                                                      reader.GetDateTime(reader.GetOrdinal("paidDate")),

                                                      reader.GetInt32(reader.GetOrdinal("bookingId"))


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

    }
}
