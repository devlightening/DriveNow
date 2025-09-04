using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.CommentCommands
{
    public class UpdateCommentCommand:IRequest<Unit>
    {
        public Guid CommentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid BlogId { get; set; }
    }
}
