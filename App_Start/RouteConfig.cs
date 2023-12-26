using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Urun",
                url: "Urun/{action}",
                defaults: new { controller = "Urun", action = "urunEkle" }
            );
            routes.MapRoute(
                name: "UrunDetay",
                url: "uruns/{action}",
                defaults: new { controller = "Home", action = "SepeteEkle" }
            );
            routes.MapRoute(
                name: "Yeni",
                url: "Yeni/{action}",
                defaults: new { controller = "Yeni", action = "yeniEkle" }
            );
            routes.MapRoute(
                name: "urunGosterme",
                url: "uruns/{action}",
                defaults: new { controller = "Home", action = "urunGosterme" }
            );
            routes.MapRoute(
                name: "Hakkinda",
                url: "hakkinda",
                defaults: new { controller = "Home", action = "Hakkinda" }
            );
           




            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AdminPanel",
                url: "AdminPanel/{action}/{id}",
                defaults: new { controller = "AdminPanel", action = "Admin", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Kategori",
                url: "Kategori/{action}",
                defaults: new { controller = "Kategori", action = "kategoriEkle" }
            );
            routes.MapRoute(
               name: "Uye",
               url: "Uye/{action}",
               defaults: new { controller = "Home", action = "UyeOl" }
            );
           

            routes.MapRoute(
               name: "Yazar",
               url: "Yazar/{action}",
               defaults: new { controller = "Yazar", action = "yazarEkle" }
           );
            routes.MapRoute(
               name: "Dil",
               url: "Dil/{action}",
               defaults: new { controller = "Dil", action = "dilEkle" }
           );
            routes.MapRoute(
               name: "Tur",
               url: "Tur/{action}",
               defaults: new { controller = "Tur", action = "turEkle" }
           );

        }
    }
}
