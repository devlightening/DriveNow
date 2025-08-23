using DriveNow.Application.Interfaces;
using DriveNow.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DriveNow.Persistance.Repositories
{
    public class Repository<T>(DriveNowContext _context) : IRepository<T> where T : class
    {

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
