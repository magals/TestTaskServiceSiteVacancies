using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public class WorkingPositionsRepository : IWorkingPositionsRepository
{
    private readonly ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext;

    public WorkingPositionsRepository(ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext)
    {
        this.serviceVacanciesAndResumesContext = serviceVacanciesAndResumesContext;
    }
    public void CreateWorkingPosition(WorkingPositionEntity workingPositionEntity)
    {
        serviceVacanciesAndResumesContext.WorkingPositionEntity.Add(workingPositionEntity);
        serviceVacanciesAndResumesContext.SaveChanges();
    }

    public List<WorkingPositionEntity> GetAll()
    {
        return serviceVacanciesAndResumesContext.WorkingPositionEntity.ToList();
    }
}
