using DriveNow.Application.Interfaces.CarPricingInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository(DriveNowContext _context) : ICarPricingRepository
    {
        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
         
            var values = await _context.CarPricings
                                       .Include(cp => cp.Car)
                                       .ThenInclude(c => c.Brand)
                                       .Include(cp => cp.Pricing)
                                       .ToListAsync();
            return values;
        }
    }
}
