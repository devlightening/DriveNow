using DriveNow.Dtos.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBannerController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Banners";
            var values = new List<ResultBannerDto>();

            try
            {
                var responseMessage = await client.GetAsync(requestUrl);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData) ?? new List<ResultBannerDto>();
                }
                else
                {
                    ViewBag.ErrorMessage = $"API error: {responseMessage.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Unexpected error: {ex.Message}";
            }

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Banners";

            var jsonData = JsonConvert.SerializeObject(createBannerDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync(requestUrl, content);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(createBannerDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/api/Banners/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var banner = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);

            if (banner == null)
                return NotFound();

            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Banners";

            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync(requestUrl, content);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(updateBannerDto);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBanner(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Banners/{id}";
            var responseMessage = await client.DeleteAsync(requestUrl);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return BadRequest("Error deleting the banner");
        }
    }
}
