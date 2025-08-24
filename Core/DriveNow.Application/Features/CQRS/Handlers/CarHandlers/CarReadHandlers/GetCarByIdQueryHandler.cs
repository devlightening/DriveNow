using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarByIdQueryHandler(IRepository<Car> _repository)
    {
        public async Task<Car> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
            {
                return null;
            }

            return value;
        }
    }
}