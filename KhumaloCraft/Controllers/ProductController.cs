using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Models;


namespace KhumaloCraft.Controllers
{
    public class ProductController : Controller
    {
        public productTBL producttbl = new productTBL();
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public ActionResult MyWork(productTBL product)
        {
            var result = producttbl.insert_Product(product);
            return RedirectToAction("MyWork", "Product");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            List<productTBL> products;
            products = productTBL.GetAllProducts();
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("userID");
            if (userID == null)
            {
                userID = 0;
            }

            ViewData["Products"] = products;
            ViewData["userID"] = userID;
            return View();
        }

    }
}
/*
 *  public IActionResult Order()
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
 */