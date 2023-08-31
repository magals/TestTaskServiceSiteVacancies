using System.ComponentModel.DataAnnotations;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class ResumeEntity : Entity
{
    [Key]
    public required long ResumeEntityId { get; init; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }
}
