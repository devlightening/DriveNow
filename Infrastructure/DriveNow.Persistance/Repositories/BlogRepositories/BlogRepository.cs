using DriveNow.Application.Interfaces.BlogInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DriveNow.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository(DriveNowContext _context) : IBlogRepository
    {
        public async  Task<List<Blog>> GetAllBlogWithAuthors()
        {
            return await _context.Blogs
                                 .Include(x => x.Author)
                                 .Include(x => x.Category)
                                 .ToListAsync();
        }

        public async Task<List<Blog>> GetLast3BlogWithAuthors()
        {
            return _context.Blogs
                  .Include(x => x.Author)
                  .OrderByDescending(x => x.BlogId)
                  .Take(3)
                  .ToList();
        }
    }
}
