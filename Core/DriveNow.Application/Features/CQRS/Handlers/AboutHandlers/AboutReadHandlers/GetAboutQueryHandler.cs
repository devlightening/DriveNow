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
    public class GetAboutQueryHandler(IRepository<About> _repository)
    {
        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
