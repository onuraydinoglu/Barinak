using Barinak.Models;
using Microsoft.AspNetCore.Authorization;
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
                TempData["msj"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("KullaniciEkle");
            }
        }
        
        [HttpPost]
        public IActionResult UyeDuzenle(int? id, UyeOl y)
        {
            if (id != y.UyeOlID)
            {
                TempData["msj"] = "Güncelleme Yapılmaz";
                return View("Hata");
            }
            if (ModelState.IsValid)
            {
                t.Uyeler.Update(y);
                t.SaveChanges();
                TempData["msj"] = y.Ad + " adlı kullanici düzenlendi";
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Lütfen verileri eksiksiz girin";
            return View();
        }
        public IActionResult UyeDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var y = t.Uyeler.FirstOrDefault(x => x.UyeOlID == id);
            if (y is null)
            {
                TempData["msj"] = "Düzenlenece herhangi bir kullanici yok";
                return View("Hata");

            }
            return View(y);
        }
       
        public IActionResult UyeDetay(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Detay kısmı getirilemez";
                return View("Hata");
            }

            var y = t.Uyeler.FirstOrDefault(x => x.UyeOlID == id);
            if (y is null)
            {
                TempData["msj"] = "Herhangi bir kullanici bulunamadı";
                return View("Hata");
            }
            return View(y);
        }
       
        public IActionResult UyeSil(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Silme kısmı çalışamaz";
                return View("Hata");
            }
            var y =t.Uyeler.FirstOrDefault(x => x.UyeOlID == id);
            if (y is null)
            {
                TempData["msj"] = "Silinecek herhangi bir kullanici yok";
                return View("Hata");

            }
            t.Uyeler.Remove(y);
            t.SaveChanges();
            TempData["msj"] = y.Ad + " adlı uye silindi";
            return RedirectToAction("Index");
        }
    }
}
