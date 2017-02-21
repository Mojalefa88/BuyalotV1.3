using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuyalotV1._3.Models;

namespace Buyalot_V1._3.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddToCart()
        {
            Item item = new Item();
            return View(item);
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            var db = new ModelDbEntities();

            if (Session["Cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Products.Find(id), 1));

                Session["Cart"] = cart;
            }
            else
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Products.Find(id), 1));

                Session["Cart"] = cart;
            }

            return View("");
        }
    }
}