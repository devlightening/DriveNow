using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.CommentCommands
{
    public class RemoveCommentCommand :IRequest<Unit>
    {
        public Guid CommentId { get; set; }

        public RemoveCommentCommand(Guid commentId)
        {
            CommentId = commentId;
        }
    }
}
