using RendMyRide.Domain.Common;
using RendMyRide.Domain.Models;

namespace RendMyRide.Domain.Interfaces.Repositories
{
    public interface IUserRepository<T> where T : EntityBase
    {
        Task CreateAsync(string name, string lastName, string phone, string email, string passwordHash);
        Task<User> GetByEmailAsync(string email);
    }
}
