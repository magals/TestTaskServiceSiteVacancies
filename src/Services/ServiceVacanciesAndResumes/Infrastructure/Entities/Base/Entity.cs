using System.ComponentModel.DataAnnotations;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Entities.Base;

public abstract class Entity
{
    [Required]
    public int Id { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
}
