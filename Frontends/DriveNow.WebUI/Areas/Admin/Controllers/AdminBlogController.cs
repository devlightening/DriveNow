using DriveNow.Dtos.AuthorDtos;
using DriveNow.Dtos.BlogDtos;
using DriveNow.Dtos.CategoryDtos;
using DriveNow.Dtos.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();

            var blogs = new List<ResultBlogDto>();
            var blogsResp = await client.GetAsync($"{_apiBaseUrl}/api/Blogs/GetAllBlogsWithAuthorList");
            if (blogsResp.IsSuccessStatusCode)
            {
                var json = await blogsResp.Content.ReadAsStringAsync();
                blogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(json) ?? new();
            }

            var authors = new List<ResultAuthorDto>();
            var authorsResp = await client.GetAsync($"{_apiBaseUrl}/api/Authors");
            if (authorsResp.IsSuccessStatusCode)
            {
                var json = await authorsResp.Content.ReadAsStringAsync();
                authors = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(json) ?? new();
            }

            var categories = new List<ResultCategoryDto>();
            var categoriesResp = await client.GetAsync($"{_apiBaseUrl}/api/Categories");
            if (categoriesResp.IsSuccessStatusCode)
            {
                var json = await categoriesResp.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json) ?? new();
            }

         
            var tagClouds = new List<ResultTagCloudDto>();
            var tagCloudsResp = await client.GetAsync($"{_apiBaseUrl}/api/TagClouds");
            if (tagCloudsResp.IsSuccessStatusCode)
            {
                var json = await tagCloudsResp.Content.ReadAsStringAsync(); 
                tagClouds = JsonConvert.DeserializeObject<List<ResultTagCloudDto>>(json) ?? new();
            }

         
            var blogToTags = tagClouds
                .GroupBy(t => t.BlogId)
                .ToDictionary(g => g.Key, g => g.ToList());

            var allTags = tagClouds
                .OrderBy(t => t.TagCloudName)
                .Select(t => new { t.TagCloudId, t.TagCloudName })
                .Distinct()
                .ToList();

            ViewBag.Authors = authors;
            ViewBag.Categories = categories;
            ViewBag.BlogToTags = blogToTags; 
            ViewBag.AllTags = allTags;

            return View(blogs);
        }


        [HttpPost]
        public async Task<IActionResult> TogglePublish(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(new { success = false, message = "Invalid id." });

            var client = httpClientFactory.CreateClient();
            var url = $"{_apiBaseUrl}/api/Blogs/TogglePublish/{id}";
            var resp = await client.PutAsync(url, content: null);
            var body = await resp.Content.ReadAsStringAsync();

            if (resp.IsSuccessStatusCode)
                return Json(new { success = true });

            return StatusCode((int)resp.StatusCode, new { success = false, message = "Error toggling publish status.", detail = body });
        }
    }
}
