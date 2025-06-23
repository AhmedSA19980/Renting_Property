using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace RentingDatabaseAccessLayer
{
    public class clsUserDataAccess
    {
        public static bool GetUserById(int ID  , ref string FullName , ref string Email, ref string Phone ) {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(SettingAccessDatabase.ConnectDatabaseAddress);

            string Query = "SELECT * FROM USER WHERE USERID=ID";

            SqlCommand cmd = new SqlCommand(Query ,connection);
            cmd.Parameters.AddWithValue("ID", ID);

            try{
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true; 
                    int USERID = (int)reader["ID"];
                    FullName = (string)reader["FullName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];

                }else
                {
                    isFound = false;
                }

                reader.Close();
            }catch (Exception ex) {
                Console.WriteLine("ERROR: " + ex.Message);
                isFound = false;
            }

            finally { connection.Close(); }

            return isFound;
        
        
        
        }


    }
}
