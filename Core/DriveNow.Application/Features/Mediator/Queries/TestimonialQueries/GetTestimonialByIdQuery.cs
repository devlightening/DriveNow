using DriveNow.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
    {
        public Guid TestimonailId { get; set; }

        public GetTestimonialByIdQuery(Guid testimonailId)
        {
            TestimonailId = testimonailId;
        }
    }
}
