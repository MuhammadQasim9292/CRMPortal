using System.Net.Mail;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Common.CommonMethods
{
    public static class CommonOpertions
    {

        public static bool isEmailValid(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                //return addr.Address == email;
                if(email == addr.Address)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void SendEmail(string email, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("abdu@gmail.com"); //gemail was originally written wrong
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

            }
            catch (Exception e)
            {
                 
            }
        }
       
        public static async Task<bool> SoftDelete(string connectionString , string tableName , long id)
        {
           using(IDbConnection db = new SqlConnection(connectionString) )
            {
                string query = $"UPDATE {tableName} SET IsDeleted = 1 WHERE Id in (@Id)";
                var affectedrows = await db.ExecuteAsync(query,new {Id = id});

               return affectedrows > 0;
            }
        }

        public static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json").Build();
  return configuration.GetConnectionString("ConnectionString");
        }



        public static async Task<IEnumerable<dynamic>> ExecuteStoredProceduresList(string storedProcedureName, DynamicParameters parameters, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var results = await connection.QueryAsync<dynamic>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                // Check if there are no records returned, then return an empty enumerable
                if (results?.Any() != true)
                {
                    return Enumerable.Empty<dynamic>();
                }

                return results;
            }
        }


    }
}
