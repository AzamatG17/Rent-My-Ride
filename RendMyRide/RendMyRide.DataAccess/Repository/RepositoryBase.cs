using Microsoft.EntityFrameworkCore;
using RendMyRide.Domain.Common;
using RendMyRide.Domain.Interfaces.Repositories;

namespace RendMyRide.DataAccess.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly RendMyRideDbContext _context;

        public RepositoryBase(RendMyRideDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entity = await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>()
                .FindAsync(id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var createdEntity = await _context.Set<T>().AddAsync(entity);

            return createdEntity.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>()
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
