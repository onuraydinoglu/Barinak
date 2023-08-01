using Barinak.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
