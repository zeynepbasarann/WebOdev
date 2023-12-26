using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FavoriList
    {
        public int favoriListID { get; set; }
        public int uyrID { get; set; }
        public int UrunId { get; set; }
        public int TopListeUcret { get; set; }
        public Urun Urun { get; set; }
        public Uye Uye { get; set; }
    }
}