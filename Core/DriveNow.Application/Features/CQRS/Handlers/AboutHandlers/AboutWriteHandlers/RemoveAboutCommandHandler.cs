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
