using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemi.Models.Entity;

namespace UrunTakipSistemi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN a)
        {
            db.TBLADMIN.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}