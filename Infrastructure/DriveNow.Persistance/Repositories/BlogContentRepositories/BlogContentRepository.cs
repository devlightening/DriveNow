using DriveNow.Application.Interfaces.BlogContentInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Persistance.Repositories.BlogContentRepositories
{
    public class BlogContentRepository(DriveNowContext _context) : IBlogContentRepository
    {
        public async Task<List<BlogContent>> GetBlogContentsByBlogIdAsync(Guid blogId)
        {
            return await _context.BlogContents
                                 .Where(x => x.BlogId == blogId)
                                 .OrderBy(x => x.Order)
                                 .ToListAsync();
        }
    }
}
