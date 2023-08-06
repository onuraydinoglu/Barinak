using Barinak.Models;
using Barinak.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Barinak.Controllers
{
    public class HomeController : Controller
    {
        BarinakContext k = new BarinakContext();

        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;

        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }

        public IActionResult Index()
        {
            ViewBag.Category = _localization.Getkey("Category").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var Kategoriler = k.Kategoriler.ToList();
            return View(Kategoriler);
        }


        public IActionResult KategoriDetay(int? id)
        {
            var y = k.Kategoriler.Include(x => x.Turler).FirstOrDefault(x => x.KategoriID == id);
            if (y is null)
            {
                TempData["msj"] = "Böyle bir kategori yok";
                return View("Hata");
            }
            return View(y);
        }


        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}