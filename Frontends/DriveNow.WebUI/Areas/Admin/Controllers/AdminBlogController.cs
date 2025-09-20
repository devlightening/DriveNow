using DriveNow.Dtos.AuthorDtos;
using DriveNow.Dtos.BlogDtos;
using DriveNow.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Blogları al
            List<ResultBlogDto> blogs = new();
            var blogsResponse = await client.GetAsync($"{_apiBaseUrl}/api/Blogs/GetAllBlogsWithAuthorList");
            if (blogsResponse.IsSuccessStatusCode)
            {
                var blogsJson = await blogsResponse.Content.ReadAsStringAsync();
                blogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(blogsJson) ?? new List<ResultBlogDto>();
            }

            // Authorları al
            List<ResultAuthorDto> authors = new();
            var authorsResponse = await client.GetAsync($"{_apiBaseUrl}/api/Authors");
            if (authorsResponse.IsSuccessStatusCode)
            {
                var authorsJson = await authorsResponse.Content.ReadAsStringAsync();
                authors = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(authorsJson) ?? new List<ResultAuthorDto>();
            }

            // Kategorileri al
            List<ResultCategoryDto> categories = new();
            var categoriesResponse = await client.GetAsync($"{_apiBaseUrl}/api/Categories");
            if (categoriesResponse.IsSuccessStatusCode)
            {
                var categoriesJson = await categoriesResponse.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoriesJson) ?? new List<ResultCategoryDto>();
            }

            ViewBag.Authors = authors;
            ViewBag.Categories = categories;

            return View(blogs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Blogs";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Blog created successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error creating Blog." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Blogs";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Blog updated successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error updating Blog." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Blogs/{id}";

            var response = await client.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Blog deleted successfully." });

            return StatusCode((int)response.StatusCode, new { success = false, message = "Error deleting Blog." });
        }
    }
}
