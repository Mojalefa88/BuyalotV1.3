using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuyalotV1._3.Models;
using BuyalotV1._3.Repository;

namespace BuyalotV1._3.Controllers
{
    public class ProductsController : Controller
    {

        Repository01 _repository = new Repository01();

        private ModelDbEntities db = new ModelDbEntities();
        // GET: Products
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult ViewProducts()
        {

            var product = (from p in db.Products
                           select p).ToList();
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewData["Categories"] = _repository.GetCategories();
             Product pro = new Product();
            return View(pro);
        }

        // GET: Products/Create


        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Product product, HttpPostedFileBase upload)
        {
            try
            {
                if (upload != null)
                {
                    product.productImage = new byte[upload.ContentLength];
                    upload.InputStream.Read(product.productImage, 0, upload.ContentLength);
                }
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.result = "Product " + product.vendor + " " + product.productName + " Added Succesfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error", "Error");
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
