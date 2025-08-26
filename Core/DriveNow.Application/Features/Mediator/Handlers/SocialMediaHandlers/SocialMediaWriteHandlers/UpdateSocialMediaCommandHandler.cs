using DriveNow.Application.Features.Mediator.Commands.SocialMediaCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.SocialMediaHandlers.SocialMediaWriteHandlers
{
    public class UpdateSocialMediaCommandHandler(IRepository<SocialMedia> _repository) : IRequestHandler<UpdateSocialMediaCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaId);
            if (value != null)
            {
                value.SocialMediaName = request.SocialMediaName;
                value.SocialMediaUrl = request.SocialMediaUrl;
                value.IconUrl = request.IconUrl;

                await _repository.UpdateAsync(value);
            }
            return Unit.Value;
        }
    }
}
