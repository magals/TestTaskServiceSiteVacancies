using System.ComponentModel.DataAnnotations;
using ServiceVacanciesAndResumes.API.Infrastructure.Entities.Base;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class WorkingPositionEntity : Entity
{
    [Key]
    public long WorkingPositionId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }
}
