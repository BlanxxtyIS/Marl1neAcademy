using Marl1neAcademy.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marl1neAcademy.PostgreSQL.Configurations;

public class AuthorConfigure : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .HasMany(a => a.Courses)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId);
    }
}
