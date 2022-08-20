using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

//#error version

namespace OnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik

        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString(); //20den az olan ürün
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;



            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = c.Uruns.Where(u => u.Urunid == (c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;

            var deger15 = c.SatisHarekets.Count(x => x.Tarih == bugun);
            ViewBag.d15 = deger15;


            if (deger15 != 0)
            {
                var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
                ViewBag.d16 = deger16;
            }
            else
            {
                ViewBag.d16 = 0;
            }



            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Caris
                        group x by x.CariSehir into g
                        select new GrupSinif
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            #region viewbag çoklu
            ////    ViewBag.sehiryuzde = new List<string>
            ////    {
            ////       {sehirler[0]},
            ////       {sehirler[1]},
            ////       {sehirler[2]},
            ////       {sehirler[3]},
            ////       {sehirler[4]},
            ////       {sehirler[5]}

            ////    };
            //viewde
            //// @foreach (var item in ViewBag.degerler)
            ////{
            ////                < li > @item </ li >
            ////                < li > @item </ li >
            ////                < li > @item </ li >
            ////            }
            ///
            /*
            string[] sehirler = c.Caris.Select(x => x.CariSehir).Distinct().ToArray();
            string[] sehirler2 = c.Caris.Select(x => x.CariSehir).ToArray();
            string sehir1 = sehirler[0]; */


            #endregion

            /*
             * 
             * 
             * 
             * 
             */

            string[] sehirler = c.Caris.Select(x => x.CariSehir).ToArray();


            var sorgu3 = int.Parse(c.Caris.Select(x => x.CariSehir).Distinct().ToString());

            for (int i = 0; i <sorgu3 ; i++)
            {
                var sorgu2 = c.Caris.Where(x => x.CariSehir == sehirler[i]);
            }





            return View(sorgu.ToList());
        }


        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Caris.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                        group x by x.Marka into g
                        select new SinifGrup2
                        {
                            marka = g.Key,
                            sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }




    }
}