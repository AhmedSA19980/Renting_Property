
namespace PR_DataAccessLayer
{
    public class clsDataSettings
    {
        // databaseConnectionString 
        static string  connectionString = Environment.GetEnvironmentVariable("databaseConnectionString");

        public static string Addresss = connectionString; //"server=localhost;Database=HouseRentingSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
      //  "Server=localhost;Database=StudentsDB;User Id=sa;Password=sa;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
    
       
    }
}
