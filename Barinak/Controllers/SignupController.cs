using Barinak.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barinak.Controllers
{
    public class SignupController : Controller
    {
        BarinakContext usr = new BarinakContext();

        public IActionResult Index()
        {
            return View();
        }

    }
}
