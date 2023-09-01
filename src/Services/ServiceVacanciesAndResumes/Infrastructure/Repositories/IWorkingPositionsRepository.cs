using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public interface IWorkingPositionsRepository
{
    public List<WorkingPositionEntity> GetAll();
    public Task CreateWorkingPosition(WorkingPositionEntity workingPositionEntity);
}
