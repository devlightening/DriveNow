using DriveNow.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Controllers
{
    public class AdminFeatureController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultFeatureDto> values = new List<ResultFeatureDto>();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Features";

            try
            {
                var responseMessage = await client.GetAsync(requestUrl);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching car data. Status code: {responseMessage.StatusCode}";
                    return View(new List<ResultFeatureDto>());
                }

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                if (values == null)
                {
                    values = new List<ResultFeatureDto>();
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"API connection error: {ex.Message}";
                values = new List<ResultFeatureDto>();
            }
            catch (JsonException ex)
            {
                ViewBag.ErrorMessage = $"Error parsing car data: {ex.Message}";
                values = new List<ResultFeatureDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                values = new List<ResultFeatureDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Features";

            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync(requestUrl, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Feature has been successfully created." });
            }

            return StatusCode((int)responseMessage.StatusCode, new { success = false, message = "Error creating the feature. Please try again." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Features";

            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync(requestUrl, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Feature has been successfully updated." });
            }

            return StatusCode((int)responseMessage.StatusCode, new { success = false, message = "Error updating the feature. Please try again." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Features/{id}";

            var responseMessage = await client.DeleteAsync(requestUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Feature has been successfully deleted." });
            }

            return StatusCode((int)responseMessage.StatusCode, new { success = false, message = "Error deleting the feature. Please try again." });
        }
    }
}