using DriveNow.Application.Features.Mediator.Queries.TestimonialQueries;
using DriveNow.Application.Features.Mediator.Results.SocialMediaResults;
using DriveNow.Application.Features.Mediator.Results.TestimonialResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.TestimonialHandlers.TestimonialReadHandlers
{
    public class GetTestimonialQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {

            var value = await _repository.GetAllAsync();
            return value.Select(s => new GetTestimonialQueryResult(s.TestimonialId,s.TestimonialName,s.Title,s.Comment,s.ImageUrl)).ToList();

        }
    }
}
