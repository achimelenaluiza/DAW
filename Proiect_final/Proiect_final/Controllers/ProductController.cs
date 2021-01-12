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

        [NonAction]
        public IEnumerable<SelectListItem> GetAllCategories()
        {
            var selectList = new List<SelectListItem>();
            foreach (var cat in db.Categories.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = cat.CategoryId.ToString(),
                    Text = cat.Name
                });
            }
            return selectList;
        }

        [HttpGet]
        public ActionResult New()
        {
            Product product = new Product();
            product.Gallery = new Gallery();
            product.CelebritiesWhoRecommand = new List<CelebrityWhoRecommands>();
            product.CategoryList = GetAllCategories();
            return View(product);
        }

        [HttpPost]
        public ActionResult New(Product productRequest)
        {
            try
            {
                productRequest.CategoryList = GetAllCategories();
                if (ModelState.IsValid)
                {
                    db.Products.Add(productRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(productRequest);
            }
            catch (Exception)
            {
                return View(productRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldProduct = db.Products.Find(product.ProductId);

                    if (oldProduct == null)
                    {
                        return HttpNotFound();
                    }

                    oldProduct.Name = product.Name;
                    oldProduct.Price = product.Price;
                    oldProduct.Description = product.Description;

                    TryUpdateModel(oldProduct);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            db.Galleries.Remove(product.Gallery);
            db.Products.Remove(product);

            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}