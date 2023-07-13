using AutoMapper;
using MyTable_API.Models;
using MyTable_API.Models.Dtos;

namespace MyTable_API.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
