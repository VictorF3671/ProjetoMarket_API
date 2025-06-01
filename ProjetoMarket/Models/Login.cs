using System.ComponentModel.DataAnnotations;

namespace ProjetoMarket.Models
{
    public class Login
    {

        [Key]
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
