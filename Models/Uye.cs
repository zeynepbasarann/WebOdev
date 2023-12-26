using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Uye
    {
        public int uyeID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string mail { get; set; }
        public int sepetID { get; set; }
        public int favoriListID { get; set; }

        public string Sifre { get; set; }
      



    }
}