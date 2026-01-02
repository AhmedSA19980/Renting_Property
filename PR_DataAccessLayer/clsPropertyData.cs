using System.Data;
using Microsoft.Data.SqlClient;

using SharedDTOLayer.Properties_.PropertiesDTO;

namespace PR_DataAccessLayer
{


    public class clsPropertyData
    {


        public static List<PropertyDTO> GetAllProperty()
        {
            var PropertyList = new List<PropertyDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllProperties", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                 

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string PlaceDescription = reader.IsDBNull(reader.GetOrdinal("PlaceDescription")) ? "" : reader.GetString(reader.GetOrdinal("PlaceDescription"));


                            decimal Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Price"));
                           
                            PropertyList.Add(new PropertyDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                    reader.GetInt32(reader.GetOrdinal("CountryID")),
                                    reader.GetString(reader.GetOrdinal("City")),
                                     reader.GetString(reader.GetOrdinal("Address")),
                                     PlaceDescription,

                                       reader.GetInt32(reader.GetOrdinal("ContainerID")),
                                      
                                      
                                          reader.GetByte(reader.GetOrdinal("NumberOfBedrooms")),
                                            reader.GetByte(reader.GetOrdinal("NumberOfBathrooms")),
                                              reader.GetByte(reader.GetOrdinal("PropertyTypeID")),
                                              Price,
                                              reader.GetString(reader.GetOrdinal("Name"))
                                             
                            ));
                        }
                    }
                }


                return PropertyList;
            }

        }



        public static List<PropertyDTO> GetAllActiveProperty()
        {
            var PropertyList = new List<PropertyDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataSettings.Addresss))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllActiveProperties", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;



                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string PlaceDescription = reader.IsDBNull(reader.GetOrdinal("PlaceDescription")) ? "" : reader.GetString(reader.GetOrdinal("PlaceDescription"));


                            decimal Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Price"));

                            PropertyList.Add(new PropertyDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                    reader.GetInt32(reader.GetOrdinal("CountryID")),
                                    reader.GetString(reader.GetOrdinal("City")),
                                     reader.GetString(reader.GetOrdinal("Address")),
                                     PlaceDescription,

                                       reader.GetInt32(reader.GetOrdinal("ContainerID")),


                                          reader.GetByte(reader.GetOrdinal("NumberOfBedrooms")),
                                            reader.GetByte(reader.GetOrdinal("NumberOfBathrooms")),
                                              reader.GetByte(reader.GetOrdinal("PropertyTypeID")),
                                              Price,
                                              reader.GetString(reader.GetOrdinal("Name"))

                            ));
                        }
                    }
                }


                return PropertyList;
            }

        }



        public static PropertyDTO FindPropertyByPropertyID2(int PropertyID)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_FindPropertyByPropertyID", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyID", (object)PropertyID ?? DBNull.Value);



                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                string PlaceDescription = reader.IsDBNull(reader.GetOrdinal("PlaceDescription")) ? "" : reader.GetString(reader.GetOrdinal("PlaceDescription"));


                                decimal Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Price"));
                               


                                return new PropertyDTO(
                                    reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                    reader.GetInt32(reader.GetOrdinal("CountryID")),
                                    reader.GetString(reader.GetOrdinal("City")),
                                     reader.GetString(reader.GetOrdinal("Address")),
                                     PlaceDescription,

                                       reader.GetInt32(reader.GetOrdinal("ContainerID")),
                                       
                                       
                                          reader.GetByte(reader.GetOrdinal("NumberOfBedrooms")),
                                            reader.GetByte(reader.GetOrdinal("NumberOfBathrooms")),
                                             reader.GetByte(reader.GetOrdinal("PropertyTypeID")),
                                            Price ,
                                              reader.GetString(reader.GetOrdinal("Name"))
                                              
                                  
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




        public static List< PropertyStatusDTO> GetAllPropertiesByClientId(int ClientId)
        {

            List<PropertyStatusDTO> Properties = new List<PropertyStatusDTO>();
            try
            {
               

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllPropertiesByClientId", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientId", (object)ClientId ?? DBNull.Value);



                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                

                                 Properties.Add(new PropertyStatusDTO(
                                    reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                       reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetString(reader.GetOrdinal("CountryName")),
                                    reader.GetString(reader.GetOrdinal("City")),
                                     reader.GetString(reader.GetOrdinal("Address")),
                                        reader.GetString(reader.GetOrdinal("PropertyTypeName")),

                                       reader.GetDecimal(reader.GetOrdinal("Price")),
                                          reader.GetString(reader.GetOrdinal("PropertyStatus"))


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

            return Properties;
        }


        public static int AddProperty(PropertyAndClientDTO PropertyDTO )
        {

            int PropertyID = -1;
            int PropertyOwnerID = -1;
            try
            {
                using (var connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SP_AddNewProperty", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryID", PropertyDTO.CountryID);

                        command.Parameters.AddWithValue("@City", PropertyDTO.City);

                        command.Parameters.AddWithValue("@Address", PropertyDTO.Address);

                        if (PropertyDTO.PlaceDescription != "" || PropertyDTO.PlaceDescription != null)
                        {
                            command.Parameters.AddWithValue("@PlaceDescription", PropertyDTO.PlaceDescription);
                        }
                        else
                            command.Parameters.AddWithValue("@PlaceDescription", System.DBNull.Value);



                        command.Parameters.AddWithValue("@ContainerID", PropertyDTO.ContainerID);


                        command.Parameters.AddWithValue("@NumberOfBedRooms", PropertyDTO.NumberOfBedrooms);
                        command.Parameters.AddWithValue("@NumberOfBathRooms", PropertyDTO.NumberOfBathrooms);
                        command.Parameters.AddWithValue("@PropertyTypeID", PropertyDTO.PropertyTypeID);
                        if (PropertyDTO.Price == 0)
                        {
                            command.Parameters.AddWithValue("@Price", System.DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Price", PropertyDTO.Price);

                        command.Parameters.AddWithValue("@Name", PropertyDTO.Name);

                        //* add client id to property DTO and once user loged in , client id comes from token => api
                        command.Parameters.AddWithValue("@ClientID", PropertyDTO.ClientID); 


                        SqlParameter outputIdParam = new SqlParameter("@PropertyID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        SqlParameter outputIdParam2 = new SqlParameter("@PropertyOwnerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        
                        command.Parameters.Add(outputIdParam2);


                        command.ExecuteNonQuery();

                        
                        if (outputIdParam.Value != DBNull.Value)
                        {
                            PropertyID = (int)outputIdParam.Value;
                        }
                        else
                        {
                         
                          //  Console.WriteLine("Warning: PropertyID returned NULL from SP_AddNewProperty.");
                          
                            PropertyID = -1; // Indicate failure
                        }

                        if (outputIdParam2.Value != DBNull.Value)
                        {
                            PropertyOwnerID = (int)outputIdParam2.Value;
                        }else
                        {
                            Console.WriteLine("Warning: PropertyOwnerID returned NULL from SP_AddNewProperty.");
                           
                            PropertyOwnerID = -1;
                        }

                        connection.Close();
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
            return PropertyID;

        }



        public static bool UpdateProperty(PropertyDTO PropertyDTO)
        {
            int RowAffected = -1 ;

       

            try
            {
                using (var connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SP_UpdateProperty", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PropertyID", PropertyDTO.PropertyID);
                    

                        command.Parameters.AddWithValue("@CountryID", PropertyDTO.CountryID);

                        command.Parameters.AddWithValue("@City", PropertyDTO.City);

                        if (PropertyDTO.PlaceDescription == "" && PropertyDTO.PlaceDescription == null)
                        {
                            command.Parameters.AddWithValue("@PlaceDescription", System.DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@PlaceDescription", PropertyDTO.PlaceDescription);


                        command.Parameters.AddWithValue("@Address", PropertyDTO.Address);

                        command.Parameters.AddWithValue("@ContainerID", PropertyDTO.ContainerID);

                        command.Parameters.AddWithValue("@PropertyTypeID", PropertyDTO.PropertyTypeID);
                        command.Parameters.AddWithValue("@NumberOfBathRooms", PropertyDTO.NumberOfBathrooms);
                        command.Parameters.AddWithValue("@NumberOfBedRooms", PropertyDTO.NumberOfBedrooms);
                        command.Parameters.AddWithValue("@Name", PropertyDTO.Name);



                        if (PropertyDTO.Price == 0)
                        {
                            command.Parameters.AddWithValue("@Price", System.DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Price", PropertyDTO.Price);
                       RowAffected =  command.ExecuteNonQuery();


                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (RowAffected >0);

        }



        public static int CheckActivePropertyDiscount(int PropertyID)
        {
            int discountID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT dbo.GetActiveDiscountByPropertyID(@PropertyID)", connection))
                    {
                        command.Parameters.AddWithValue("@PropertyID", PropertyID);
                        Console.WriteLine(command.CommandText);
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {

                            discountID = (int)result;
                        }
                        else
                        {
                            
                            discountID = -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            return discountID;
        }


        public static int GetRandomPropertyID()
        {
            int PropertyID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetRandomPropertyID", connection))
                    {
                       
                        Console.WriteLine(command.CommandText);
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {

                            PropertyID = (int)result;
                        }
                        else
                        {
                         
                            PropertyID = -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            return PropertyID;
        }



        public static bool DeleteProperty(int PropertyID)
        {


            int RowAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteProperty", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PropertyID", PropertyID);



                        RowAffected =(int) cmd.ExecuteNonQuery();

                    }
                    connection.Close();

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }



            return (RowAffected >0);

        }



    }
}
