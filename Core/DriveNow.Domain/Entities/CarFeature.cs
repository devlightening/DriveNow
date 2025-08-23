using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Entities
{
    public class CarFeature
    {
        public Guid CarFeatureId { get; set; }
        public Guid CarId { get; set; }
        public Guid FeatureId { get; set; }
        public Car Car { get; set; }
        public Feature Feature { get; set; }
        public bool IsAvailable { get; set; }
    }
}
