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
    public class TurController : Controller
    {
        private readonly VbContext _vbcontext;

        public TurController()
        {
            _vbcontext = new VbContext();
        }
        public async Task<ActionResult> Index()
        {
            var turler = await _vbcontext.Turler.ToListAsync();
            return View(turler);
        }
       
       
        public ActionResult turEkle()
        {
            ViewData["Kategoriler"] = new SelectList(_vbcontext.Kategoriler, "kategoriID", "kategoriAd");
            return View();

        }
        
        public async Task<ActionResult> Admin()
        {
            var turler = await _vbcontext.Turler.ToListAsync();
            return View(turler);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tur = await _vbcontext.Turler
                .FirstOrDefaultAsync(m => m.turID == id);

            if (tur == null)
            {
                return HttpNotFound();
            }

            return View(tur);
        }

        // GET: Students/Create
      

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> turEkle([Bind(Include = "turID,turAd,kategoriID")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                _vbcontext.Turler.Add(tur);
                await _vbcontext.SaveChangesAsync();
                return RedirectToAction("turEkle");
            }
            ViewData["Kategoriler"] = new SelectList(_vbcontext.Kategoriler, "kategoriID", "kategoriAd", tur.kategoriID);
            return View(tur);
            
        }
        public async Task<ActionResult> turListele()
        {

            var turler = await _vbcontext.Turler.Include(t => t.Kategori).ToListAsync();
            return View(turler);
        }
        public async Task<ActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tur = await _vbcontext.Turler.FindAsync(id);

            if (tur == null)
            {
                return HttpNotFound();
            }

            _vbcontext.Turler.Remove(tur);
            await _vbcontext.SaveChangesAsync();

            return RedirectToAction("turListele");
        }
        public async Task<ActionResult> Guncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tur = await _vbcontext.Turler.FindAsync(id);

            if (tur == null)
            {
                return HttpNotFound();
            }

            return View(tur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guncelle(Tur tur)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _vbcontext.Entry(tur).State = EntityState.Modified;
                    await _vbcontext.SaveChangesAsync();
                    return RedirectToAction("turListele");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}");
                    return View(tur);
                }
            }

            return View(tur);
        }
        public JsonResult GetTurler(int kategoriID)
        {
            var turler = _vbcontext.Turler.Where(t => t.kategoriID == kategoriID).ToList();
            return Json(turler, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTurlerByKategori(int kategoriID)
        {
            var turler = _vbcontext.Turler.Where(t => t.kategoriID == kategoriID).ToList();
            return Json(turler, JsonRequestBehavior.AllowGet);
        }









    }
}
