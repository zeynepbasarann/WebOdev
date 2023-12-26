using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly VbContext _vbcontext;

        public HomeController()
        {
            _vbcontext = new VbContext();
        }
       

        public ActionResult Index()
        {

            var turler = _vbcontext.Turler.ToList();
            return View(turler);

        }
       
        public async Task<ActionResult> urunGosterme(int turID)
        {
            var uruns = await _vbcontext.Uruns.Where(u => u.turID == turID).ToListAsync();
            return View(uruns);
        }


        public ActionResult Hakkinda()
        {
            using (var db = new VbContext())
            {
                var hakkindaVerisi = db.Hakkinda.FirstOrDefault(); // Varsayılan olarak ilk kaydı alır, sizin için uygunsa kullanabilirsiniz.

                ViewBag.Baslik = hakkindaVerisi?.baslik;
                ViewBag.Icerik = hakkindaVerisi?.icerik;
            }

            return View();
        }

        public ActionResult Iletisim()
        {
            using (var db = new VbContext())
            {
                var iletisimVerisi = db.Iletisim.FirstOrDefault(); // Varsayılan olarak ilk kaydı alır, sizin için uygunsa kullanabilirsiniz.

                ViewBag.BaslikIletisim = iletisimVerisi?.baslikIletisim;
                ViewBag.Adres = iletisimVerisi?.adres;
                ViewBag.Tel = iletisimVerisi?.tel;
                ViewBag.Mail = iletisimVerisi?.mail;
            }

            return View();
        }

        public ActionResult UyeOl()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UyeOl([Bind(Include = "uyeID,Ad,Soyad,mail,Sifre")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                _vbcontext.Uyeler.Add(uye);
                await _vbcontext.SaveChangesAsync();
                return RedirectToAction("UyeOl");
            }

            return View(uye);
        }
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(string mail, string Sifre)
        {
            var uye = _vbcontext.Uyeler.FirstOrDefault(u => u.mail == mail && u.Sifre == Sifre);

            if (uye != null)
            {
                // Giriş başarılı, kullanıcıyı ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Giriş başarısız, hata mesajını göster
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre");
                return View();
            }
        }
        public ActionResult YeniEklenenUrunler()
        {
            // Get the new products (you can customize this query based on your business logic)
            var newProducts = _vbcontext.Uruns.OrderByDescending(u => u.UrunId).Take(5).ToList();

            // Map Urun objects to Yeni objects or create a new ViewModel as needed
            var yeniUrunler = newProducts.Select(u => new Yeni
            {
                yeniID = u.UrunId,
                UrunId = u.UrunId,
                Urun = u
            }).ToList();

            return PartialView("_YeniEklenenUrunlerPartial", yeniUrunler);
        }
        public ActionResult UrunDetay(int urunId)
        {
            var urun = _vbcontext.Uruns.FirstOrDefault(u => u.UrunId == urunId);

            if (urun == null)
            {
                // Urun bulunamazsa, hata sayfasına yönlendir
                return HttpNotFound();
            }

            return View(urun);
        }
        [HttpPost]
        public ActionResult SepeteEkle(int UrunId)
        {
            List<Sepet> sepet = Session["Sepet"] as List<Sepet> ?? new List<Sepet>();

            Urun urun = _vbcontext.Uruns.Find(UrunId);
            sepet.Add(new Sepet { UrunId = UrunId, Urun = urun, TopUcret = urun.ucret });

            Session["Sepet"] = sepet;

            return RedirectToAction("UrunDetay"); // Redirect to the shopping cart page or any other page
        }

    }







}
