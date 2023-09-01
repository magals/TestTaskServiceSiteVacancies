using Microsoft.EntityFrameworkCore;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public class VacanciesRepository : IVacanciesRepository
{
    private readonly ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext;

    public VacanciesRepository(ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext)
    {
        this.serviceVacanciesAndResumesContext = serviceVacanciesAndResumesContext;
    }

    public async Task CreateVacancie(VacancieEntity vacancieEntity)
    {
        serviceVacanciesAndResumesContext.VacancieEntity.Add(vacancieEntity);
        await serviceVacanciesAndResumesContext.SaveChangesAsync();
    }

    public List<VacancieEntity> GetAll()
    {
        return serviceVacanciesAndResumesContext.VacancieEntity.Include(x => x.WorkingPositionEntity)
                                                               .Include(x => x.ScheduleWorkEntity)
                                                               .ToList();
    }

    public VacancieEntity GetVacancieById(long vacancieId)
    {
        return serviceVacanciesAndResumesContext.VacancieEntity.Include(x => x.WorkingPositionEntity)
                                                               .Include(x => x.ScheduleWorkEntity)
                                                               .First(x => x.VacancieId == vacancieId);
    }
}
