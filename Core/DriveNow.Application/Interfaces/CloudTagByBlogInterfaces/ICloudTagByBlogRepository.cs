
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Interfaces.CloudTagByBlogInterfaces
{
    public interface ICloudTagByBlogRepository
    {
        Task<List<CloudTagByBlog>> GetAllTagsAsync();
        Task<List<CloudTagByBlog>> GetTagsByBlogIdAsync(Guid blogId);
    }
}
