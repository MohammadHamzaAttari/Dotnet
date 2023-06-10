using Backend.Dtos.Base;
using Backend.Dtos.Model;
using Backend.Dtos.Trim;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Company
{
    public class AllCompaniesDto : BaseDto
    {
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<ModelDetailsDto>? Models { get; set; }

    }
}
