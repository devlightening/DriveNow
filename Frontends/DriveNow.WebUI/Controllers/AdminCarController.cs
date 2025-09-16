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
        private readonly string _apiBaseUrl = "https://localhost:7031";

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
                responseMessage.EnsureSuccessStatusCode();

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);

                if (values == null)
                {
                    values = new List<ResultCarWithBrandsDto>();
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"Error fetching car data: {ex.Message}";
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

            ViewBag.CarTypeItems = Enum.GetValues(typeof(CarType)).Cast<CarType>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            }).ToList();

            ViewBag.FuelTypeItems = Enum.GetValues(typeof(FuelType)).Cast<FuelType>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            }).ToList();

            ViewBag.DriveTypeItems = Enum.GetValues(typeof(DriveTypes)).Cast<DriveTypes>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            }).ToList();

            ViewBag.TransmissionItems = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            }).ToList();

            return View(new CreateCarDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            if (!ModelState.IsValid)
            {
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

                ViewBag.CarTypeItems = Enum.GetValues(typeof(CarType)).Cast<CarType>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();
                ViewBag.FuelTypeItems = Enum.GetValues(typeof(FuelType)).Cast<FuelType>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();
                ViewBag.DriveTypeItems = Enum.GetValues(typeof(DriveTypes)).Cast<DriveTypes>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();
                ViewBag.TransmissionItems = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();

                return View(createCarDto);
            }

            var clientPost = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createCarDto);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var responseMessagePost = await clientPost.PostAsync($"{_apiBaseUrl}/api/Cars", stringContent);
                responseMessagePost.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "AdminCar");
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"An error occurred while creating the car: {ex.Message}";

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

                ViewBag.CarTypeItems = Enum.GetValues(typeof(CarType)).Cast<CarType>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();
                ViewBag.FuelTypeItems = Enum.GetValues(typeof(FuelType)).Cast<FuelType>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();
                ViewBag.DriveTypeItems = Enum.GetValues(typeof(DriveTypes)).Cast<DriveTypes>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();
                ViewBag.TransmissionItems = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>().Select(e => new SelectListItem { Text = e.ToString(), Value = ((int)e).ToString() }).ToList();

                return View(createCarDto);
            }
        }

        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Cars/{id}";

            try
            {
                var responseMessage = await client.DeleteAsync(requestUrl);
                responseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "AdminCar");
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"Error deleting car: {ex.Message}";
                return RedirectToAction("Index", "AdminCar");
            }
        }
    }
}   