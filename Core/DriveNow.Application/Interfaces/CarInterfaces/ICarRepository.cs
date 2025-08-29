using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarListWithBrandsAsync();
        Task<Car> GetCarWithBrandAsync(Guid id);
        Task<List<Car>> GetCarsByBrandIdAsync(Guid brandId);
        Task<List<Car>> GetCarsListWithBrands();
        Task<List<Car>> GetLast5CarsWithBrands();
        Task<List<Car>> GetCarsWithPricings();
        int GetCarCount();
    }
}