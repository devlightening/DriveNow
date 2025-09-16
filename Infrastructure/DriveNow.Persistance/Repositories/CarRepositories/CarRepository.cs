using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DriveNow.Persistance.Repositories.CarRepositories
{
    public class CarRepository(DriveNowContext _context) : ICarRepository
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

        public async Task<List<Car>> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }
        public async Task<List<Car>> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(5).ToList();
            return values;
        }

        public async Task<List<Car>> GetPublishedCars(bool isPublished)
        {
            return await _context.Cars.Where(x => x.IsPublished == isPublished).ToListAsync();
        }

        public async Task<Car> GetByIdAsync(Guid id)
        {

            return await _context.Set<Car>().FindAsync(id);
        }

        public async Task<Car> UpdateAsync(Car car)
        {
            _context.Set<Car>().Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}