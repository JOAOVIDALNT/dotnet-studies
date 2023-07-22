using MyTable_API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyTable_API.Models.Dtos
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Genre { get; set; }
        public int? Pages { get; set; }
    }
}
