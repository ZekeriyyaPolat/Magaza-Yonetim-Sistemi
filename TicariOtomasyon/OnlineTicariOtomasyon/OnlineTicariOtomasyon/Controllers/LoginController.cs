using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
using System.Web.Security;
using System.Web.Helpers;

namespace OnlineTicariOtomasyon.Controllers
{

    // global.asax Authorize
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context C = new Context();
        public ActionResult Index()
        {
            return View();
        }

        #region eski müşteri kaydı
        [HttpGet]
        public PartialViewResult Partial1()  
        {
            return PartialView();
        }  
        [HttpPost]
        public PartialViewResult Partial1(Cari p)
        {
            C.Caris.Add(p);
            C.SaveChanges();
            return PartialView();
        }
        #endregion
        
        
        
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cari p)
        {
            var bilgiler = C.Caris.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            ViewBag.hata1 = "Giriş Başarısız";
            return View("Index");
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = C.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            ViewBag.hata1 = "Giriş Başarısız";
            return View("Index");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SifreReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifreReset(Cari p, string CariMail)
        {
            Random rnd = new Random();
            var sayi1 = rnd.Next(100, 1000);
            var sayi2 = rnd.Next(100, 1000);
            string sifre = sayi1.ToString() + sayi2.ToString();
            var kontrol = C.Caris.Where(x => x.CariMail == p.CariMail).FirstOrDefault();
            if (kontrol != null)
            {
                kontrol.CariSifre = sifre;
                C.SaveChanges();
                string konu = "Şifre Bilgilendirme";
                string icerik = "Şifreniz :" + sifre;
                WebMail.Send(CariMail, konu, icerik, null, null, null, true, null, null, null, null, null, null);
                ViewBag.basarili = "Şifreniz mail adresine gönderildi";
                return View("Index");
            }
            ViewBag.hata = "Mail Adresi Hatalı";
            return View();
        }
    }
}