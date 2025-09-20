using DriveNow.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            List<ResultCategoryDto> values = new();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Categories";

            try
            {
                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching  private readonly string _apiBaseUrl = \"https://localhost:7031\";\r\n\r\n        public async Task<IActionResult> Index()\r\n        {{\r\n            List<ResultAuthorDto> values = new();\r\n            var client = _httpClientFactory.CreateClient();\r\n            var requestUrl = $\"{{_apiBaseUrl}}/api/Authors\";\r\n\r\n            try\r\n            {{\r\n                var response = await client.GetAsync(requestUrl);\r\n                if (!response.IsSuccessStatusCode)\r\n                {{\r\n                    ViewBag.ErrorMessage = $\"Error fetching Authors. Status: {{response.StatusCode}}\";\r\n                    return View(new List<ResultAuthorDto>());\r\n                }}\r\n\r\n                var json = await response.Content.ReadAsStringAsync();\r\n                values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(json) ?? new List<ResultAuthorDto>();\r\n            }}\r\n            catch (Exception ex)\r\n            {{\r\n                ViewBag.ErrorMessage = $\"An error occurred: {{ex.Message}}\";\r\n                values = new List<ResultAuthorDto>();\r\n            }}\r\n\r\n            return View(values);\r\n        }}\r\n\r\n        [HttpPost]\r\n        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto dto)\r\n        {{\r\n            var client = _httpClientFactory.CreateClient();\r\n            var requestUrl = $\"{{_apiBaseUrl}}/api/Authors\";\r\n\r\n            var json = JsonConvert.SerializeObject(dto);\r\n            var content = new StringContent(json, Encoding.UTF8, \"application/json\");\r\n\r\n            var response = await client.PostAsync(requestUrl, content);\r\n\r\n            if (response.IsSuccessStatusCode)\r\n                return Json(new {{ success = true, message = \"Author created successfully.\" }});\r\n\r\n            return StatusCode((int)response.StatusCode, new {{ success = false, message = \"Error creating Author.\" }});\r\n        }}\r\n\r\n        [HttpPost]\r\n        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto dto)\r\n        {{\r\n            var client = _httpClientFactory.CreateClient();\r\n            var requestUrl = $\"{{_apiBaseUrl}}/api/Authors\";\r\n\r\n            var json = JsonConvert.SerializeObject(dto);\r\n            var content = new StringContent(json, Encoding.UTF8, \"application/json\");\r\n\r\n            var response = await client.PutAsync(requestUrl, content);\r\n\r\n            if (response.IsSuccessStatusCode)\r\n                return Json(new {{ success = true, message = \"Author updated successfully.\" }});\r\n\r\n            return StatusCode((int)response.StatusCode, new {{ success = false, message = \"Error updating Author.\" }});\r\n        }}\r\n\r\n        [HttpDelete]\r\n        public async Task<IActionResult> DeleteAuthor(Guid id)\r\n        {{\r\n            var client = _httpClientFactory.CreateClient();\r\n            var requestUrl = $\"{{_apiBaseUrl}}/api/Authors/{{id}}\";\r\n\r\n            var response = await client.DeleteAsync(requestUrl);\r\n\r\n            if (response.IsSuccessStatusCode)\r\n                return Json(new {{ success = true, message = \"Author deleted successfully.\" }});\r\n\r\n            return StatusCode((int)response.StatusCode, new {{ success = false, message = \"Error deleting Author.\" }});\r\n        }}. Status: {response.StatusCode}";
                    return View(new List<ResultCategoryDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json) ?? new List<ResultCategoryDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                values = new List<ResultCategoryDto>();
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Categories";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Category created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating Category." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Categories";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Category updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating Category." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Categories/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Category deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting Category." });
        }
    }
}
