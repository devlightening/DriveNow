namespace DriveNow.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery
    {
        public Guid Id { get; set; }

        public GetCarByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}