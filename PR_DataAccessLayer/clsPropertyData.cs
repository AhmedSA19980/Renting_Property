using System.Data;
using System.Diagnostics;
using System.Net;
using Microsoft.Data.SqlClient;

namespace PR_DataAccessLayer
{

    public class PropertyDTOWithContainerDTO
    {
       
        public PropertyDTO Property { get; set; }
        public ImagesDTO Container { get; set; }
    }
    public class PropertyDTO
    {
        public PropertyDTO(int PropertyID, int CountryID, string City, string Address,
          string PlaceDescription, int ContainerID, 
         byte NumberOfBedRooms, byte NumberOfBathRooms, byte PropertyTypeID, decimal Price, string Name)
        {
            this.PropertyID = PropertyID;
            this.CountryID = CountryID;
            this.City = City;
            this.Address = Address;
            this.PlaceDescription = PlaceDescription;
            this.ContainerID = ContainerID;
            this.NumberOfBedrooms = NumberOfBedRooms;
            this.NumberOfBathrooms = NumberOfBathRooms;
            this.PropertyTypeID = PropertyTypeID;
            this.Price = Price;
            this.Name = Name;   


        }
      
        public int PropertyID { get; set; }
        public int CountryID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PlaceDescription { get; set; }

        public int ContainerID { get; set; }
        public byte NumberOfBedrooms { get; set; }
        public byte NumberOfBathrooms { get; set; }
        public byte PropertyTypeID { get; set; }
       

        public decimal Price { get; set; }
        public string Name { get; set; }
    }
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
                            // bool IsPropertyDeleted = reader.IsDBNull(reader.GetOrdinal("IsPropertyDeleted")) ? false : reader.GetBoolean(reader.GetOrdinal("IsPropertyDeleted"));

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


        //**************************   implement full porperties info


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
                                // bool IsPropertyDeleted = reader.IsDBNull(reader.GetOrdinal("IsPropertyDeleted")) ? false : reader.GetBoolean(reader.GetOrdinal("IsPropertyDeleted"));



                                return new PropertyDTO(
                                    reader.GetInt32(reader.GetOrdinal("PropertyID")),
                                    reader.GetInt32(reader.GetOrdinal("CountryID")),
                                    reader.GetString(reader.GetOrdinal("City")),
                                     reader.GetString(reader.GetOrdinal("Address")),
                                     PlaceDescription,

                                       reader.GetInt32(reader.GetOrdinal("ContainerID")),
                                       
                                        reader.GetByte(reader.GetOrdinal("PropertyTypeID")),
                                          reader.GetByte(reader.GetOrdinal("NumberOfBedrooms")),
                                            reader.GetByte(reader.GetOrdinal("NumberOfBathrooms")),
                                            Price ,
                                              reader.GetString(reader.GetOrdinal("Name"))
                                              

                                    //  IsPropertyDeleted
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


        public static int AddProperty(PropertyDTO PropertyDTO)
        {

            int PropertyID = -1;
            int clientID = -1;
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

                        if (PropertyDTO.PlaceDescription != "" && PropertyDTO.PlaceDescription != null)
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


                        command.Parameters.AddWithValue("@ClientID", 14);






                        SqlParameter outputIdParam = new SqlParameter("@PropertyID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);


                        command.ExecuteScalar();



                        PropertyID = (int)command.Parameters["@PropertyID"].Value;
                        clientID = (int)command.Parameters["@propertyOwnerID"].Value;
                    }
                    connection.Close();
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

                        if (PropertyDTO.PlaceDescription != "" && PropertyDTO.PlaceDescription != null)
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
                            // Handle the case where no discount is found
                            discountID = -1; // Or another default value
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
                       // command.Parameters.AddWithValue("@PropertyID", PropertyID);
                        Console.WriteLine(command.CommandText);
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {

                            PropertyID = (int)result;
                        }
                        else
                        {
                            // Handle the case where no discount is found
                            PropertyID = -1; // Or another default value
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



        public static bool FindPropertyByPropertyID(int PropertyID, ref int CountryID, ref string City, ref string Address,
           ref string PlaceDescription, ref int ImagesContainerID, ref decimal Price,
          ref byte PropertyTypeID, ref byte NumberOfBedRooms, ref byte NumberOfBathRooms, ref bool IsPropertyDeleted)
        {

            bool isFound = false;
            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_FindPropertyByPropertyID", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyID", (object)PropertyID ?? DBNull.Value);


                        //SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        //{
                        //    Direction = ParameterDirection.ReturnValue
                        //};


                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;
                                PropertyID = (int)reader["PropertyID"];
                                CountryID = (int)reader["CountryID"];
                                ImagesContainerID = (int)reader["ContainerID"];
                                Address = (string)reader["Address"];
                                City = (string)reader["City"];
                                PropertyTypeID = (byte)reader["PropertyTypeID"];
                                NumberOfBathRooms = (byte)reader["NumberOfBathRooms"];
                                NumberOfBedRooms = (byte)reader["NumberOfBedRooms"];


                                if (reader["PlaceDescription"] == DBNull.Value)
                                {
                                    PlaceDescription = "";
                                }
                                else
                                {
                                    PlaceDescription = (string)reader["PlaceDescription"];

                                }

                                if (reader["Price"] == DBNull.Value)
                                {
                                    Price = 0;
                                }
                                else
                                {
                                    Price = (decimal)reader["Price"];

                                }


                                if (reader["IsPropertyDeleted"] == DBNull.Value)
                                {
                                    IsPropertyDeleted = false;
                                }
                                else
                                {
                                    IsPropertyDeleted = (bool)reader["IsPropertyDeleted"];


                                }


                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
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

            return isFound;
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