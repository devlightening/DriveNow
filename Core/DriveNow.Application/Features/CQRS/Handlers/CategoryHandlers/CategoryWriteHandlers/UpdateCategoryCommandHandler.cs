using DriveNow.Application.Features.CQRS.Commands.CategoryCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryWriteHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository)
    {
        public async Task<Category> Handle(UpdateCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.CategoryId);

            if (category == null)
            {
                return null;
            }

            category.CategoryName = command.CategoryName;

            return await _repository.UpdateAsync(category);
        }
    }
}