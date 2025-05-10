using Marl1neAcademy.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Marl1neAcademy.PostgreSQL.Repositories;

public class AuthorRepository
{
    public readonly PostgreDbContext _dbContext;

    public AuthorRepository(PostgreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AuthorEntity?> GetAuthor()
    {
        return await _dbContext.Authors
            .FirstOrDefaultAsync();
    }

    public async Task AddAuthor(AuthorEntity author)
    {
        await _dbContext.AddAsync(author);
        await _dbContext.SaveChangesAsync();
    }
}
