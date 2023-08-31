using System.ComponentModel.DataAnnotations;
using ServiceVacanciesAndResumes.API.Infrastructure.Entities.Base;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class ScheduleWorkEntity : Entity
{
    [Key]
    public required long ScheduleWorkId { get; init; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }
}
