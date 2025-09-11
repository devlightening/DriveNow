using DriveNow.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorAboutCompenentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Blogs/GetBlogByAuthorId/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

              
                var authors = JsonConvert.DeserializeObject<List<GetAuthorByBlogAuthorIdDto>>(jsonData);

             
                if (authors != null && authors.Any())
                {
                    return View(authors.FirstOrDefault());
                }
            }

         
            return View(new GetAuthorByBlogAuthorIdDto());
        }
    }
}