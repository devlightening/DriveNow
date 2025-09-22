using DriveNow.Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSocialMediaController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultSocialMediaDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/SocialMedias";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching SocialMedias. Status: {response.StatusCode}";
                    return View(new List<ResultSocialMediaDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(json) ?? new List<ResultSocialMediaDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultSocialMediaDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/SocialMedias";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "SocialMedia created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating SocialMedia." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/SocialMedias";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "SocialMedia updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating SocialMedia." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/SocialMedias/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "SocialMedia deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting SocialMedia." });
        }
    }
}
