using DriveNow.Application.Features.Mediator.Commands.BannerCommands;
using DriveNow.Application.Features.Mediator.Commands.BannerCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BannerHandlers.BannerWriteHandlers
{
    public class RemoveBannerCommandHandler(IRepository<Banner> _repository) : IRequestHandler<RemoveBannerCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BannerId);

            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            return Unit.Value;
        }
    }
}