using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }


        public GetFeatureQueryResult(Guid featureId, string featureName)
        {
            FeatureId = featureId;
            FeatureName = featureName;
        }


    }
}
