using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string  KategoriAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}