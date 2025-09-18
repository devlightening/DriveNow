using DriveNow.Application.Features.CQRS.Queries.BrandQueries;
using DriveNow.Application.Features.CQRS.Results.BrandResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandReadHandlers
{
    public class GetBrandQueryHandler(IRepository<Brand> repository)
    {
        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery query)
        {
            var values = await repository.GetAllAsync();

            return values.Select(x => new GetBrandQueryResult(x.BrandId, x.BrandName,x.LogoUrl)).ToList();
        }
    }
}