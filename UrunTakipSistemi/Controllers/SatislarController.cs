using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemi.Models.Entity;

namespace UrunTakipSistemi.Controllers
{
    [Authorize]
    public class SatislarController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Satislar
        public ActionResult Index()
        {
            var satis = db.TBLSATISLAR.ToList();
            return View(satis);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urn = (from x in db.TBLURUNLER.Where(x => x.DURUM == true).ToList() select new SelectListItem { Text = x.AD, Value = x.ID.ToString() }).ToList();
            ViewBag.urun = urn;
            List<SelectListItem> urnst = (from x in db.TBLURUNLER.Where(x => x.DURUM == true).ToList() select new SelectListItem { Text = x.SATISFIYAT.ToString(), Value = x.ID.ToString() }).ToList();
            ViewBag.fiyat = urnst;
            List<SelectListItem> must = (from x in db.TBLMUSTERI.Where(x => x.DURUM == true).ToList() select new SelectListItem { Text = x.AD + " " + x.SOYAD, Value = x.ID.ToString() }).ToList();
            ViewBag.must = must;
            List<SelectListItem> per = (from x in db.TBLPERSONEL.ToList() select new SelectListItem { Text = x.AD + " " + x.SOYAD, Value = x.ID.ToString() }).ToList();
            ViewBag.pers = per;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR s)
        {
            var urun = db.TBLURUNLER.Where(x => x.ID == s.TBLURUNLER.ID).FirstOrDefault();
            var must = db.TBLMUSTERI.Where(x => x.ID == s.TBLMUSTERI.ID).FirstOrDefault();
            var pers = db.TBLPERSONEL.Where(x => x.ID == s.TBLPERSONEL.ID).FirstOrDefault();
            s.TBLURUNLER = urun;
            s.TBLMUSTERI = must;
            s.TBLPERSONEL = pers;
            s.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLSATISLAR.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}