using DriveNow.Dtos.CloudTagByBlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.CloudTagByBlogViewComponents
{
    public class _BlogDetailCloudTagByBlogCompenentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid blogId) 
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/CloudTagByBlogs/GetByBlogId/{blogId}"); 

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCloudTagByBlogDto>>(jsonData);
                return View(values);
            }
            // Başarısız durumda boş bir liste döndürmek, frontend'in çökmesini engeller.
            return View(new List<ResultCloudTagByBlogDto>());
        }
    }
}