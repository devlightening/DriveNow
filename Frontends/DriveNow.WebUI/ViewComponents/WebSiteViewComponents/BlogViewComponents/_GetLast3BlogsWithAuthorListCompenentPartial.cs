using DriveNow.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorListCompenentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Blogs/GetLast3BlogsWithAuthorsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogWithAuthorsDto>>(jsonData);
                return View(values);
            }

            return View();

        }
    }
}