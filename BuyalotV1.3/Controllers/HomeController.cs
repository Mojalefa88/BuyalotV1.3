using BuyalotV1._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuyalotV1._3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ModelDbEntities();

            var product = (from p in db.Products
                           select p).ToList();
            return View(product);
            
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