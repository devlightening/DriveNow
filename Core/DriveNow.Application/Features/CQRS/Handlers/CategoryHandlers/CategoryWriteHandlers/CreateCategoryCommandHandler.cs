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
    public class CreateCategoryCommandHandler(IRepository<Category> _repository)
    {
        public async Task<Category> Handle(CreateCategoryCommand command)
        {
            var category = new Category
            {
                CategoryName = command.CategoryName
            };
            return await _repository.CreateAsync(category);
        }
    }
}
