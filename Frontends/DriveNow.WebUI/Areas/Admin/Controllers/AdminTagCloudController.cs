using DriveNow.Dtos.TagCloudDtos;
using DriveNow.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTagCloudController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:7031";

        [HttpGet]
        public async Task<IActionResult> Index(Guid? blogId)
        {
            var client = _httpClientFactory.CreateClient();

            // TagCloud'lar
            List<ResultTagCloudDto> values = new();
            var response = await client.GetAsync($"{_apiBaseUrl}/api/TagClouds");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultTagCloudDto>>(json) ?? new();
            }

            // Blog başlıklarını da çekiyoruz (map için)
            var blogsResp = await client.GetAsync($"{_apiBaseUrl}/api/Blogs");
            if (blogsResp.IsSuccessStatusCode)
            {
                var blogsJson = await blogsResp.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(blogsJson) ?? new();
                var blogMap = blogs.ToDictionary(b => b.BlogId.ToString(), b => b.Title ?? "Untitled");
                ViewBag.BlogMap = blogMap;
                ViewBag.Blogs = blogs.Select(b => new { Id = b.BlogId.ToString(), Title = b.Title }).ToList();
            }
            else
            {
                ViewBag.BlogMap = new Dictionary<string, string>();
                ViewBag.Blogs = new List<object>();
            }

            // >>> başlangıçta seçilecek blog
            ViewBag.InitialBlogId = blogId?.ToString() ?? string.Empty;

            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTagCloud([FromBody] CreateTagCloudDto dto)
        {
            if (!ModelState.IsValid || dto == null || dto.BlogId == Guid.Empty || string.IsNullOrWhiteSpace(dto.TagCloudName))
                return BadRequest(new { success = false, message = "Invalid data." });

            var client = _httpClientFactory.CreateClient();
            var res = await client.PostAsync(
                $"{_apiBaseUrl}/api/TagClouds",
                new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
            );

            if (res.IsSuccessStatusCode)
                return Ok(new { success = true, message = "Tag created." });

            var body = await res.Content.ReadAsStringAsync();
            return StatusCode((int)res.StatusCode, new { success = false, message = "Error creating TagCloud.", details = body });
        }

        [HttpPost] // UI POST eder; API'ye PUT atacağız
        public async Task<IActionResult> UpdateTagCloud([FromBody] UpdateTagCloudDto dto)
        {
            if (dto == null || dto.TagCloudId == Guid.Empty ||
                dto.BlogId == Guid.Empty || string.IsNullOrWhiteSpace(dto.TagCloudName))
                return BadRequest(new { success = false, message = "Invalid data." });

            var client = _httpClientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // 1) Önce /api/TagClouds/{id} dene
            var firstUrl = $"{_apiBaseUrl}/api/TagClouds/{dto.TagCloudId}";
            var firstRes = await client.PutAsync(firstUrl, content);
            var firstBody = await firstRes.Content.ReadAsStringAsync();

            // 405 (Method Not Allowed) veya 404 (endpoint bu imzayı desteklemiyor) ise
            // 2) /api/TagClouds (id gövdede) fallback
            if (firstRes.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed ||
                firstRes.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // içeriği yeniden oluştur (StringContent tek kullanımlık)
                content = new StringContent(json, Encoding.UTF8, "application/json");
                var secondUrl = $"{_apiBaseUrl}/api/TagClouds";
                var secondRes = await client.PutAsync(secondUrl, content);
                var secondBody = await secondRes.Content.ReadAsStringAsync();

                if (secondRes.IsSuccessStatusCode)
                    return Ok(new { success = true, message = "Tag updated." });

                return StatusCode((int)secondRes.StatusCode, new
                {
                    success = false,
                    message = "Error updating TagCloud.",
                    details = secondBody
                });
            }

            if (firstRes.IsSuccessStatusCode)
                return Ok(new { success = true, message = "Tag updated." });

            // ilk deneme başarısızsa aynen ilet
            return StatusCode((int)firstRes.StatusCode, new
            {
                success = false,
                message = "Error updating TagCloud.",
                details = firstBody
            });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTagCloud(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(new { success = false, message = "Invalid id." });

            var client = _httpClientFactory.CreateClient();
            var res = await client.DeleteAsync($"{_apiBaseUrl}/api/TagClouds/{id}");

            if (res.IsSuccessStatusCode)
                return Ok(new { success = true, message = "Tag deleted." });

            var body = await res.Content.ReadAsStringAsync();
            return StatusCode((int)res.StatusCode, new { success = false, message = "Error deleting TagCloud.", details = body });
        }
    }
}
