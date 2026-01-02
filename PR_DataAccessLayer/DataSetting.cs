
namespace PR_DataAccessLayer
{
    public class clsDataSettings
    {
       
        static string  connectionString = Environment.GetEnvironmentVariable("databaseConnectionString");

        public static string Addresss = connectionString; 
    
       
    }
}
