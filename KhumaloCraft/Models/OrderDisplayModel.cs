using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class OrderDisplayModel
    {
        public int orderID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public OrderDisplayModel() { }
        public OrderDisplayModel(int orderID, int userID,int productID)
        {
            this.orderID = orderID;
            this.userID = userID;
            this.productID = productID;
        }
       public static List<OrderDisplayModel> ViewOrderDetails() 
        {
            List<OrderDisplayModel> orderDetails = new List<OrderDisplayModel>();
            string con_string = "Server=tcp:clvd-sql-server.database.windows.net,1433;Initial Catalog=clvd-db;Persist Security Info=False;User ID=Jose;Password=2004Fr@ney;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using(SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM TransactionTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    OrderDisplayModel order = new OrderDisplayModel();
                    order.orderID = Convert.ToInt32(reader["orderID"]);
                    order.productID = Convert.ToInt32(reader["productID"]);
                    order.userID = Convert.ToInt32(reader["user_id"]);
                    orderDetails.Add(order);
                }
                reader.Close();
            }
            return orderDetails;
           
        }
    }
}
