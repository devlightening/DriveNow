using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers
{
    public class CreateAboutCommandHandler(IRepository<About> _repository)
    {
        public async Task Handle(CreateAboutCommand command)
        {
            await _repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl

            });
        }
    }
}
