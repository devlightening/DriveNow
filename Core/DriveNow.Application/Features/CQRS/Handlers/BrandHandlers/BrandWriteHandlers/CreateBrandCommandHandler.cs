using DriveNow.Application.Features.CQRS.Commands.BrandCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandWriteHandlers
{
    public class CreateBrandCommandHandler(IRepository<Brand> repository)
    {
        public async Task<Brand> Handle(CreateBrandCommand command)
        {
            var brand = new Brand
            {
                BrandName = command.BrandName,
                LogoUrl = command.LogoUrl
            };
            return await repository.CreateAsync(brand);
        }
    }
}
