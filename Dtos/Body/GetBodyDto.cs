using System.ComponentModel.DataAnnotations.Schema;
using Backend.Dtos.Base;

namespace Backend.Dtos.Body
{
    public class GetBodyDto : BaseDto
    {

        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
    }
}
