using BuyalotV1._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuyalotV1._3.Repository;
using System.Collections;

namespace BuyalotV1._3.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository iCategoryRepository = new CategoryRepository();


        public ActionResult Index(string searchString)
        {
            var db = new ModelDbEntities();

            var product = (from p in db.Products
                           select p);
            

            if (!String.IsNullOrEmpty(searchString))
            {
                product =  product.Where(s => s.productName.StartsWith(searchString)
                                        || s.productName.Contains(searchString)
                                        || s.vendor.StartsWith(searchString)
                                        || s.vendor.Contains(searchString));

            }
            return View(product);

        }

        public ActionResult Category(int id)
        {
            var category = iCategoryRepository.find(id);
            ViewBag.category = category;
            ViewBag.products = category.Products.ToList();

            return View("Category");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}