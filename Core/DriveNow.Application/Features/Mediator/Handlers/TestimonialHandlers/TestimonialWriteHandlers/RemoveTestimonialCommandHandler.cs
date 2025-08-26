using DriveNow.Application.Features.Mediator.Commands.TestimonialCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.TestimonialHandlers.TestimonialWriteHandlers
{
    public class RemoveTestimonialCommandHandler(IRepository<Testimonial> _repository) : IRequestHandler<RemoveTestimonialCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            if(value != null)
            {
                await _repository.RemoveAsync(value);

            }
            return Unit.Value;

           
        }
    }
}
