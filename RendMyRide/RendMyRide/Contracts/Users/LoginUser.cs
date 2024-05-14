using System.ComponentModel.DataAnnotations;

namespace RendMyRide.Contracts.Users
{
    public record LoginUser(
        [Required] string Email,
        [Required] string Password);
}
