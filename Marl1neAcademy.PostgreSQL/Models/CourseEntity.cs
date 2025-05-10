namespace Marl1neAcademy.PostgreSQL.Models;

public class CourseEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } 
    public Guid AuthorId { get; set; }
    public AuthorEntity Author { get; set; } = null!;
    public List<LessionEntity> Lessions { get; set; } = [];
    public List<StudentEntity> Students { get; set; } = [];
}
