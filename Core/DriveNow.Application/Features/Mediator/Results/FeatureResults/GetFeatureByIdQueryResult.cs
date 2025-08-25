using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureByIdQueryResult
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }


        public GetFeatureByIdQueryResult(Guid featureId, string featureName)
        {
            FeatureId = featureId;
            FeatureName = featureName;
        }

    }
}
