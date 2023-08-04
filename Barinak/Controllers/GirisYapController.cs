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
             var usr = k.Uyeler.Where(x => x.Mail == uye.Mail && x.Sifre == uye.Sifre).FirstOrDefault();
             if (usr is not null)
             {
                 var cookopt = new CookieOptions
                 {
                     Expires = DateTime.Now.AddSeconds(1000)
                 };
                 HttpContext.Session.SetString("SessionMail", uye.Mail);
                 HttpContext.Response.Cookies.Append("UserAd", usr.Ad , cookopt);
                 return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
             }
             TempData["msj"] = "Hatalı Giriş Yapıldı";
             return View("Index");
         }


    }
}
