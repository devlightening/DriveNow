using DriveNow.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAuthorController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultAuthorDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Authors";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching Authors. Status: {response.StatusCode}";
                    return View(new List<ResultAuthorDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(json) ?? new List<ResultAuthorDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultAuthorDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Authors";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Author created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating Author." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Authors";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Author updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating Author." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Authors/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Author deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting Author." });
        }
    }
}
