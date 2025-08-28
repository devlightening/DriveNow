using DriveNow.Application.Features.Mediator.Queries.AuthorQueries;
using DriveNow.Application.Features.Mediator.Results.AuthorResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorReadHandlers
{
    public class GetAuthorQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var Authors = await _repository.GetAllAsync();
            return Authors.Select(f => new GetAuthorQueryResult(f.AuthorId, f.AuthorName, f.ImageUrl,f.Description)).ToList();
        }
    }
}
