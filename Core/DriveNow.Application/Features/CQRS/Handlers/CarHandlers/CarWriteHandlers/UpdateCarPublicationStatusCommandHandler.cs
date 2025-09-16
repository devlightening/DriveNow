using MediatR;
using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Application.Features.CQRS.Commands.CarCommands;
using DriveNow.Application.Features.CQRS.Results.CarResults;

public class UpdateCarPublicationStatusCommandHandler(ICarRepository carRepository)
        : IRequestHandler<UpdateCarPublicationStatusCommand, UpdateCarPublicationStatusResult>
{
    public async Task<UpdateCarPublicationStatusResult> Handle(UpdateCarPublicationStatusCommand request, CancellationToken cancellationToken)
    {
        // Önce aracı bul
        var car = await carRepository.GetByIdAsync(request.CarId);

        if (car == null)
        {
            return new UpdateCarPublicationStatusResult { Success = false, Message = "Car not found." };
        }

        car.IsPublished = request.IsPublished;

        try
        {
            await carRepository.UpdateAsync(car);
            return new UpdateCarPublicationStatusResult { Success = true, Message = "Car status updated successfully." };
        }
        catch (Exception ex)
        {
            // Hata olursa loglama yapılabilir
            return new UpdateCarPublicationStatusResult { Success = false, Message = $"Database error: {ex.Message}" };
        }
    }
}
