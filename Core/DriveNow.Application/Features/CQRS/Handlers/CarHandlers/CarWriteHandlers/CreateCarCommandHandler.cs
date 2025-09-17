using DriveNow.Application.Features.CQRS.Commands.CarCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarWriteHandlers
{
    public class CreateCarCommandHandler(IRepository<Car> _repository)
    {
        public async Task<Car> Handle(CreateCarCommand command)
        {
            var car = new Car
            {
                BrandId = command.BrandId,
                Model = command.Model,
                Kilometer = command.Kilometer,
                Seat = command.Seat,
                Luggage = command.Luggage,
                CoverImageUrl = command.CoverImageUrl,
                BigImageUrl = command.BigImageUrl,
                Transmission = command.Transmission,
                CarType = command.CarType,
                FuelType = command.FuelType,
                DriveType = command.DriveType,
                ModelYear=command.ModelYear,
                IsPublished = command.IsPublished

            };

            return await _repository.CreateAsync(car);
        }
    }
}