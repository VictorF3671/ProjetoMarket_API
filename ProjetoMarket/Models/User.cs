using System.ComponentModel.DataAnnotations;

namespace ProjetoMarket.Models
{
    public class User
    {
        [Key]public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string PhoneNumber { get; set; }

        public required int Group { get; set; } = 1; // 1 = Vendedor, 2 = Administrador
    }
}
