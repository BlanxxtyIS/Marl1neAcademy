using Marl1neAcademy.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marl1neAcademy.PostgreSQL.Configurations;

public class StudentConfigure : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students);
    }
}
