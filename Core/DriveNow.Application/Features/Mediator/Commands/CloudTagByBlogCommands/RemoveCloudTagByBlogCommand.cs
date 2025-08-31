using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.CloudTagByBlogCommands
{
    public class RemoveCloudTagByBlogCommand:IRequest<Unit>
    {
        public RemoveCloudTagByBlogCommand(Guid cloudTagByBlogId)
        {
            CloudTagByBlogId = cloudTagByBlogId;
        }

        public Guid CloudTagByBlogId { get; set; }
     
    }
}
