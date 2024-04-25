using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace KhumaloCraft.Models
{
    public class userTBL
    {
        public static string conString = "Server=tcp:clvd-sql-server.database.windows.net,1433;Initial Catalog=clvd-db;Persist Security Info=False;User ID=Jose;Password=2004Fr@ney;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(conString);

        public string userName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }


        public int insert_User(userTBL u)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string sql = "INSERT INTO userTBL (userName, surname, email) VALUES(@userName, @surname, @email)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@userName", u.userName);
                    cmd.Parameters.AddWithValue("@surname", u.surname);
                    cmd.Parameters.AddWithValue("@email", u.email);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}