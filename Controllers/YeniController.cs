using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class YeniController:Controller
    {
        private readonly VbContext _vbcontext;

        public YeniController()
        {
            _vbcontext = new VbContext();
        }
        public ActionResult yeniEkle()
        {
            ViewData["Uruns"] = new SelectList(_vbcontext.Uruns, "urunId", "egitimAd");
           

            return View();

        }
        public async Task<ActionResult> Admin()
        {
            var yeniler= await _vbcontext.Yeniler.ToListAsync();
            return View(yeniler);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var yeni = await _vbcontext.Yeniler
                .FirstOrDefaultAsync(m => m.yeniID== id);

            if (yeni== null)
            {
                return HttpNotFound();
            }

            return View(yeni);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> yeniEkle(Yeni yeni)
        {
            if (ModelState.IsValid)
            {
                // Resim yükleme işlemini gerçekleştir
                
                _vbcontext.Yeniler.Add(yeni);
                await _vbcontext.SaveChangesAsync();

                return RedirectToAction("yeniEkle");
            }

            // Eğer model durumu geçerli değilse, hatalarla birlikte görünümü döndürün
            return View(yeni);
        }
    }
}