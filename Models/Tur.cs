using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tur
    {
        public int turID { get; set; }
        public string turAd { get; set; }
        public int kategoriID { get; set; }
        public Kategori Kategori { get; set; }
        
    }
}