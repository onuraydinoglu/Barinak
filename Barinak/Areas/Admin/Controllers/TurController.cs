using Barinak.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barinak.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TurController : Controller
    {
        BarinakContext t = new BarinakContext();

        public IActionResult Index()
        {
            var Turler = t.Turler.ToList();
            return View(Turler);
        }

        public IActionResult TurEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TurEkle(Tur Tur)
        {
            if (ModelState.IsValid)
            {
                t.Turler.Add(Tur);
                t.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                t.Turler.Add(Tur);
                t.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult TurDuzenle(int? id, Tur y)
        {
            if (id != y.TurID)
            {
                TempData["hata"] = "Güncelleme Yapılmaz";
                return View("Hata");
            }
            if (ModelState.IsValid)
            {
                t.Turler.Update(y);
                t.SaveChanges();
                TempData["msj"] = y.TurID + " Olan ID düzenlendi";
                return RedirectToAction("Index");
            }
            t.Turler.Update(y);
            t.SaveChanges();
            TempData["msj"] = y.TurID + " Olan ID düzenlendi";
            return RedirectToAction("Index");
        }
        public IActionResult TurDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var y = t.Turler.FirstOrDefault(x => x.TurID == id);
            if (y is null)
            {
                TempData["msj"] = "Düzenlenecek herhangi bir tur yok";
                return View("Hata");

            }
            return View(y);
        }

        public IActionResult TurDetay(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Detay kısmı getirilemez";
                return View("Hata");
            }

            var y = t.Turler.FirstOrDefault(x => x.TurID == id);
            if (y is null)
            {
                TempData["msj"] = "Herhangi bir tur bulunamadı";
                return View("Hata");
            }
            return View(y);
        }

        public IActionResult TurSil(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Silme kısmı çalışamaz";
                return View("Hata");
            }
            var y = t.Turler.FirstOrDefault(x => x.TurID == id);
            if (y is null)
            {
                TempData["msj"] = "Silinecek herhangi bir tur yok";
                return View("Hata");

            }
            t.Turler.Remove(y);
            t.SaveChanges();
            TempData["msj"] = y.TurAd + " adlı Tur silindi";
            return RedirectToAction("Index");
        }


    }
}