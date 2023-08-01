using Barinak.Models;
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
    }
}
