using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.CloudTagByBlogCommands
{
    public  class UpdateCloudTagByBlogCommand:IRequest<Unit>
    {
        public Guid CloudTagByBlogId { get; set; }
        public string TagName { get; set; }

    }
}
