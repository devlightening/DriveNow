using DriveNow.Dtos.AuthorDtos;
using DriveNow.Dtos.BlogDtos;
using DriveNow.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Blogs
            var blogs = new List<ResultBlogDto>();
            var blogsResp = await client.GetAsync($"{_apiBaseUrl}/api/Blogs/GetAllBlogsWithAuthorList");
            if (blogsResp.IsSuccessStatusCode)
            {
                var json = await blogsResp.Content.ReadAsStringAsync();
                blogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(json) ?? new();
            }

            // Authors
            var authors = new List<ResultAuthorDto>();
            var authorsResp = await client.GetAsync($"{_apiBaseUrl}/api/Authors");
            if (authorsResp.IsSuccessStatusCode)
            {
                var json = await authorsResp.Content.ReadAsStringAsync();
                authors = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(json) ?? new();
            }

            // Categories
            var categories = new List<ResultCategoryDto>();
            var categoriesResp = await client.GetAsync($"{_apiBaseUrl}/api/Categories");
            if (categoriesResp.IsSuccessStatusCode)
            {
                var json = await categoriesResp.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json) ?? new();
            }

            ViewBag.Authors = authors;
            ViewBag.Categories = categories;
            return View(blogs);
        }

        // Admin: publish/unpublish toggle
        [HttpPost]
        public async Task<IActionResult> TogglePublish(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(new { success = false, message = "Invalid id." });

            var client = _httpClientFactory.CreateClient();

            // API'de TogglePublish endpoint'i olmalı (PUT/POST fark edebilir; sizde hangisiyse onu kullanın)
            var url = $"{_apiBaseUrl}/api/Blogs/TogglePublish/{id}";
            var resp = await client.PutAsync(url, content: null);
            var body = await resp.Content.ReadAsStringAsync();

            if (resp.IsSuccessStatusCode)
                return Json(new { success = true, message = "Publish status toggled." });

            return StatusCode((int)resp.StatusCode, new { success = false, message = "Error toggling publish status.", detail = body });
        }
    }
}
