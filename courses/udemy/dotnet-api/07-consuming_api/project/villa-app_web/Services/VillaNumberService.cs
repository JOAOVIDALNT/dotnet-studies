using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using villa_app_utility;
using villa_app_web.Models;
using villa_app_web.Models.dto;
using villa_app_web.Services.IServices;

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
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.POST,
                Data = dto,
                Url = villaUrl+ "/api/villa-number/"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.DELETE,
                Url = villaUrl + "/api/villa-number/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.GET,
                Url = villaUrl + "/api/villa-number/"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.GET,
                Url = villaUrl + "/api/villa-number/" +id
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Details.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/villa-number/" + dto.VillaNo
            });
        }
    }
}
