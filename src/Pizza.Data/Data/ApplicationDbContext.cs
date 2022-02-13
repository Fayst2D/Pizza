using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizza.Core.Entities;
using PizzaShop.Models;

namespace Pizza.Data.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Core.Entities.Pizza> Pizzas { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}