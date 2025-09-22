using DriveNow.Dtos.ServiceDtos;
using DriveNow.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminServiceController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultServiceDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Services";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching Services. Status: {response.StatusCode}";
                    return View(new List<ResultServiceDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(json) ?? new List<ResultServiceDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultServiceDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Services";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Service created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating Service." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Services";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Service updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating Service." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Services/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Service deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting Service." });
        }
    }
}
