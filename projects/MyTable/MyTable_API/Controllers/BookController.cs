using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTable_API.Models;
using MyTable_API.Models.Dtos;
using MyTable_API.Repository;

namespace MyTable_API.Controllers
{
    [ApiController]
    [Route("api/v1/my-table")]
    public class BookController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository repository, IMapper mapper)
        {                           
            _repository = repository;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetBooks()
        {
            try
            {
                IEnumerable<Book> bookList = await _repository.GetAllAsync();

                if (!bookList.Any())
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string> { "No books yet" };
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<List<BookDTO>>(bookList);
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

        [HttpGet("{id:int}", Name = "GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetBook(int id)
        {
            try
            {
                var entity = await _repository.GetAsync(x => x.Id == id);

                if (entity == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string> { $"Nenhum livro encontrado com o id: {id}" };
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<BookDTO>(entity);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateBook([FromBody] BookCreateDTO bookDTO)
        {
            try
            {
                if (await _repository
                        .GetAsync(x => x.Title.ToUpper() == bookDTO.Title.ToUpper()) != null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { $"Book with title '{bookDTO.Title}' already exists" };
                    return BadRequest(_response);
                }
                
                Book book = _mapper.Map<Book>(bookDTO);
                await _repository.CreateAsync(book);

                _response.Result = _mapper.Map<BookDTO>(book);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetBook", new { id = book.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateBook(int id, [FromBody] BookCreateDTO createDTO)
        {
            try
            {
                var entity = await _repository.GetAsync(x => x.Id == id);
            
                if (entity == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>{ $"Nenhum livro encontrado com o id: {id}" };
                    return NotFound(_response);
                }

                entity.Title = createDTO.Title;
                entity.Author = createDTO.Author;
                entity.Genre = createDTO.Genre;
                entity.Pages = createDTO.Pages;
                entity.UpdatedAt = DateTime.Now;

                await _repository.UpdateAsync(entity);

                _response.Result = _mapper.Map<BookDTO>(entity);
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


        [HttpDelete("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteBook(int id)
        {
            try
            {
                var entity = await _repository.GetAsync(x => x.Id == id);

                if (entity == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string> { $"Nenhum livro encontrado com o id: {id}" };
                    return NotFound(_response);
                }

                await _repository.DeleteAsync(entity);

                _response.Result = _mapper.Map<BookDTO>(entity);
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
    }
}
