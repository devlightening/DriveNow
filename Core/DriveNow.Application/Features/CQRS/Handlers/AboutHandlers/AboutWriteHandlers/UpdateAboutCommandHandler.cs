using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers
{
    public class UpdateAboutCommandHandler(IRepository<About> _repository)
    {
        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AboutId);
            if (values != null)
            {
                values.Title = command.Title;
                values.Description = command.Description;
                values.ImageUrl = command.ImageUrl;
                await _repository.UpdateAsync(values);
            }
        }

    }
}
