using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public interface IResumesRepository
{
    public List<ResumeEntity> GetAll();
    public void CreateResume(ResumeEntity vacancieEntity);
}
