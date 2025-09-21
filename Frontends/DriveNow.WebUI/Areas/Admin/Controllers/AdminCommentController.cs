using DriveNow.Dtos.BlogDtos;
using DriveNow.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminCommentController(IHttpClientFactory http) : Controller
    {
        private readonly string _api = "https://localhost:7031";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = http.CreateClient();

            // 1) Yorumlar
            var comments = new List<ResultCommentDto>();
            var cRes = await client.GetAsync($"{_api}/api/Comments");
            if (cRes.IsSuccessStatusCode)
            {
                var json = await cRes.Content.ReadAsStringAsync();
                comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(json) ?? new();
            }

            // 2) Blog başlıklarını map’le (BlogId -> Title)
            var blogMap = new Dictionary<Guid, string>();
            var bRes = await client.GetAsync($"{_api}/api/Blogs/GetAllBlogsWithAuthorList");
            if (bRes.IsSuccessStatusCode)
            {
                var json = await bRes.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(json) ?? new();
                foreach (var b in blogs)
                    if (!blogMap.ContainsKey(b.BlogId))
                        blogMap[b.BlogId] = b.Title ?? "Untitled";
            }

            ViewBag.BlogMap = blogMap;             
            ViewBag.TotalCount = comments.Count;

            return View(comments);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(new { success = false, message = "Invalid id." });

            var client = http.CreateClient();
            var res = await client.DeleteAsync($"{_api}/api/Comments/{id}");
            var body = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
                return Json(new { success = true });

            return StatusCode((int)res.StatusCode, new { success = false, message = "Delete failed.", detail = body });
        }
    }
}
