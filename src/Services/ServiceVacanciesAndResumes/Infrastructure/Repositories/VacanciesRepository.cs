using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public class VacanciesRepository : IVacanciesRepository
{
    public VacanciesRepository()
    {
        using (var context = new ServiceVacanciesAndResumesContext())
        {
            var authors = new List<VacancieEntity>
                {
                    new VacancieEntity
                    {
                        VacancieId = 1,
                        Title = "Title",
                        Text = "Text",
                        Enable = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "InMemory"
                    }
                };
            context.VacancieEntity.AddRange(authors);
            context.SaveChanges();
        }
    }

    public List<VacancieEntity> GetAll()
    {
        using var context = new ServiceVacanciesAndResumesContext();
        return context.VacancieEntity.ToList();
    }
}
