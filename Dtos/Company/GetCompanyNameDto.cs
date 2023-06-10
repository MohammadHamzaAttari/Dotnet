using Backend.Dtos.Base;
using Backend.Dtos.Model;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Company
{
    public class GetCompanyNameDto : BaseDto
    {
        [Required]
        public string? Name { get; set; }


    }
}
