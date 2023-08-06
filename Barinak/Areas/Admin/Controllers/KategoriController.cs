using Barinak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barinak.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class KategoriController : Controller
    {
        BarinakContext k = new BarinakContext();

        public IActionResult Index()
        {
            var Kategoriler = k.Kategoriler.ToList();
            return View(Kategoriler);
        }

        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kategori Kategori)
        {
            if (ModelState.IsValid)
            {
                k.Add(Kategori);
                k.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msj"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("KategoriEkle");
            }
        }

        [HttpPost]
        public IActionResult KategoriDuzenle(int? id, Kategori y)
        {
            if (id != y.KategoriID)
            {
                TempData["msj"] = "Güncelleme Yapılmaz";
                return View("Hata");
            }
            if (ModelState.IsValid)
            {
                k.Kategoriler.Update(y);
                k.SaveChanges();
                TempData["msj"] = y.KategoriAdi + " Kategorisi düzenlendi";
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Lütfen verileri eksiksiz girin";
            return View();
        }
        public IActionResult KategoriDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var y = k.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["msj"] = "Düzenlenece herhangi bir kategori yok";
                return View("Hata");

            }
            return View(y);
        }

        public IActionResult KategoriDetay(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Detay kısmı getirilemez";
                return View("Hata");
            }

            var y = k.Kategoriler.Include(x => x.Turler).FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["msj"] = "Herhangi bir kategori bulunamadı";
                return View("Hata");
            }
            return View(y);
        }

        public IActionResult KategoriSil(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Silme kısmı çalışamaz";
                return View("Hata");
            }
            var y = k.Kategoriler.Include(x => x.Turler).FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["msj"] = "Silinecek herhangi bir kategori yok";
                return View("Hata");

            }
            if (y.Turler.Count > 0)
            {
                TempData["msj"] = "kategorinin turu olduğundan silme işlemi yapılamaz";
                return View("Hata");
            }
            k.Kategoriler.Remove(y);
            k.SaveChanges();
            TempData["msj"] = y.KategoriAdi + " adlı kategori silindi";
            return RedirectToAction("Index");
        }


    }
}
