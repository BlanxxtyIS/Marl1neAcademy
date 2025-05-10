using Marl1neAcademy.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marl1neAcademy.PostgreSQL.Configurations;

public class LessionConfigure : IEntityTypeConfiguration<LessionEntity>
{
    public void Configure(EntityTypeBuilder<LessionEntity> builder)
    {
        builder.HasKey(l => l.Id);

        builder
            .HasOne(l => l.Course)
            .WithMany(c => c.Lessions)
            .HasForeignKey(l => l.CourseId);
    }
}
