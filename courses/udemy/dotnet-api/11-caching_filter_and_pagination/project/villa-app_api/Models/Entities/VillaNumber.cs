using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace villa_app_api.Models.Entities
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] // o usuário vai setar o número
        public int VillaNo { get; set; }
        [ForeignKey("Villa")]
        public int VillaId { get; set; }
        public Villa Villa { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
