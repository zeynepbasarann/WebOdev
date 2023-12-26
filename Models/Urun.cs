using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Urun
    {
        [Key] // Bu satır, anahtar (primary key) olduğunu belirtir
        public int UrunId { get; set; }
        public string egitimAd { get; set; }
        
        public int turID { get; set; }
        public int yazarID { get; set; }
        public int dilID { get; set; }
        public int yorumID { get; set; }
        public string Resim { get; set; }
        public int ucret { get; set; }
        public int kategoriID { get; set; }
        
        public Tur Tur { get; set; }
        public Yazar Yazar { get; set; }
        public Dil Dil { get; set; }

        

    }
}