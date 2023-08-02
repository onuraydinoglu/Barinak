using Barinak.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Barinak.Controllers
{
    public class UyeOlController : Controller
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
    }
}
