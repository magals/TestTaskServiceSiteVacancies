using System.ComponentModel.DataAnnotations;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class WorkingPositionEntity : Entity
{
    [Key]
    public required long WorkingPositionId { get; init; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }
}
