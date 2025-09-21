using MediatR;
using System;


namespace DriveNow.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand:IRequest<Unit>
    { 
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public int CommentCount { get; set; } = 0;
        public bool? IsPublished { get; set; }
    }
}
