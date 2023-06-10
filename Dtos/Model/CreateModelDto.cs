using Backend.Dtos.Company;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Model
{
    public class CreateModelDto
    {

        public string? Name { get; set; }

        public decimal Price { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public IFormFile? FileUpload { get; set; }

    }
}
