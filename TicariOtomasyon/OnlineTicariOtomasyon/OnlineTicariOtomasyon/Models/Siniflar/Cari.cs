using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int Cariid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz")]
        public string CariAd { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş bırakamazsınız")]
        public string CariSoyad{ get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string CariSehir{ get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string CariMail{ get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string CariSifre { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }

}