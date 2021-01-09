using Proiect_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proiect_final.Controllers
{
    public class CategoryController : Controller
    {
        private DbCtx db = new DbCtx();

        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            ViewBag.Categories = categories;

            return View();
        }
        [HttpGet]
        public ActionResult CategoryDescription(int? id)
        {
            if (id.HasValue)
            {
                Category category = db.Categories.Find(id);
                if (category != null)
                {
                    return View(category);
                }
                return HttpNotFound("Couldn't find the category with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing category id parameter!");
        }
    }
}