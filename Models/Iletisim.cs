using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Iletisim
    {

        [Key]
        public int IletisimId { get; set; }

        public string baslikIletisim { get; set; }
        public string adres { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }

    }
}