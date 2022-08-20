using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int Personelid { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyad")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelSoyad{ get; set; }

        [Display(Name = "Görsel")]
        public string PersonelGorsel{ get; set; }
        public string PersonelAdres{ get; set; }
        public string PersonelTelefon{ get; set; }
        public string PersonelMail{ get; set; }



        public bool  Durum{ get; set; }
     

        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}