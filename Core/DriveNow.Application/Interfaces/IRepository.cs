namespace DriveNow.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);


        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}