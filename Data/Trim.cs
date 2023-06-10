using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data
{
    public class Trim : Base
    {

        public string? Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
        public virtual Model? Model { get; set; }
    }
}
