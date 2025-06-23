using System;
using System.Data;
using Microsoft.Data.SqlClient;
using PR_DataAccessLayer;
namespace PR_DataAccessLayer
{

    public class PersonDTO {

      public  int PersonID { get; set; }
        public string FirstName { set; get; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public int NationalityCountryID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PersonalImage {  get; set; }
        public PersonDTO() { }
        public PersonDTO(int PersonID, string firstname , string lastname , DateTime dateOfBirth ,bool Gender , 
            string Address , int nationalityCountryId , string phone , string email  , string personalImage) { 
        
            this.PersonID = PersonID;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.DateOfBirth = dateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.NationalityCountryID = nationalityCountryId;   
            this.Phone = phone;
            this.Email = email;
            this.PersonalImage = personalImage;
        

        }
    }
    public  class clsPeopleData
    {

       // public static int GetPersonID;

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


                        //SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        //{
                        //    Direction = ParameterDirection.ReturnValue
                        //};


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


            //GetPersonID = PersonID;

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
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
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
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
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

                    // Replace "SP_UpdateUser" with the actual stored procedure name for user update
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


                        // Assuming PersonalImage is a path, you might need additional logic for storing it.
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




        public static bool DeletePerson(int PersonId)
        {


            int RowAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PersonId", PersonId);


                       
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


        public static bool IsUserBlocked(int personId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
            {
                using (SqlCommand command = new SqlCommand("SP_IsUserBlocked", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the input parameter
                    command.Parameters.AddWithValue("@PersonID", personId);

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
                        // Handle any potential database errors
                        Console.WriteLine($"Error checking user block status: {ex.Message}");
                        return false; // Or throw the exception, depending on your error handling strategy
                    }
                }
            }
        }

    }
}
