using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class SchedulersRequest
{
    [ProtoMember(1)]
    public bool Enable { get; set; }
}
