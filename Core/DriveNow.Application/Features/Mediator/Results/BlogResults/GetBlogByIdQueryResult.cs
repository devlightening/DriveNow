using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogByIdQueryResult
    {
        public GetBlogByIdQueryResult(Guid blogId, Guid authorId, string title, string coverImageUrl, DateTime createdDate, Guid categoryId)
        {
            BlogId = blogId;
            AuthorId = authorId;
            Title = title;
            CoverImageUrl = coverImageUrl;
            CreatedDate = createdDate;
            CategoryId = categoryId;
        }

        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }
        
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        // public Category Category { get; set; }
        //public Author Author { get; set; }
    }
}
