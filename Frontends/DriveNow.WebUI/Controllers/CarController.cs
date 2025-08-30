using DriveNow.Dtos.CarDtos;
using DriveNow.Dtos.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.Controllers
{
    public class CarController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Our Vehicle Fleet";
            ViewBag.v2 = "Find the Perfect Car for Your Journey";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/CarPricings/GetCarPricingWithCarList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarsDto>>(jsonData);
                return View(values);
            }

            return View();

        }
    }
}
