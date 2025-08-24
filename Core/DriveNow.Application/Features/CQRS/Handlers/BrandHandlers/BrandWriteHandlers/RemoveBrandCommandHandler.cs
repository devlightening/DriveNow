using DriveNow.Application.Features.CQRS.Commands.BrandCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandWriteHandlers
{
    public class RemoveBrandCommandHandler(IRepository<Brand> _repository)
    {
        public async Task Handle(RemoveBrandCommand command)
        {
            var brand = await _repository.GetByIdAsync(command.BrandId);
            if (brand != null)
            {
                await _repository.RemoveAsync(brand);
            }
        }
    }
}
