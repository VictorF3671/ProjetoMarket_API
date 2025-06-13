namespace ProjetoMarket.Models
{
    public class CreateUserDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public int Group { get; set; } = 1;
    }
}
