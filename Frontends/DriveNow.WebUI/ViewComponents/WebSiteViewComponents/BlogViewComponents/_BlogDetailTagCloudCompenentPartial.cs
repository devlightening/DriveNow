using DriveNow.Dtos.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.BlogViewComponents
{
    public class _BlogDetailTagCloudCompenentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid blogId)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/TagClouds/GetTagCloudsByBlogId/{blogId}"); 

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTagCloudByBlogIdDto>>(jsonData);
                return View(values);
            }
         
            return View(new List<ResultTagCloudByBlogIdDto>());
        }
    }
}