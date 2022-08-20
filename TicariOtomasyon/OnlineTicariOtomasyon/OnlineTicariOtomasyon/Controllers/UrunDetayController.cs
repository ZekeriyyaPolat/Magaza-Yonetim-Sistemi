using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay

        Context c = new Context();

        public ActionResult Index(int id)
        {
            //Class1 cs = new Class1();
            //// var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
           

            //cs.Deger1 = c.Uruns.Where(x => x.Urunid == id).ToList();
            //cs.Deger2 = c.Detays.Where(y => y.DetayID == id).ToList();
            //cs
            //int id == urunid? (string?)nullable
            //(x => x.Urunid == gelen id )
            //(x => x.detayd == gelen id )


            var degerler = c.Uruns.Where(x => x.Urunid == id).ToList();
            if (degerler!=null)
            {
                return View(degerler);
            }
            else
            {
                return RedirectToAction("Index", "Galeri");
            }
        }


    }
}
