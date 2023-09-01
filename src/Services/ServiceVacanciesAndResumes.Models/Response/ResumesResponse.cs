using ProtoBuf;
namespace ServiceVacanciesAndResumes.Models.Response;

[ProtoContract]
public class ResumesResponse
{
    [ProtoMember(1)]
    public List<ResumeResponse> Resumes{ get; set; }
}
