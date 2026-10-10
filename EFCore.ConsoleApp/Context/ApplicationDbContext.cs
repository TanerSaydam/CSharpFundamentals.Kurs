using EFCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.ConsoleApp.Context;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-UOERPMR\\SQLEXPRESS;" +
            "Initial Catalog=EFCoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
    }

    public DbSet<Product> Products { get; set; }
}