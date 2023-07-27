using MyTable_API.Models;

namespace MyTable_API.Repository
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<User> Login(User user);
    }
}
