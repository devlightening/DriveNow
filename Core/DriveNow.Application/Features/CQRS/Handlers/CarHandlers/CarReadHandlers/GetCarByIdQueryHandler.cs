using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarByIdQueryHandler(IRepository<Car> _repository)
    {
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
            {
                return null;
            }

     
            return new GetCarByIdQueryResult(
                value.CarId,
                value.BrandId,
                value.Model,
                value.Kilometer,
                value.Seat,
                value.Luggage,
                value.CoverImageUrl,
                value.BigImageUrl,
                value.Transmission,
                value.CarType,
                value.FuelType,
                value.DriveType
            );
        }
    }
}