using DriveNow.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSideBarRecentBlogsCompenentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            // Önce tüm blogları getir
            var blogsResponse = await client.GetAsync("https://localhost:7031/api/Blogs/");

            if (blogsResponse.IsSuccessStatusCode)
            {
                var blogsJsonData = await blogsResponse.Content.ReadAsStringAsync();
                var blogList = JsonConvert.DeserializeObject<List<ResultRecentBlogDto>>(blogsJsonData);

                // Eğer blogList null veya boş değilse, her blog için yorum sayısını al
                if (blogList != null && blogList.Any())
                {
                    foreach (var blog in blogList)
                    {
                        // Her blog için yorum sayısını getirecek API'yi çağır
                        var commentCountResponse = await client.GetAsync($"https://localhost:7031/api/Comments/GetCommentCountByBlog/{blog.BlogId}");

                        if (commentCountResponse.IsSuccessStatusCode)
                        {
                            var commentJsonData = await commentCountResponse.Content.ReadAsStringAsync();
                            // JSON yapısı "{"commentCount": 10}" gibi ise, bu şekilde deserialize edilebilir:
                            var commentData = JsonConvert.DeserializeAnonymousType(commentJsonData, new { commentCount = 0 });
                            blog.CommentCount = commentData.commentCount;
                        }
                        else
                        {
                            // Yorum sayısı alınamazsa varsayılan olarak 0 ayarla veya hata yönetimi yap
                            blog.CommentCount = 0;
                        }
                    }
                    return View(blogList);
                }
            }

            // Hata durumunda veya boş liste geldiğinde boş View döndür
            return View();
        }
    }
}