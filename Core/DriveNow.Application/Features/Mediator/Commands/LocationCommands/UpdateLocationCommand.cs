using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.LocationCommands
{
    public class UpdateLocationCommand : IRequest<Unit>
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }

    }
}
