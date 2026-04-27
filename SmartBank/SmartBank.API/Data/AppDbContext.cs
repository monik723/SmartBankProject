using Microsoft.EntityFrameworkCore;
using SmartBank.Core.Models;

namespace SmartBank.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "Customer" },
            new Role { Id = 3, Name = "Teller" },
            new Role { Id = 4, Name = "Manager" },
            new Role { Id = 5, Name = "Auditor" }
        );
    }
}
