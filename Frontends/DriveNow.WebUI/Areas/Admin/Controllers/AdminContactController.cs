using DriveNow.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminContactController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                var res = await client.GetAsync($"{_apiBaseUrl}/api/Contacts");
                if (!res.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = $"Error loading Contact data. Status code: {res.StatusCode}";
                    return View(new List<ResultContactDto>());
                }

                var json = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(json) ?? new();
                return View(values);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An unexpected error occurred: {ex.Message}";
                return View(new List<ResultContactDto>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDto dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid data provided." });

            try
            {
                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync($"{_apiBaseUrl}/api/Contacts", content);
                if (res.IsSuccessStatusCode)
                    return Ok(new { success = true, message = "Contact created successfully!" });

                var body = await res.Content.ReadAsStringAsync();
                return StatusCode((int)res.StatusCode, new
                {
                    success = false,
                    message = "Failed to create contact.",
                    details = body
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Server error: {ex.Message}" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(new { success = false, message = "Invalid id." });

            try
            {
                var client = _httpClientFactory.CreateClient();
                var res = await client.DeleteAsync($"{_apiBaseUrl}/api/Contacts/{id}");

                if (res.IsSuccessStatusCode)
                    return Ok(new { success = true, message = "Contact deleted successfully!" });

                var body = await res.Content.ReadAsStringAsync();
                return StatusCode((int)res.StatusCode, new
                {
                    success = false,
                    message = "Failed to delete contact.",
                    details = body
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Server error: {ex.Message}" });
            }
        }     
    }
}
