
namespace DriveNow.Application.Features.CQRS.Queries.CarQueries
{
    public class GetPublishedCarsQuery 
    {
        public GetPublishedCarsQuery(bool ısPublished)
        {
            IsPublished = ısPublished;
        }

        public bool IsPublished { get; set; } = true;

        
    }
}
