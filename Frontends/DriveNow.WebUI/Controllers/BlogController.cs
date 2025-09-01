using DriveNow.Dtos.BlogContentDtos;
using DriveNow.Dtos.BlogDtos;
using DriveNow.Dtos.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriveNow.WebUI.Controllers
{
    public class BlogController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Stories from the Road";
            ViewBag.v2 = "An Anthology of Our Authors' Journeys";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Blogs/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorDto>>(jsonData);
                return View(values);
            }

            return View();

        }


        public  async Task<IActionResult> BlogDetail(Guid id)
        {
            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Blog Details and Comments";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Blogs/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // Not: "GetBlogByIdQueryResult" adını kullanarak API'den gelen veriyi
                // uygun DTO'ya dönüştürüyoruz.
                var values = JsonConvert.DeserializeObject<GetBlogByIdQueryResultDto>(jsonData);

                // Veriyi doğrudan View'e model olarak gönderiyoruz.
                return View(values);
            }

            // İstek başarısız olursa veya veri bulunamazsa 404 Not Found döndür.
            return NotFound();

        }
    }
}