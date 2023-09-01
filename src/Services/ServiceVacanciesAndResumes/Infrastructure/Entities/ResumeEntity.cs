using System.ComponentModel.DataAnnotations;
using ServiceVacanciesAndResumes.API.Infrastructure.Entities.Base;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class ResumeEntity : Entity
{
    [Key]
    public long ResumeId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; init; }

    [Required]
    [MaxLength(500)]
    public required string Text { get; init; }

    public VacancieEntity VacancieEntity { get; set; } = default!;

    public ScheduleWorkEntity ScheduleWorkEntity { get; set; } = default!;

    public WorkingPositionEntity WorkingPositionEntity { get; set; } = default!;
}
