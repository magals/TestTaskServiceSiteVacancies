using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public interface IWorkingPositionsRepository
{
    public List<WorkingPositionEntity> GetAll();
    public void CreateWorkingPosition(WorkingPositionEntity workingPositionEntity);
}
