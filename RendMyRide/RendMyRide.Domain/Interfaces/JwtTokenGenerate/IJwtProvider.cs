using RendMyRide.Domain.Models;

namespace RendMyRide.Domain.Interfaces.JwtTokenGenerate
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
