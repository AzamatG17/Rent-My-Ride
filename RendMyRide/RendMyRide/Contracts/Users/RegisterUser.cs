using System.ComponentModel.DataAnnotations;

namespace RendMyRide.Contracts.Users
{
    public record RegisterUser(
        [Required] string UserName,
        [Required] string UserLastName,
        [Required] string Email,
        [Required] string Phone,
        [Required] string Password);
}
