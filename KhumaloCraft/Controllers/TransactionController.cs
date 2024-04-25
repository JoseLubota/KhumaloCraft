using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace KhumaloCraft.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(productTBL.conString))
                {
                    string sql = "INSERT INTO TransactionTable (userID, productID) VALUES (@userID, @productID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        // Open SqlConnection
                        con.Open();
                        // Execute the sqlCommand to insert the record into the transactionTable
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriatly
                // For now, return an error view or message
                throw ex;
            }
        }
    }
}
