using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PR_BusinessLayer.Utilities
{
    public class clsGlobal
    {
        public static clsClients CurrentUser;


        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            //try
            //{
            //    //gets the current project's directory
            //    string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            //    // Path for the file that contains the credential.
            //    string filePath  = currentDirectory + "\\data.txt";

            //    // Check if the file exists before attempting to read it
            //    if (File.Exists(filePath))
            //    {
            //        // Create a StreamReader to read from the file
            //        using (StreamReader reader = new StreamReader(filePath))
            //        {
            //            // Read data line by line until the end of the file
            //            string line;
            //            while ((line = reader.ReadLine()) != null)
            //            {
            //                Console.WriteLine(line); // Output each line of data to the console
            //                string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

            //                Username = result[0];
            //                Password = result[1];
            //            }
            //            return true;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show ($"An error occurred: {ex.Message}");
            //    return false;   
            //}



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

                // MessageBox.Show($"An error occurred: {ex.Message}");
                //SaveToEventLog(ex.Message, EventLogEntryType.Warning);
                return false;
            }

        }

        public static bool RememberUsernameAndPassword(string UserName, string Password)
        {

            //try
            //{
            //    //this will get the current project directory folder.
            //    string currentDirectory = System.IO.Directory.GetCurrentDirectory();


            //    // Define the path to the text file where you want to save the data
            //    string filePath = currentDirectory + "\\data.txt";

            //    //incase the username is empty, delete the file
            //    if (Username=="" && File.Exists(filePath)) 
            //    { 
            //         File.Delete(filePath);
            //        return true;

            //    }

            //    // concatonate username and passwrod withe seperator.
            //    string dataToSave = Username + "#//#"+Password ;

            //    // Create a StreamWriter to write to the file
            //    using (StreamWriter writer = new StreamWriter(filePath))
            //    {
            //        // Write the data to the file
            //        writer.WriteLine(dataToSave);

            //      return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //   MessageBox.Show ($"An error occurred: {ex.Message}");
            //    return false;
            //}





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



        public static string Mask(string CardNum)
        {
            if (CardNum.Length < 12)
            {
                return "Invalid Card Number length";
            }

            string mask = CardNum.Substring(0, 6) + new string('*', CardNum.Length - 10) + CardNum.Substring(CardNum.Length - 10);
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

