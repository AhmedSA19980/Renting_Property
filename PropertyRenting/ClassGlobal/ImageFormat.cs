using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.ClassGlobal
{
    internal class ImageFormat
    {

       
        public static bool HandlePersonImage(PictureBox PropertyImage, string ImagePath)
        {
            return HandleImage(PropertyImage , ImagePath, @"\Person\");
        }


        public static async Task< bool> HandlePropertyImage(PictureBox PropertyImage, string ImagePath)
        {
            return await HandleMutlipeFile(PropertyImage, ImagePath ,@"\Person\");
        }


        public static bool HandleImage(PictureBox PropertyImage, string ImagePath  , string defaultFolder ="")
        {
            try
            {
                
                if (ImagePath != PropertyImage.ImageLocation)
                {

                    if (ImagePath != "")
                    {
                        //first we delete the old image from the folder in case there is any.

                      

                        try
                        {
                            File.Delete(ImagePath);
                            //File.Delete(ImagePath);
                        }
                        catch (IOException ex)
                        {

                            clsGlobal.SaveToEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                            //clsGlobal.SaveToEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                            // We could not delete the file.
                            //log it later
                            //
                        }
                    }

                    if (PropertyImage.ImageLocation != null)
                    {
                        string SoruceFileImage = PropertyImage.ImageLocation.ToString();
                        bool NewPath = clsUtill.CopyImageToProjectImagesFolder2(ref SoruceFileImage, defaultFolder);// clsUtill.CopyImageToProjectImagesFolder2(ref SoruceFileImage , defaultFolder);
                        if (NewPath != null)
                        {
                            PropertyImage.ImageLocation = SoruceFileImage;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }

                }

            }
            catch (Exception ex) {

                clsGlobal.SaveToEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return true ;
        }




        public static async Task< bool> HandleMutlipeFile(PictureBox PropertyImage, string ImagePath, string defaultFolder = "")
        {
            try
            {

                if (ImagePath != PropertyImage.ImageLocation)
                {

                    if (ImagePath != "")
                    {
                        //first we delete the old image from the folder in case there is any.



                        try
                        {
                           await Task.Run(()=> File.Delete(ImagePath));
                            //File.Delete(ImagePath);
                        }
                        catch (IOException ex)
                        {

                            clsGlobal.SaveToEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                            //clsGlobal.SaveToEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                            // We could not delete the file.
                            //log it later
                            //
                        }
                    }

                    if (PropertyImage.ImageLocation != null)
                    {
                        string SoruceFileImage = PropertyImage.ImageLocation.ToString();
                        string NewPath =await clsUtill.CopyImageToProjectImagesFolder2( SoruceFileImage, defaultFolder);// clsUtill.CopyImageToProjectImagesFolder2(ref SoruceFileImage , defaultFolder);
                        if (NewPath != null)
                        {
                            PropertyImage.ImageLocation = SoruceFileImage;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }

                }

            }
            catch (Exception ex)
            {

                clsGlobal.SaveToEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return true;
        }



        public static void LLopenFileDialog_Click(object sender, EventArgs e, PictureBox Photo, Button BtnRemoveImage, OpenFileDialog openfiledialog)
        {
            openfiledialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openfiledialog.FilterIndex = 1;
            openfiledialog.RestoreDirectory = true;


            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {


                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                string selectedFilePath = openfiledialog.FileName;


                Photo.Load(selectedFilePath);

                BtnRemoveImage.Visible = true;
            }


        }

    }
}
