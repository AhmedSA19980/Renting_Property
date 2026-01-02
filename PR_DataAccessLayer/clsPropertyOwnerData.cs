using Microsoft.Data.SqlClient;
using SharedDTOLayer.ProperiesOwner.PropertiesOwnerDTO;
using System.Data;





namespace PR_DataAccessLayer
{
  
    public class clsPropertyOwnerData
    {


        public static int GetPropertyClientIdByPropertyID(int PropertyID)
        {
            int clientid = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPropertyClientIdByPropertyID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PropertyID", PropertyID);

                        connection.Open();
                        object result = command.ExecuteScalar(); 

                        if (result != null && result != DBNull.Value)
                        {
                            clientid = Convert.ToInt32(result); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return clientid;
        }

        public static PropertyOwnerDTO FindPropertyOwnerByPropertyOwnerID(int PropertyOwnerID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPropertyOwnerByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PropertyOwnerID", PropertyOwnerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new PropertyOwnerDTO(
                                        reader.GetInt32(reader.GetOrdinal("PropertyOwnerID")),
                                        reader.GetInt32(reader.GetOrdinal("ClientID")),
                                        reader.GetInt32(reader.GetOrdinal("PropertyID"))

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



        public static List<PropertyOwnerDTO> FindAllPropertiesBelongToOwner(int ClientID )
        {
            List<PropertyOwnerDTO> PropertyOwnerDTO = new List<PropertyOwnerDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllPropertiesBelongToOwner", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", ClientID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            while (reader.Read())
                            {
                                
                                PropertyOwnerDTO.Add(new PropertyOwnerDTO(
                                     reader.GetInt32(reader.GetOrdinal("PropertyOwnerID")),
                                     reader.GetInt32(reader.GetOrdinal("ClientID")),
                                     reader.GetInt32(reader.GetOrdinal("PropertyID"))
                                       
                                    
                                ));

                            }

                            reader.Close();
                        }
                        connection.Close();
                        return PropertyOwnerDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return null;
        }





    }
}
