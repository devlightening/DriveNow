using DriveNow.Application.Features.Mediator.Commands.SocialMediaCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.SocialMediaHandlers.SocialMediaWriteHandlers
{
    public class CreateSocialMediaCommandHandler(IRepository<SocialMedia> _repository) : IRequestHandler<CreateSocialMediaCommand, Unit>
    {
        public async Task<Unit> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = new SocialMedia
            {
                SocialMediaName= request.SocialMediaName,
                SocialMediaUrl= request.SocialMediaUrl,
                IconUrl= request.IconUrl,
            };
            await _repository.CreateAsync(values);
            return Unit.Value;

           
        }
    }
}
