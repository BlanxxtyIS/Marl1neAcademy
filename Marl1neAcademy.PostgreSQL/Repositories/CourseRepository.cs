using Marl1neAcademy.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Marl1neAcademy.PostgreSQL.Repositories;

public class CourseRepository
{
    public readonly PostgreDbContext _dbContext;

    public CourseRepository(PostgreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CourseEntity>> GetCourses()
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .OrderBy(c => c.Title)
            .ToListAsync();
    }

    public async Task<CourseEntity?> GetByIdCourse(Guid id)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddCourse(CourseEntity course)
    {
        await _dbContext.AddAsync(course);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCourse(CourseEntity course)
    {
        await _dbContext.Courses
            .Where(c => c.Id == course.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, course.Title)
                .SetProperty(c => c.Description, course.Description)
                .SetProperty(c => c.Price, course.Price)
                .SetProperty(c => c.Author, course.Author)
                .SetProperty(c => c.Students, course.Students)
                .SetProperty(c => c.Lessions, course.Lessions));
    }

    public async Task DeleteCourse(Guid id)
    {
        await _dbContext.Courses
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}
