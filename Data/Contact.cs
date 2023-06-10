using System.ComponentModel.DataAnnotations;
using Backend.Data;

public class Contact : Base
{
    [Required]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Message { get; set; }
}