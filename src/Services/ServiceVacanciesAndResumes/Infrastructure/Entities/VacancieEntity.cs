using System.ComponentModel.DataAnnotations;
using ServiceVacanciesAndResumes.API.Infrastructure.Entities.Base;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class VacancieEntity : Entity
{
    [Key]
    public required long VacancieId { get; init; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }

    [Required]
    [MaxLength(500)]
    public required string Text { get; init; }

    [Required]
    public required DateTimeOffset CreatedAt { get; init; }

    [MaxLength(100)]
    public required string CreatedBy { get; init; }

    [Required]
    public DateTimeOffset? UpdatedAt { get; set; }

    [MaxLength(100)]
    public string? UpdatedBy { get; set; } = default!;

    [Required]
    public required bool Enable { get; set; }

    [Key]
    public long ScheduleWorkId { get; set; }
    public ScheduleWorkEntity ScheduleWorkEntity { get; set; } = default!;

    [Key]
    public long WorkingPositionId { get; set; }
    public WorkingPositionEntity WorkingPositionEntity { get; set; } = default!;
}
