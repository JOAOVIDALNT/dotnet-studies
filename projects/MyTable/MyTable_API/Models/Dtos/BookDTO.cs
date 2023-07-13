using MyTable_API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyTable_API.Models.Dtos
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public GenreEnum? Genre { get; set; }
        public int? Pages { get; set; }
    }
}
