using ProtoBuf.Grpc.Configuration;
using ServiceVacanciesAndResumes.Models.Requests;
using ServiceVacanciesAndResumes.Models.Response;

namespace ServiceVacanciesAndResumes.IGrpcService;

[Service(nameof(IGrpcService))]
public interface IGrpcService
{
    ValueTask<ResumesResponse> GetAllResumes(ResumesRequest request);
    ValueTask CreateResume(ResumeCreateRequest request);

    ValueTask<VacanciesResponse> GetAllVacancies(VacanciesRequest request);
    ValueTask CreateVacancies(VacancyCreateRequest request);
    ValueTask<VacancyResponse> GetVacationById(GetVacationByIdRequest request);

    ValueTask<SchedulersResponse> GetAllSchedulers(SchedulersRequest request);
    ValueTask<WorkingPositionsResponse> GetAllWorkingPositions(WorkingPositionsRequest request);
}
