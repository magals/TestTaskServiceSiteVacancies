﻿using Microsoft.EntityFrameworkCore;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure.Repositories;

public class VacanciesRepository : IVacanciesRepository
{
    private readonly ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext;

    public VacanciesRepository(ServiceVacanciesAndResumesContext serviceVacanciesAndResumesContext)
    {
        this.serviceVacanciesAndResumesContext = serviceVacanciesAndResumesContext;
    }

    public void CreateVacancie(VacancieEntity vacancieEntity)
    {
        serviceVacanciesAndResumesContext.VacancieEntity.Add(vacancieEntity);
        serviceVacanciesAndResumesContext.SaveChanges();
    }

    public List<VacancieEntity> GetAll()
    {
        return serviceVacanciesAndResumesContext.VacancieEntity.Include(x => x.WorkingPositionEntity)
                                                               .Include(x => x.ScheduleWorkEntity)
                                                               .ToList();
    }
}
