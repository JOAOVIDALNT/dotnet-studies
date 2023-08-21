using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using villa_app_api.Models.Dtos;
using villa_app_api.Repository.IRepository;
using villa_app_api.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace villa_app_api.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/villa-number")]
    [ApiVersion("2.0")]
    public class VillaNumberController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepository _repository;
        private readonly IMapper _mapper;
        private readonly IVillaRepository _villaRepository;

        public VillaNumberController(IVillaNumberRepository repository, IMapper mapper, IVillaRepository villaRepository)
        {
            _villaRepository = villaRepository;
            _repository = repository;
            _mapper = mapper;
            _response = new();
        }

        //[MapToApiVersion("2.0")] // -> NÃO PRECISA POIS O CONTRLLER AGORA É APENAS PARA O V2
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "velue1", "value2" };
        }

    }
}
