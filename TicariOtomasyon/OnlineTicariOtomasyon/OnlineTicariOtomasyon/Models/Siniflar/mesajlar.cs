using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class mesajlar
    {
        [Key]
        public int Mesajid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Gönderici { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string icerik { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}