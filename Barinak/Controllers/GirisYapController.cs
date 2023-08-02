using Microsoft.AspNetCore.Mvc;

namespace Barinak.Controllers
{
    public class GirisYapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GirisYap()
        {
            return View();
        }
    }
}
