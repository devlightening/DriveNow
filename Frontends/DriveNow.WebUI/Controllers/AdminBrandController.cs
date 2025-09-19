using DriveNow.Dtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Controllers
{
    public class AdminBrandController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultBrandDto> values = new List<ResultBrandDto>();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Brands";

            try
            {
                var responseMessage = await client.GetAsync(requestUrl);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching car data. Status code: {responseMessage.StatusCode}";
                    return View(new List<ResultBrandDto>());
                }

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                if (values == null)
                {
                    values = new List<ResultBrandDto>();
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"API connection error: {ex.Message}";
                values = new List<ResultBrandDto>();
            }
            catch (JsonException ex)
            {
                ViewBag.ErrorMessage = $"Error parsing car data: {ex.Message}";
                values = new List<ResultBrandDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                values = new List<ResultBrandDto>();
            }

            return View(values);
        }

        [HttpGet] 
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Brands";

            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync(requestUrl, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Brand has been successfully created." });
            }

            return StatusCode((int)responseMessage.StatusCode, new { success = false, message = "Error creating the Brand. Please try again." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Brands";

            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync(requestUrl, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Brand has been successfully updated." });
            }

            return StatusCode((int)responseMessage.StatusCode, new { success = false, message = "Error updating the Brand. Please try again." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Brands/{id}";

            var responseMessage = await client.DeleteAsync(requestUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Brand has been successfully deleted." });
            }

            return StatusCode((int)responseMessage.StatusCode, new { success = false, message = "Error deleting the Brand. Please try again." });
        }
    }
}