using Barinak.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Tracing;

namespace Barinak.Controllers
{
    public class LoginController : Controller
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
        public IActionResult LoginList()
        {
            var Loginler = t.Loginler.ToList();
            return View(Loginler);
        }
    }
}
