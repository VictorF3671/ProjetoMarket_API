namespace ProjetoMarket.Services
    
{
    using Microsoft.CodeAnalysis.Scripting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Org.BouncyCastle.Crypto.Generators;
    using ProjetoMarket.Data;
    using ProjetoMarket.Interfaces;
    using ProjetoMarket.Models;
    using System.Drawing.Text;
    using BCrypt.Net;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
    
        public UserService(AppDbContext context, IConfiguration configuration) {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<User?> Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !VerifyPassword(password, user.HashPassword))
            {
                return null;
            }
            return user;
        }

        public string GenerateHashPassword(string password)
        {
            {
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("A senha não pode ser vazia.", nameof(password));

                return BCrypt.HashPassword(password);
            }
        }
    public bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
                return false;

            return BCrypt.Verify(password, hashedPassword);
        }

        public string HashPassword(string password)
        {
            return GenerateHashPassword(password);
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Group.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
