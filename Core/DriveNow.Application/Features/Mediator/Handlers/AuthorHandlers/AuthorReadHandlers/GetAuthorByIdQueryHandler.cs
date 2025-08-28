using DriveNow.Application.Features.Mediator.Queries.AuthorQueries;
using DriveNow.Application.Features.Mediator.Results.AuthorResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorReadHandlers
{
    public class GetAuthorByIdQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {

            var author = await _repository.GetByIdAsync(request.AuthorId);


            if (author == null)
            {

                return null;
            }


            return new GetAuthorByIdQueryResult(author.AuthorId,author.AuthorName,author.Description,author.ImageUrl);
        }
    }
}