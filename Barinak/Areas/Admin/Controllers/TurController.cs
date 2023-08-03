﻿using Barinak.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barinak.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TurController : Controller
    {
        BarinakContext t = new BarinakContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kaydet(Tur Tur)
        {
            t.Turler.Add(Tur);
            t.SaveChanges();
            return RedirectToAction("TurList");
        }

        public IActionResult TurList()
        {
            var Turler = t.Turler.ToList();
            return View(Turler);
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
                return RedirectToAction("TurList");
            }
            TempData["Hata"] = "Lütfen verileri eksiksiz girin";
            return View();
        }
        public IActionResult TurDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var y = t.Turler.FirstOrDefault(x => x.TurID == id);
            if (y is null)
            {
                TempData["hata"] = "Düzenlenecek herhangi bir tur yok";
                return View("Hata");

            }
            return View(y);
        }

        public IActionResult TurDetay(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Detay kısmı getirilemez";
                return View("Hata");
            }

            var y = t.Turler.FirstOrDefault(x => x.TurID == id);
            if (y is null)
            {
                TempData["hata"] = "Herhangi bir yazar bulunamadı";
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
                TempData["hata"] = "Silinecek herhangi bir yazar yok";
                return View("Hata");

            }
            t.Turler.Remove(y);
            t.SaveChanges();
            TempData["msj"] = y.TurAd + " adlı Tur silindi";
            return RedirectToAction("TurList");
        }


    }
}
