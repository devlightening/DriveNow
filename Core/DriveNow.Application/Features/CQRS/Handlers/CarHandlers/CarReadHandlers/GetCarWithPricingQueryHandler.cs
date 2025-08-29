using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarWithPricingQueryHandler(ICarRepository _repository)
    {
        public async Task<List<GetCarWithPricingQueryResult>> Handle()
        {
            var values = await _repository.GetCarsWithPricings();
            return values.SelectMany(car => car.CarPricings.Select(pricing => new GetCarWithPricingQueryResult(
                             car.CarId,
                             car.BrandId,
                             car.Model,
                             car.Kilometer,
                             car.Seat,
                             car.Luggage,
                             car.CoverImageUrl,
                             car.BigImageUrl,
                             car.ModelYear,
                             car.Transmission,
                             car.CarType,
                             car.FuelType,
                             car.DriveType,
                             car.Brand.BrandName,
                             pricing.Pricing.PricingName,
                             pricing.Price
                           ))).ToList();
        }
    }
}