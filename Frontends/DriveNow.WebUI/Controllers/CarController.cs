using DriveNow.Dtos.CarDtos; // GetCarPricingWithCarQueryResult buradaysa
using DriveNow.Application.Features.DTOs; // CarListWithCountDto'nun olduğu yer
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DriveNow.Application.Features.Mediator.Results.CarPricingResults;

namespace DriveNow.WebUI.Controllers
{
    public class CarController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Our Vehicle Fleet";
            ViewBag.v2 = "Find the Perfect Car for Your Journey";
            var client = _httpClientFactory.CreateClient();

            // Güncellenmiş API endpoint'ini çağırın
            var responseMessage = await client.GetAsync("https://localhost:7031/api/CarPricings/GetPublishedCarPricings");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultData = JsonConvert.DeserializeObject<CarListWithCountDto>(jsonData);

                return View(resultData); 
            }

            return View(new CarListWithCountDto { Cars = new List<GetPublishedCarPricingWithCarQueryResult>(), TotalCount = 0 });
        }
    }
}