using Barinak.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barinak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullanicilarController : Controller
    {
        BarinakContext t = new BarinakContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kaydet(UyeOl UyeOl)
        {
            t.Uyeler.Add(UyeOl);
            t.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UyeList()
        {
            var Uyeler = t.Uyeler.ToList();
            return View(Uyeler);
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
    }
}
