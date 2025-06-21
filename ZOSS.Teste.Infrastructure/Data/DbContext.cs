using Microsoft.EntityFrameworkCore;
using ZOSS.Teste.Back.Models;

namespace ZOSS.Teste.Back.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
