using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Interfaces.CarInterfaces
{
    public interface ICarResository
    {
        Task<List<Car>> GetCarListWithBrandsAsync();
        Task<Car> GetCarWithBrandAsync(Guid id);
        Task<List<Car>> GetCarsByBrandIdAsync(Guid brandId); 
    }
}