using DriveNow.Dtos.ParagraphDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.ParagraphViewComponents
{
    public class _ParagraphBlogDetailSideBarCompenentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
     
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Paragraphs");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogSideBarParagraphBoxDto>>(jsonData);

              
                if (values == null)
                {
                    return View(new List<ResultBlogSideBarParagraphBoxDto>());
                }

                return View(values);
            }

            return View(new List<ResultBlogSideBarParagraphBoxDto>());
        }
    }
}