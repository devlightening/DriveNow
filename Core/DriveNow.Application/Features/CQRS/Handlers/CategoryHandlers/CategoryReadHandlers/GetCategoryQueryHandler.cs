using DriveNow.Application.Features.CQRS.Queries.CategoryQueries;
using DriveNow.Application.Features.CQRS.Results.CategoryResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryReadHandlers
{
    public class GetCategoryQueryHandler(IRepository<Category> _repository)
    {
        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery query)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetCategoryQueryResult(
                z.CategoryId,
                z.CategoryName
            )).ToList();
        }
    }
}