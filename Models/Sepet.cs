using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Sepet
    {
        public int sepetID { get; set; }
        public int uyeID { get; set; }
        public int UrunId{ get; set; }
        public int TopUcret { get; set; }
        public Urun Urun { get; set; }
        public Uye Uye { get; set; }
    }
}