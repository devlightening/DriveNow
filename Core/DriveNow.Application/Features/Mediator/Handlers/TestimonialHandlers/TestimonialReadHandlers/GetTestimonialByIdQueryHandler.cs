using DriveNow.Application.Features.Mediator.Queries.TestimonialQueries;
using DriveNow.Application.Features.Mediator.Results.TestimonialResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.TestimonialHandlers.TestimonialReadHandlers
{
    public class GetTestimonialByIdQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonailId);
            if (value == null)
            {
                return null;
            }
            return new GetTestimonialByIdQueryResult(value.TestimonialId, value.TestimonialName, value.Title, value.Comment,value.ImageUrl);


        }
    }
}
