using Barinak.Areas.Admin.Controllers;
using Barinak.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barinak.Controllers
{
    public class GirisYapController : Controller
    {
        BarinakContext k = new BarinakContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GirisYap(UyeOl uye)
         {
            var usr = k.Uyeler.FirstOrDefault(x => x.Mail == uye.Mail && x.Sifre == uye.Sifre);
            if (usr is not null)       
            {
               var cookopt = new CookieOptions
                {
                    Expires = DateTime.Now.AddSeconds(10)
                };

                var userRole = k.Uyeler.FirstOrDefault(r => r.Role == usr.Role)?.Role;

                HttpContext.Session.SetString("SessionMail", uye.Mail);
                HttpContext.Response.Cookies.Append("UserRole", userRole ?? "Guest", cookopt);
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            TempData["msj"] = "Hatalı Giriş Yapıldı";
            return View("Index");
        }

    }
}
