using DriveNow.Application.Interfaces.CarPricingInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;


namespace DriveNow.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository(DriveNowContext _context) : ICarPricingRepository
    {
        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            
            Guid dailyPricingId = Guid.Parse("b752e876-15fc-401e-a099-d8fa58890ee2");

            var values = await _context.CarPricings
                                       .Include(cp => cp.Car)
                                       .ThenInclude(c => c.Brand)
                                       .Include(cp => cp.Pricing)
                                       .Where(cp => cp.PricingId == dailyPricingId)
                                       .ToListAsync(); 

            return values;
        }
        public async Task<(List<CarPricing> Cars, int Count)> GetPublishedCarPricingWithCarsAndCount()
        {
            Guid dailyPricingId = Guid.Parse("b752e876-15fc-401e-a099-d8fa58890ee2");

            var cars = await _context.CarPricings
                                     .Include(cp => cp.Car)
                                     .ThenInclude(c => c.Brand)
                                     .Include(cp => cp.Pricing)
                                     .Where(cp => cp.PricingId == dailyPricingId && cp.Car.IsPublished)
                                     .ToListAsync();

            int count = await _context.CarPricings 
                                      .Include(cp => cp.Car) 
                                      .Where(cp => cp.PricingId == dailyPricingId && cp.Car.IsPublished)
                                      .CountAsync();

            return (cars, count);
        }
    }
}
