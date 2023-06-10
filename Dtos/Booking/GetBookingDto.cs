using Backend.Data;

public class GetBookingDto : Base
{
    public string? FirstName { get; set; }
    public string? UserId { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ModelName { get; set; }
    public double? Price { get; set; }
    public string? Body { get; set; }
    public string? TrimName { get; set; }
    public double TrimPrice { get; set; }
    public double TotalPrice { get; set; }
}