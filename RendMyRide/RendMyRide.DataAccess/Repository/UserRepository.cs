using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RendMyRide.Domain.Interfaces.Auth;
using RendMyRide.Domain.Interfaces.Repositories;
using RendMyRide.Domain.Models;

namespace RendMyRide.DataAccess.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly RendMyRideDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(RendMyRideDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(string name, string lastName, string phone, string email, string passwordHash)
        {
            var userEntity = new User
            {
                UserName = name,
                UserLastName = lastName,
                Email = email,
                Phone = phone,
                PasswordHash = passwordHash,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }
    }
}
