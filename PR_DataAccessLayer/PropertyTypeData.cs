﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PR_DataAccessLayer;
namespace PR_DataAccessLayer
{

    public class PropertyTypeDTO
    {
        public byte   PropertyTypeID { set; get; }    
        public string PropertyTypeName { set; get; }

        public PropertyTypeDTO(byte PropertyTypeID, string PropertyTypeName)
        {
            this.PropertyTypeID = PropertyTypeID;
            this.PropertyTypeName = PropertyTypeName;
        }
    
    }
    public class clsPropertyTypeData
    {

        public static PropertyTypeDTO GetPropertyByPropertyID(int PropertyTypeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPropertyTypeByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@PropertyTypeID",(object) PropertyTypeID ?? DBNull.Value);

                        //SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        //{
                        //    Direction = ParameterDirection.ReturnValue
                        //};

                    
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                               
                                return new PropertyTypeDTO(
                                    reader.GetByte(reader.GetOrdinal("PropertyTypeID")),
                                    reader.GetString(reader.GetOrdinal("PropertyTypeName"))    
                                 );

                            }
                          

                            reader.Close();
                        }

                    }
                    connection.Close();
                }

            }
            catch (Exception e) { isFound = false; }



            return null;
        }

        public static PropertyTypeDTO GetPropertyTypeByPropertyName(string PropertyTypeName)
        {
          

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPropertyTypeByPropertyTypeName", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@PropertyTypeName", PropertyTypeName);

                     
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {


                                return new PropertyTypeDTO(
                                    reader.GetByte(reader.GetOrdinal("PropertyTypeID")),
                                    reader.GetString(reader.GetOrdinal("PropertyTypeName"))
                                 );

                            }
                       


                            reader.Close();
                        }

                    }
                    connection.Close();
                }

            }
            catch (Exception e) { Console.WriteLine("Error: " + e.Message); }



            return null;
        }




        public static List<PropertyTypeDTO> GetPropertiesType()
        {

            List<PropertyTypeDTO> PropertiesType = new List<PropertyTypeDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPropertiesType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                PropertiesType.Add(new PropertyTypeDTO
                                (
                                    reader.GetByte(reader.GetOrdinal("PropertyTypeID")),
                                    reader.GetString(reader.GetOrdinal("PropertyTypeName"))
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

            return PropertiesType;

        }








        public static DataTable GetAllPropertiesType()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPropertiesType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)

                            {
                                dt.Load(reader);
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

            return dt;

        }



        public static int AddNewPropertyType(PropertyTypeDTO propertyType )
        {


            byte PropertyTypeID = 0;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {

                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewPropertyType", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@PropertyTypeName", propertyType.PropertyTypeName);

                     
                        SqlParameter outputIdParam = new SqlParameter("@PropertyTypeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);


                        cmd.ExecuteScalar();
                        /*if (outputIdParam.Value != DBNull.Value)
                        {
                            PropertyTypeID = Convert.ToSByte(outputIdParam.Value); // Use Convert.ToSByte for better type handling
                        }
                        else return -1;
                        */
                        //PropertyTypeID = (byte)cmd.Parameters["@PropertyTypeID"].Value;

                    }
                    connection.Close();
                }

            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            return PropertyTypeID;

        }


        public static bool UpdateTypeProperty(PropertyTypeDTO PropertyType)
        {


            int RowAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UpdatePropertyType", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PropertyTypeID", PropertyType.PropertyTypeID);
                        cmd.Parameters.AddWithValue("@PropertyTypeName", PropertyType.PropertyTypeName);

                     

                     
                        RowAffected = cmd.ExecuteNonQuery();




                    }
                    connection.Close();

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }



            return (RowAffected >= 0);

        }


        public static bool DeleteTypeProperty(int PropertyTypeID)
        {


            int RowAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeletePropertyType", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PropertyTypeID", PropertyTypeID);

                        connection.Open();
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
