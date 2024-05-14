using RendMyRide.Domain.Common;

namespace RendMyRide.Domain.Models
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
    }
}
