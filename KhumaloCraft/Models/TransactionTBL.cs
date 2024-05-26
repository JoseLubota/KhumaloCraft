using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Transactions;

namespace KhumaloCraft.Models
{
    public class TransactionTBL : Controller
    {
        public static string conString = "Server=tcp:clvd-sql-server.database.windows.net,1433;Initial Catalog=clvd-db;Persist Security Info=False;User ID=Jose;Password=2004Fr@ney;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public int orderID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public string userName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string productName { get; set; }
        public Decimal productPrice { get; set; }
        public string productCategory { get; set; }

        public static List<TransactionTBL> getUserDetails(int userID)
        {
            List<TransactionTBL> orderDetails = new List<TransactionTBL>();
            string con_string = "Server=tcp:clvd-sql-server.database.windows.net,1433;Initial Catalog=clvd-db;Persist Security Info=False;User ID=Jose;Password=2004Fr@ney;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT TOP 1 TransactionTable.orderID, userTBL.userName,  userTBL.userID, userTBL.surname, userTBL.email, productTBL.productName, productTBL.productPrice,  productTBL.productCategory\r\nFROM TransactionTable\r\nINNER JOIN userTBL ON TransactionTable.userID = userTBL.userID\r\nINNER JOIN productTBL ON TransactionTable.productID = productTBL.productID\r\nWHERE userTBL.userID = @userID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TransactionTBL order = new TransactionTBL();
                    order.orderID = Convert.ToInt32(reader["orderID"]);
                    if (reader["userID"] == null)
                    {
                        order.userID = 0;
                    }
                    else
                    {
                        order.userID = Convert.ToInt32(reader["userID"]);
                    }

                   
                    order.userName = Convert.ToString(reader["userName"]);
                    order.surname = Convert.ToString(reader["surname"]);
                    order.productName = Convert.ToString(reader["productName"]);
                    order.productPrice = Convert.ToDecimal(reader["productPrice"]);
                    order.productCategory = Convert.ToString(reader["productCategory"]);

                    orderDetails.Add(order);
                }
                reader.Close();
            }
            return orderDetails;

        }
        public static List<TransactionTBL> getProductDetails(int userID)
        {
            List<TransactionTBL> orderDetails = new List<TransactionTBL>();
            string con_string = "Server=tcp:clvd-sql-server.database.windows.net,1433;Initial Catalog=clvd-db;Persist Security Info=False;User ID=Jose;Password=2004Fr@ney;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT  TransactionTable.orderID, userTBL.userID, userTBL.userName, userTBL.surname, userTBL.email, productTBL.productName, productTBL.productPrice,  productTBL.productCategory\r\nFROM TransactionTable\r\nINNER JOIN userTBL ON TransactionTable.userID = userTBL.userID\r\nINNER JOIN productTBL ON TransactionTable.productID = productTBL.productID\r\nWHERE userTBL.userID = @userID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TransactionTBL order = new TransactionTBL();
                    order.orderID = Convert.ToInt32(reader["orderID"]);
                    order.userName = Convert.ToString(reader["userName"]);
                    order.surname = Convert.ToString(reader["surname"]);
                    order.productName = Convert.ToString(reader["productName"]);
                    order.productPrice = Convert.ToDecimal(reader["productPrice"]);
                    order.productCategory = Convert.ToString(reader["productCategory"]);
                    orderDetails.Add(order);
                }
                reader.Close();
            }
            return orderDetails;

        }
    }
}
