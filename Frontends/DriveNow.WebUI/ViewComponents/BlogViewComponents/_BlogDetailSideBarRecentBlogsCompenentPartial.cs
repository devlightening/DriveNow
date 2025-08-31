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
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Blogs/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
                return View(values);
            }

            return View();

        }
    }
}