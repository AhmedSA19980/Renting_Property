
using System.Data;
using Microsoft.Data.SqlClient;
using SharedDTOLayer.Countries.CountriesDTO;


namespace PR_DataAccessLayer
{

  
    public  class clsCountriesData
    {


        public static CountryDTO GetCountryInfoByID(int CountryID)
        {


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCountryInfoByID", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryID", (object)CountryID ?? DBNull.Value);





                        using (var reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                return new CountryDTO(
                                   
                                    reader.GetInt32(reader.GetOrdinal("CountryID")),
                                    reader.GetString(reader.GetOrdinal("CountryName"))
                                   
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


      

        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool isFound = false;

            try {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetCountryInfoByID", connection)) {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@CountryID", ID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read())
                            {

                            
                                isFound = true;

                                CountryName = (string)reader["CountryName"];

                            }
                            else
                            {
                            
                                isFound = false;
                            }


                            reader.Close();
                        }

                    }
                    connection.Close(); 
                }

            }
            catch (Exception e) { isFound = false;}
          

         
            return isFound;
        }

        public static bool GetCountryInfoByName(string CountryName, ref int ID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetCountryInfoByCountryName", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@CountryName", CountryName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                    
                                isFound = true;

                                ID = (int)reader["CountryID"];

                            }
                            else
                            {
                             
                                isFound = false;
                            }


                            reader.Close();
                        }

                    }
                    connection.Close();
                }

            }
            catch (Exception e) { isFound = false; }



            return isFound;
        }

        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    using(SqlCommand command = new SqlCommand("SP_GetAllCountries", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.HasRows)

                            {
                                dt.Load(reader);
                            }

                            reader.Close();

                        }
                    }

                }
            }
            catch (Exception e) { 
                
                Console.WriteLine( "Error: " + e.ToString());
            }

            return dt;

        }


        public static List<CountryDTO> ListAllCountries()
        {

            List<CountryDTO> Countries = new List<CountryDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllCountries", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                           while (reader.Read())

                            {
                                Countries.Add(new CountryDTO(reader.GetInt32(reader.GetOrdinal("CountryID")),
                                    
                                        reader.GetString(reader.GetOrdinal("CountryName"))
                                    ));
                            }

                            reader.Close();

                        }
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e.ToString());
            }

            return Countries;

        }



    }
}
