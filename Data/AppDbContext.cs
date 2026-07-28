using first_dotnet_app.Models;
using Microsoft.EntityFrameworkCore;

namespace first_dotnet_app.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}