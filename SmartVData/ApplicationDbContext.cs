using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartVision.Entities;
namespace SmartVData;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=EmployeeManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Employee>().Ignore(t => t.Email);
        base.OnModelCreating(builder);

        builder.Entity<Employee>().ToTable("Employee");
        builder.Entity<Timesheet>().ToTable("Timesheet");
    }



    public DbSet<Employee> Employee { get; set; }
    public DbSet<Timesheet> Timesheet { get; set; }
}
