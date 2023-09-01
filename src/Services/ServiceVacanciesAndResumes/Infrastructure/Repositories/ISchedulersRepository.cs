using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public interface ISchedulersRepository
{
    public List<ScheduleWorkEntity> GetAll();
}
