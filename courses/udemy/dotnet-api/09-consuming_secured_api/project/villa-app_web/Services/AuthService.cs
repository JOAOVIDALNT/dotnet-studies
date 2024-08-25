using villa_app_utility;
using villa_app_web.Models.Dtos;
using villa_app_web.Models.Entities;
using villa_app_web.Services.IServices;

namespace villa_app_web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaUrl;
        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        }

        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.POST,
                Data = loginRequestDTO,
                Url = villaUrl + "/api/auth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO registrationRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.POST,
                Data = registrationRequestDTO,
                Url = villaUrl + "/api/auth/register"
            });
        }
    }
}