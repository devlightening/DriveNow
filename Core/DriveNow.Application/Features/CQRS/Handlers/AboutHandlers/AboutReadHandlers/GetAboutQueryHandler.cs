using DriveNow.Application.Features.CQRS.Queries.AboutQueries;
using DriveNow.Application.Features.CQRS.Results.AboutResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutReadHandlers
{
    public class GetAboutQueryHandler(IRepository<About> _repository)
    {
        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery query)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetAboutQueryResult(
                x.AboutId,
                x.Title,
                x.Description,
                x.ImageUrl
            )).ToList();
        }
    }
}