using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;



namespace WebApplication1.Controllers
{
    public class YazarController : Controller
    {
        private readonly VbContext _vbcontext;

        public YazarController()
        {
            _vbcontext = new VbContext();
        }
        

        public async Task<ActionResult> Admin()
        {
            var yazarlar = await _vbcontext.Yazarlar.ToListAsync();
            return View(yazarlar);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var yazar = await _vbcontext.Yazarlar
                .FirstOrDefaultAsync(m => m.yazarID == id);

            if (yazar == null)
            {
                return HttpNotFound();
            }

            return View(yazar);
        }
        public ActionResult yazarEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> yazarEkle([Bind(Include = "yazarID,yazarAd")] Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _vbcontext.Yazarlar.Add(yazar);
                await _vbcontext.SaveChangesAsync();
                return RedirectToAction("yazarEkle");
            }

            return View(yazar);
        }
        public async Task<ActionResult> yazarListele()
        {
            var yazarlar = await _vbcontext.Yazarlar.ToListAsync();
            return View(yazarlar);
        }
        public async Task<ActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var yazar = await _vbcontext.Yazarlar.FindAsync(id);

            if (yazar == null)
            {
                return HttpNotFound();
            }

            _vbcontext.Yazarlar.Remove(yazar);
            await _vbcontext.SaveChangesAsync();

            return RedirectToAction("yazarListele");
        }
        public async Task<ActionResult> Guncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var yazar = await _vbcontext.Yazarlar.FindAsync(id);

            if (yazar == null)
            {
                return HttpNotFound();
            }

            return View(yazar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guncelle(Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _vbcontext.Entry(yazar).State = EntityState.Modified;
                    await _vbcontext.SaveChangesAsync();
                    return RedirectToAction("yazarListele");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}");
                    return View(yazar);
                }
            }

            return View(yazar);
        }






    }
}
