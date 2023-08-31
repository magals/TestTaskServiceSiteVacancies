using ProtoBuf.Grpc.Configuration;
using ServiceVacanciesAndResumes.Models.Requests;
using ServiceVacanciesAndResumes.Models.Response;

namespace ServiceVacanciesAndResumes.IGrpcService;

[Service(nameof(IGrpcService))]
public interface IGrpcService
{
    ValueTask<ResumesResponse> GetAllResumes(ResumesRequest request);
    ValueTask<VacanciesResponse> GetAllVacancies(VacanciesRequest request);
}
