using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Yeni
    {
        public int yeniID { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }

    }
}