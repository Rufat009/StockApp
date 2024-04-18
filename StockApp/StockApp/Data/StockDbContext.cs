using Microsoft.EntityFrameworkCore;
using StockApp.Models;
using System;
using System.Linq;

namespace StockApp.Data;

public class StockDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer(App.connectionString);
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .Property(e => e.Categories)
            .HasConversion(
                v => string.Join(",", v.Select(e => e.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .Select(e => Enum.Parse<Category>(e))
                      .ToList()
            );
    }
}
