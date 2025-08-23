using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers
{
    public class UpdateAboutCommandHandler(IRepository<About> _repository)
    {
        public async Task<About> Handle(UpdateAboutCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AboutId);

            if (values == null)
            {

                return null;
            }

            values.Title = command.Title;
            values.Description = command.Description;
            values.ImageUrl = command.ImageUrl;


            return await _repository.UpdateAsync(values);
        }
    }
}