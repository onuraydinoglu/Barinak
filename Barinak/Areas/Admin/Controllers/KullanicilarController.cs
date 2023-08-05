using Barinak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barinak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullanicilarController : Controller
    {
        BarinakContext t = new BarinakContext();

        public IActionResult Index()
        {
            var Uyeler = t.Uyeler.ToList();
            return View(Uyeler);
        }

        public IActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KullaniciEkle(UyeOl UyeOl)
        {
            if (ModelState.IsValid)
            {
                t.Uyeler.Add(UyeOl);
                t.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("KullaniciEkle");
            }
        }
        
        [HttpPost]
        public IActionResult UyeDuzenle(int? id, UyeOl y)
        {
            if (id != y.UyeOlID)
            {
                TempData["hata"] = "Güncelleme Yapılmaz";
                return View("Hata");
            }
            if (ModelState.IsValid)
            {
                t.Uyeler.Update(y);
                t.SaveChanges();
                TempData["msj"] = y.Ad + " adlı yazar düzenlendi";
                return RedirectToAction("Index");
            }
            TempData["Hata"] = "Lütfen verileri eksiksiz girin";
            return View();
        }
        public IActionResult UyeDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var y = t.Uyeler.FirstOrDefault(x => x.UyeOlID == id);
            if (y is null)
            {
                TempData["hata"] = "Düzenlenece herhangi bir yazar yok";
                return View("Hata");

            }
            return View(y);
        }

       
        public IActionResult UyeDetay(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Detay kısmı getirilemez";
                return View("Hata");
            }

            var y = t.Uyeler.FirstOrDefault(x => x.UyeOlID == id);
            if (y is null)
            {
                TempData["hata"] = "Herhangi bir yazar bulunamadı";
                return View("Hata");
            }
            return View(y);
        }

       
        public IActionResult UyeSil(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Silme kısmı çalışamaz";
                return View("Hata");
            }
            var y =t.Uyeler.FirstOrDefault(x => x.UyeOlID == id);
            if (y is null)
            {
                TempData["hata"] = "Silinecek herhangi bir yazar yok";
                return View("Hata");

            }
            t.Uyeler.Remove(y);
            t.SaveChanges();
            TempData["msj"] = y.Ad + " adlı uye silindi";
            return RedirectToAction("Index");
        }
    }
}
