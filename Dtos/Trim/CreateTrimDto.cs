using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Backend.Dtos.Trim
{
    public class CreateTrimDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }

    }
}
