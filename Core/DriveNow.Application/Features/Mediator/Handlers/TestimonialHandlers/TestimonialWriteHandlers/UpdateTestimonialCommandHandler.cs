using DriveNow.Application.Features.Mediator.Commands.TestimonialCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.TestimonialHandlers.TestimonialWriteHandlers
{

    public class UpdateTestimonialCommandHandler(IRepository<Testimonial> _repository) : IRequestHandler<UpdateTestimonialCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            if (value != null)
            {
                value.TestimonialName = request.TestimonialName;
                value.Comment = request.Comment;
                value.Title= request.Title;
                value.ImageUrl = request.ImageUrl;

                await _repository.UpdateAsync(value);
            }
            return Unit.Value;
        }
    }
}
