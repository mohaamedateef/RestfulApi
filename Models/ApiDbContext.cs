using Microsoft.EntityFrameworkCore;
namespace RestfullAPI.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() { }
        public ApiDbContext(DbContextOptions options):base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
