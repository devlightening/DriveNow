using DriveNow.Application.Interfaces.TagCloudInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DriveNow.Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepository(DriveNowContext _context) : ITagCloudRepository
    {
        public async Task<List<TagCloud>> GetAllTagCloudsAsync()
        {
            return await _context.TagClouds.ToListAsync();
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogIdAsync(Guid blogId)
        {
            var tags = await _context.TagClouds
                .Where(t => t.BlogId == blogId)
                .ToListAsync();

            return tags;
        }
    }
}