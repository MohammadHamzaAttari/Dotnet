using Backend.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Model
{
    public class GetModelDto : BaseDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public byte[]? Image { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
    }
}