using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemi.Models.Entity;
namespace UrunTakipSistemi.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index(string search)
        {
            var urn = db.TBLURUNLER.Where(x => x.DURUM == true);
            if (!string.IsNullOrEmpty(search))
            {
                urn = urn.Where(x => x.AD.Contains(search) && x.DURUM == true);
            }
            //var urn = db.TBLURUNLER.Where(x => x.DURUM == true).ToList();
            return View(urn.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.TBLKATEGORI.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD,
                                            Value = x.ID.ToString()
                                        }).ToList();
            ViewBag.urndrop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER u)
        {
            u.DURUM = true;
            var ktgr = db.TBLKATEGORI.Where(x => x.ID == u.TBLKATEGORI.ID).FirstOrDefault();
            u.TBLKATEGORI = ktgr;
            db.TBLURUNLER.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> ktgr = (from x in db.TBLKATEGORI.ToList() select new SelectListItem { Text = x.AD, Value = x.ID.ToString() }).ToList();
            var urn = db.TBLURUNLER.Find(id);
            ViewBag.urnkt = ktgr;
            return View("UrunGetir", urn);
        }
        public ActionResult UrunGuncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.ID);
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.ALISFIYAT = p.ALISFIYAT;
            urun.SATISFIYAT = p.SATISFIYAT;
            urun.AD = p.AD;
            var ktg = db.TBLKATEGORI.Where(x => x.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            urun.KATEGORI = ktg.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(TBLURUNLER u)
        {
            var urun = db.TBLURUNLER.Find(u.ID);
            urun.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}