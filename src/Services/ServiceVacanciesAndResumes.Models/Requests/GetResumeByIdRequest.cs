using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class GetResumeByIdRequest
{
    [ProtoMember(1)]
    public int ResumeId { get; set; }
}
