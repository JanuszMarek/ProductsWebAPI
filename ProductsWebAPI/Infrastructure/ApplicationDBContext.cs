using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.Models;

namespace ProductsWebAPI.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
