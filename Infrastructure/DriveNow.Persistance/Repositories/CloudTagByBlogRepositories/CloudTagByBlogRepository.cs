using DriveNow.Application.Interfaces.CloudTagByBlogInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DriveNow.Persistance.Repositories.CloudTagByBlogRepositories
{
    public class CloudTagByBlogRepository(DriveNowContext _context) : ICloudTagByBlogRepository
    {
     
        public async Task<List<CloudTagByBlog>> GetAllTagsAsync()
        {
   
            return await _context.CloudTagByBlogs.ToListAsync();
        }

        public async Task<List<CloudTagByBlog>> GetTagsByBlogIdAsync(Guid blogId)
        {
           
            var blogWithTags = await _context.Blogs
                .Include(b => b.CloudTagByBlogs)
                .FirstOrDefaultAsync(b => b.BlogId == blogId);

            
            return blogWithTags?.CloudTagByBlogs.ToList() ?? new List<CloudTagByBlog>();
        }
    }
}