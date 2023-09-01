using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public interface IResumesRepository
{
    public List<ResumeEntity> GetAll();
    public Task CreateResume(ResumeEntity vacancieEntity);
    public ResumeEntity GetResumeById(long ResumeId);
}
