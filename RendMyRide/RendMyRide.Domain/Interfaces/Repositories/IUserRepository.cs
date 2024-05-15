using RendMyRide.Domain.Common;
using RendMyRide.Domain.Models;

namespace RendMyRide.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task CreateAsync(string name, string lastName, string phone, string email, string passwordHash);
        Task<User> GetByEmailAsync(string email);
    }
}
