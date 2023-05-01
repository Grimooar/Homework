using ConsoleApp1.models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.context;

public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Element> Elements { get; set; }
    public DbSet<SalesInvoice> SalesInvoices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=<server>;Database=WBA_DATABASECONCEPT;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the many-to-many relationship between SalesInvoice and Element
        modelBuilder.Entity<SalesInvoice>()
            .HasMany(s => s.Elements)
            .WithMany()
            .UsingEntity(j => j.ToTable("SalesInvoiceElement"));
    }
}