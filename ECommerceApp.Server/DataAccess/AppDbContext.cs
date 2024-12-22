using ECommerceApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Server.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Product> Products { get; set; }

    }
}
