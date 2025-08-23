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
    public class UpdateBannerCommandHandler(IRepository<Banner> _repository)
    {
        public async Task<Banner> Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BannerId);

            if (values == null)
            {

                return null;
            }
            values.Title = command.Title;
            values.Description = command.Description;
            values.VideoDescription = command.VideoDescription;
            values.VideoUrl = command.VideoUrl;

            return await _repository.UpdateAsync(values);
        }
    }
}
