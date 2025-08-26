using DriveNow.Application.Features.Mediator.Commands.SocialMediaCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.SocialMediaHandlers.SocialMediaWriteHandlers
{
    public class RemoveSocialMediaCommandHandler(IRepository<SocialMedia> _repository) : IRequestHandler<RemoveSocialMediaCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaId);
            if (value != null)
            {
                await _repository.RemoveAsync(value);   
            }
            return Unit.Value;   
        }
    }
}
