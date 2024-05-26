using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace KhumaloCraft.Models
{
    public class productTBL 
    {
        public static string conString = "Server=tcp:clvd-sql-server.database.windows.net,1433;Initial Catalog=clvd-db;Persist Security Info=False;User ID=Jose;Password=2004Fr@ney;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(conString);

        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productCategory { get; set; }
        public string productAvailability { get; set; }
        public int productID { get; set; }


        public int insert_Product(productTBL p)
        {
            try
            {
                string sql = "INSERT INTO productTBL (productName, productPrice, productCategory, productAvailability) VALUES(@ProductName, @ProductPrice, @ProductCategory, @ProductAvailability)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", p.productName);
                        cmd.Parameters.AddWithValue("@ProductPrice", p.productPrice);
                        cmd.Parameters.AddWithValue("@ProductCategory", p.productCategory);
                        cmd.Parameters.AddWithValue("@ProductAvailability", p.productAvailability);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;

                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }

        }
        public static List<productTBL> GetAllProducts()
        {
            List<productTBL> products = new List<productTBL>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT * FROM productTBL";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTBL product = new productTBL();
                    product.productID = Convert.ToInt32(rdr["productID"]);
                    product.productName = rdr["productName"].ToString();
                    product.productPrice = Convert.ToDecimal(rdr["productPrice"]);
                    product.productCategory = rdr["productCategory"].ToString();
                    product.productAvailability = rdr["productAvailability"].ToString();

                    products.Add(product);
                }
            }
            return products;
        }

    }
}
