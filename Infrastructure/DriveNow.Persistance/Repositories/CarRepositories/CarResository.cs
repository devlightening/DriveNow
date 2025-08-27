using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Persistance.Repositories.CarRepositories
{
    public class CarResository(DriveNowContext _context) : ICarResository
    {
      
        public async Task<Car> GetCarWithBrandAsync(Guid id)
        {
            return await _context.Cars
                                 .Include(c => c.Brand)
                                 .SingleOrDefaultAsync(c => c.CarId == id);
        }

     
        public async Task<List<Car>> GetCarListWithBrandsAsync()
        {
            return await _context.Cars
                                 .Include(c => c.Brand)
                                 .ToListAsync();
        }

        public async Task<List<Car>> GetCarsByBrandIdAsync(Guid brandId)
        {
       
            return await _context.Cars
                                 .Include(c => c.Brand)
                                 .Where(c => c.BrandId == brandId)
                                 .ToListAsync();
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }
        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(5).ToList();
            return values;
        }
    }
}