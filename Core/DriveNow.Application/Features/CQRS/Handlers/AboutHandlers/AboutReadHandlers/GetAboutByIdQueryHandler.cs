using DriveNow.Application.Features.CQRS.Queries.AboutQueries;
using DriveNow.Application.Features.CQRS.Results.AboutResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutReadHandlers
{
    public class GetAboutByIdQueryHandler(IRepository<About> _repository)
    {
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.AboutId);

            if (value == null)
            {
                return null;
            }

            return new GetAboutByIdQueryResult(
                value.AboutId,
                value.Title,
                value.Description,
                value.ImageUrl
            );
        }
    }
}