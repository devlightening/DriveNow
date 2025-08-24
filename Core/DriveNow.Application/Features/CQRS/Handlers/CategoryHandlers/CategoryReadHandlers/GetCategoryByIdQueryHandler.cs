using DriveNow.Application.Features.CQRS.Queries.CategoryQueries;
using DriveNow.Application.Features.CQRS.Results.CategoryResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryReadHandlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> _repository)
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.CategoryId);

            if (value == null)
            {
                return null;
            }

            return new GetCategoryByIdQueryResult(
                value.CategoryId,
                value.CategoryName
            );
        }
    }
}