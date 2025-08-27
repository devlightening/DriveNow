using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.Controllers
{
    public class ContactController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
