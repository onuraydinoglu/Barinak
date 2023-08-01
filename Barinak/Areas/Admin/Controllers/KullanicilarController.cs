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
        public IActionResult Kaydet(Login Login)
        {
            t.Loginler.Add(Login);
            t.SaveChanges();
            return RedirectToAction("Signup");
        }
        public IActionResult KullanicilarListesi()
        {
            var Loginler = t.Loginler.ToList();
            return View(Loginler);
        }
    }
}
