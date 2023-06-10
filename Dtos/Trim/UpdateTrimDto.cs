using Backend.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Trim
{
    public class UpdateTrimDto:BaseDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
    }
}
