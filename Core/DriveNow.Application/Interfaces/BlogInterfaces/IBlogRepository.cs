
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public Task<List<Blog>> GetLast3BlogWithAuthors();
        public Task<List<Blog>> GetAllBlogWithAuthors();
        public List<Blog> GetBlogByAuthorId(Guid id);

    }
}
