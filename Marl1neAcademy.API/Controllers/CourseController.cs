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
    private readonly CourseRepository _courseRepository;

    public CourseController(
        ILogger<CourseController> logger,
        PostgreDbContext dbContext)
    {
        _logger = logger;
        _courseRepository = new CourseRepository(dbContext);
    }

    [HttpGet]
    public async Task<ActionResult<List<CourseEntity>>> GetAllCourses()
    {
        try
        {
            var courses = await _courseRepository.GetCourses();
            return Ok(courses);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка в GetAllCourses: {ex.Message}");
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CourseEntity>> GetCourseById(Guid id)
    {
        try
        {
            var course = await _courseRepository.GetByIdCourse(id);
            return Ok(course);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка в GetCourseById: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCourse(CourseEntity course)
    {
        try
        {
            var createId = await _courseRepository.AddCourse(course);
            return Ok(createId);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка в CreateCourse: {ex.Message}");
        }

    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateCourse(CourseEntity course)
    {
        try
        {
            var updatedId = await _courseRepository.UpdateCourse(course);
            return Ok(updatedId);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка в UpdateCourse: {ex.Message}");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteCourse(Guid id)
    {
        try
        {
            var deletedId = await _courseRepository.DeleteCourse(id);
            return Ok(deletedId);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка в DeleteCourse: {ex.Message}");
        }
    }
}
