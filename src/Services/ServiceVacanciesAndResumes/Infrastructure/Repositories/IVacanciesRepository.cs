using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public interface IVacanciesRepository
{
    public List<VacancieEntity> GetAll();
    public VacancieEntity GetVacancieById(long vacancieId);
    public Task CreateVacancie(VacancieEntity vacancieEntity);
}
