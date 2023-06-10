using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data
{
    public class Model : Base
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public byte[]? Image { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Body>? Bodies { get; set; }
        public virtual ICollection<Trim>? Trims { get; set; }
        [NotMapped]
        public IFormFile? FileUpload { get; set; }
    }
}