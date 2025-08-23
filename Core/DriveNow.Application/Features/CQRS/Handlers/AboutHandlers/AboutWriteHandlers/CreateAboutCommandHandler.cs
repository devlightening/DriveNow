using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers
{
    public class CreateAboutCommandHandler(IRepository<About> _repository)
    {

        public async Task<About> Handle(CreateAboutCommand command)
        {
            var about = new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            };
            

            return await _repository.CreateAsync(about);
        }
    }
}