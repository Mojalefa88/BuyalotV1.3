using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using BuyalotV1._3.Models;

namespace BuyalotV1._3.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext DbEntities;
        // GET: Role
     
        public RoleController()
        {
            DbEntities = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var Roles = DbEntities.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create a New role
        /// </summary>
        /// <returns></returns>

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);

        }

        /// <summary>
        /// Create a New role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            DbEntities.Roles.Add(Role);
            DbEntities.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}