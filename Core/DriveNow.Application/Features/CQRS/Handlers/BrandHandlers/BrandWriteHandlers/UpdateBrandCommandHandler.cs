using DriveNow.Application.Features.CQRS.Commands.BrandCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandWriteHandlers
{
    public class UpdateBrandCommandHandler(IRepository<Brand> _repository)
    {
        public async Task<Brand> Handle(UpdateBrandCommand command)
        {
            var brand = await _repository.GetByIdAsync(command.BrandId);

            if (brand == null)
            {
                return null;
            }

            brand.BrandName = command.BrandName;

            return await _repository.UpdateAsync(brand);
        }
    }
}