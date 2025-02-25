using Marl1neAcademy.PostgreSQL.Configurations;
using Marl1neAcademy.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Marl1neAcademy.PostgreSQL;

public class PostgreDbContext : DbContext
{
    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) 
        : base(options)
    { 
    }

    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<LessionEntity> Lessions { get; set; }
    public DbSet<StudentEntity> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfigure());
        modelBuilder.ApplyConfiguration(new LessionConfigure());
        modelBuilder.ApplyConfiguration(new StudentConfigure());
    }
}
