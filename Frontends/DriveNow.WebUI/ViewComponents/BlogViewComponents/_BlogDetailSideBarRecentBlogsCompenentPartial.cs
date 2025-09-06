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
          
            var blogsResponse = await client.GetAsync("https://localhost:7031/api/Blogs/");

            if (blogsResponse.IsSuccessStatusCode)
            {
                var blogsJsonData = await blogsResponse.Content.ReadAsStringAsync();
                var blogList = JsonConvert.DeserializeObject<List<ResultRecentBlogDto>>(blogsJsonData);

             
                if (blogList != null && blogList.Any())
                {
                    foreach (var blog in blogList)
                    {
                    
                        var commentCountResponse = await client.GetAsync($"https://localhost:7031/api/Comments/GetCommentCountByBlog/{blog.Slug}");

                        if (commentCountResponse.IsSuccessStatusCode)
                        {
                            var commentJsonData = await commentCountResponse.Content.ReadAsStringAsync();
                          
                            var commentData = JsonConvert.DeserializeAnonymousType(commentJsonData, new { commentCount = 0 });
                            blog.CommentCount = commentData.commentCount;
                        }
                        else
                        {
                           
                            blog.CommentCount = 0;
                        }
                    }
                    return View(blogList);
                }
            }

         
            return View();
        }
    }
}