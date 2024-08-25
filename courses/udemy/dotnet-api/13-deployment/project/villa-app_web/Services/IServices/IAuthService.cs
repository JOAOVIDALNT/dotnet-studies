using villa_app_web.Models.Dtos;

namespace villa_app_web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO registrationRequestDTO);
    }
}
