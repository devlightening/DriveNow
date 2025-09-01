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
            var tags = await _context.BlogCloudTagByBlogs // Ara tablo üzerinden sorgulayın
                .Include(bt => bt.CloudTagByBlog) // Ara tablo üzerinden etiket entity'sine erişin
                .Where(bt => bt.BlogId == blogId) // Belirli blog ID'sine göre filtreleyin
                .Select(bt => bt.CloudTagByBlog) // Sadece etiketleri seçin
                .ToListAsync();

            return tags;
        }
    }
}