using RendMyRide.Domain.Interfaces.Repositories;
using RendMyRide.Domain.Models;

namespace RendMyRide.DataAccess.Repository
{
    public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(RendMyRideDbContext context) : base(context)
        {
        }
    }
}
