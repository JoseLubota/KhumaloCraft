using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class OrderDisplayModel : Controller
    {
        public int orderID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public string userName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productCategory { get; set; }
        public OrderDisplayModel() { }

       public static List<OrderDisplayModel>SelectMyOrder(string userName, string surname, string email) 
        {
            List<OrderDisplayModel> orderDetails = new List<OrderDisplayModel>();
            string con_string = "Server=tcp:clvd-sql-server.database.windows.net,1433;Initial Catalog=clvd-db;Persist Security Info=False;User ID=Jose;Password=2004Fr@ney;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using(SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT TransactionTable.orderID, userTBL.userName, userTBL.surname, userTBL.email, productTBL.productName, productTBL.productPrice,  productTBL.productCategory\r\nFROM TransactionTable\r\nINNER JOIN userTBL ON TransactionTable.userID = userTBL.userID\r\nINNER JOIN productTBL ON TransactionTable.productID = productTBL.productID\r\nWHERE userTBL.userName = @userName AND  userTBL.surname = @surname AND userTBL.email = @email ";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    OrderDisplayModel order = new OrderDisplayModel();
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
