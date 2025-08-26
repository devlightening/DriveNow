using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
