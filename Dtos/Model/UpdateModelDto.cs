using Backend.Dtos.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Model
{
    public class UpdateModelDto : BaseDto
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }

        public decimal Price { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        [NotMapped]
        public IFormFile? FileUpload { get; set; }
    }
}
