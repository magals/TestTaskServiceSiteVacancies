using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class ResumesRequest
{
    [ProtoMember(1)]
    public bool Enable { get; set; }
}