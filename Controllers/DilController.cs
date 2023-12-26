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
    public class DilController : Controller
    {
        private readonly VbContext _vbcontext;

        public DilController()
        {
            _vbcontext = new VbContext();
        }
        
        

        public async Task<ActionResult> Admin()
        {
            var diller = await _vbcontext.Diller.ToListAsync();
            return View(diller);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dil = await _vbcontext.Diller
                .FirstOrDefaultAsync(m => m.dilID == id);

            if (dil == null)
            {
                return HttpNotFound();
            }

            return View(dil);
        }

        // GET: Students/Create
        public ActionResult dilEkle()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> dilEkle([Bind(Include = "dilID,dilAd")] Dil dil)
        {
            if (ModelState.IsValid)
            {
                _vbcontext.Diller.Add(dil);
                await _vbcontext.SaveChangesAsync();
                return RedirectToAction("dilEkle");
            }

            return View(dil);
        }
        public async Task<ActionResult> dilListele()
        {
            var diller = await _vbcontext.Diller.ToListAsync();
            return View(diller);
        }
        public async Task<ActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dil = await _vbcontext.Diller.FindAsync(id);

            if (dil == null)
            {
                return HttpNotFound();
            }

            _vbcontext.Diller.Remove(dil);
            await _vbcontext.SaveChangesAsync();

            return RedirectToAction("dilListele");
        }
        public async Task<ActionResult> Guncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dil = await _vbcontext.Diller.FindAsync(id);

            if (dil == null)
            {
                return HttpNotFound();
            }

            return View(dil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guncelle(Dil dil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _vbcontext.Entry(dil).State = EntityState.Modified;
                    await _vbcontext.SaveChangesAsync();
                    return RedirectToAction("dilListele");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}");
                    return View(dil);
                }
            }

            return View(dil);
        }


    }
}
