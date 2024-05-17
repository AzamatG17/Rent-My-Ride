namespace RendMyRide.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);
        Task Register(string name, string lastName, string phone, string email, string password);
    }
}
