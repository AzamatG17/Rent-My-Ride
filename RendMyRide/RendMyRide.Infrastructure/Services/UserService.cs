using RendMyRide.Domain.Interfaces.Auth;
using RendMyRide.Domain.Interfaces.JwtTokenGenerate;
using RendMyRide.Domain.Interfaces.Repositories;
using RendMyRide.Domain.Models;

namespace RendMyRide.Infrastructure.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IPasswordHasher password, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = password;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string name, string lastName, string phone, string email, string password)
        {
            var passwordHash = _passwordHasher.Generate(password);

            await _userRepository.CreateAsync(name, lastName, phone, email, passwordHash);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
