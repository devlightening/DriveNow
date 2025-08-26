using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand : IRequest<Unit>
    {
        public RemoveTestimonialCommand(Guid testimonialId)
        {
            TestimonialId = testimonialId;
        }

        public Guid TestimonialId { get; set; }

    }
}
