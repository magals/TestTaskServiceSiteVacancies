using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using ServiceVacanciesAndResumes.Models.Requests;
using ServiceVacanciesAndResumes.Models.Response;

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

        public ValueTask CreateResumes(ResumeCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public ValueTask CreateVacancies(VacancyCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ResumesResponse> GetAllResumes(ResumesRequest request)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<SchedulersResponse> GetAllSchedulers(SchedulersRequest request)
        {
            var items = schedulersRepository.GetAll();
            var answer = new SchedulersResponse() { ScheduleWorks = new List<Models.ScheduleWork>()};
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
            var answer = new VacanciesResponse
            {
                Vacancies = new List<VacancyResponse>()
            };

            var items = vacanciesRepository.GetAll();
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
            var answer = new WorkingPositionsResponse() { WorkingPositions = new List<Models.WorkingPosition>()};
            items.ForEach(x =>
            {
                answer.WorkingPositions.Add(new Models.WorkingPosition
                {
                    Title = x.Title
                });
            });

            return await Task.FromResult(answer);
        }
    }
}
