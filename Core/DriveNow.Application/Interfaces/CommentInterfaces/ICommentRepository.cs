
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Interfaces.CommentInterfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByBlogId(Guid id);
        Task<int> GetCommentCountByBlog(Guid id);
        Task<Comment> GetByIdAsync(Guid id);

    }
}
