using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public Guid FeatureId { get; set; }
        public string  FeatureName { get; set; }
        public string IconUrl { get; set; }

    }
}
