using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class Hakkinda
    {
        [Key]
        public int Id { get; set; }

        public string baslik { get; set; }
        public string icerik { get; set; }
    }
}