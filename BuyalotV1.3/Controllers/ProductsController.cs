using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuyalotV1._3.Models;
using BuyalotV1._3.Repository;
using System.Net;
using System.Data.Entity;

namespace BuyalotV1._3.Controllers
{
    public class ProductsController : Controller
    {

        Repository01 _repository = new Repository01();

        private ModelDbEntities db = new ModelDbEntities();
        // GET: Products
        public ActionResult Index()
        {

            //ViewBag.prodCategoryID = new SelectList(db.ProductCategories, "prodCategoryID", "categoryName");
            //var product = (from p in db.Products
            //               select p).ToList();
            //return View(product);

            ViewBag.ProductList = db.Products.ToList();
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult ViewProducts()
        {
            ViewBag.prodCategoryID = new SelectList(db.ProductCategories, "prodCategoryID", "categoryName");
            var product = (from p in db.Products
                           select p).ToList();
            return View(product);
        }


        private int itemExist(int id)
        {
            List<Item> cart = (List<Item>)Session["Cart"];
            int counter = cart.Count;
            for (int i = 0; i < counter; i++)
            {
                if (cart[i].Prdcts.productID == id)
                {
                    return i;
                }
            }
            return -1;

        }
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
                List<Item> cart = (List<Item>)Session["Cart"];

                int index = itemExist(id);

                if (index == -1)
                {
                    cart.Add(new Item(db.Products.Find(id), 1));
                }
                else
                {
                    cart[index].Quantity++;

                    //ViewBag.addQ = cart[index].Quantity++;
                }
                Session["Cart"] = cart;
            }

            return View("AddToCart");
        }

        public ActionResult DeleteCart(int id)
        {
            List<Item> cart = (List<Item>)Session["Cart"];
            int index = itemExist(id);


            cart.RemoveAt(index);

            Session["Cart"] = cart;

            return View("AddToCart");
        }

        public ActionResult UpdateQuantity(FormCollection fc)
        {
            string[] quantities = fc.GetValues("txtQuantity");
            List<Item> cart = (List<Item>)Session["Cart"];
            int counter = cart.Count;

            for (int i = 0; i < counter; i++)
            {
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
                Session["Cart"] = cart;
            }



            return View("AddToCart");
        }


    }
}
