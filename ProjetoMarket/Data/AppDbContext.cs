using Microsoft.EntityFrameworkCore;
using ProjetoMarket.Models;
namespace ProjetoMarket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


        public DbSet<User> Market {  get; set; }
        protected AppDbContext()
        {
        }
        public DbSet<ProjetoMarket.Models.Login> Login { get; set; } = default!;
    }
}
