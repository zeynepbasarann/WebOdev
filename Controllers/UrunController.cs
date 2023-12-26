using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;
using System.IO;



namespace WebApplication1.Controllers
{
    public class UrunController: Controller
    {
        private readonly VbContext _vbcontext;
        
        public UrunController()
        {
            _vbcontext = new VbContext();
        }
        public ActionResult urunEkle()
        {
            ViewData["Turler"] = new SelectList(_vbcontext.Turler, "turID", "turAd");
            ViewData["Yazarlar"] = new SelectList(_vbcontext.Yazarlar, "yazarID", "yazarAd");
            ViewData["Diller"] = new SelectList(_vbcontext.Diller, "dilID", "dilAd");
            
            return View();

        }

        public async Task<ActionResult> Admin()
        {
            var uruns = await _vbcontext.Uruns.ToListAsync();
            return View(uruns);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var urun = await _vbcontext.Uruns
                .FirstOrDefaultAsync(m => m.UrunId == id);

            if (urun == null)
            {
                return HttpNotFound();
            }

            return View(urun);
        }

       


       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> urunEkle(Urun urun, HttpPostedFileBase resimFile)
        {
            if (ModelState.IsValid)
            {
                // Resim yükleme işlemini gerçekleştir
                if (resimFile != null && resimFile.ContentLength > 0)
                {
                    try
                    {
                        // Dosya yükleme işlemleri
                        var fileName = Path.GetFileName(resimFile.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Content"), fileName);
                        resimFile.SaveAs(filePath);
                        urun.Resim = fileName; // Modelde resim yolunu ayarlayın

                        // Diğer işlemler
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda loglama veya hata mesajı gösterme
                        Console.WriteLine("Dosya yükleme hatası: " + ex.Message);
                    }
                }


                _vbcontext.Uruns.Add(urun);
                await _vbcontext.SaveChangesAsync();

                return RedirectToAction("urunEkle");
            }

            // Eğer model durumu geçerli değilse, hatalarla birlikte görünümü döndürün
            return View(urun);
        }


        public async Task<ActionResult> urunListele()
        {

            var uruns = await _vbcontext.Uruns
                .Include(e => e.Tur)
                .Include(e => e.Yazar)
                .Include(e => e.Dil)
              
                .ToListAsync();

            return View(uruns);
        }
        public async Task<ActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var urun = await _vbcontext.Uruns.FindAsync(id);

            if (urun == null)
            {
                return HttpNotFound();
            }

            _vbcontext.Uruns.Remove(urun);
            await _vbcontext.SaveChangesAsync();

            return RedirectToAction("urunListele");
        }
        public async Task<ActionResult> Guncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var urun = await _vbcontext.Uruns.FindAsync(id);

            if (urun == null)
            {
                return HttpNotFound();
            }

            return View(urun);
        }
        public ActionResult GetEgitimlerByTur(int turID)
        {
            var uruns = _vbcontext.Uruns.Where(e => e.turID == turID).ToList();
            return Json(uruns, JsonRequestBehavior.AllowGet);
        }
        

          
        






    }

}



