using System.Data;
using Microsoft.Data.SqlClient;
using SharedDTOLayer.People.PeopleDTO;

<<<<<<< HEAD


namespace PR_DataAccessLayer
{

    public  class clsPeopleData
    {

       

        public static PersonDTO FindPersonByPersonID(int PersonID)
        {

            bool isFound = false;
            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPersonByPersonID ", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                return new PersonDTO(
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                     reader.GetString(reader.GetOrdinal("LastName")),
                                     reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                      reader.GetBoolean(reader.GetOrdinal("Gender")),
                                       reader.GetString(reader.GetOrdinal("Address")),
                                     reader.GetInt32(reader.GetOrdinal("NationalityCountryID")),
                                       reader.GetString(reader.GetOrdinal("Phone")),
                                         reader.GetString(reader.GetOrdinal("Email")),
                                           reader.GetString(reader.GetOrdinal("PersonalImage"))


                                );
                                // The record was found

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




        public static int AddNewPerson(PersonDTO Person)
        {


            int PersonID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@NationalityCountryID",Person. NationalityCountryID);

                        cmd.Parameters.AddWithValue("@FirstName",Person. FirstName);
                        cmd.Parameters.AddWithValue("@LastName",Person. LastName);

                       
                            cmd.Parameters.AddWithValue("@Email", Person.Email);


                        cmd.Parameters.AddWithValue("@Address", Person.Address);

                    
                        cmd.Parameters.AddWithValue("@Phone", Person.Phone);
                        cmd.Parameters.AddWithValue("@Gender", Person.Gender);
                        cmd.Parameters.AddWithValue("@DateOfBirth", Person.DateOfBirth);
                        cmd.Parameters.AddWithValue("@PersonalImage",Person.PersonalImage);


                        SqlParameter outputIdParam = new SqlParameter("@PersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);

                        connection.Open();
                        cmd.ExecuteScalar();



                        PersonID = (int)cmd.Parameters["@PersonID"].Value;
                        connection.Close();
                    }

                }

            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }


         

            return PersonID;

        }



        public static bool Blockuser(int PersonID)
        {
            int rowsAffected = -1;

            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_BlockUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@clientID", PersonID);
                        rowsAffected = cmd.ExecuteNonQuery();


                    }
                    connection.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; };
        
           return rowsAffected > 0;
        }

        public static bool UnBlockuser(int PersonID)
        {
            int rowsAffected = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UnBlockUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@clientID", PersonID);
                        rowsAffected = cmd.ExecuteNonQuery();


                    }
                    connection.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; };

            return rowsAffected > 0;
        }
        public static bool UpdateUser(PersonDTO Person)
        {
            int rowsAffected = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

              
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateNewPerson", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PersonID",Person. PersonID);
                        cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", Person.LastName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", Person.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", Person.Gender);
                        cmd.Parameters.AddWithValue("@Address", Person.Address);
                        cmd.Parameters.AddWithValue("@NationalityCountryID", Person.NationalityCountryID);
                        cmd.Parameters.AddWithValue("@Phone", Person.Phone);
               
                        cmd.Parameters.AddWithValue("@Email", Person.Email);


                        //  PersonalImage is a path
                        cmd.Parameters.AddWithValue("@PersonalImage",Person.PersonalImage);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return rowsAffected > 0;
        }





        public static int GetClientIdByEmail(string Email)
        {
            int PersonID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPersonIdByPersonEmail", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", Email);
                        //Console.WriteLine(command.CommandText);
                        object result = command.ExecuteScalar();

                        if (result != null )
                        {

                            PersonID = (int)result;
                        }
                        else
                        {
                            // Handle the case where no discount is found
                            PersonID = -1; // Or another default value
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            return PersonID;
        }
        public static int GetClientIdByPersonID(int PersonID)
        {
            int clientID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetClientIdByPersonID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                 
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {

                            clientID = (int)result;
                        }
                        else
                        {
                          
                            clientID = -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        public static int GetClientIdByEmail(string Email)
        {
            int PersonID = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPersonIdByPersonEmail", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", Email);
                        //Console.WriteLine(command.CommandText);
                        object result = command.ExecuteScalar();

                        if (result != null )
                        {

                            PersonID = (int)result;
                        }
                        else
                        {
                            // Handle the case where no discount is found
                            PersonID = -1; // Or another default value
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            return PersonID;
        }
        public static int GetClientIdByPersonID(int PersonID)
        {
            int clientID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetClientIdByPersonID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                 
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {

                            clientID = (int)result;
                        }
                        else
                        {
                          
                            clientID = -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return clientID;
        }
        public static bool IsUserBlocked(int personId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
            {
                using (SqlCommand command = new SqlCommand("SP_IsUserBlocked", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the input parameter
                    command.Parameters.AddWithValue("@clientID", personId);

                    // Add the output parameter
                    SqlParameter isBlockedParam = new SqlParameter("@IsBlocked", System.Data.SqlDbType.Bit);
                    isBlockedParam.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(isBlockedParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        if (isBlockedParam.Value != DBNull.Value && (bool)isBlockedParam.Value)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                     
                        Console.WriteLine($"Error checking user block status: {ex.Message}");
                        return false; 
                    }
                }
            }
        }

    }

 
}
