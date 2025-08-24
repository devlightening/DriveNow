using DriveNow.Application.Features.CQRS.Commands.CarCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarWriteHandlers
{
    public class RemoveCarCommandHandler(IRepository<Car> _repository)
    {
        public async Task Handle(RemoveCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.Id);
            if (car != null)
            {
                await _repository.RemoveAsync(car);
            }
        }
    }
}