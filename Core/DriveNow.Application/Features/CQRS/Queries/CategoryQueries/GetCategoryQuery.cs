using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryQuery
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public GetCategoryQuery(Guid categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public GetCategoryQuery()
        {
        }

    }
}
