using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.ClassGlobal
{
    public class clsUtill
    {
        public static string GenerateGUID()
        {
            Guid newID = Guid.NewGuid();

            return newID.ToString();


        }


        public static string ReplaceFileNameWithGUID(string SoruceFile)
        {

            string FileName = SoruceFile;
            FileInfo fi = new FileInfo(FileName);
            string extn = fi.Extension;

            return GenerateGUID() + extn;

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static async Task<string> CopyImageToProjectImagesFolder( string sourceFile)
        {


            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            try {
                string DestinationFolder = @"D:\RentingPorpertySystem\";

                if (!CreateFolderIfDoesNotExist(DestinationFolder))
                {
                    return null;
                }

                string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
                await Task.Run(() => File.Copy(sourceFile, destinationFile, true));

                sourceFile = destinationFile;
                return destinationFile;

            } catch (IOException iox) {

                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
           

           

     
        }

        

        public static bool CopyImageToProjectImagesFolder2(ref string sourceFile , string DefultFolder ="" )
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @$"D:\RentingPropertySystem{DefultFolder}";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.SaveToEventLog(iox.Message, EventLogEntryType.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }



        



        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"D:\RentingPorpertySystem\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.SaveToEventLog(iox.Message, EventLogEntryType.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static async Task<string> CopyImageToProjectImagesFolder2(string sourceFile, string defaultPath = "")
        {


            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            try
            {
                string DestinationFolder = @$"D:\RentingPropertySystem{defaultPath}";

                if (!CreateFolderIfDoesNotExist(DestinationFolder))
                {
                    return null;
                }

                string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
                await Task.Run(() => File.Copy(sourceFile, destinationFile, true));

                sourceFile = destinationFile;
                return destinationFile;

            }
            catch (IOException iox)
            {

                //MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error" + iox.Message);
                return null;
            }





        }


    }
}
