using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace KhumaloCraft.Controllers
{
    public class TransactionController : Controller
    {
        public TransactionTBL myOrder = new TransactionTBL();

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
                            return RedirectToAction("Index", "Home", new { userID = userID });

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

        [HttpPost]
        public ActionResult Order(string userName, string surname, string email)
        {
            try
            {
                List<TransactionTBL> userDetails;
                userDetails = TransactionTBL.getUserDetails(userName, surname, email);
                List<TransactionTBL> productDetails;
                productDetails = TransactionTBL.getProductDetails(userName, surname, email);

                if (userDetails != null && productDetails != null)
                {
                    return View((productDetails,userDetails));
                }
                else
                {
                    return View();
                }

            } catch (Exception ex)
            {
                throw ex ;
            }
     
        }
        [HttpGet]
        public IActionResult Order()
        {
            List<TransactionTBL> userDetails;
            //int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("userID");
            userDetails = TransactionTBL.getUserDetails("","","");
            List<TransactionTBL> productDetails;
            productDetails = TransactionTBL.getProductDetails("", "", "");
            return View((productDetails, userDetails));
        }

        
    }
}
