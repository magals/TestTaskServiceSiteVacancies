using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public interface IVacanciesRepository
{
    public List<VacancieEntity> GetAll();
    public Task CreateVacancie(VacancieEntity vacancieEntity);
}
