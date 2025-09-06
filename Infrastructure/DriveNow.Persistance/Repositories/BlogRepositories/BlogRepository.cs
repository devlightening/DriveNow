using DriveNow.Application.Interfaces.BlogInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DriveNow.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository(DriveNowContext _context) : IBlogRepository
    {
        public async Task<List<Blog>> GetAllBlogsWithCommentCountAsync()
        {
             return await _context.Blogs
            .Include(b => b.Comments) 
            .ToListAsync();
        }

        public async  Task<List<Blog>> GetAllBlogWithAuthors()
        {
            return await _context.Blogs
                                 .Include(x => x.Author)
                                 .Include(x => x.Category)
                                 .ToListAsync();
        }

        public async Task<Blog?> GetBlogByAuthorId(Guid id)
        {
            var value = await _context.Blogs
                                      .Include(x => x.Author)
                                      .FirstOrDefaultAsync(y => y.AuthorId == id);
            return value;
        }

        public async Task<Blog?> GetBlogBySlugAsync(string slug)
        {
            return await _context.Blogs
                .Include(b => b.Author) 
                .FirstOrDefaultAsync(b => b.Slug.ToLower() == slug.ToLower());
        }


        public async Task<List<Blog>> GetLast3BlogWithAuthors()
        {
            return await _context.Blogs
                  .Include(x => x.Author)
                  .OrderByDescending(x => x.BlogId)
                  .Take(3)
                  .ToListAsync();
        }
    }
}
