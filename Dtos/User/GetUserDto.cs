namespace Backend.Dtos.User
{
    public class GetUserDto : LoginUserDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
