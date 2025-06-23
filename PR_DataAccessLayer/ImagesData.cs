using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PR_DataAccessLayer;

namespace PR_DataAccessLayer
{


    public class ImagesDTO
    {
        public ImagesDTO() {

            this.ContainerID = -1;
            this.ImageOnePath = "";
            this.ImageTwoPath = "";
            this.ImageThreePath = "";
            this.ImageFourPath = "";
            this.ImageFivePath = "";
            this.ImageSixPath = "";
            this.ImageSevenPath = "";
            this.ImageEightPath = "";
            this.ImageNinePath ="";

        }
        public ImagesDTO(int ContainerID,  string imageOnePath,  string imageTwoPath,string imageThreePath, 
            string imageFourPath,  string imageFivePath, string imageSixPath,  string imageSevenPath,
           string imageEightPath, string imageNinePath) { 
        
            this.ContainerID = ContainerID; 
            this.ImageOnePath = imageOnePath;
            this.ImageTwoPath = imageTwoPath;
            this.ImageThreePath = imageThreePath;
            this.ImageFourPath = imageFourPath;
            this.ImageFivePath = imageFivePath;
            this.ImageSixPath = imageSixPath;
            this.ImageSevenPath = imageSevenPath;
            this.ImageEightPath = imageEightPath;
            this.ImageNinePath = imageNinePath;

            
        }


        public int ContainerID { get; set; }    
        public string ImageOnePath { get; set; }
        public string ImageTwoPath { get; set; }
        public string ImageThreePath { get; set; }
        public string ImageFourPath { get; set; }
        public string ImageFivePath { get; set; }
        public string ImageSixPath { get; set; }
        public string ImageSevenPath { get; set; }
        public string ImageEightPath { get; set;}   
        public string ImageNinePath { get;set;} 



    }
    public  class clsImagesData
    {

        public static ImagesDTO FindContainerByContainerID(int ContainerID)
        {
            try
            {
                using (var connection = new SqlConnection(clsDataSettings.Addresss))
                {
                     connection.Open();

                    using (var command = new SqlCommand("SP_FindImageContainerByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ContainerID", ContainerID);
                        //command.Parameters.AddWithValue("@ContainerID", (object)ContainerID ?? DBNull.Value);

                        using (var reader = command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                string ImageFourPath = reader.IsDBNull(reader.GetOrdinal("ImageFourPath")) ? "" : reader.GetString(reader.GetOrdinal("ImageFourPath"));

                                string ImageFivePath = reader.IsDBNull(reader.GetOrdinal("ImageFivePath")) ? "" : reader.GetString(reader.GetOrdinal("ImageFivePath"));

                                string ImageSixPath = reader.IsDBNull(reader.GetOrdinal("ImageSixPath")) ? "" : reader.GetString(reader.GetOrdinal("ImageSixPath"));

                                string ImageSevenPath = reader.IsDBNull(reader.GetOrdinal("ImageSevenPath")) ? "" : reader.GetString(reader.GetOrdinal("ImageSevenPath"));

                                string ImageEightPath = reader.IsDBNull(reader.GetOrdinal("ImageEightPath")) ? "" : reader.GetString(reader.GetOrdinal("ImageEightPath"));

                                string ImageNinePath = reader.IsDBNull(reader.GetOrdinal("ImageNinePath")) ? "" : reader.GetString(reader.GetOrdinal("ImageNinePath"));


                                return new ImagesDTO
                                (
                               
                                    reader.GetInt32(reader.GetOrdinal("ContainerID")),
                                    reader.GetString(reader.GetOrdinal("ImageOnePath")),
                                    reader.GetString(reader.GetOrdinal("ImageTwoPath")),
                                    reader.GetString(reader.GetOrdinal("ImageThreePath")),
                                    ImageFourPath,
                                    ImageFivePath ,
                                    ImageSixPath ,
                                    ImageSevenPath ,
                                    ImageEightPath,
                                    ImageNinePath
                                );
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return null; // Container not found
        }
      




        public static int AddNewImages(ImagesDTO Image)
        {


            int ContainerID = -1;
            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewPropertyImageContainer", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;



                        cmd.Parameters.AddWithValue("@ImageOnePath", Image.ImageOnePath);

                        cmd.Parameters.AddWithValue("@ImageTwoPath", Image.ImageTwoPath);

                        cmd.Parameters.AddWithValue("@ImageThreePath", Image.ImageThreePath);




                        if (Image.ImageFourPath == "" || Image.ImageFourPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageFourPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageFourPath", Image.ImageFourPath);

                        if (Image.ImageFivePath == "" || Image.ImageFivePath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageFivePath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageFivePath", Image.ImageFivePath);


                        if (Image.ImageSixPath == "" || Image.ImageSixPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageSixPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageSixPath", Image.ImageSixPath);


                        if (Image.ImageSevenPath == "" || Image.ImageSevenPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageSevenPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageSevenPath", Image.ImageSevenPath);


                        if (Image.ImageEightPath == "" || Image.ImageEightPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageEightPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageEightPath", Image.ImageEightPath);

                        if (Image.ImageNinePath == "" || Image.ImageNinePath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageNinePath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageNinePath", Image.ImageNinePath);






                        SqlParameter outputIdParam = new SqlParameter("@ContainerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };


                        cmd.Parameters.Add(outputIdParam);



                      
                        object Result = cmd.ExecuteScalar();

                        //connection.Open();
                        //object Result = cmd.ExecuteScalar();
                        //if (Result != null && int.TryParse(Result.ToString(), out int InsertedPropertyID))
                        //{
                        //    ContainerID = InsertedPropertyID;

                        //}

                        ContainerID = (int)cmd.Parameters["@ContainerID"].Value;


                        connection.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
               

            }
            return ContainerID;
        }


        public static bool UpdateImages(ImagesDTO Image)
        {
            int RowAffected = -1;

            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UpdatePropertyImagesContainer", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;




                        cmd.Parameters.AddWithValue("@ContainerID", Image.ContainerID);
                        cmd.Parameters.AddWithValue("@ImageOnePath", Image.ImageOnePath);

                        cmd.Parameters.AddWithValue("@ImageTwoPath", Image.ImageTwoPath);

                        cmd.Parameters.AddWithValue("@ImageThreePath", Image.ImageThreePath);



                        if (Image.ImageFourPath == "" || Image.ImageFourPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageFourPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageFourPath", Image.ImageFourPath);

                        if (Image.ImageFivePath == "" || Image.ImageFivePath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageFivePath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageFivePath", Image.ImageFivePath);


                        if (Image.ImageSixPath == ""  || Image.ImageSixPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageSixPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageSixPath", Image.ImageSixPath);


                        if (Image.ImageSevenPath == "" || Image.ImageSevenPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageSevenPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageSevenPath", Image.ImageSevenPath);


                        if (Image.ImageEightPath == "" || Image.ImageEightPath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageEightPath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageEightPath", Image.ImageEightPath);

                        if (Image.ImageNinePath == "" || Image.ImageNinePath == null)
                        {
                            cmd.Parameters.AddWithValue("@ImageNinePath", System.DBNull.Value);
                        }
                        else
                            cmd.Parameters.AddWithValue("@ImageNinePath", Image.ImageNinePath);



                      
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
    }
}
