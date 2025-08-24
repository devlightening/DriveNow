using DriveNow.Application.Features.CQRS.Commands.CategoryCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryWriteHandlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> _repository)
    {
        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.CategoryId);
            if (category != null)
            {
                await _repository.RemoveAsync(category);
            }
        }

    }
}
