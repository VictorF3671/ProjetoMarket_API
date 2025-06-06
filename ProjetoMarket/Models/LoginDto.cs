namespace ProjetoMarket.Models
{
    public class LoginDto
    {
        public  required string Token { get; set; }
        
        public required string Email { get; set; }

        public required string Name { get; set; }
        public required string group { get; set; } // 1 = Vendedor, 2 = Administrador
    }
}
