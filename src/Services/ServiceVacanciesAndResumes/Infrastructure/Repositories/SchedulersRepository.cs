using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public class SchedulersRepository : ISchedulersRepository
{
    private readonly ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext;

    public SchedulersRepository(ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext)
    {
        this.serviceVacanciesAndResumesContext = serviceVacanciesAndResumesContext;
    }
    public List<ScheduleWorkEntity> GetAll()
    {
        return serviceVacanciesAndResumesContext.ScheduleWorkEntity.ToList();
    }
}
