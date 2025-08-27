using DriveNow.Dtos.ServiceDtos;
using DriveNow.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {

            return View();

        }
    }
}
