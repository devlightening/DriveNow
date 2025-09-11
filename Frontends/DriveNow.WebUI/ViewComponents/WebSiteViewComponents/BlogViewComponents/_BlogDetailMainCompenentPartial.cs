using DriveNow.Dtos.BlogContentDtos;
using DriveNow.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.BlogViewComponents
{
    public class _BlogDetailMainCompenentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/BlogContents/GetBlogContentsByBlogId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogContentByBlogIdDto>>(jsonData);
                return View(values);
            }

            return View();

        }

    }
}

