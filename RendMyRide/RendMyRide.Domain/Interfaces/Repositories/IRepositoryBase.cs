using RendMyRide.Domain.Common;

namespace RendMyRide.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
