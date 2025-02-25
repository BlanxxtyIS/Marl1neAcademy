using Marl1neAcademy.PostgreSQL;
using Marl1neAcademy.PostgreSQL.Models;
using Marl1neAcademy.PostgreSQL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Marl1neAcademy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly PostgreDbContext _dbContext;
    private readonly CourseRepository _courseRepository;
    private readonly AuthorRepository _authorRepository;

    public CourseController(
        ILogger<CourseController> logger, 
        PostgreDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
        _courseRepository = new CourseRepository(dbContext);
        _authorRepository = new AuthorRepository(dbContext);
    }

    [HttpPost("Test")]
    public async Task<IActionResult> TestCourse()
    {
        AuthorEntity? author = await _authorRepository.GetAuthor();
        if (author == null)
        {
            return BadRequest("Автор не найден");
        }
        try
        {
            CourseEntity course = new CourseEntity()
            {
                Id = Guid.NewGuid(),
                Title = "C#",
                Description = "Курс по C# для продвинутых",
                Price = 99.99m,
                AuthorId = author.Id,
                Author = author
            };
            await _courseRepository.AddCourse(
                course
            );

            return Ok("Добавили");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
