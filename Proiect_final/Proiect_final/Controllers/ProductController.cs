using Proiect_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proiect_final.Controllers
{
    public class ProductController : Controller
    {
        private DbCtx db = new DbCtx();
        
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            ViewBag.Products = products;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product product = db.Products.Find(id);
                if (product != null)
                {
                    return View(product);
                }
                return HttpNotFound("Couldn't find the product with id " + id.ToString());
            }
            return HttpNotFound("Missing product id parameter!");
        }
    }
}