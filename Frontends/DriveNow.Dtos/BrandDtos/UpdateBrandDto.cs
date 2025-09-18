using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.BrandDtos
{
    public class UpdateBrandDto
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string LogoUrl { get; set; }

    }
}
