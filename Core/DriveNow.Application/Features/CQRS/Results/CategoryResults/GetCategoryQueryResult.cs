using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public GetCategoryQueryResult(Guid categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }
}