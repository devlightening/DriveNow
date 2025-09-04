
using DriveNow.Application.Interfaces.CommentInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DriveNow.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository(DriveNowContext _context) : ICommentRepository
    {
        public async Task<Comment> GetByIdAsync(Guid id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<int> GetCommentCountByBlog(Guid id)
        {
            return await _context.Comments.Where(x => x.BlogId == id).CountAsync();
        }

        public async Task<List<Comment>> GetCommentsByBlogId(Guid id)
        {
            return await _context.Comments.Where(x => x.BlogId == id).ToListAsync();
        }
    }
}
