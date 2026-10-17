using CSharpFundamentals.eTicaret.WebAPI.Abstractions;
using CSharpFundamentals.eTicaret.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpFundamentals.eTicaret.WebAPI.Context;

public class ApplicationDbContext() : DbContext
{
    //AI tercihi ve best practices
    //public ApplicationDbContext(DbContextOptions options) : base(options) 
    //{
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-UOERPMR\\SQLEXPRESS;Initial Catalog=TesteTicaretDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
    }

    public DbSet<Product> Products { get; set; }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries<Entity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.CreatedAt).CurrentValue = DateTimeOffset.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                if (entry.Property(p => p.IsDeleted).CurrentValue == true)
                {
                    entry.Property(p => p.DeletedAt).CurrentValue = DateTimeOffset.Now;
                }
                else
                {
                    entry.Property(p => p.UpdatedAt).CurrentValue = DateTimeOffset.Now;
                }
            }
        }

        return base.SaveChanges();
    }
}