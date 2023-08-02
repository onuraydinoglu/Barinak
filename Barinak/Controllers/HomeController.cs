using Barinak.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult Privacy()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}