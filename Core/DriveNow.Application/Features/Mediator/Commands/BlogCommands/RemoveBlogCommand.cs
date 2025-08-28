using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand : IRequest<Unit>
    {
        public RemoveBlogCommand(Guid blogId)
        {
            BlogId = blogId;
        }

        public Guid BlogId { get; set; }
       
    }
}
