using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PR_DataAccessLayer
{
    public class ClientDTO 
    {
        public ClientDTO(int ClientID , string username , string password  , int personID) { 
        
            this.ClientID = ClientID;
            this.UserName = username;   
            this.Password = password;   
            this.PersonID = personID;


        }
        public int ClientID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }    
        public int PersonID { get; set; }
    }


    public class FullClientDTO : PersonDTO
    {
     
        public FullClientDTO(int ClientID, string UserName, string Password,  int ClientPersonID, int PersonID,
            string FirstName, string LastName, DateTime DateOfBirth, bool Gender,
            string Address, int NationalityCountryID, string Phone, string email, string personalImage): base(PersonID,  FirstName,  LastName,  DateOfBirth,  Gender,
             Address, NationalityCountryID, Phone,  email,  personalImage)
        {
            this.ClientID = ClientID;
            this.UserName = UserName;
            this.Password = Password;
            this.ClientPersonID = ClientPersonID;


           this.PersonID = PersonID;
            this.FirstName = FirstName; 
            this.LastName = LastName;   
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.NationalityCountryID = NationalityCountryID;
            this.Phone = Phone; 
            this.Email = email;
            this.PersonalImage = personalImage; 
            

          
        }
        public FullClientDTO() { }
        

        public int ClientID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       public int ClientPersonID { get; set; }
    }



    public class clsClientsData
    {

       
        public static ClientDTO GetClientByID(int ClientID)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetClientByID", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);
                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                return new ClientDTO(

                                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                     reader.GetString(reader.GetOrdinal("Password")),
                                      reader.GetInt32(reader.GetOrdinal("PersonID"))
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


        public static FullClientDTO GetFullClientInfoByID(int ClientID)
        {

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetFullClientInfo", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);

                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                return new FullClientDTO(

                                     reader.GetInt32(reader.GetOrdinal("ClientID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                     reader.GetString(reader.GetOrdinal("Password")),
                                     reader.GetInt32(reader.GetOrdinal("ClientPersonID")),

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




        public static DataTable GetClientCards(int ClientID)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetClientCards", connection))
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

       
        public static int AddNewClient(ClientDTO Client )
        {
           
            int ClientID = -1;
           
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {

                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewClient", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                       // cmd.Parameters.AddWithValue("@ClientID", Client.ClientID);
                        cmd.Parameters.AddWithValue("@UserName", Client.UserName);
                        cmd.Parameters.AddWithValue("@Password", Client.Password);
                        cmd.Parameters.AddWithValue("@PersonID", Client.PersonID);

                        SqlParameter outputIdParam = new SqlParameter("@ClientID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);

                        cmd.ExecuteScalar();

                        ClientID = (int)cmd.Parameters["@ClientID"].Value;
                      

                    }
                    connection.Close();
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
           
           

            return ClientID;
        }


        public static bool UpdateClient(ClientDTO Client)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateClient", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.AddWithValue("@ClientID", Client.ClientID);
                        cmd.Parameters.AddWithValue("@UserName", Client.UserName);
                        cmd.Parameters.AddWithValue("@Password", Client.Password);
                        //cmd.Parameters.AddWithValue("@PersonID", Client.PersonID);
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



        public static bool ChangePassword(int ClientID , string Password)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_ChangePassword", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);
                       // cmd.Parameters.AddWithValue("@UserName", Client.UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        //cmd.Parameters.AddWithValue("@PersonID", Client.PersonID);
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



        public static void CheckClientExists(string Email)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_CheckClientExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@email", (object)Email ?? DBNull.Value);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        command.ExecuteNonQuery();

                        bool ClientExists = (int)returnParameter.Value == 1;

                        Console.WriteLine($" Client Exist   {ClientExists}");

                        connection.Close();

                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($" Person doesn't Exist   {ex.Message}");
            }

        }

        public static bool GetUserByUserNameAndPassword(string UserName , string password)
        {
            

            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoByUserNameAndPass", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", (object)password ?? DBNull.Value);
                        using (var reader = command.ExecuteReader())
                        {

                            return reader.Read();

                           

                        }
                      
                        connection.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //return false;
            }

            return false;
        }


        public static FullClientDTO GetUserInfoByUserNameAndPassword(string UserName, string password)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetClientInfoByUserNameAndPassword", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", (object)password ?? DBNull.Value);
                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                return new FullClientDTO(

                                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                     reader.GetString(reader.GetOrdinal("Password")),
                                      
                                     reader.GetInt32(reader.GetOrdinal("PersonID")),
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

        public static ClientDTO GetUserInfoByUserNameAndPassword_2(string UserName, string password)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoByUserNameAndPass", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", (object)password ?? DBNull.Value);
                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                return new ClientDTO(

                                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                     reader.GetString(reader.GetOrdinal("Password")),
                                      reader.GetInt32(reader.GetOrdinal("PersonID"))
                                      

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

    }
}
