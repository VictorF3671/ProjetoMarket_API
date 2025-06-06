using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMarket.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string HashPassword { get; set; }

        public required string PhoneNumber { get; set; }

        public required int Group { get; set; } = 1; // 1 = Vendedor, 2 = Administrador
    }
}
