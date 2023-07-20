
using MyTable_API.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTable_API.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Genre { get; set; }
        public int? Pages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


    }
}
