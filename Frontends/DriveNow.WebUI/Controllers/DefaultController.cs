using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
