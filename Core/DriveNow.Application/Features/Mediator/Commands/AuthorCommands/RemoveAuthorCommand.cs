using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.AuthorCommands
{
    public class RemoveAuthorCommand : IRequest<Unit>
    {
        public Guid AuthorId { get; set; }

        public RemoveAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}