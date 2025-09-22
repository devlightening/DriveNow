using DriveNow.Dtos.FooterAddressDtos;
using DriveNow.Dtos.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFooterAddressController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultFooterAddressDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/FooterAddresses";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching FooterAddresses. Status: {response.StatusCode}";
                    return View(new List<ResultFooterAddressDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(json) ?? new List<ResultFooterAddressDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultFooterAddressDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress([FromBody] CreateFooterAddressDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/FooterAddresses";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "FooterAddress created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating FooterAddress." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFooterAddress([FromBody] UpdateFooterAddressDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/FooterAddresses";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "FooterAddress updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating FooterAddress." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddress(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/FooterAddresses/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "FooterAddress deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting FooterAddress." });
        }
    }
}
