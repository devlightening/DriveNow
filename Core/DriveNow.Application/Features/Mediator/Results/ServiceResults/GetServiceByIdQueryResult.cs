using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public GetServiceByIdQueryResult(Guid serviceId, string title, string description, string ıconUrl)
        {
            ServiceId = serviceId;
            Title = title;
            Description = description;
            IconUrl = ıconUrl;
        }

        public Guid ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
