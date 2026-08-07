using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

using System.Windows.Forms;
namespace PropertyRenting.ClassGlobal
{
    public class clsGlobal
    {
        public static Models.SessionManager CurrentUser ; // Models.Client
     


        //public static Models.Client CurrentUser;
        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
           


            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

            string valueUserName = "UserName";
            //string valueUSerNameData = Username;


            string valuePassword = "Password";
            // string valuePasswordData = Password;

            try
            {

                string User = Registry.GetValue(keyPath, valueUserName, UserName.ToString()) as string;

                string Pass = Registry.GetValue(keyPath, valuePassword, Password.ToString()) as string;


                if (User != null && Pass != null)
                {
                    UserName = User;
                    Password = Pass;
                    // MessageBox.Show($"{User} {Pass}");
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");
                SaveToEventLog(ex.Message, EventLogEntryType.Warning);
                return false;
            }

        }

        public static bool RememberUsernameAndPassword(string UserName, string Password)
        {

            

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";
            string valueName = "UserName";
            string valueData = UserName;

            string valuePassword = "Password";
            string valuePasswordData = Password;
            string SourceName = "DrivingLicenseSystem";

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);
                Registry.SetValue(keyPath, valuePassword, valuePasswordData, RegistryValueKind.String);

                // MessageBox.Show($"Value {valueData} successfully written to the Registry.");
                //Console.Write($"Value {valueName} successfully written to the Registry.");


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }



        }

        public static void SaveToEventLog(string EventMessage, EventLogEntryType EventLogType, string SourceName = "RentingPorpertySystem")
        {

            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                    Console.WriteLine("Event source has been created!");
                }

                EventLog.WriteEntry(SourceName, EventMessage, EventLogType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to event log: {ex.Message}");
                // Optionally, log the exception to a file or another logging system
            }
        }

        public static string  Mask(string CardNum)
        {
            if(CardNum .Length < 12)
            {
                return "Invalid Card Number length";
            }

          string mask = CardNum.Substring(0 , 6) + new string('*' , CardNum.Length - 10) + CardNum.Substring(CardNum.Length - 10);
          return mask;
        }

        public static string hashPassword(string Password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
