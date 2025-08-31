using DriveNow.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.BlogContentCommands
{
    public class CreateBlogContentCommand : IRequest<Unit>
    {
        public Guid BlogId { get; set; }
        public string Content { get; set; }
        public BlogContentType ContentType { get; set; }
        public int Order { get; set; }
    }
}
