
using System.Data;
using Microsoft.Data.SqlClient;
using SharedDTOLayer.Images;







namespace PR_DataAccessLayer
{


  
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

        public static bool DeleteContainerImages(int ContainerId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_RemoveContainerOnlyWhenPropertyFailedToConstructed", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@containerId", ContainerId);


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

    }
}
