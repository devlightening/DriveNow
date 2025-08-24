using DriveNow.Application.Features.CQRS.Commands.CarCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarWriteHandlers
{
    public class UpdateCarCommandHandler(IRepository<Car> _repository)
    {
        public async Task<Car> Handle(UpdateCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.CarId);

            if (car == null)
            {
                return null;
            }

            car.BrandId = command.BrandId;
            car.Model = command.Model;
            car.Kilometer = command.Kilometer;
            car.Seat = command.Seat;
            car.Luggage = command.Luggage;
            car.CoverImageUrl = command.CoverImageUrl;
            car.BigImageUrl = command.BigImageUrl;
            car.Transmission = command.Transmission;
            car.CarType = command.CarType;
            car.FuelType = command.FuelType;
            car.DriveType = command.DriveType;

            return await _repository.UpdateAsync(car);
        }
    }
}