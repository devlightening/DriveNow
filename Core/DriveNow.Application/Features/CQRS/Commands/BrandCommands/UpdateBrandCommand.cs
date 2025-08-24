using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Commands.BrandCommands
{
    public class UpdateBrandCommand
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public UpdateBrandCommand(Guid brandId, string brandName)
        {
            BrandId = brandId;
            BrandName = brandName;
        }
    }
}
