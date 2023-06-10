using System.ComponentModel.DataAnnotations.Schema;
using Backend.Dtos.Base;
using Backend.Dtos.Model;

namespace Backend.Dtos.Body
{
    public class GetBodiesDetailDto : BaseDto
    {
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
        public virtual GetModelDto? GetModelDto { get; set; }
    }
}
