using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using ServiceVacanciesAndResumes.Models.Requests;
using ServiceVacanciesAndResumes.Models.Response;

namespace ServiceVacanciesAndResumes.API.Grpc
{
    public class GrpcApiService : IGrpcService.IGrpcService
    {
        private readonly IResumesRepository resumesRepository;
        private readonly IVacanciesRepository vacanciesRepository;

        public GrpcApiService(IResumesRepository resumesRepository,
                              IVacanciesRepository vacanciesRepository)
        {
            this.resumesRepository = resumesRepository;
            this.vacanciesRepository = vacanciesRepository;
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
    }
}
