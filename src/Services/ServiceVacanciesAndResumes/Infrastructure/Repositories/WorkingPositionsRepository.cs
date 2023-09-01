using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public class WorkingPositionsRepository : IWorkingPositionsRepository
{
    private readonly ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext;

    public WorkingPositionsRepository(ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext)
    {
        this.serviceVacanciesAndResumesContext = serviceVacanciesAndResumesContext;
    }
    public async Task CreateWorkingPosition(WorkingPositionEntity workingPositionEntity)
    {
        serviceVacanciesAndResumesContext.WorkingPositionEntity.Add(workingPositionEntity);
        await serviceVacanciesAndResumesContext.SaveChangesAsync();
    }

    public List<WorkingPositionEntity> GetAll()
    {
        return serviceVacanciesAndResumesContext.WorkingPositionEntity.ToList();
    }
}
