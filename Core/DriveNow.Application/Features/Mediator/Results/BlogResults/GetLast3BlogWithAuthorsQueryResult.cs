
namespace DriveNow.Application.Features.Mediator.Results.BlogResults
{
    public class GetLast3BlogWithAuthorsQueryResult
    {
       

        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }

        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public string AuthorName { get; set; }

    }
}
