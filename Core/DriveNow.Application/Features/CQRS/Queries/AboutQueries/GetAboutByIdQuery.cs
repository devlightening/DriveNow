namespace DriveNow.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public Guid AboutId { get; set; }
        public GetAboutByIdQuery(Guid aboutId)
        {
            AboutId = aboutId;
        }
    }
}
