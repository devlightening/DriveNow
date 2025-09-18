using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public GetFeatureQueryResult(Guid featureId, string featureName, string ıconUrl)
        {
            FeatureId = featureId;
            FeatureName = featureName;
            IconUrl = ıconUrl;
        }

        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string IconUrl { get; set; }



       


    }
}
