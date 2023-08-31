using Microsoft.EntityFrameworkCore;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Infrastructure;

public class ServiceVacanciesAndResumesContext : DbContext
{
    public DbSet<ResumeEntity> ResumeEntity { get; set; } = default!;
    public DbSet<ScheduleWorkEntity> ScheduleWorkEntity { get; set; } = default!;
    public DbSet<VacancieEntity> VacancieEntity { get; set; } = default!;
    public DbSet<WorkingPositionEntity> WorkingPositionEntity { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "VRdatabase");
    }
}
