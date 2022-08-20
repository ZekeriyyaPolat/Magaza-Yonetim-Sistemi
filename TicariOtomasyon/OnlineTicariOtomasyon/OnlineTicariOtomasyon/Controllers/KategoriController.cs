using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {

            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            k.Durum = true;
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            ktg.Durum = false;
            //  c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            ktgr.Durum = k.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        #region Cascading Deneme
        //cascading ,için listeleme
        public ActionResult CascadingDene()
        {
            CascadingDeneme cd = new CascadingDeneme();
            cd.Kategoriler = new SelectList(c.Kategoris, "KategoriID", "KategoriAd");
            cd.Urunler = new SelectList(c.Uruns, "Urunid", "UrunAd");

            return View(cd);
        }
        //cascading için json
        public JsonResult UrunGetir(int p)
        {
            var urunler = (from x in c.Uruns
                           join y in c.Kategoris
                           on x.Kategori.KategoriID equals y.KategoriID
                           where x.Kategori.KategoriID == p
                           select new
                           {
                               Text = x.UrunAd,
                               Value = x.Urunid.ToString()
                           }
                         ).ToList();
            return Json(urunler, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}