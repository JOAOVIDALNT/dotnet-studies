using MyTable_API.Models;
using MyTable_API.Models.Dtos;

namespace MyTable_API.Repository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<User> Register(RegistrationRequestDTO registrationRequest);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);
    }
}
