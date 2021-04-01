using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemi.Models.Entity;

namespace UrunTakipSistemi.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI k)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORI.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI k)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriGetir");
            }
            var ktg = db.TBLKATEGORI.Find(k.ID);
            ktg.AD = k.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}