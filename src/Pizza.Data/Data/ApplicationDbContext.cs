using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pizza.Data.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Core.Entities.Pizza> Pizzas { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}