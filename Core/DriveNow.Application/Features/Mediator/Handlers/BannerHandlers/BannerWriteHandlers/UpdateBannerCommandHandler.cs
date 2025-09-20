using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Features.Mediator.Commands.BannerCommands;
using DriveNow.Application.Features.Mediator.Commands.BannerCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BannerHandlers.BannerWriteHandlers
{
    public class UpdateBannerCommandHandler(IRepository<Banner> _repository) : IRequestHandler<UpdateBannerCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {

            var Banner = await _repository.GetByIdAsync(request.BannerId);


            if (Banner == null)
            {

                throw new Exception($"Banner with ID {request.BannerId} not found.");
            }


            Banner.Title = request.Title;
            Banner.Description = request.Description;
            Banner.VideoUrl = request.VideoUrl;
            Banner.VideoDescription = request.VideoDescription;



            await _repository.UpdateAsync(Banner);
            return Unit.Value;
        }
    }
}