using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using villa_app_api.Models.Dtos;
using villa_app_api.Repository.IRepository;
using villa_app_api.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace villa_app_api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/villa-number")]
    //[ApiVersion("1.0", Deprecated = true)] // DEPRECATED INDICARA NO HEADER DA REQUISIÇÃO QUE E VERSÃO ESTÁ DEPRECIADA
    [ApiVersion("1.0")]
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

        //[MapToApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {

            try
            {
                IEnumerable<VillaNumber> villaNumberList = await _repository.GetAllAsync(includeProperties: "Villa");
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var villaNumber = await _repository.GetAsync(x => x.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            {
                if (await _repository.GetAsync(x => x.VillaNo == createDTO.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa Number already exists");
                    return BadRequest(ModelState);
                }
                if (await _villaRepository.GetAsync(x => x.Id == createDTO.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is invalid");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(createDTO);
                }

                VillaNumber villaNumber = _mapper.Map<VillaNumber>(createDTO);

                villaNumber.CreatedDate = DateTime.Now;

                await _repository.CreateAsync(villaNumber);

                _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = villaNumber.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}", Name = "DeleteVillaNumber")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var villaNumber = await _repository.GetAsync(x => x.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.IsSuccess = false;
                    return NotFound();
                }

                await _repository.DeleteAsync(villaNumber);

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;


        }

        [HttpPut("{id}", Name = "UpdateVillaNumber")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.VillaNo)
                {
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                if (await _villaRepository.GetAsync(x => x.Id == updateDTO.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is invalid");
                    _response.IsSuccess = false;
                    return BadRequest(ModelState);
                }

                VillaNumber villaNumber = _mapper.Map<VillaNumber>(updateDTO);

                await _repository.UpdateAsync(villaNumber);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
