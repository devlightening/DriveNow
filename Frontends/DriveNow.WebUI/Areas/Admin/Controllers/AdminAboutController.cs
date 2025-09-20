using DriveNow.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAboutController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultAboutDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Abouts";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching Abouts. Status: {response.StatusCode}";
                    return View(new List<ResultAboutDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(json) ?? new List<ResultAboutDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultAboutDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Abouts";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "About created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating About." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Abouts";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "About updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating About." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Abouts/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "About deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting About." });
        }
    }
}
