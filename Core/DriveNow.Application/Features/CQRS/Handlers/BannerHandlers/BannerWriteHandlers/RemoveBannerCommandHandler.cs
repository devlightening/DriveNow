using DriveNow.Application.Features.CQRS.Commands.BannerCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.BannerHandlers.BannerWriteHandlers
{
    public class RemoveBannerCommandHandler(IRepository<Banner> _repository)
    {
        public async Task Handle(RemoveBannerCommand command)
        {
            var banner = await _repository.GetByIdAsync(command.BannerId);
            if (banner != null)
            {
                await _repository.RemoveAsync(banner);
            }
        }
    }
}
