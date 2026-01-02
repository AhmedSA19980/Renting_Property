using Microsoft.Data.SqlClient;
using SharedDTOLayer.Offer.DiscountDTO;
using System.Data;



namespace PR_DataAccessLayer
{

 

  
    public class clsDiscountData
    {

        public static DiscountDTO FindDiscountByDiscountID(int DiscountID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_FindDiscountByDiscountID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DiscountID", DiscountID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                    return new DiscountDTO(
                                        reader.GetInt32(reader.GetOrdinal("DiscountID")),
                                        reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                        reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
                                        reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                        reader.GetDateTime(reader.GetOrdinal("EndDate")),

                                        reader.GetBoolean(reader.GetOrdinal("IsDeleted"))


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
                isFound = false;
            }   

            return null;
        }



        public static DiscountDTO FindDiscountByPropertyID(int PropertyID)
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_FindDiscountsByPropertyID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyID", PropertyID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DiscountDTO(
                                        reader.GetInt32(reader.GetOrdinal("DiscountID")),
                                        reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                        reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
                                        reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                        reader.GetDateTime(reader.GetOrdinal("EndDate")),

                                        reader.GetBoolean(reader.GetOrdinal("IsDeleted"))


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


        public static List< DiscountDTO> FindAllDiscountByPropertyID(int PropertyID)
        {
            List<DiscountDTO> Discounts = new List<DiscountDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_FindDiscountsByPropertyID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyID", PropertyID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                 Discounts.Add(  new DiscountDTO(
                                        reader.GetInt32(reader.GetOrdinal("DiscountID")),
                                        reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                        reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
                                        reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                        reader.GetDateTime(reader.GetOrdinal("EndDate")),

                                        reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                        

                                        ));

                            }

                            reader.Close();
                        }
                        connection.Close();
                        return Discounts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return null;
        }


        public static DataTable GetPropertysDiscounts(int PropertyID)
        {

            DataTable dt =new  DataTable();    
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPropertysDiscounts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyID", PropertyID);

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


        public static List<PropertyDiscountDTO> FindAllDiscountBelongToAPropertyByPropertyID(int PropertyID)
        {
            List<PropertyDiscountDTO> PropertyDiscountsDTO = new List<PropertyDiscountDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPropertysDiscounts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@PropertyID", PropertyID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                          

                            while (reader.Read())
                            {
                                decimal Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Price"));
                                PropertyDiscountsDTO.Add(new PropertyDiscountDTO(
                                       reader.GetInt32(reader.GetOrdinal("DisID")),
                                       reader.GetInt32(reader.GetOrdinal("PropID")),
                                        reader.GetString(reader.GetOrdinal("CountryName")),
                                         reader.GetString(reader.GetOrdinal("City")),
                                     reader.GetString(reader.GetOrdinal("Address")),
                                               Price,
                                       reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
                                       reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                       reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                       reader.GetBoolean(reader.GetOrdinal("IsCompeleted")),
                                        reader.GetBoolean(reader.GetOrdinal("IsPropertyDeleted"))

                                ));

                            }

                            reader.Close();
                        }
                        connection.Close();
                        return PropertyDiscountsDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return null;
        }







        public static int AddNewDiscount(DiscountDTO Discount)
        {
            int discountID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewDiscount", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PropertyID",Discount.PropertyID );
                        cmd.Parameters.AddWithValue("@DiscountPercentage", Discount.DiscountPercentage);
                        cmd.Parameters.AddWithValue("@StartDate", Discount.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", Discount.EndDate);

                        SqlParameter outputIdParam = new SqlParameter("@DiscountID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);

                      
                        cmd.ExecuteScalar();
                     
                        discountID = (int)cmd.Parameters["@DiscountID"].Value;
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


        public static bool UpdateDiscount(DiscountDTO Discount)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateDiscount", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DiscountID", Discount.DiscountID);
                        cmd.Parameters.AddWithValue("@PropertyID", Discount.PropertyID);
                        cmd.Parameters.AddWithValue("@DiscountPercentage", Discount.DiscountPercentage);
                        cmd.Parameters.AddWithValue("@StartDate", Discount.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", Discount.EndDate);

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

        public static bool DeleteDiscount(int discountID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteDiscount", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DiscountID", discountID);

                        
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
