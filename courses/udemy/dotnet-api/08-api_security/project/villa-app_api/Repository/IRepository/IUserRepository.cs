using villa_app_api.Models.Dtos;
using villa_app_api.Models.Entities;

namespace villa_app_api.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
