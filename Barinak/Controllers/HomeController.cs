using Barinak.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Barinak.Controllers
{
    public class HomeController : Controller
    {
        BarinakContext k = new BarinakContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Kategoriler = k.Kategoriler.ToList();
            return View(Kategoriler);
        }


        public IActionResult KategoriDetay(int? id)
        {
            var y = k.Kategoriler.Include(x => x.Turler).FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["hata"] = "Böyle bir kategori yok";
                return View("Hata");
            }
            return View(y);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}