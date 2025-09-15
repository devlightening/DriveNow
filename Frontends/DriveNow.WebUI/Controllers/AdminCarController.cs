using DriveNow.Domain.Enums;
using DriveNow.Dtos.BrandDtos;
using DriveNow.Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DriveNow.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl = "https://localhost:7031"; // API base URL'nizi doğru ayarlayın

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ResultCarWithBrandsDto> values = new List<ResultCarWithBrandsDto>();
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Cars/GetCarWithBrand";

            try
            {
                var responseMessage = await client.GetAsync(requestUrl);
                responseMessage.EnsureSuccessStatusCode(); // HTTP hata kodları için kontrol

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);

                if (values == null)
                {
                    values = new List<ResultCarWithBrandsDto>(); // Null ise boş liste ata
                }
            }
            catch (HttpRequestException ex)
            {
                // Hata yönetimi: Loglama veya kullanıcıya bilgi verme
                // Log.Error(ex, "Failed to fetch car list.");
                // Şimdilik basit bir hata mesajı ile View'ı gösterebiliriz
                ViewBag.ErrorMessage = $"Error fetching car data: {ex.Message}";
                // Boş bir liste ile devam edilebilir veya özel bir hata sayfasına yönlendirilebilir.
                values = new List<ResultCarWithBrandsDto>();
            }

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            List<ResultBrandDto> brandValuesApi = null;

            try
            {
                var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Brands/");
                responseMessage.EnsureSuccessStatusCode(); // Hata durumunda exception fırlatır

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                brandValuesApi = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            }
            catch (HttpRequestException ex)
            {
                // Hata yönetimi: Loglama veya kullanıcıya bilgi verme
                // Log.Error(ex, "Failed to fetch brands.");
                return View("ErrorApiFetch"); // Custom bir hata sayfası oluşturulabilir
            }

            // Dropdown için SelectListItem listesini oluştur
            List<SelectListItem> brandSelectItems = brandValuesApi.Select(x => new SelectListItem
            {
                Text = x.BrandName,
                Value = x.BrandId.ToString()
            }).ToList();

            // ViewBag'e dropdown seçeneklerini ve boş bir CreateCarDto gönderiyoruz
            ViewBag.BrandSelectItems = brandSelectItems;

            // Enumlar için de SelectListItem listeleri oluşturabiliriz
            ViewBag.CarTypeItems = Enum.GetValues(typeof(CarType))
                                       .Cast<CarType>()
                                       .Select(e => new SelectListItem
                                       {
                                           Text = e.ToString(),
                                           Value = ((int)e).ToString()
                                       }).ToList();

            ViewBag.FuelTypeItems = Enum.GetValues(typeof(FuelType))
                                        .Cast<FuelType>()
                                        .Select(e => new SelectListItem
                                        {
                                            Text = e.ToString(),
                                            Value = ((int)e).ToString()
                                        }).ToList();

            ViewBag.DriveTypeItems = Enum.GetValues(typeof(DriveTypes)) // Burada DriveTypes kullanıldı
                                         .Cast<DriveTypes>()
                                         .Select(e => new SelectListItem
                                         {
                                             Text = e.ToString(),
                                             Value = ((int)e).ToString()
                                         }).ToList();

            ViewBag.TransmissionItems = Enum.GetValues(typeof(TransmissionType))
                                            .Cast<TransmissionType>()
                                            .Select(e => new SelectListItem
                                            {
                                                Text = e.ToString(),
                                                Value = ((int)e).ToString()
                                            }).ToList();


            // View'a boş bir CreateCarDto modeli gönderiyoruz, formun doğru çalışması için
            return View(new CreateCarDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            // Model doğrulaması yapılır
            if (!ModelState.IsValid)
            {
                // Model doğrulama başarısız olursa, hata mesajlarını tekrar gösterebilmek için
                // Gerekli verileri (marka listesi ve enum listeleri) tekrar alıp View'a göndermeliyiz
                var client = _httpClientFactory.CreateClient();
                List<ResultBrandDto> brandValuesApi = null;
                try
                {
                    var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Brands/");
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    brandValuesApi = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                }
                catch (HttpRequestException)
                {
                    return View("ErrorApiFetch");
                }

                List<SelectListItem> brandSelectItems = brandValuesApi.Select(x => new SelectListItem
                {
                    Text = x.BrandName,
                    Value = x.BrandId.ToString()
                }).ToList();
                ViewBag.BrandSelectItems = brandSelectItems;

                // Enum listelerini de tekrar yükle
                ViewBag.CarTypeItems = Enum.GetValues(typeof(CarType))
                                           .Cast<CarType>()
                                           .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                           .ToList();

                ViewBag.FuelTypeItems = Enum.GetValues(typeof(FuelType))
                                            .Cast<FuelType>()
                                            .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                            .ToList();

                ViewBag.DriveTypeItems = Enum.GetValues(typeof(DriveTypes)) // DriveTypes kullanıldı
                                             .Cast<DriveTypes>()
                                             .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                             .ToList();

                ViewBag.TransmissionItems = Enum.GetValues(typeof(TransmissionType))
                                                .Cast<TransmissionType>()
                                                .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                                .ToList();

                return View(createCarDto); // Hatalı model ile View'ı tekrar göster
            }

            // Model doğrulaması başarılı ise API'ye gönder
            var clientPost = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createCarDto);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var responseMessagePost = await clientPost.PostAsync($"{_apiBaseUrl}/api/Cars", stringContent);
                responseMessagePost.EnsureSuccessStatusCode();

                // Başarılı ise Car Inventory sayfasına yönlendir
                return RedirectToAction("Index", "AdminCar");
            }
            catch (HttpRequestException ex)
            {
                // Hata yönetimi
                // Log.Error(ex, "Failed to create car.");
                ViewBag.ErrorMessage = $"An error occurred while creating the car: {ex.Message}";

                // Hata durumunda da marka ve enum listelerini göstermeliyiz
                var brandClient = _httpClientFactory.CreateClient();
                List<ResultBrandDto> errorBrandValuesApi = null;
                try
                {
                    var brandResponseMessage = await brandClient.GetAsync($"{_apiBaseUrl}/api/Brands/");
                    brandResponseMessage.EnsureSuccessStatusCode();
                    var brandJsonData = await brandResponseMessage.Content.ReadAsStringAsync();
                    errorBrandValuesApi = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJsonData);
                }
                catch (HttpRequestException)
                {
                    return View("ErrorApiFetch");
                }

                List<SelectListItem> errorBrandSelectItems = errorBrandValuesApi.Select(x => new SelectListItem
                {
                    Text = x.BrandName,
                    Value = x.BrandId.ToString()
                }).ToList();
                ViewBag.BrandSelectItems = errorBrandSelectItems;

                // Enum listelerini de tekrar yükle
                ViewBag.CarTypeItems = Enum.GetValues(typeof(CarType))
                                           .Cast<CarType>()
                                           .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                           .ToList();

                ViewBag.FuelTypeItems = Enum.GetValues(typeof(FuelType))
                                            .Cast<FuelType>()
                                            .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                            .ToList();

                ViewBag.DriveTypeItems = Enum.GetValues(typeof(DriveTypes)) // DriveTypes kullanıldı
                                             .Cast<DriveTypes>()
                                             .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                             .ToList();

                ViewBag.TransmissionItems = Enum.GetValues(typeof(TransmissionType))
                                                .Cast<TransmissionType>()
                                                .Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() })
                                                .ToList();

                return View(createCarDto); // Hata mesajıyla formu tekrar göster
            }
        }
    }
}