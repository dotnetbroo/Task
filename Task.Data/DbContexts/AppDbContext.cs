using Microsoft.EntityFrameworkCore;
using Task.Domain.Entities;

namespace Task.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<Class> classes { get; set; }
    public DbSet<Student> students { get; set; }
}
