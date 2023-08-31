using ServiceVacanciesAndResumes.API.Infrastructure;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API;

public class SeedData
{
    public static async Task EnsureSeedData(IServiceScope scope, IConfiguration configuration, ILogger logger)
    {
        var context = scope.ServiceProvider.GetRequiredService<ServiceVacanciesAndResumesContext>();

        var swe = new ScheduleWorkEntity[]
        {
            new ScheduleWorkEntity
            {
                ScheduleWorkId = 1,
                Title = "Full Time"
            },
            new ScheduleWorkEntity
            {
                ScheduleWorkId = 2,
                Title = "Half Time"
            },
            new ScheduleWorkEntity
            {
                ScheduleWorkId = 3,
                Title = "Internship"
            }
        };
        context.ScheduleWorkEntity.AddRange(swe);

        var wpe = new WorkingPositionEntity[]
        {
            new WorkingPositionEntity
            {
                WorkingPositionId = 1,
                Title = "IT"
            },
            new WorkingPositionEntity
            {
                WorkingPositionId = 2,
                Title = "Accountant"
            }
        };
        context.WorkingPositionEntity.AddRange(wpe);

        var vacancie = new List<VacancieEntity>
        {
            new VacancieEntity
            {
                VacancieId = 1,
                Title = "EBS Integrator, Programmer",
                Text = "Bla-bla bla, need C# programmer",
                Enable = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "InMemory",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "InMemory",
                ScheduleWorkEntity =  swe.First(x => x.ScheduleWorkId == 1),
                WorkingPositionEntity = wpe.First(x => x.WorkingPositionId == 1)
            },
             new VacancieEntity
            {
                VacancieId = 2,
                Title = "MAIB, Finance",
                Text = "Need an accountant",
                Enable = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "InMemory",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "InMemory",
                ScheduleWorkEntity =  swe.First(x => x.ScheduleWorkId == 2),
                WorkingPositionEntity = wpe.First(x => x.WorkingPositionId == 2)
            }
        };
        context.VacancieEntity.AddRange(vacancie);
        await context.SaveChangesAsync(); 
    }
}
