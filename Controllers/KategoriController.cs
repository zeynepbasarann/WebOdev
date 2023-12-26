using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace WebApplication1.Controllers
{
    public class KategoriController : Controller
    {
        private readonly VbContext _vbcontext;

        public KategoriController()
        {
            _vbcontext = new VbContext();
        }

        public async Task<ActionResult> Index()
        {
            var kategoriler = await _vbcontext.Kategoriler.ToListAsync();
            return View(kategoriler);
        }


        public async Task<ActionResult> Admin()
        {
            var kategoriler = await _vbcontext.Kategoriler.ToListAsync();
            return View(kategoriler);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kategori = await _vbcontext.Kategoriler
                .FirstOrDefaultAsync(m => m.kategoriID == id);

            if (kategori == null)
            {
                return HttpNotFound();
            }

            return View(kategori);
        }
        public ActionResult kategoriEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> kategoriEkle([Bind(Include = "kategoriID,kategoriAd")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _vbcontext.Kategoriler.Add(kategori);
                await _vbcontext.SaveChangesAsync();
                return RedirectToAction("kategoriEkle");
            }
            else
            {
                // Model bağlama hatası olduğunu kontrol et
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(kategori);
        }
        public async Task<ActionResult> kategoriListele()
        {
            var kategoriler = await _vbcontext.Kategoriler.ToListAsync();
            return View(kategoriler);
        }
        public async Task<ActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kategori = await _vbcontext.Kategoriler.FindAsync(id);

            if (kategori == null)
            {
                return HttpNotFound();
            }

            _vbcontext.Kategoriler.Remove(kategori);
            await _vbcontext.SaveChangesAsync();

            return RedirectToAction("kategoriListele");
        }
        public async Task<ActionResult> Guncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kategori = await _vbcontext.Kategoriler.FindAsync(id);

            if (kategori == null)
            {
                return HttpNotFound();
            }

            return View(kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guncelle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _vbcontext.Entry(kategori).State = EntityState.Modified;
                    await _vbcontext.SaveChangesAsync();
                    return RedirectToAction("KategoriListele");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}");
                    return View(kategori);
                }
            }

            return View(kategori);
        }


        public JsonResult GetKategoriler()
        {
            var kategoriler = _vbcontext.Kategoriler.ToList();
            return Json(kategoriler, JsonRequestBehavior.AllowGet);
        }


        





    }
}