using Microsoft.Data.SqlClient;
using SharedDTOLayer.Tokens.TokensDTO;
using System.Data;


namespace PR_DataAccessLayer
{




    public class clsResfreshTokenData
    {

        public static async Task<int> AddNewRefreshToken(RefreshTokenDTO Token)
        {

         
            int TokenID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_AddRefreshToken", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@ClientId", Token.ClientId);

                        cmd.Parameters.AddWithValue("@Token", Token.Token);
                        cmd.Parameters.AddWithValue("@Expires", Token.Expires);


                        cmd.Parameters.AddWithValue("@Created", Token.Created);


                        cmd.Parameters.AddWithValue("@CreatedByIp", Token.CreatedByIp);



                        SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);


                        await cmd.ExecuteScalarAsync();



                        TokenID = (int)cmd.Parameters["@Id"].Value;
                        connection.Close();
                    }

                }

            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }


         

            return TokenID;

        }


        public static async Task<RefreshTokenDTO?> GetRefreshTokenByTokenAsync(string Token)
        {

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SP_GetRefreshTokenByToken", connection))
                    {


                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Token", (object)Token ?? DBNull.Value);

                        using (var reader = await command.ExecuteReaderAsync())
                        {

                            if (await reader.ReadAsync())
                            {
                               DateTime? Revoked = reader.IsDBNull(reader.GetOrdinal("Revoked")) ? (DateTime?)null   : reader.GetDateTime(reader.GetOrdinal("Revoked"));

                                string RevokedByIp = reader.IsDBNull(reader.GetOrdinal("RevokedByIp")) ? "" : reader.GetString(reader.GetOrdinal("RevokedByIp"));


                                string ReplacedByToken = reader.IsDBNull(reader.GetOrdinal("ReplacedByToken")) ? "" : reader.GetString(reader.GetOrdinal("ReplacedByToken"));


                                string ReasonRevoked = reader.IsDBNull(reader.GetOrdinal("ReasonRevoked")) ? "" : reader.GetString(reader.GetOrdinal("ReasonRevoked"));


                                return new RefreshTokenDTO(
                                    reader.GetInt32(reader.GetOrdinal("Id")),

                                    reader.GetString(reader.GetOrdinal("Token")),
                                     reader.GetDateTime(reader.GetOrdinal("Expires")),
                                     reader.GetDateTime(reader.GetOrdinal("Created")),
                                     reader.GetString(reader.GetOrdinal("CreatedByIp")),

                                   Revoked,
                                    RevokedByIp,
                                    ReplacedByToken,
                                     ReasonRevoked,
                                     reader.GetInt32(reader.GetOrdinal("ClientId"))



                                    );


                            }

                            await reader.CloseAsync();

                        }
                        connection.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return null;
        }



        public async static Task< bool> UpdateRefreshTokenAsync(RefreshTokenDTO Token)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    connection.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateRefreshToken", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", Token.Id);
                        cmd.Parameters.AddWithValue("@Revoked", Token.Revoked);
                        cmd.Parameters.AddWithValue("@RevokedByIp", Token.RevokedByIp);
                        cmd.Parameters.AddWithValue("@ReplacedByToken", Token.ReplacedByToken);
                        cmd.Parameters.AddWithValue("@ReasonRevoked", Token.ReasonRevoked);
                        rowsAffected = cmd.ExecuteNonQuery();

                        connection.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return rowsAffected > 0;
        }




        public static async Task<bool> RevokeAllRefreshTokensForUser( RefreshTokenDTO Token, string ClientId)
        {
            int rowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataSettings.Addresss))
                {
                    await connection.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_RevokeAllRefreshTokensForUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@ClientId", ClientId);
                        cmd.Parameters.AddWithValue("@RevokedByIp", Token.RevokedByIp);
                        cmd.Parameters.AddWithValue("@ReasonRevoked", Token.ReasonRevoked);


                       rowsAffected =  await cmd.ExecuteNonQueryAsync();   
                        connection.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            return   rowsAffected >  0;
        }

    } 
}