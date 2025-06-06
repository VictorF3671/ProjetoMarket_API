using Microsoft.EntityFrameworkCore;
using ProjetoMarket.Models;
namespace ProjetoMarket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


        public DbSet<User> Users {  get; set; }
        protected AppDbContext()
        {
        }
        public DbSet<ProjetoMarket.Models.Login> Login { get; set; } = default!;
        public DbSet<ProjetoMarket.Models.Products> Products { get; set; } = default!;
        public DbSet<ProjetoMarket.Models.Sale> Sale { get; set; } = default!;
    }
}
