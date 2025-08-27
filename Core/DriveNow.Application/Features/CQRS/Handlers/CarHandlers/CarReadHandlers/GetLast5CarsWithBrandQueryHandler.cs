using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces.CarInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetLast5CarsWithBrandQueryHandler(ICarRepository _repository)
    {
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values =await  _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult(
                x.CarId,
                x.BrandId,
                x.Brand.BrandName, 
                x.Model,
                x.Kilometer,     
                x.Seat,
                x.Luggage,
                x.CoverImageUrl,
                x.BigImageUrl,
                x.Transmission,
                x.CarType,
                x.FuelType,     
                x.DriveType,
                x.ModelYear
            )).ToList();
        }
    }
}