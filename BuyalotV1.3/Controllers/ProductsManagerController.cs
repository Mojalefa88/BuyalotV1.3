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

    
    public class ProductsManagerController : Controller
    {

        Repository01 _repository = new Repository01();

        private ModelDbEntities db = new ModelDbEntities();

        
        // GET: ProductsManager
        public ActionResult Index()
        {

            ViewBag.prodCategoryID = new SelectList(db.ProductCategories, "prodCategoryID", "categoryName");
            var product = (from p in db.Products
                           select p).ToList();
            return View(product);
        }

        // GET: ProductsManager/Details/5
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
        // GET: ProductsManager/Create
        public ActionResult Create()
        {
            ViewData["Categories"] = _repository.GetCategories();
            ViewBag.prodCategoryID = new SelectList(db.ProductCategories, "prodCategoryID", "categoryName");
            Product pro = new Product();
            return View(pro);
        }

        // POST: ProductsManager/Create
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
                    ViewBag.prodCategoryID = new SelectList(db.ProductCategories, "prodCategoryID", "categoryName", product.prodCategoryID);
             
                return View(product);

            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }

        }

        // GET: ProductsManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.prodCategoryID = new SelectList(db.ProductCategories, "prodCategoryID", "categoryName");
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductsManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "productID,productImage")] */Product product, FormCollection collection, HttpPostedFileBase upload)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        product.productImage = new byte[upload.ContentLength];
                        upload.InputStream.Read(product.productImage, 0, upload.ContentLength);
                    }

                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.result = "Product " + product.vendor + " " + product.productName + " Updated Succesfully!";
                    ViewBag.prodCategoryID = new SelectList(db.ProductCategories, "prodCategoryID", "categoryName", product.prodCategoryID);
                    return View(product);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: ProductsManager/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: ProductsManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection, HttpPostedFileBase upload)
        {
            try
            {

                Product product = db.Products.Find(id);
                if (upload != null)
                {
                    product.productImage = new byte[upload.ContentLength];
                    upload.InputStream.Read(product.productImage, 0, upload.ContentLength);
                }

                db.Products.Remove(product);
                db.SaveChanges();
                ViewBag.result = "Product " + product.vendor + " " + product.productName + " Deleted Succesfully!";

                return RedirectToAction("Index");
            }

            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
    }
}
