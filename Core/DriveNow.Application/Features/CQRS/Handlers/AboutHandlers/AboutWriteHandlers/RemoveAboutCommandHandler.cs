using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers
{
    public class RemoveAboutCommandHandler(IRepository<About> _repository)
    {
        public async Task Handle(RemoveAboutCommand command)
        {
            var about = await _repository.GetByIdAsync(command.AboutId);
            if (about != null)
            {
                await _repository.RemoveAsync(about);
            }
        }
    }
}
