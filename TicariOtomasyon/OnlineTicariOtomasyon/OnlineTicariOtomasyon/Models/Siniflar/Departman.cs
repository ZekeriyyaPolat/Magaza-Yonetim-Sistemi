using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int Departmanid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }

        public bool Durum { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }
}