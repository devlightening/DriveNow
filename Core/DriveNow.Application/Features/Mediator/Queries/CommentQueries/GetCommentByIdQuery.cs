using DriveNow.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByIdQuery :IRequest<GetCommentByIdQueryResult>
    {
        public GetCommentByIdQuery(Guid commentId)
        {
            CommentId = commentId;
        }
        public Guid CommentId { get; set; }
    }
}
