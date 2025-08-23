using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Features.CQRS.Commands.BannerCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.BannerHandlers.BannerWriteHandlers
{
    public class CreateBannerCommandHandler(IRepository<Banner> _repository)
    {
        public async Task<Banner> Handle(CreateBannerCommand command)
        {
            var banner = new Banner
            {
                Title = command.Title,
                Description = command.Description,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl

            };
            return await _repository.CreateAsync(banner);
        }
    }
}
