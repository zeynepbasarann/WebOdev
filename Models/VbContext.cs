using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace WebApplication1.Models
{
    public class VbContext : DbContext
    {
        
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Dil> Diller { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Hakkinda> Hakkinda { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Iletisim>  Iletisim { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Sepet> Sepetler{ get; set; }
        public DbSet<FavoriList> FavoriListler { get; set; }
        public DbSet<Yeni> Yeniler { get; set; }
        public DbSet<CokSatan> CokSatanlar { get; set; }
        public VbContext() : base("Data Source=ZEYBASARAN;Initial Catalog=WEB;User Id= ZEYBASARAN\\zeynep; Integrated Security=True;Encrypt=True;TrustServerCertificate=True;")

        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}