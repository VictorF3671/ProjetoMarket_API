using System.Security;

namespace ProjetoMarket.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required int Group { get; set; }
    }
}
