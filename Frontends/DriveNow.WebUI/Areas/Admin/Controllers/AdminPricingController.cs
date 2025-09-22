using DriveNow.Dtos.PricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPricingController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiBaseUrl}/api/Pricings");

                if (!response.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = $"Error loading pricing data. Status code: {response.StatusCode}";
                    return View(new List<ResultPricingDto>());
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData) ?? new List<ResultPricingDto>();

                return View(values);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An unexpected error occurred: {ex.Message}";
                return View(new List<ResultPricingDto>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Invalid data provided." });
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{_apiBaseUrl}/api/Pricings", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { success = true, message = "Pricing plan created successfully!" });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, new
                {
                    success = false,
                    message = $"Failed to create pricing plan: {response.StatusCode}",
                    details = errorContent
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Server error: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricing([FromBody] UpdatePricingDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Invalid data provided." });
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Fix: Use PUT with ID in URL
                var response = await client.PutAsync($"{_apiBaseUrl}/api/Pricings/{dto.PricingId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { success = true, message = "Pricing plan updated successfully!" });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, new
                {
                    success = false,
                    message = $"Failed to update pricing plan: {response.StatusCode}",
                    details = errorContent
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Server error: {ex.Message}" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePricing(Guid id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.DeleteAsync($"{_apiBaseUrl}/api/Pricings/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { success = true, message = "Pricing plan deleted successfully!" });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, new
                {
                    success = false,
                    message = $"Failed to delete pricing plan: {response.StatusCode}",
                    details = errorContent
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Server error: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPricing(Guid id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiBaseUrl}/api/Pricings/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var pricing = JsonConvert.DeserializeObject<ResultPricingDto>(jsonData);
                    return Ok(pricing);
                }

                return StatusCode((int)response.StatusCode, new
                {
                    success = false,
                    message = "Pricing plan not found"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Server error: {ex.Message}" });
            }
        }
    }
}