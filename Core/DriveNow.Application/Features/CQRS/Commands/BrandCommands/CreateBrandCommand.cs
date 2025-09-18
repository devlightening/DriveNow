using System;

namespace DriveNow.Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public CreateBrandCommand(string brandName, string logoUrl)
        {
            BrandName = brandName;
            LogoUrl = logoUrl;
        }

        public string BrandName { get; }
        public string LogoUrl { get; set; }


    
    }
}