namespace Marl1neAcademy.PostgreSQL.Models;

public class LessionEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string LessionText { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;
}
