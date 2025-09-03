namespace DriveNow.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T, in TKey> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}