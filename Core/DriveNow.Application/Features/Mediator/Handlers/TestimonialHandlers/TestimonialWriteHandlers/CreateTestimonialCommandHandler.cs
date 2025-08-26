using DriveNow.Application.Features.Mediator.Commands.TestimonialCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.TestimonialHandlers.TestimonialWriteHandlers
{
    public class CreateTestimonialCommandHandler(IRepository<Testimonial> _repository) : IRequestHandler<CreateTestimonialCommand, Unit>
    {
        public async Task<Unit> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = new Testimonial
            {
               TestimonialName=request.TestimonialName,
               Title=request.Title,
               Comment=request.Comment,
               ImageUrl=request.ImageUrl
            };
            await _repository.CreateAsync(value);
            return Unit.Value;
            
        }
    }


}
