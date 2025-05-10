namespace Marl1neAcademy.PostgreSQL.Models;

public class AuthorEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public List<CourseEntity> Courses { get; set; } = [];
}
