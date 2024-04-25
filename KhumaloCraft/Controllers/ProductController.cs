using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Models;


namespace KhumaloCraft.Controllers
{
    public class ProductController : Controller
    {
        public productTBL producttbl = new productTBL();

        [HttpPost]
        public ActionResult MyWork(productTBL product)
        {
            var result = producttbl.insert_Product(product);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MyWOrk()
        {
            return View(producttbl);
        }
    }
}
