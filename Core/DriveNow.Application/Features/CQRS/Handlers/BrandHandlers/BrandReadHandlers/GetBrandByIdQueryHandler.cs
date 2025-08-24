using DriveNow.Application.Features.CQRS.Queries.BrandQueries;
using DriveNow.Application.Features.CQRS.Results.BrandResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandReadHandlers
{
    public class GetBrandByIdQueryHandler(IRepository<Brand> _repository)
    {
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.BrandId);

            if (value == null)
            {
                return null;
            }

            return new GetBrandByIdQueryResult(value.BrandId, value.BrandName);
        }
    }
}