using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace KhumaloCraft.Controllers
{
    public class TransactionController : Controller
    {
        public TransactionTBL myOrder = new TransactionTBL();
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransactionController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

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
            catch
            {
                // Log the exception or handle it appropriatly
                // For now, return an error view or message
                
                return RedirectToAction("Index", "Home");
            }
        }
        
        
        public IActionResult Order()
        {
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("userID");
            if( userID == null)
            {
              userID = 0;
            }
            List<TransactionTBL> userDetails;
            List<TransactionTBL> productDetails;

            userDetails = TransactionTBL.getUserDetails((int)userID);
            productDetails = TransactionTBL.getProductDetails((int)userID );

            ViewData["userID"] = userID;
            return View((productDetails, userDetails));
        }

        
    }
}
 