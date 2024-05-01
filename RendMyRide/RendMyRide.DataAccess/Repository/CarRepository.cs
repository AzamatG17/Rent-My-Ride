using RendMyRide.Domain.Interfaces.Repositories;
using RendMyRide.Domain.Models;

namespace RendMyRide.DataAccess.Repository
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RendMyRideDbContext context) : base(context)
        {
        }
    }
}
