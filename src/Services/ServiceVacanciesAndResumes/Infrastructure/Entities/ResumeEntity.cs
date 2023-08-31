using System.ComponentModel.DataAnnotations;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class ResumeEntity : Entity
{
    [Key]
    public required long ResumeId { get; init; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }

    [Key]
    public long VacancieId { get; set; }
    public VacancieEntity VacancieEntity { get; set; } = default!;

    [Key]
    public long ScheduleWorkId { get; set; }
    public ScheduleWorkEntity ScheduleWorkEntity { get; set; } = default!;

    [Key]
    public long WorkingPositionId { get; set; }
    public WorkingPositionEntity WorkingPositionEntity { get; set; } = default!;
}
