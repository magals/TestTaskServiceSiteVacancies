using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using ServiceVacanciesAndResumes.Infrastructure.Entities;
using ServiceVacanciesAndResumes.Models.Requests;
using ServiceVacanciesAndResumes.Models.Response;
using System.Runtime.Intrinsics.X86;

namespace ServiceVacanciesAndResumes.API.Grpc
{
    public class GrpcApiService : IGrpcService.IGrpcService
    {
        private readonly IResumesRepository resumesRepository;
        private readonly IVacanciesRepository vacanciesRepository;
        private readonly ISchedulersRepository schedulersRepository;
        private readonly IWorkingPositionsRepository workingPositionsRepository;

        public GrpcApiService(IResumesRepository resumesRepository,
                              IVacanciesRepository vacanciesRepository,
                              ISchedulersRepository schedulersRepository,
                              IWorkingPositionsRepository workingPositionsRepository)
        {
            this.resumesRepository = resumesRepository;
            this.vacanciesRepository = vacanciesRepository;
            this.schedulersRepository = schedulersRepository;
            this.workingPositionsRepository = workingPositionsRepository;
        }

        public async ValueTask CreateResume(ResumeCreateRequest request)
        {
            var schwork = this.schedulersRepository.GetAll();
            var workpos = this.workingPositionsRepository.GetAll();
            var vacan = this.vacanciesRepository.GetVacancieById(request.VacancieId);

            await resumesRepository.CreateResume(new ResumeEntity
            { 
                Name = request.Name,
                Text = request.Text,
                VacancieEntity = vacan,
                WorkingPositionEntity = vacan.WorkingPositionEntity,
                ScheduleWorkEntity = vacan.ScheduleWorkEntity
            });
        }

        public async ValueTask CreateVacancies(VacancyCreateRequest request)
        {
            var schwork = this.schedulersRepository.GetAll();
            var workpos = this.workingPositionsRepository.GetAll();

            await vacanciesRepository.CreateVacancie(new VacancieEntity
            {
                Title = request.Title,
                Text = request.Text,
                Enable = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Admin",
                WorkingPositionEntity = workpos.First(x => string.Equals(x.Title, request.Position)),
                ScheduleWorkEntity = schwork.First(x => string.Equals(x.Title, request.ScheduleWork))
            });
        }

        public async ValueTask<ResumesResponse> GetAllResumes(ResumesRequest request)
        {
            var items = resumesRepository.GetAll();
            var answer = new ResumesResponse() { Resumes = new List<Resume>() };

            items.ForEach(x =>
            {
                answer.Resumes.Add(new Resume()
                {
                    Text = x.Text,
                    Name = x.Name,
                    ScheduleWork = new Models.ScheduleWork
                    { 
                        Title = x.ScheduleWorkEntity.Title
                    },
                    WorkingPosition = new Models.WorkingPosition
                    {
                        Title = x.WorkingPositionEntity.Title,
                    },
                    Vacancie = new Models.Vacancy
                    {
                        Title = x.VacancieEntity.Title
                    }
                });
            });

            return await Task.FromResult(answer);
        }

        public async ValueTask<SchedulersResponse> GetAllSchedulers(SchedulersRequest request)
        {
            var items = schedulersRepository.GetAll();
            var answer = new SchedulersResponse() { ScheduleWorks = new List<Models.ScheduleWork>() };
            items.ForEach(x =>
            {
                answer.ScheduleWorks.Add(new Models.ScheduleWork
                {
                    Title = x.Title
                });
            });

            return await Task.FromResult(answer);
        }

        public async ValueTask<VacanciesResponse> GetAllVacancies(VacanciesRequest request)
        {
            var answer = new VacanciesResponse { Vacancies = new List<VacancyResponse>() };

            var items = vacanciesRepository.GetAll().Where(x => request.ScheduleWorks.Any(y => string.Equals(y.Title, x.ScheduleWorkEntity.Title) && y.Check)
                                                                                          && request.WorkingPositions.Any(y => string.Equals(y.Title, x.WorkingPositionEntity.Title) && y.Check)).ToList();

            items.ForEach(x =>
            {
                answer.Vacancies.Add(new VacancyResponse
                {
                    VacancieId = x.VacancieId,
                    Text = x.Text,
                    Title = x.Title,
                    ScheduleWork = new Models.ScheduleWork
                    {
                        Title = x.ScheduleWorkEntity.Title,
                    },
                    WorkingPosition = new Models.WorkingPosition
                    {
                        Title = x.WorkingPositionEntity.Title,
                    }
                });
            });
            return await Task.FromResult(answer);
        }

        public async ValueTask<WorkingPositionsResponse> GetAllWorkingPositions(WorkingPositionsRequest request)
        {
            var items = workingPositionsRepository.GetAll();
            var answer = new WorkingPositionsResponse() { WorkingPositions = new List<Models.WorkingPosition>() };
            items.ForEach(x =>
            {
                answer.WorkingPositions.Add(new Models.WorkingPosition
                {
                    Title = x.Title
                });
            });

            return await Task.FromResult(answer);
        }

        public async ValueTask<VacancyResponse> GetVacationById(GetVacationByIdRequest request)
        {
            var item = vacanciesRepository.GetVacancieById(request.VacancieId);
            var answer = new VacancyResponse()
            {
                Text = item.Text,
                Title = item.Title,
                ScheduleWork = new Models.ScheduleWork
                {
                    Title = item.ScheduleWorkEntity.Title,
                },
                WorkingPosition = new Models.WorkingPosition
                {
                    Title = item.WorkingPositionEntity.Title,
                }
            };

            return await Task.FromResult(answer);
        }
    }
}
