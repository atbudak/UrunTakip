using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using UrunTakipSistemi.Models.Entity;

namespace UrunTakipSistemi.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Personel
        public ActionResult Index(int page = 1)
        {
            var pers = db.TBLPERSONEL.Where(x => x.DURUM == true).ToList().ToPagedList(page, 10);
            return View(pers);
        }
        
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniPersonel");
            }
            var pers = db.TBLPERSONEL.Add(p);
            pers.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var per = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir",per);
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }
            var pers = db.TBLPERSONEL.Find(p.ID);
            pers.AD = p.AD;
            pers.SOYAD = p.SOYAD;
            pers.DEPARTMAN = p.DEPARTMAN;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(TBLPERSONEL p)
        {
            var sil = db.TBLPERSONEL.Find(p.ID);
            sil.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}