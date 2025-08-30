
namespace DriveNow.Application.Features.Mediator.Results.BlogResults
{
    public class GetAllBlogsWithAuthorQueryResult
    {
        public GetAllBlogsWithAuthorQueryResult(Guid blogId, Guid authorId, string title, string description, string authorName, string categoryName, string coverImageUrl, DateTime createdDate, Guid categoryId)
        {
            BlogId = blogId;
            AuthorId = authorId;
            Title = title;
            Description = description;
            AuthorName = authorName;
            CategoryName = categoryName;
            CoverImageUrl = coverImageUrl;
            CreatedDate = createdDate;
            CategoryId = categoryId;
        }

        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }


    }
}
