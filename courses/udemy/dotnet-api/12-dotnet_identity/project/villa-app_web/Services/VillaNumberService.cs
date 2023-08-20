using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using villa_app_utility;
using villa_app_web.Models.Entities;
using villa_app_web.Models.Dtos;
using villa_app_web.Services.IServices;
using Newtonsoft.Json.Linq;

namespace villa_app_web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaUrl;
        public VillaNumberService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        }
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.POST,
                Data = dto,
                Url = villaUrl+ "/api/v1/villa-number/",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.DELETE,
                Url = villaUrl + "/api/v1/villa-number/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.GET,
                Url = villaUrl + "/api/v1/villa-number/",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.GET,
                Url = villaUrl + "/api/v1/villa-number/" +id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/v1/villa-number/" + dto.VillaNo,
                Token = token
            });
        }
    }
}
