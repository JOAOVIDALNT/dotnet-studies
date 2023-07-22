
using MyTable_API.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyTable_API.Models.Dtos
{
    public class BookCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        [EnumDataType(typeof(GenreEnum))]
        [DefaultValue("ROMANCE")]
        public string? Genre { get; set; }
        public int? Pages { get; set; }
    }
}
