using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.TagCloudDtos
{
    public class UpdateTagCloudDto
    {
        public Guid TagCloudId { get; set; }
        public string TagCloudName { get; set; }
        public Guid BlogId { get; set; }
    }
}
