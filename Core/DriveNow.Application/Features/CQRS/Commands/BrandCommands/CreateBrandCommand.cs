using System;

namespace DriveNow.Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public string BrandName { get; }

        public CreateBrandCommand(string brandName)
        {
            BrandName = brandName;
        }
    }
}