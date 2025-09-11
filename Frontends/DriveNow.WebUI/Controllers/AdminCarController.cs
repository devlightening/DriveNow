using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
