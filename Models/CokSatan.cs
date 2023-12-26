using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CokSatan
    {
        public int cokSatanID { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }

    }
}