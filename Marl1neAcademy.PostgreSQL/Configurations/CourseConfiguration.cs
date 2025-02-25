using Marl1neAcademy.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marl1neAcademy.PostgreSQL.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(c => c.AuthorId);

        builder
            .HasMany(c => c.Lessions)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId);

        builder
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);
    }
}
