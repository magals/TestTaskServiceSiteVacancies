using System.ComponentModel.DataAnnotations;
using ServiceVacanciesAndResumes.API.Infrastructure.Entities.Base;

namespace ServiceVacanciesAndResumes.Infrastructure.Entities;

public class ScheduleWorkEntity : Entity
{
    [Key]
    public long ScheduleWorkId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Title { get; init; }
}
