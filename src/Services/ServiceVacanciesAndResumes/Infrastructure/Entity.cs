using System.ComponentModel.DataAnnotations;

namespace ServiceVacanciesAndResumes.Infrastructure;

public abstract class Entity
{
    [Required]
    public int Id { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
}
