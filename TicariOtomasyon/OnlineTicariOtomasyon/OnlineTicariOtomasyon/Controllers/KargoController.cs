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
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p,int sayfa=1)
        {

            var kargolar = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            } 
            return View(kargolar.ToList().ToPagedList(sayfa,5));
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            //guid
            //random fonk
            Random rnd = new Random();
            string[] karakter = { "A", "B", "C", "D" };
            int krktr1, krktr2, krktr3;
            krktr1 = rnd.Next(0, 4);//krktr2 = rnd.Next(0, karakter.len);
            krktr2 = rnd.Next(0, 4);
            krktr2 = rnd.Next(0, 4);
            krktr3 = rnd.Next(0, 4);
            int sayi1, sayi2, sayi3;
            sayi1 = rnd.Next(100, 1000);
            sayi2 = rnd.Next(10, 100);
            sayi3 = rnd.Next(10, 100);
            string kod = sayi1.ToString() + karakter[krktr1] + sayi2.ToString() + karakter[krktr2] + sayi3.ToString() + karakter[krktr3];
            ViewBag.takipkodu = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kd)
        {
            c.KargoDetays.Add(kd);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }


    }
}