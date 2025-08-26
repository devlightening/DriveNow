using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
