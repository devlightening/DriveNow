using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public Guid AboutId { get; set; }
        public GetAboutByIdQuery(Guid aboutId)
        {
            AboutId = aboutId;
        }
    }
}
