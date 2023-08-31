using System.ComponentModel.DataAnnotations;
using ServiceVacanciesAndResumes.API.Infrastructure.Entities.Base;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class ResumeEntity : Entity
{
    [Key]
    public required long ResumeId { get; init; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }

    public VacancieEntity VacancieEntity { get; set; } = default!;

    public ScheduleWorkEntity ScheduleWorkEntity { get; set; } = default!;

    public WorkingPositionEntity WorkingPositionEntity { get; set; } = default!;
}
