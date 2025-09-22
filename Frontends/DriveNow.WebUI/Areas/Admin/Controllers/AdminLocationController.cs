using DriveNow.Dtos.LocationDtos;
using DriveNow.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLocationController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultLocationDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Locations";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching Locations. Status: {response.StatusCode}";
                    return View(new List<ResultLocationDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(json) ?? new List<ResultLocationDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultLocationDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Locations";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Location created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating Location." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Locations";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Location updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating Location." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Locations/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Location deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting Location." });
        }
    }
}
