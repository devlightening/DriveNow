using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Entities
{
    public class Feature
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }
        public List<CarFeature> CarFeatures { get; set; }


    }
}
