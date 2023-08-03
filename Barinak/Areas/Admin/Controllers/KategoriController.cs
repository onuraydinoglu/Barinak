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
            return View();
        }

        public IActionResult Kaydet(Kategori Kategori)
        {
            k.Kategoriler.Add(Kategori);
            k.SaveChanges();
            return RedirectToAction("KategoriList");
        }

        public IActionResult KategoriList()
        {
            var Kategoriler = k.Kategoriler.ToList();
            return View(Kategoriler);
        }

        [HttpPost]
        public IActionResult KategoriDuzenle(int? id, Kategori y)
        {
            if (id != y.KategoriID)
            {
                TempData["hata"] = "Güncelleme Yapılmaz";
                return View("Hata");
            }
            if (ModelState.IsValid)
            {
                k.Kategoriler.Update(y);
                k.SaveChanges();
                TempData["msj"] = y.KategoriAdi + " Kategorisi düzenlendi";
                return RedirectToAction("KategoriList");
            }
            TempData["Hata"] = "Lütfen verileri eksiksiz girin";
            return View();
        }
        public IActionResult KategoriDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var y = k.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["hata"] = "Düzenlenece herhangi bir yazar yok";
                return View("Hata");

            }
            return View(y);
        }

        public IActionResult KategoriDetay(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Detay kısmı getirilemez";
                return View("Hata");
            }

            var y = k.Kategoriler.Include(x => x.Turler).FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["hata"] = "Herhangi bir yazar bulunamadı";
                return View("Hata");
            }
            return View(y);
        }

        public IActionResult KategoriSil(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Silme kısmı çalışamaz";
                return View("Hata");
            }
            var y = k.Kategoriler.Include(x => x.Turler).FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["hata"] = "Silinecek herhangi bir yazar yok";
                return View("Hata");

            }
            if (y.Turler.Count > 0)
            {
                TempData["hata"] = "Yazarın kitabı olduğundan silme işlemi yapılamaz";
                return View("Hata");
            }
            k.Kategoriler.Remove(y);
            k.SaveChanges();
            TempData["msj"] = y.KategoriAdi + " adlı kategori silindi";
            return RedirectToAction("KategoriList");
        }


    }
}
