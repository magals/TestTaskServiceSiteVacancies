using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class WorkingPositionsRequest
{
    [ProtoMember(1)]
    public bool Enable { get; set; }
}
