using DriveNow.Application.Features.CQRS.Queries.AboutQueries;
using DriveNow.Application.Features.CQRS.Results.AboutResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutReadHandlers
{
    public class GetAboutByIdQueryHandler(IRepository<About> _repository)
    {
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.AboutId);        
            return new GetAboutByIdQueryResult
            {
                AboutId = value.AboutId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
        }

    }
}
