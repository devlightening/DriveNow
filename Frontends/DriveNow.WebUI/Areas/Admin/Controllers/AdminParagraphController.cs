using DriveNow.Dtos.ParagraphDtos;
using DriveNow.Dtos.ParagraphDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminParagraphController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultParagraphDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Paragraphs";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching Paragraphs. Status: {response.StatusCode}";
                    return View(new List<ResultParagraphDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultParagraphDto>>(json) ?? new List<ResultParagraphDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultParagraphDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParagraph([FromBody] CreateParagraphDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Paragraphs";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Paragraph created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating Paragraph." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateParagraph([FromBody] UpdateParagraphDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Paragraphs";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Paragraph updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating Paragraph." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParagraph(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Paragraphs/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Paragraph deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting Paragraph." });
        }
    }
}
