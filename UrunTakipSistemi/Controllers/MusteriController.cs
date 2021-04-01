using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace UrunTakipSistemi.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index(int page = 1)
        {
            var musteriler = db.TBLMUSTERI.Where(x => x.DURUM == true).ToList().ToPagedList(page, 10);
            return View(musteriler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI m)
        {
            if (!ModelState.IsValid)
            {             
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View("YeniMusteri");
            }
            if (m.BAKIYE == null)
            {
                m.BAKIYE = 0;              
            }
            m.DURUM = true;
            db.TBLMUSTERI.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(TBLMUSTERI m)
        {
            var musteri = db.TBLMUSTERI.Find(m.ID);
            musteri.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult MusteriGuncelle(TBLMUSTERI m)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGetir");
            }
            var mus = db.TBLMUSTERI.Find(m.ID);
            mus.AD = m.AD;
            mus.SOYAD = m.SOYAD;
            mus.SEHIR = m.SEHIR;
            if(m.BAKIYE == null || m.BAKIYE < 0)
            {
                m.BAKIYE = 0;
            }
            mus.BAKIYE = m.BAKIYE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}