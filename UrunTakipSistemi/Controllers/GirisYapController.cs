using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemi.Models.Entity;
using System.Web.Security;

namespace UrunTakipSistemi.Controllers
{
    public class GirisYapController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: GirisYap
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(TBLADMIN a)
        {
            var bilgi = db.TBLADMIN.FirstOrDefault(x => x.KULLANICI == a.KULLANICI && x.SIFRE == a.SIFRE);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICI, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                ViewBag.hata ="Kullanıcı Adı veya Şifrenizi Hatalı Girdiniz ..!";
                return View();
            }           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris");
        }
    }
}