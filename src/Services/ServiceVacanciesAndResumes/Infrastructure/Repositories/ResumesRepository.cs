using Microsoft.EntityFrameworkCore;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public class ResumesRepository : IResumesRepository
{
    private readonly ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext;

    public ResumesRepository(ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext)
    {
        this.serviceVacanciesAndResumesContext = serviceVacanciesAndResumesContext;
    }
    public void CreateResume(ResumeEntity resumeEntity)
    {
        serviceVacanciesAndResumesContext.ResumeEntity.Add(resumeEntity);
        serviceVacanciesAndResumesContext.SaveChanges();
    }

    public List<ResumeEntity> GetAll()
    {
        return serviceVacanciesAndResumesContext.ResumeEntity.Include(x => x.WorkingPositionEntity)
                                                               .Include(x => x.ScheduleWorkEntity)
                                                                .Include(x => x.VacancieEntity)
                                                               .ToList();
    }
}
