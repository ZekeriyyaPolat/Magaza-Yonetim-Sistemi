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
    public class SilinmisOgelerController : Controller
    {
        // GET: SilinmisOgeler
        Context c = new Context();

        #region Ürünler silinmiş
        public ActionResult Index(int sayfa=1)
        {
            var urunler = c.Uruns.Where(x => x.Durum == false).ToList().ToPagedList(sayfa,5);
            return View(urunler);
        }

        public ActionResult UrunAktifEt(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Silinmiş Kategoriler
        public ActionResult SilinmisKategoriler(int sayfa = 1)
        {
            var kategoriler = c.Kategoris.Where(x => x.Durum == false).ToList().ToPagedList(sayfa, 5);
            return View(kategoriler);
        }

        public ActionResult KategoriAktifEt(int id)
        {
            var kategori = c.Kategoris.Find(id);
            kategori.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index","Kategori");
        }

        #endregion


        public ActionResult SilinmisDepartman(int sayfa = 1)
        {
            var departman = c.Departmans.Where(x => x.Durum == false).ToList().ToPagedList(sayfa, 5);
            return View(departman);
        }

        public ActionResult DepartmanAktifEt(int id)
        {
            var departman = c.Departmans.Find(id);
            departman.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }

    }
}