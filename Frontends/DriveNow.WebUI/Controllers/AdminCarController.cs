using DriveNow.Domain.Enums;
using DriveNow.Dtos.BrandDtos;
using DriveNow.Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using DriveNow.Application.Features.CQRS.Commands.CarCommands;

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
                if (!responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Error fetching car data. Status code: {responseMessage.StatusCode}";
                    return View(new List<ResultCarWithBrandsDto>());
                }

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);

                if (values == null)
                {
                    values = new List<ResultCarWithBrandsDto>();
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"API connection error: {ex.Message}";
                values = new List<ResultCarWithBrandsDto>();
            }
            catch (JsonException ex)
            {
                ViewBag.ErrorMessage = $"Error parsing car data: {ex.Message}";
                values = new List<ResultCarWithBrandsDto>();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                values = new List<ResultCarWithBrandsDto>();
            }

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            await PopulateDropdowns();
            return View(new CreateCarDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(createCarDto);
            }

            var client = _httpClientFactory.CreateClient();

            var commandToSend = new CreateCarCommand
            {
                BrandId = createCarDto.BrandId,
                Model = createCarDto.Model,
                Kilometer = createCarDto.Kilometer,
                Seat = createCarDto.Seat,
                Luggage = createCarDto.Luggage,
                CoverImageUrl = createCarDto.CoverImageUrl,
                BigImageUrl = createCarDto.BigImageUrl,
                Transmission = createCarDto.Transmission,
                CarType = createCarDto.CarType,
                FuelType = createCarDto.FuelType,
                DriveType = createCarDto.DriveType,
                ModelYear = createCarDto.ModelYear,
                IsPublished = createCarDto.IsPublished,
            };

            var json = JsonConvert.SerializeObject(commandToSend);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Cars", stringContent);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorBody = await responseMessage.Content.ReadAsStringAsync();
                    ViewBag.ErrorMessage = $"Error creating car. Status: {responseMessage.StatusCode}. Details: {errorBody}";
                    await PopulateDropdowns();
                    return View(createCarDto);
                }

                return RedirectToAction("Index", "AdminCar");
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"API connection error during car creation: {ex.Message}";
                await PopulateDropdowns();
                return View(createCarDto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An unexpected error occurred during car creation: {ex.Message}";
                await PopulateDropdowns();
                return View(createCarDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBrandViaAjax(CreateBrandDto createBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBrandDto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Brands", stringContent);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorBody = await responseMessage.Content.ReadAsStringAsync();
                    var statusCode = (int)responseMessage.StatusCode;
                    return StatusCode(statusCode, new { success = false, message = $"API Error: {errorBody}", statusCode = statusCode });
                }

                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var newBrand = JsonConvert.DeserializeObject<ResultBrandDto>(responseData);

                return Json(new { success = true, brand = newBrand });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { success = false, message = $"API connection error: {ex.Message}" });
            }
            catch (JsonException ex)
            {
                return StatusCode(500, new { success = false, message = $"Error processing API response: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"An unexpected error occurred: {ex.Message}" });
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

        [HttpGet]
        public async Task<IActionResult> UpdateCar(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Cars/{id}";

            try
            {
                var responseMessage = await client.GetAsync(requestUrl);
                responseMessage.EnsureSuccessStatusCode();
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateCarDto = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);

                if (updateCarDto == null)
                {
                    return NotFound();
                }

                await PopulateDropdowns(updateCarDto.BrandId, updateCarDto.CarType, updateCarDto.FuelType, updateCarDto.DriveType, updateCarDto.Transmission);
                return View(updateCarDto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An unexpected error occurred while fetching car details: {ex.Message}";
                return RedirectToAction("Index", "AdminCar");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(updateCarDto.BrandId, updateCarDto.CarType, updateCarDto.FuelType, updateCarDto.DriveType, updateCarDto.Transmission);
                return View(updateCarDto);
            }

            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{_apiBaseUrl}/api/Cars/{updateCarDto.CarId}";
            var json = JsonConvert.SerializeObject(updateCarDto, new JsonSerializerSettings { Culture = CultureInfo.InvariantCulture });
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var responseMessage = await client.PutAsync(requestUrl, stringContent);
                responseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "AdminCar");
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"An error occurred while updating the car: {ex.Message}";
                await PopulateDropdowns(updateCarDto.BrandId, updateCarDto.CarType, updateCarDto.FuelType, updateCarDto.DriveType, updateCarDto.Transmission);
                return View(updateCarDto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An unexpected error occurred during car update: {ex.Message}";
                await PopulateDropdowns(updateCarDto.BrandId, updateCarDto.CarType, updateCarDto.FuelType, updateCarDto.DriveType, updateCarDto.Transmission);
                return View(updateCarDto);
            }
        }

        private async Task PopulateDropdowns(Guid? selectedBrandId = null, CarType? selectedCarType = null, FuelType? selectedFuelType = null, DriveTypes? selectedDriveType = null, TransmissionType? selectedTransmission = null)
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
            }

            if (brandValuesApi != null)
            {
                ViewBag.BrandSelectItems = brandValuesApi.Select(x => new SelectListItem
                {
                    Text = x.BrandName,
                    Value = x.BrandId.ToString(),
                    Selected = x.BrandId == selectedBrandId
                }).ToList();
            }
            else
            {
                ViewBag.BrandSelectItems = new List<SelectListItem>();
            }

            ViewBag.CarTypeItems = Enum.GetValues(typeof(CarType)).Cast<CarType>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString(),
                Selected = e == selectedCarType
            }).ToList();

            ViewBag.FuelTypeItems = Enum.GetValues(typeof(FuelType)).Cast<FuelType>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString(),
                Selected = e == selectedFuelType
            }).ToList();

            ViewBag.DriveTypeItems = Enum.GetValues(typeof(DriveTypes)).Cast<DriveTypes>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString(),
                Selected = e == selectedDriveType
            }).ToList();

            ViewBag.TransmissionItems = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString(),
                Selected = e == selectedTransmission
            }).ToList();
        }
    }
}